using Microsoft.VisualBasic.FileIO;
using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Numerics;
using MathNet.Filtering.FIR;
using MathNet.Filtering;
using MathNet.Numerics.LinearRegression;
using MathNet.Numerics;
using DSPLib;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;




namespace Damping_Data_Processor
{


    public partial class form1 : Form
    {

        //GLOBAL VARIABLES

        //allocate vertical annotation

        VerticalLineAnnotation lower_data_boundary_vertical_line = new VerticalLineAnnotation();
        VerticalLineAnnotation upper_data_boundary_vertical_line = new VerticalLineAnnotation();

        string current_selected_dataset_filepath = string.Empty;

        //pixel width of charts, used to samplke data for plotting
        int chart_width = 1389;

        // these data sets are for the current loaded data sets
        //the imported string list from csv
        List<List<string>> generic_input_data_string = new List<List<string>>();
        //the converted and processed data save as a master copy (kept as an original in case user wants to revert to original data)
        List<List<double>> generic_input_data_double_master = new List<List<double>>();
        //a copy of the master data but edit and trimming can be made to this data set (will be reset when user reverts to master)
        List<List<double>> generic_input_data_double_clone = new List<List<double>>();
        //same as cloned dataset but with applied filter
        List<List<double>> generic_input_data_double_clone_filtered = new List<List<double>>();
        // the data set but with trimmed local maximas data points
        List<List<double>> generic_input_data_double_clone_maximas = new List<List<double>>();

        //these following variables are catalogs of all data set used in thew session
        List<List<List<double>>> generic_input_data_double_master_catalog = new List<List<List<double>>>();
        List<List<List<double>>> generic_input_data_double_clone_catalog = new List<List<List<double>>>();
        List<List<List<double>>> generic_input_data_double_clone_filtered_catalog = new List<List<List<double>>>();

        //variables that holds the freq response of for all direction for the current csv
        List<List<double>> real_spectrum = new List<List<double>>();
        List<List<double>> freq_span = new List<List<double>>();

        //keep track of what cutoff frequencies are used
        List<double> low_cutoff_freq_tracker = new List<double>();
        List<double> high_cutoff_freq_tracker = new List<double>();

        //folder picked by user with all input data
        string input_folder = string.Empty;

        //stores all csv filepath found in the slected input folder
        List<string> csv_input_filepaths = new List<string>();
        //stores all csv filepath found in the slected input folder (in short form for readability)
        List<string> csv_input_filepaths_short = new List<string>();

        //holds the header when exportimng data
        List<string> acceleration_dataset_csv_header = new List<string>();

        //sample rate of input data
        double input_data_sample_rate = 1024;

        //List that holds data direction names
        List<string> data_direction_name = new List<string>();

        //hold the text of the results for the current csv
        string results_summary_text = string.Empty;

        //Boolean is_data_filtered = false;
        List<Boolean> is_data_filtered = new List<Boolean>();

        //holds the values where the annotation will be placed
        List<int> x_index_trim_lower_index_trimmed = new List<int>();
        List<int> x_index_trim_upper_index_trimmed = new List<int>();

        //holds the values where the annotation is placed relative to the original time dataset (not trimmed)
        //useful when applying a filter to a dataset that has been trimmed twice
        List<int> x_index_trim_lower_index_master = new List<int>();
        List<int> x_index_trim_upper_index_master = new List<int>();

        //y label of data chart
        string y_axis_label_data_chart = "Acceleration (m/s^2)";

        List<string> dataset_result_summary_text_list = new List<string>();

        int current_selected_csv_checkedlistbox_index = 0;

        string save_results_folder = string.Empty;

        string output_folder_name = @"Damping Reduction Output\";

        //the file extension (custom to this software) (damping reduction data sets)
        string save_session_filetype = ".json";


        public form1()
        {
            //test

            InitializeComponent();

            acceleration_dataset_csv_header.Add("Time (Seconds)");
            acceleration_dataset_csv_header.Add("X " + y_axis_label_data_chart);
            acceleration_dataset_csv_header.Add("Y " + y_axis_label_data_chart);
            acceleration_dataset_csv_header.Add("Z " + y_axis_label_data_chart);
            acceleration_dataset_csv_header.Add("XY VS" + y_axis_label_data_chart);
            acceleration_dataset_csv_header.Add("XZ VS" + y_axis_label_data_chart);
            acceleration_dataset_csv_header.Add("YZ VS" + y_axis_label_data_chart);

            //set default value in the comboboxs;
            use_DFT_or_peaks_combobox.SelectedIndex = 0;
            linear_or_log_combobox.SelectedIndex = 0;
        }

        public double get_actual_max_freq(List<double> freq_span, List<double> mag_span)
        {
            //get the actual max freq by using a prarbolic curve fit
            //automatic trim of data to get the peak data to fit a curve
            double mag_avg = mag_span.Average();

            //get std dev
            double x = 0;
            for (int i = 0; i < mag_span.Count; i++)
            {
                x = x + Math.Pow(mag_span[i] - mag_avg, 2);
            }
            double std_deviation = Math.Sqrt(x / mag_span.Count);

            //stores all spans of indexs where peaks occur
            List<List<int>> peak_span_indexs = new List<List<int>>();
            List<int> temp_span = new List<int>();

            Boolean span_flag = false;

            for(int i =0; i < mag_span.Count; i++)
            {
                //found span
                if(mag_span[i]> std_deviation * 2)
                {
                    temp_span.Add(i);
                    span_flag = true;
                }
                else
                {
                    //span ends
                    if (span_flag == true)
                    {
                        peak_span_indexs.Add(temp_span);
                        temp_span = new List<int>();
                    }
                    span_flag = false;
                }
            }

            if (peak_span_indexs.Count == 0)
            {
                return 0;
            }

            return 0;

        }

        public void save_session(Boolean display_error_message = true, Boolean ask_user_save_location = true, Boolean autosave_tag = false)
        {
            if (check_if_list_list_double_is_empty(generic_input_data_double_master_catalog) && check_if_list_list_double_is_empty(generic_input_data_double_clone_catalog) && check_if_list_list_double_is_empty(generic_input_data_double_clone_filtered_catalog))
            {
                if (display_error_message == true)
                {
                    string message = "There is no data loaded into the current session";
                    string title = "Error";
                    MessageBox.Show(message, title);
                }
                return;
            }

            //create session object (drs = damping reduction session)
            damping_reduction_session drs = new damping_reduction_session();
            drs.generic_input_data_double_master_catalog_drs = generic_input_data_double_master_catalog;
            drs.generic_input_data_double_clone_catalog_drs = generic_input_data_double_clone_catalog;
            drs.generic_input_data_double_clone_filtered_catalog_drs = generic_input_data_double_clone_filtered_catalog;
            drs.csv_input_filepaths_drs = csv_input_filepaths;
            drs.csv_input_filepaths_short_drs = csv_input_filepaths_short;
            drs.low_cutoff_freq_tracker_drs = low_cutoff_freq_tracker;
            drs.high_cutoff_freq_tracker_drs = high_cutoff_freq_tracker;
            drs.is_data_filtered_drs = is_data_filtered;
            drs.dataset_result_summary_text_list_drs = dataset_result_summary_text_list;
            drs.x_index_trim_lower_index_trimmed_drs = x_index_trim_lower_index_trimmed;
            drs.x_index_trim_upper_index_trimmed_drs = x_index_trim_upper_index_trimmed;
            drs.x_index_trim_lower_index_master_drs = x_index_trim_lower_index_master;
            drs.x_index_trim_upper_index_master_drs = x_index_trim_upper_index_master;
            drs.input_folder_drs = input_folder;


            //get default session file name (using the last folder in the input folder filepath and append the filetype extension
            string input_folder_wo_filepath = input_folder;
            if (input_folder_wo_filepath.LastIndexOf(@"\") == input_folder_wo_filepath.Length - 1)
            {
                input_folder_wo_filepath = input_folder.Remove(input_folder.Length - 1);
            }
            int index = input_folder_wo_filepath.LastIndexOf(@"\") + 1;
            int lng = (input_folder_wo_filepath.Length) - index;
            input_folder_wo_filepath = input_folder_wo_filepath.Substring(index, lng);
            string default_file_name = string.Empty;
            if (autosave_tag == true)
            {
                default_file_name = input_folder_wo_filepath + "-Damping Reduction Session [Autosave]" + save_session_filetype;
            }
            else
            {
                default_file_name = input_folder_wo_filepath + "-Damping Reduction Session" + save_session_filetype;
            }

            string save_filepath = string.Empty;

            if (ask_user_save_location == true)
            {
                //make user save file using file explorer
                SaveFileDialog save_session_file_dialog = new SaveFileDialog();
                save_session_file_dialog.Filter = "Damping Reduction Data Sets(" + save_session_filetype + ")| *" + save_session_filetype;
                save_session_file_dialog.Title = "Save Damping Reduction Session";
                save_session_file_dialog.InitialDirectory = input_folder + output_folder_name;
                save_session_file_dialog.FileName = default_file_name;
                save_session_file_dialog.ShowDialog();
                save_filepath = save_session_file_dialog.FileName;
            }
            else
            {
                save_filepath = input_folder + output_folder_name + default_file_name;
            }

            // If the file name is not an empty string open it for saving.
            if (!String.IsNullOrEmpty(save_filepath))
            {
                File.WriteAllText(save_filepath, JsonConvert.SerializeObject(drs));

            }
            else
            {
                if (display_error_message == true)
                {
                    string message = "The filepath/name was invalid and could not be saved";
                    string title = "Error";
                    MessageBox.Show(message, title);
                }
                return;
            }
        }

        public Boolean check_if_list_list_double_is_empty(List<List<List<double>>> list)
        {
            Boolean is_empty = true;
            for (int i = 0; i < list.Count - 1; i++)
            {
                if (list[i].Count > 0)
                {
                    is_empty = false;
                    break;
                }
            }
            return is_empty;
        }

        //generic program functions

        public void activity_log(string log)
        {
            activity_log_textbox.AppendText(log + "\n\r\n\r");
        }

        public void export_acceleration_datasets_csv(Boolean export_master = true, Boolean export_clone = true, Boolean export_filter = true)
        {
            if (generic_input_data_double_master_catalog.Count == 0)
            {
                string message = "There is no dataset to export";
                string title = "Error";
                MessageBox.Show(message, title);
                return;
            }


            for (int catalog_index = 0; catalog_index < generic_input_data_double_master_catalog.Count; catalog_index++)
            {

                //check for empty data then skip
                if (generic_input_data_double_master_catalog[catalog_index].Count == 0)
                {
                    continue;
                }

                //get cutoff freqs
                double low_cutoff_freq = low_cutoff_freq_tracker[catalog_index];
                double high_cutoff_freq = high_cutoff_freq_tracker[catalog_index];

                //get timestamps of trimmed data
                double first_timestamp = 0;
                double second_timestamp = 0;
                //added error checking for indexing issues
                if (generic_input_data_double_clone_catalog[catalog_index].Count > 0)
                {
                    if (generic_input_data_double_clone_catalog[catalog_index][0].Count > 0)
                    {
                        first_timestamp = Math.Round(generic_input_data_double_clone_catalog[catalog_index][0][0], 1);
                        second_timestamp = Math.Round(generic_input_data_double_clone_catalog[catalog_index][0][generic_input_data_double_clone_catalog[catalog_index][0].Count - 1], 1);
                    }
                }

                //get dataset name
                string dataset_name = get_filename_from_filepath(csv_input_filepaths_short[catalog_index]);
                string dataset_name_trimmed = dataset_name + "[" + first_timestamp + "s - " + second_timestamp + "s]";
                string dataset_name_trimmed_filtered = dataset_name_trimmed + "[" + low_cutoff_freq + "Hz - " + high_cutoff_freq + "Hz]";

                //create the folder
                Directory.CreateDirectory(save_results_folder);

                if (export_master == true)
                {
                    process_save_dataset_as_csv(generic_input_data_double_master_catalog[catalog_index], save_results_folder + "Accel. Datasets " + dataset_name + " [Unedited].csv");
                }
                if (export_clone == true)
                {
                    process_save_dataset_as_csv(generic_input_data_double_clone_catalog[catalog_index], save_results_folder + "Accel. Datasets " + dataset_name_trimmed + " [Trimmed].csv");
                }
                if (export_filter == true)
                {
                    process_save_dataset_as_csv(generic_input_data_double_clone_filtered_catalog[catalog_index], save_results_folder + "Accel. Datasets " + dataset_name_trimmed_filtered + " [Filtered Trimmed].csv");
                }

                //play sound to allert user
                System.Media.SystemSounds.Beep.Play();

                ////CONVERT DATA SETS TO STRINGS
                //if (export_master == true)
                //{
                //    csv_data_master = convert_list_of_list_double_to_string(generic_input_data_double_master_catalog[catalog_index]);
                //}
                //if (export_clone == true)
                //{
                //    csv_data_clone = convert_list_of_list_double_to_string(generic_input_data_double_clone_catalog[catalog_index]);
                //}
                //if (export_filter == true)
                //{
                //    csv_data_clone_filter = convert_list_of_list_double_to_string(generic_input_data_double_clone_filtered_catalog[catalog_index]);
                //}

                ////add headers to data sets
                //for (int i = 0; i < acceleration_dataset_csv_header.Count; i++)
                //{
                //    if (export_master == true)
                //    {
                //        csv_data_master[i].Insert(0, acceleration_dataset_csv_header[i]);
                //    }
                //    if (export_clone == true)
                //    {
                //        csv_data_clone[i].Insert(0, acceleration_dataset_csv_header[i]);
                //    }
                //    if (export_filter == true)
                //    {
                //        csv_data_clone_filter[i].Insert(0, acceleration_dataset_csv_header[i]);
                //    }
                //}

                ////transpose the data
                //if (export_master == true)
                //{
                //    csv_data_master = transpose_list_of_list_string(csv_data_master);
                //}
                //if (export_clone == true)
                //{
                //    csv_data_clone = transpose_list_of_list_string(csv_data_clone);
                //}
                //if (export_filter == true)
                //{
                //    csv_data_clone_filter = transpose_list_of_list_string(csv_data_clone_filter);
                //}

                ////save the files at their filepath
                //save_list_of_list_string_as_csv(csv_data_master, save_results_folder + "Accel. Datasets " + dataset_name + " [Unedited].csv");
                //save_list_of_list_string_as_csv(csv_data_clone, save_results_folder + "Accel. Datasets " + dataset_name_trimmed + " [Trimmed].csv");
                //if (generic_input_data_double_clone_filtered_catalog[catalog_index].Count != 0)
                //{
                //    save_list_of_list_string_as_csv(csv_data_clone_filter, save_results_folder + "Accel. Datasets " + dataset_name_trimmed_filtered + " [Trimmed & Filtered].csv");
                //}

            }
        }

        public Boolean process_save_dataset_as_csv(List<List<double>> dataset_double, string save_filepath)
        {
            //check if data set is empty
            if (dataset_double.Count == 0)
            {
                //string message = "There is no dataset to export";
                //string title = "Error";
                //MessageBox.Show(message, title);
                return false;
            }

            //convert the doubles to string
            List<List<string>> dataset_string = convert_list_of_list_double_to_string(dataset_double);
            //insert header into data
            for (int i = 0; i < acceleration_dataset_csv_header.Count; i++)
            {
                dataset_string[i].Insert(0, acceleration_dataset_csv_header[i]);
            }
            //transpose the data to work better with excel
            dataset_string = transpose_list_of_list_string(dataset_string);

            //save the data at the output folder
            save_list_of_list_string_as_csv(dataset_string, save_filepath);

            activity_log("Dataset exported: " + save_filepath);

            return true;
        }

        public string concat_dataset_results_summary()
        {
            string dataset_result_summary_text_concatenated = string.Empty;

            for (int i = 0; i < dataset_result_summary_text_list.Count; i++)
            {
                dataset_result_summary_text_concatenated = dataset_result_summary_text_concatenated + dataset_result_summary_text_list[i];
            }

            //check if there is no results
            if (String.IsNullOrEmpty(dataset_result_summary_text_concatenated))
            {
                string message = "There are no results to export. The results are generated after clicking -" + calculate_damp_ratio_and_freq_button.Text + "- Button";
                string title = "Error";
                MessageBox.Show(message, title);
                return string.Empty;
            }

            return dataset_result_summary_text_concatenated;
        }

        public double calculate_coffecient_of_determination(List<double> sample_data, List<double> fitted_data_full, List<int> index_of_sample_data)
        {
            double coffecient_of_determination = 0;
            //total sum of squares
            double ss_tot = 0;
            //residual sum of squares
            double ss_res = 0;

            double sample_average = sample_data.Average();
            for (int i = 0; i < sample_data.Count; i++)
            {
                ss_tot += Math.Pow((sample_data[i] - sample_average), 2);

                ss_res += Math.Pow((sample_data[i] - fitted_data_full[index_of_sample_data[i]]), 2);
            }

            coffecient_of_determination = 1 - ss_res / ss_tot;
            return coffecient_of_determination;
        }

        public string get_filename_from_filepath(string filepath)
        {
            int slash_index = filepath.LastIndexOf(@"\");
            int dot_index = filepath.LastIndexOf(@".");

            //remove filepath and filetype and keep raw filename
            string filename = filepath.Substring(slash_index + 1, dot_index - slash_index - 1);

            return filename;
        }

        public void clear_all_global_variables()
        {
            VerticalLineAnnotation lower_data_boundary_vertical_line = new VerticalLineAnnotation();
            VerticalLineAnnotation upper_data_boundary_vertical_line = new VerticalLineAnnotation();

            current_selected_dataset_filepath = string.Empty;

            //pixel width of charts, used to samplke data for plotting
            chart_width = 1389;

            //the imported string list from csv
            generic_input_data_string.Clear();
            //the converted and processed data save as a master copy (kept as an original in case user wants to revert to original data)
            generic_input_data_double_master.Clear();
            //a copy of the master data but edit and trimming can be made to this data set (will be reset when user reverts to master)
            generic_input_data_double_clone.Clear();
            //same as cloned dataset but with applied filter
            generic_input_data_double_clone_filtered.Clear();
            // the data set but with trimmed local maximas data points
            generic_input_data_double_clone_maximas.Clear();

            //folder picked by user with all input data
            input_folder = string.Empty;

            //stores all csv filepath found in the slected input folder
            csv_input_filepaths.Clear(); ;
            //stores all csv filepath found in the slected input folder (in short form for readability)
            csv_input_filepaths_short.Clear();

            double input_data_sample_rate = 1024;

            data_direction_name.Clear();

            string results_summary_text = string.Empty;

            Boolean is_data_filtered = false;

            int x_index_trim_lower_index = 0;
            int x_index_trim_upper_index = 0;

            string y_axis_label_data_chart = "Acceleration (m/s^2)";

            List<string> dataset_result_summary_text_list = new List<string>();

            int current_selected_csv_checkedlistbox_index = 0;

            //these following variables are catalogs of all data set used in thew session
            generic_input_data_double_master_catalog.Clear();
            generic_input_data_double_clone_catalog.Clear();
            generic_input_data_double_clone_filtered_catalog.Clear();

            //keep track of what cutoff frequencies are used
            low_cutoff_freq_tracker.Clear();
            high_cutoff_freq_tracker.Clear();
        }

        public List<List<string>> transpose_list_of_list_string(List<List<string>> data)
        {
            List<List<string>> transposed_data = data.SelectMany(inner => inner.Select((item, index) => new { item, index }))
            .GroupBy(i => i.index, i => i.item)
            .Select(g => g.ToList())
            .ToList();

            return transposed_data;
        }

        public void populate_select_data_direction_checked_list()
        {
            select_data_direction_check_list_box.Items.Clear();

            data_direction_name.Clear();

            data_direction_name.Add("X");
            data_direction_name.Add("Y");
            data_direction_name.Add("Z");
            data_direction_name.Add("XY VS");
            data_direction_name.Add("XZ VS");
            data_direction_name.Add("YZ VS");

            foreach (string data_direction in data_direction_name)
            {
                select_data_direction_check_list_box.Items.Add(data_direction, CheckState.Checked);
            }

            select_data_direction_check_list_box.SetItemChecked(3, false);
            select_data_direction_check_list_box.SetItemChecked(4, false);
            select_data_direction_check_list_box.SetItemChecked(5, false);
        }

        public List<double> average_remove_outliers(List<double> data)
        {
            //remove outliers that are higher than 90% of average and less than 10 % of averag
            List<double> data_trimmed = new List<double>();

            double x = 0;

            for (int i = 0; i < data.Count; i++)
            {
                x = x + Math.Pow(data[i] - data.Average(), 2);
            }
            double std_deviation = Math.Sqrt(x / data.Count);

            for (int i = 0; i < data.Count; i++)
            {
                if (data[i] < data.Average() + std_deviation * 3 && data[i] > data.Average() - std_deviation * 3)
                {
                    data_trimmed.Add(data[i]);
                }
            }
            return data_trimmed;

        }

        public List<double> exponential_curve_fit(List<double> x_data, List<double> y_data, double C_offset = 0)
        {
            //returns the coefficents of the exp curve

            //exp form
            //y = A * exp(K * t)
            //linear form
            //y - C = K*t + log(A)

            List<double> y_data_log = new List<double>();

            for (int i = 0; i < y_data.Count(); i++)
            {
                //remove offset
                y_data_log.Add(y_data[i] - C_offset);
                //convert to linear curve
                y_data_log[i] = Math.Log(y_data_log[i]);
            }

            Tuple<double, double> p = Fit.Line(x_data.ToArray(), y_data_log.ToArray());
            double a = Math.Exp(p.Item1);
            double k = p.Item2;

            List<double> exp_coffecients = new List<double>();
            exp_coffecients.Add(a);
            exp_coffecients.Add(k);

            return exp_coffecients;
        }

        double[] Exponential(double[] x, double[] y, DirectRegressionMethod method = DirectRegressionMethod.QR)
        {
            //curve fit exponential curve
            double[] y_hat = Generate.Map(y, Math.Log);
            double[] p_hat = Fit.LinearCombination(x, y_hat, method, t => 1.0, t => t);
            return new[] { Math.Exp(p_hat[0]), p_hat[1] };
        }




        public List<double> calculate_natural_frequency_peaks(List<int> peak_int_indexs, double sample_rate, string series_name)
        {
            //get the freqs by using the integer indecies of the maximas and the sample rate
            List<double> frequency_peaks = new List<double>();

            for (int i = 1; i < peak_int_indexs.Count; i++)
            {
                double samples_between_peaks = Convert.ToDouble(peak_int_indexs[i] - peak_int_indexs[i - 1]);
                frequency_peaks.Add((1 / (samples_between_peaks / 1024)) / 2);
            }

            frequency_peaks = average_remove_outliers(frequency_peaks);
            //remove last data point as signal is not usually trimmed perfectly
            frequency_peaks.RemoveAt(frequency_peaks.Count - 1);

            //abitrary list to display clauclated frequencies
            List<int> count_list = new List<int>();
            for (int i = 1; i < frequency_peaks.Count + 1; i++)
            {
                count_list.Add(i);
            }


            //remove last data point to match lengths for plotting (list not used anymnore)
            peak_int_indexs.RemoveAt(peak_int_indexs.Count - 1);

            plot_freq_peaks_response(count_list, frequency_peaks, series_name);

            return frequency_peaks;
        }

        public List<List<double>> vector_sum_xyz_datasets(List<List<double>> datasets_xyz)
        {
            List<double> xy = new List<double>();
            List<double> xz = new List<double>();
            List<double> yz = new List<double>();

            for (int i = 0; i < datasets_xyz[0].Count; i++)
            {
                xy.Add(Math.Sqrt(Math.Pow(datasets_xyz[1][i], 2) * Math.Pow(datasets_xyz[2][i], 2)));
                xz.Add(Math.Sqrt(Math.Pow(datasets_xyz[1][i], 2) * Math.Pow(datasets_xyz[3][i], 2)));
                yz.Add(Math.Sqrt(Math.Pow(datasets_xyz[2][i], 2) * Math.Pow(datasets_xyz[3][i], 2)));
            }

            datasets_xyz.Add(xy);
            datasets_xyz.Add(xz);
            datasets_xyz.Add(yz);

            return datasets_xyz;
        }

        public void plot_freq_response(List<List<double>> freq_span, List<List<double>> real_spectrum, List<string> data_direction_names)
        {
            //created trimmed data based on the user selected cutoff plot freq
            List<List<double>> freq = new List<List<double>>();
            List<List<double>> mag = new List<List<double>>();

            //get user input value
            double plot_lower_cuttoff_freq = 0;
            double plot_upper_cuttoff_freq = 0;
            //checking which cutoff is higher
            if (Convert.ToDouble(upper_freq_plot_cutoff_numupdown.Value) > Convert.ToDouble(lower_freq_plot_cutoff_numupdown.Value))
            {
                plot_lower_cuttoff_freq = Convert.ToDouble(lower_freq_plot_cutoff_numupdown.Value);
                plot_upper_cuttoff_freq = Convert.ToDouble(upper_freq_plot_cutoff_numupdown.Value);
            }
            else
            {
                plot_lower_cuttoff_freq = Convert.ToDouble(upper_freq_plot_cutoff_numupdown.Value);
                plot_upper_cuttoff_freq = Convert.ToDouble(lower_freq_plot_cutoff_numupdown.Value);
            }


            //cycle through and grab trimmed value
            for (int list_index = 0; list_index < freq_span.Count; list_index++)
            {
                //temp lists
                List<double> freq_temp = new List<double>();
                List<double> mag_temp = new List<double>();

                for (int i = 0; i < freq_span[list_index].Count; i++)
                {
                    if (freq_span[list_index][i] > plot_lower_cuttoff_freq)
                    {
                        freq_temp.Add(freq_span[list_index][i]);
                        mag_temp.Add(real_spectrum[list_index][i]);
                    }
                    if (freq_span[list_index][i] > plot_upper_cuttoff_freq)
                    {
                        break;
                    }

                }

                freq.Add(freq_temp);
                mag.Add(mag_temp);
            }


            //plot the data
            plot_data_on_freq_chart(freq_dft_chart, data_direction_names, freq, mag, "Frequency (Hz)", "Amplitude");
        }

        public List<double> dft_analysis(List<List<double>> signal_data, List<string> data_direction_name)
        {
            List<double> natural_frequncy = new List<double>();

            real_spectrum = new List<List<double>>();
            freq_span = new List<List<double>>();

            for (int list_index = 0; list_index < signal_data.Count; list_index++)
            {
                // Instantiate a new DFT
                FFT fft = new FFT();

                // Initialize the DFT
                // You only need to do this once or if you change any of the DFT parameters.
                UInt32 lng = Convert.ToUInt32(signal_data[list_index].Count);
                UInt32 zero_pad = Convert.ToUInt32(signal_data[list_index].Count*3);

                Boolean padding_not_found = true;
                int i = 0;
                while (padding_not_found)
                {
                    i=i+2;
                    if (Math.Pow(2, i) > (lng + zero_pad))
                    {
                        zero_pad = Convert.ToUInt32(Math.Pow(2, i)) - lng;
                        padding_not_found = false;
                    }
                }

                fft.Initialize(lng, zero_pad);

                // Call the DFT and get the scaled spectrum back
                Complex[] complex_spectrum = fft.Execute(convert_double_list_to_array(signal_data[list_index]));

                // Convert the complex spectrum to magnitude
                real_spectrum.Add(DSP.ConvertComplex.ToMagnitude(complex_spectrum).ToList());

                // contains a properly scaled Spectrum from 0 - 50,000 Hz (1/2 the Sampling Frequency)

                // For plotting on an XY Scatter plot, generate the X Axis frequency Span
                freq_span.Add(fft.FrequencySpan(input_data_sample_rate).ToList());

                //DSPLib.FFT fft = new DSPLib.FFT();
                //fft.Initialize(Convert.ToUInt32(signal_data[list_index].Count));
                //Complex[] cSpectrum = fft.Execute(convert_double_list_to_array(signal_data[list_index]));



                //remove first entry of 0Hz
                real_spectrum[list_index].RemoveAt(0);
                freq_span[list_index].RemoveAt(0);

                get_actual_max_freq(freq_span[list_index], real_spectrum[list_index]);

                natural_frequncy.Add(freq_span[list_index][real_spectrum[list_index].IndexOf(real_spectrum[list_index].Max())]);
            }

            

            ////make the vector sum frequencies the average of their compenet frequencies
            //natural_frequncy.Add((natural_frequncy[0] + natural_frequncy[1]) / 2);
            //natural_frequncy.Add((natural_frequncy[0] + natural_frequncy[2]) / 2);
            //natural_frequncy.Add((natural_frequncy[1] + natural_frequncy[2]) / 2);

            plot_freq_response(freq_span, real_spectrum, data_direction_name);

            return natural_frequncy;
        }

        private int find_closest_value(double val, List<Double> list)
        {
            int max = list.Count;
            int min = 0;
            int index = max / 2;

            while (max - min > 1)
            {
                if (val < list[index])
                    max = index;
                else if (val > list[index])
                    min = index;
                else
                    return index;

                index = (max - min) / 2 + min;
            }

            if (max != list.Count &&
                    Math.Abs(list[max] - val) < Math.Abs(list[min] - val))
            {
                return max;
            }
            return min;
        }

        public double[] convert_double_list_to_array_pad_with_zeros(List<double> data)
        {
            int j = 2;
            Boolean while_flag = true;
            while (while_flag)
            {
                if (Math.Pow(j, 2) >= data.Count)
                {
                    while_flag = false;
                }
                j = j + 2;
            }


            double[] double_array = new double[Convert.ToInt32(Math.Pow(j, 2))];

            for (int i = 0; i < data.Count; i++)
            {
                double_array[i] = data[i];
            }
            return double_array;
        }

        public double[] convert_double_list_to_array(List<double> data)
        {
            double[] double_array = new double[data.Count];
            for (int i = 0; i < data.Count; i++)
            {
                double_array[i] = data[i];
            }
            return double_array;
        }

        public List<List<double>> sample_plotting_data(List<List<double>> data_sets, int max_samples)
        {
            //X & Y muust be same length
            //if(X.Count != Y.Count)
            //{

            //}

            List<List<double>> sampled_data_sets = new List<List<double>>();

            if (data_sets[0].Count <= max_samples)
            {
                return data_sets;
            }

            int sample_rate = data_sets[0].Count / max_samples;

            //List<double> time_sampled = new List<double>();
            //List<double> X_sampled = new List<double>();
            //List<double> Y_sampled = new List<double>();
            //List<double> Z_sampled = new List<double>();

            for (int list_index = 0; list_index < data_sets.Count; list_index++)
            {

                List<double> sampled_data = new List<double>();

                for (int i = 0; i < data_sets[list_index].Count; i = i + sample_rate)
                {
                    sampled_data.Add(Math.Abs(data_sets[list_index][i]));
                    //sampled_data.Add((data_sets[list_index][i]));

                    //time_sampled.Add(data_sets[0][i]);
                    //X_sampled.Add(data_sets[1][i]);
                    //Y_sampled.Add(data_sets[2][i]);
                    //Z_sampled.Add(data_sets[3][i]);
                }
                sampled_data_sets.Add(sampled_data);
            }

            //sampled_data_sets.Add(time_sampled);
            //sampled_data_sets.Add(X_sampled);
            //sampled_data_sets.Add(Y_sampled);
            //sampled_data_sets.Add(Z_sampled);

            return sampled_data_sets;

        }

        public List<double> remove_data_offset(List<double> data)
        {
            double offset = data.Average();
            for (int i = 0; i < data.Count; i++)
            {
                data[i] = data[i] - offset;
            }
            return data;
        }

        public List<double> compute_integration_list(List<double> x_data, List<double> y_data)
        {
            //integrate data list using composite midpoint method 
            //assume data is has no abritraty offse


            List<double> y_data_integrated = new List<double>();

            double cumulative_area = 0;

            for (int i = 1; i < y_data.Count; i++)
            {
                double width = x_data[i] - x_data[i - 1];
                double area = width * y_data[i - 1];
                //cumulative_area = cumulative_area + area;
                y_data_integrated.Add(width * area);
            }

            return y_data_integrated;
        }


        public static List<int> find_local_maximas(List<double> values, int range_of_peaks)
        {
            List<int> peaks = new List<int>();
            double current;
            IEnumerable<double> range;

            int checksOnEachSide = range_of_peaks / 2;
            for (int i = 0; i < values.Count; i++)
            {
                current = values[i];
                range = values;

                if (i > checksOnEachSide)
                {
                    range = range.Skip(i - checksOnEachSide);
                }

                range = range.Take(range_of_peaks);
                if ((range.Count() > 0) && (current == range.Max()))
                {
                    peaks.Add(i);
                }
            }

            return peaks;
        }

        public void convert_ticks_to_seconds()
        {
            for (int i = 0; i < generic_input_data_double_master[0].Count; i++)
            {
                generic_input_data_double_master[0][i] = Convert.ToDouble(i + 1) / input_data_sample_rate;
            }
        }

        public List<List<double>> convert_list_of_list_string_to_double(List<List<string>> list_of_lists_data)
        {
            List<List<double>> double_data = new List<List<double>>();

            foreach (List<string> list_of_data in list_of_lists_data)
            {
                double_data.Add(list_of_data.Select(x => double.Parse(x)).ToList());
            }
            return double_data;
        }

        public List<List<string>> convert_list_of_list_double_to_string(List<List<double>> list_of_lists_data)
        {
            List<List<string>> string_data = new List<List<string>>();

            foreach (List<double> list_of_data in list_of_lists_data)
            {
                string_data.Add(list_of_data.Select(x => (x).ToString()).ToList());
            }
            return string_data;
        }

        public void update_trimmed_input_data(int lower_boundary_index, int upper_boundary_index)
        {
            //trim all data out side the indexes
            List<List<double>> temp_list1 = new List<List<double>>();
            List<List<double>> temp_list2 = new List<List<double>>();
            foreach (List<double> data in generic_input_data_double_clone)
            {
                temp_list1.Add(data.GetRange(lower_boundary_index, upper_boundary_index - lower_boundary_index));
            }
            generic_input_data_double_clone = temp_list1;

            foreach (List<double> data in generic_input_data_double_clone_filtered)
            {
                temp_list2.Add(data.GetRange(lower_boundary_index, upper_boundary_index - lower_boundary_index));
            }
            generic_input_data_double_clone_filtered = temp_list2;
        }

        public List<int> calculate_amount_zero_crossings(List<double> data)
        {

            List<int> zero_cross_index = new List<int>();

            //remove offset from data
            double data_avg = data.Average();
            for (int i = 0; i < data.Count; i++)
            {
                data[i] = data[i] - data_avg;
            }

            for (int i = 1; i < data.Count; i++)
            {
                if (data[i] < 0 && data[i - 1] >= 0)
                {
                    zero_cross_index.Add(i);
                }

                if (data[i] > 0 && data[i - 1] <= 0)
                {
                    zero_cross_index.Add(i);
                }
            }

            return zero_cross_index;

        }

        public double calculate_freq_based_zero_crossings(List<double> time_data, List<int> points_of_interest)
        {
            List<double> time_between_zero_crossings = new List<double>();

            for (int i = 1; i < points_of_interest.Count; i++)
            {
                time_between_zero_crossings.Add(time_data[points_of_interest[i]] - time_data[points_of_interest[i - 1]]);
            }

            double frequency = 1 / (time_between_zero_crossings.Average() * 2);
            return frequency;
        }

        //program control functions

        public void check_checked_chart_series()
        {
            for (int i = 0; i < select_data_direction_check_list_box.Items.Count; i++)
            {
                if (select_data_direction_check_list_box.GetItemCheckState(i) == CheckState.Checked)
                {
                    //try catch added because user could click on control before and chart data was loaded casuing error
                    try
                    {
                        data_chart.Series[i].Enabled = true;
                    }
                    catch { }
                }
                else
                {
                    try
                    {
                        data_chart.Series[i].Enabled = false;
                    }
                    catch { }
                }
            }
        }

        public void load_data_of_selected_dataset_existing_session_update_charts()
        {
            ////these following variables are catalogs of all data set used in thew session
            //List<List<List<double>>> generic_input_data_double_master_catalog = new List<List<List<double>>>();
            //List<List<List<double>>> generic_input_data_double_clone_catalog = new List<List<List<double>>>();
            //List<List<List<double>>> generic_input_data_double_clone_filtered_catalog = new List<List<List<double>>>();

            List<List<double>> selected_dataset = new List<List<double>>();

            ////get which data set to load into data chart
            //check if there is any filtered data in the catalog
            if (generic_input_data_double_clone_filtered_catalog[select_data_set_tool_strip_combo_box.SelectedIndex].Count > 0)
            {
                selected_dataset = generic_input_data_double_clone_filtered_catalog[select_data_set_tool_strip_combo_box.SelectedIndex];

                generic_input_data_double_clone_filtered = generic_input_data_double_clone_filtered_catalog[select_data_set_tool_strip_combo_box.SelectedIndex];
                generic_input_data_double_clone = generic_input_data_double_clone_catalog[select_data_set_tool_strip_combo_box.SelectedIndex];
                generic_input_data_double_master = generic_input_data_double_master_catalog[select_data_set_tool_strip_combo_box.SelectedIndex];

            }
            //check if there is any cloned data in the catalog
            else if (generic_input_data_double_clone_catalog[select_data_set_tool_strip_combo_box.SelectedIndex].Count > 0)
            {
                selected_dataset = generic_input_data_double_clone_catalog[select_data_set_tool_strip_combo_box.SelectedIndex];

                generic_input_data_double_clone_filtered = new List<List<double>>();
                generic_input_data_double_clone = generic_input_data_double_clone_catalog[select_data_set_tool_strip_combo_box.SelectedIndex];
                generic_input_data_double_master = generic_input_data_double_master_catalog[select_data_set_tool_strip_combo_box.SelectedIndex];
            }
            //check if there is any master data in the catalog
            else if (generic_input_data_double_master_catalog[select_data_set_tool_strip_combo_box.SelectedIndex].Count > 0)
            {
                selected_dataset = generic_input_data_double_master_catalog[select_data_set_tool_strip_combo_box.SelectedIndex];

                generic_input_data_double_clone_filtered = new List<List<double>>();
                generic_input_data_double_clone = generic_input_data_double_master_catalog[select_data_set_tool_strip_combo_box.SelectedIndex]; //set clone to master snyway
                generic_input_data_double_master = generic_input_data_double_master_catalog[select_data_set_tool_strip_combo_box.SelectedIndex];
            }

            ////set all data sets from the catalog to the current selected datasets
            //generic_input_data_double_clone_filtered= generic_input_data_double_clone_filtered_catalog[select_data_set_tool_strip_combo_box.SelectedIndex];
            //generic_input_data_double_clone = generic_input_data_double_clone_catalog[select_data_set_tool_strip_combo_box.SelectedIndex];
            //generic_input_data_double_master = generic_input_data_double_master_catalog[select_data_set_tool_strip_combo_box.SelectedIndex];



            //plot data on chart
            plot_data_on_chart(data_chart, data_direction_name, selected_dataset, "Time (Seconds)", y_axis_label_data_chart);

            //plot the trimming annotations
            draw_vertical_annotations(data_chart, lower_data_boundary_vertical_line, upper_data_boundary_vertical_line, selected_dataset[0]);
        }

        public void load_data_of_selected_dataset_update_charts()
        {
            generic_input_data_string = load_csv_as_2d_list_string_cols(current_selected_dataset_filepath);

            //remove header from data
            foreach (List<string> data in generic_input_data_string)
            {
                data.RemoveAt(0);
            }
            //convert from string list to double list
            generic_input_data_double_master = convert_list_of_list_string_to_double(generic_input_data_string);

            //converts the time data from ticks to seconds (1 tick = 1/1024 seconds)
            convert_ticks_to_seconds();

            //remove data offsets
            for (int i = 1; i < generic_input_data_double_master.Count; i++)
            {
                generic_input_data_double_master[i] = remove_data_offset(generic_input_data_double_master[i]);
            }

            //vector sum sets of 2 directions of data and add to main data set
            generic_input_data_double_master = vector_sum_xyz_datasets(generic_input_data_double_master);

            //clone the master data set
            generic_input_data_double_clone = generic_input_data_double_master;

            //add data to catalog
            generic_input_data_double_master_catalog[select_data_set_tool_strip_combo_box.SelectedIndex] = generic_input_data_double_master;

            //clear any filtered data
            generic_input_data_double_clone_filtered.Clear();

            //plot data on chart
            plot_data_on_chart(data_chart, data_direction_name, generic_input_data_double_clone, "Time (Seconds)", y_axis_label_data_chart);

            //plot the trimming annotations
            draw_vertical_annotations(data_chart, lower_data_boundary_vertical_line, upper_data_boundary_vertical_line, generic_input_data_double_clone[0]);
        }

        public void update_program_after_load_session()
        {
            //clear all visible UI elements
            summary_results_textbox.Clear();
            activity_log_textbox.Clear();
            data_chart.Series.Clear();
            freq_dft_chart.Series.Clear();
            freq_peaks_chart.Series.Clear();

            //clear select data set combobox
            select_data_set_tool_strip_combo_box.Items.Clear();


            //update the output folder
            save_results_folder = input_folder + output_folder_name;

            //set selected input folder textbox to user selected folder
            input_folder_textbox.Text = input_folder;

            select_data_set_tool_strip_combo_box.Items.Clear();
            for (int i = 0; i < csv_input_filepaths.Count; i++)
            {
                select_data_set_tool_strip_combo_box.Items.Add(csv_input_filepaths_short[i]);
            }

            current_selected_csv_checkedlistbox_index = 0;
        }

        public void update_program_after_input_folder_select()
        {
            //clear all visible UI elements
            summary_results_textbox.Clear();
            activity_log_textbox.Clear();
            data_chart.Series.Clear();
            freq_dft_chart.Series.Clear();
            freq_peaks_chart.Series.Clear();

            //clear catalogs of data
            generic_input_data_double_master_catalog.Clear();
            generic_input_data_double_clone_catalog.Clear();
            generic_input_data_double_clone_filtered_catalog.Clear();

            //clear select data set combobox
            select_data_set_tool_strip_combo_box.Items.Clear();

            //clear all saved summaries
            dataset_result_summary_text_list.Clear();

            //open windows explorer to retrieve user folder
            select_folder(out input_folder);

            if (input_folder == string.Empty)
            {
                return;
            }
            input_folder = input_folder + @"\";

            Directory.CreateDirectory(input_folder + output_folder_name);

            activity_log("Input folder selected: " + input_folder);

            //update the output folder
            save_results_folder = input_folder + output_folder_name;

            //set selected input folder textbox to user selected folder
            input_folder_textbox.Text = input_folder;

            //get all dataset files (within user folder) and save to a list
            csv_input_filepaths = (Directory.GetFiles(input_folder, "*.csv", System.IO.SearchOption.AllDirectories)).ToList();


            //removes output files if option is selected
            if (importcsvFilesFromOutputFolderWhenSelectingToolStripMenuItem.Checked == false)
            {
                //remove files located in the output folder
                for (int i = csv_input_filepaths.Count - 1; i >= 0; i--)
                {
                    if (csv_input_filepaths[i].Contains(output_folder_name) == true)
                    {
                        csv_input_filepaths.RemoveAt(i);
                    }
                }
            }

            //create a short version of all found csv files
            csv_input_filepaths_short = new List<string>();
            for (int i = 0; i < csv_input_filepaths.Count; i++)
            {
                csv_input_filepaths_short.Add(csv_input_filepaths[i].Replace(input_folder, String.Empty));
                //add blank enrties for each possible loaded dataset (for the summary results list)
                dataset_result_summary_text_list.Add(string.Empty);

                //add blank entries for the catalog lists
                generic_input_data_double_master_catalog.Add(new List<List<double>>());
                generic_input_data_double_clone_catalog.Add(new List<List<double>>());
                generic_input_data_double_clone_filtered_catalog.Add(new List<List<double>>());

                //add blank freqs to the tracker
                low_cutoff_freq_tracker.Add(0);
                high_cutoff_freq_tracker.Add(0);

                //add entries to say all data is initally unfiltered
                is_data_filtered.Add(false);

                //add blank entries to allocate slots for all datasets
                x_index_trim_lower_index_trimmed.Add(0);
                x_index_trim_upper_index_trimmed.Add(0);
                x_index_trim_lower_index_master.Add(0);
                x_index_trim_upper_index_master.Add(0);
            }

            for (int i = 0; i < csv_input_filepaths.Count; i++)
            {
                select_data_set_tool_strip_combo_box.Items.Add(csv_input_filepaths_short[i]);
            }
        }

        //load/save csv functions
        public List<List<string>> load_csv_as_2d_list_string_cols(string csv_file_path1)
        {
            List<List<string>> parsed_csv = new List<List<string>>();

            //string[,] parsed_csv;
            List<string[]> csvLines = new List<string[]>();
            TextFieldParser parser = new TextFieldParser(csv_file_path1);
            parser.Delimiters = new string[] { "," };
            parser.TextFieldType = FieldType.Delimited;
            int maxLines = 999999999, lineCount = 0;

            try
            {
                while (!parser.EndOfData && lineCount++ < maxLines)
                {
                    csvLines.Add(parser.ReadFields());
                }
            }
            catch (MalformedLineException)
            {

            }


            List<string> temp_list = new List<string>();
            for (int j = 0; j < csvLines[0].Length; j++)
            {
                for (int i = 0; i < csvLines.Count; i++)
                {
                    temp_list.Add(csvLines[i][j]);
                }
                parsed_csv.Add(new List<string>(temp_list));
                temp_list.Clear();

            }

            return parsed_csv;

        }

        public List<List<string>> load_csv_as_2d_list_string_rows(string csv_file_path1)
        {
            List<List<string>> parsed_csv = new List<List<string>>();

            //string[,] parsed_csv;
            List<string[]> csvLines = new List<string[]>();
            TextFieldParser parser = new TextFieldParser(csv_file_path1);
            parser.Delimiters = new string[] { "," };
            parser.TextFieldType = FieldType.Delimited;
            int maxLines = 999999999, lineCount = 0;

            try
            {
                while (!parser.EndOfData && lineCount++ < maxLines)
                {
                    csvLines.Add(parser.ReadFields());
                }
            }
            catch (MalformedLineException)
            {

            }


            List<string> temp_list = new List<string>();

            for (int i = 0; i < csvLines.Count; i++)
            {
                for (int j = 0; j < csvLines[i].Length; j++)
                {
                    temp_list.Add(csvLines[i][j]);
                }
                parsed_csv.Add(new List<string>(temp_list));
                temp_list.Clear();

            }

            return parsed_csv;

        }

        public void save_list_of_list_string_as_csv(List<List<string>> data, string filepath)
        {

            const string SEPARATOR = ",";
            using (StreamWriter writer = new StreamWriter(filepath))
            {
                data.ForEach(line =>
                {
                    var lineArray = line.Select(c =>
                        c.Contains(SEPARATOR) ? c.Replace(SEPARATOR.ToString(), "\\" + SEPARATOR) : c).ToArray();
                    writer.WriteLine(string.Join(SEPARATOR, lineArray));
                });
            }
        }

        //manipulate chart functions

        public void plot_freq_peaks_response(List<int> time_peaks, List<double> frequency_peaks, string series_name)
        {
            System.Windows.Forms.DataVisualization.Charting.Series series = freq_peaks_chart.Series.Add(series_name + " Freq. Resp.");
            series.ChartType = SeriesChartType.Point;
            series.Points.DataBindXY(time_peaks, frequency_peaks);
            series.BorderWidth = 1;
            series.ToolTip = "#SERIESNAME\nX: #VALX\nY: #VAL";


            freq_peaks_chart.ChartAreas[0].AxisX.Title = "Freq. Calc. #";
            freq_peaks_chart.ChartAreas[0].AxisY.Title = "Frequency (Hz)";

            //rescale y axis
            freq_peaks_chart.ChartAreas[0].AxisY.IsStartedFromZero = false;

        }

        public void trim_data_function()
        {
            double x_index_trim_lower = 0;
            double x_index_trim_upper = 0;

            //get boundary values from vertical annotations
            if (upper_data_boundary_vertical_line.X > lower_data_boundary_vertical_line.X)
            {
                x_index_trim_lower = lower_data_boundary_vertical_line.X;
                x_index_trim_upper = upper_data_boundary_vertical_line.X;
            }
            else
            {
                x_index_trim_upper = lower_data_boundary_vertical_line.X;
                x_index_trim_lower = upper_data_boundary_vertical_line.X;
            }

            if (is_data_filtered[select_data_set_tool_strip_combo_box.SelectedIndex] == true && generic_input_data_double_clone_filtered.Count > 0)
            {
                x_index_trim_lower_index_trimmed[select_data_set_tool_strip_combo_box.SelectedIndex] = find_closest_value(x_index_trim_lower, generic_input_data_double_clone_filtered[0]);
                x_index_trim_upper_index_trimmed[select_data_set_tool_strip_combo_box.SelectedIndex] = find_closest_value(x_index_trim_upper, generic_input_data_double_clone_filtered[0]);

                //get time value of of the horiz annotation and get the index of the time from the master time list
                x_index_trim_lower_index_master[select_data_set_tool_strip_combo_box.SelectedIndex] = generic_input_data_double_master[0].IndexOf(generic_input_data_double_clone_filtered[0][find_closest_value(x_index_trim_lower, generic_input_data_double_clone[0])]);
                x_index_trim_upper_index_master[select_data_set_tool_strip_combo_box.SelectedIndex] = generic_input_data_double_master[0].IndexOf(generic_input_data_double_clone_filtered[0][find_closest_value(x_index_trim_upper, generic_input_data_double_clone[0])]);
            }
            else
            {
                x_index_trim_lower_index_trimmed[select_data_set_tool_strip_combo_box.SelectedIndex] = find_closest_value(x_index_trim_lower, generic_input_data_double_clone[0]);
                x_index_trim_upper_index_trimmed[select_data_set_tool_strip_combo_box.SelectedIndex] = find_closest_value(x_index_trim_upper, generic_input_data_double_clone[0]);

                //get time value of of the horiz annotation and get the index of the time from the master time list
                x_index_trim_lower_index_master[select_data_set_tool_strip_combo_box.SelectedIndex] = generic_input_data_double_master[0].IndexOf(generic_input_data_double_clone[0][find_closest_value(x_index_trim_lower, generic_input_data_double_clone[0])]);
                x_index_trim_upper_index_master[select_data_set_tool_strip_combo_box.SelectedIndex] = generic_input_data_double_master[0].IndexOf(generic_input_data_double_clone[0][find_closest_value(x_index_trim_upper, generic_input_data_double_clone[0])]);
            }

            if (Math.Abs(x_index_trim_upper_index_trimmed[select_data_set_tool_strip_combo_box.SelectedIndex] - x_index_trim_lower_index_trimmed[select_data_set_tool_strip_combo_box.SelectedIndex]) < 15)
            {
                string message = "Cannot trim data to less than 15 data points";
                string title = "Error";
                MessageBox.Show(message, title);
                return;
            }

            update_trimmed_input_data(x_index_trim_lower_index_trimmed[select_data_set_tool_strip_combo_box.SelectedIndex], x_index_trim_upper_index_trimmed[select_data_set_tool_strip_combo_box.SelectedIndex]);

            //add data to catalog
            generic_input_data_double_clone_catalog[select_data_set_tool_strip_combo_box.SelectedIndex] = generic_input_data_double_clone;

            if (is_data_filtered[select_data_set_tool_strip_combo_box.SelectedIndex] == true && generic_input_data_double_clone_filtered.Count > 0)
            {
                List<string> data_direction_name_filter = new List<string>();
                foreach (string name in data_direction_name)
                {
                    data_direction_name_filter.Add(name + "(Filt.)");
                }

                plot_data_on_chart(data_chart, data_direction_name_filter, generic_input_data_double_clone_filtered, "Time (Seconds)", y_axis_label_data_chart);
            }
            else
            {
                plot_data_on_chart(data_chart, data_direction_name, generic_input_data_double_clone, "Time (Seconds)", y_axis_label_data_chart);
            }


            draw_vertical_annotations(data_chart, lower_data_boundary_vertical_line, upper_data_boundary_vertical_line, generic_input_data_double_clone[0]);

            check_checked_chart_series();
        }

        public List<double> plot_fitted_exponential_curve(double A, double k, string dataset_name)
        {
            List<double> exp_curve_values = new List<double>();

            for (int i = 0; i < generic_input_data_double_clone[0].Count; i++)
            {
                exp_curve_values.Add(A * Math.Exp(k * generic_input_data_double_clone[0][i]));
            }

            string series_name = dataset_name + " Exp. Fit";

            //plot with settings
            try
            {
                System.Windows.Forms.DataVisualization.Charting.Series series = data_chart.Series.Add(series_name);
                data_chart.Series[series_name].Points.Clear();
                series.ChartType = SeriesChartType.Line;
                series.Color = Color.DarkRed;
                series.Points.DataBindXY(generic_input_data_double_clone[0], exp_curve_values);
                series.BorderWidth = 2;
                series.ToolTip = "#SERIESNAME\nX: #VALX\nY: #VAL";
            }
            catch
            {
                data_chart.Series[series_name].Points.Clear();
                data_chart.Series[series_name].ChartType = SeriesChartType.Line;
                data_chart.Series[series_name].Color = Color.DarkRed;
                data_chart.Series[series_name].Points.DataBindXY(generic_input_data_double_clone[0], exp_curve_values);
                data_chart.Series[series_name].BorderWidth = 2;
                data_chart.Series[series_name].ToolTip = "#SERIESNAME\nX: #VALX\nY: #VAL";
            }


            return exp_curve_values;
        }

        public List<double> plot_peaks_chart(List<int> peak_indexs, List<double> abs_data, string series_name)
        {
            //clear existing series
            //Series series_name1 = new Series(series_name);
            //data_chart.Series.Remove(series_name1);
            //try
            //{
            //    data_chart.Series[series_name].Dispose();
            //    data_chart.Series.Remove(new Series(series_name));
            //}
            //catch{ }

            List<double> peak_times = new List<double>();
            List<double> peak_amplitudes = new List<double>();

            //dont include last point it can be a bad data point
            for (int i = 0; i < peak_indexs.Count - 1; i++)
            {
                peak_times.Add(generic_input_data_double_clone[0][peak_indexs[i]]);
                peak_amplitudes.Add(abs_data[peak_indexs[i]]);
            }
            try
            {
                System.Windows.Forms.DataVisualization.Charting.Series series = data_chart.Series.Add(series_name);
                data_chart.Series[series_name].Points.Clear();
                series.ChartType = SeriesChartType.Point;
                series.Color = Color.Red;
                series.Points.DataBindXY(peak_times, peak_amplitudes);
                series.BorderWidth = 3;
                series.ToolTip = "#SERIESNAME\nX: #VALX\nY: #VAL";
            }
            catch
            {
                data_chart.Series[series_name].Points.Clear();
                data_chart.Series[series_name].ChartType = SeriesChartType.Point;
                data_chart.Series[series_name].Color = Color.Red;
                data_chart.Series[series_name].Points.DataBindXY(peak_times, peak_amplitudes);
                data_chart.Series[series_name].BorderWidth = 3;
                data_chart.Series[series_name].ToolTip = "#SERIESNAME\nX: #VALX\nY: #VAL";
            }


            return peak_amplitudes;
        }

        public void plot_data_on_chart(Chart chart_name, List<string> data_sets_names, List<List<double>> data_sets, string x_axis_label, string y_axis_label)
        {

            List<List<double>> sampled_data_sets = sample_plotting_data(data_sets, chart_width);

            //create series and plot
            chart_name.Series.Clear();

            for (int i = 1; i < sampled_data_sets.Count; i++)
            {
                System.Windows.Forms.DataVisualization.Charting.Series series = chart_name.Series.Add(data_sets_names[i - 1]);
                series.ChartType = SeriesChartType.Line;
                series.Points.DataBindXY(sampled_data_sets[0], sampled_data_sets[i]);
                series.BorderWidth = 1;
                series.ToolTip = "#SERIESNAME\nX: #VALX\nY: #VAL";
            }

            chart_name.ChartAreas[0].AxisX.Title = x_axis_label;
            chart_name.ChartAreas[0].AxisY.Title = y_axis_label;

            chart_name.ChartAreas[0].AxisX.LabelStyle.Format = "0.00";
        }

        public void plot_data_on_freq_chart(Chart chart_name, List<string> data_sets_names, List<List<double>> freq_span, List<List<double>> mag_values, string x_axis_label, string y_axis_label)
        {

            //List<List<double>> sampled_data_sets = sample_plotting_data(data_sets, chart_width);

            //create series and plot
            chart_name.Series.Clear();

            for (int i = 0; i < freq_span.Count; i++)
            {
                System.Windows.Forms.DataVisualization.Charting.Series series = chart_name.Series.Add(data_sets_names[i] + " Freq. Resp.");
                series.ChartType = SeriesChartType.Line;
                series.Points.DataBindXY(freq_span[i], mag_values[i]);
                series.BorderWidth = 2;
                series.ToolTip = "#SERIESNAME\nX: #VALX\nY: #VAL";
            }

            chart_name.ChartAreas[0].AxisX.Title = x_axis_label;
            chart_name.ChartAreas[0].AxisY.Title = y_axis_label;

            chart_name.ChartAreas[0].AxisX.LabelStyle.Format = "0.00";

            chart_name.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            chart_name.ChartAreas[0].CursorX.AutoScroll = true;
            chart_name.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;

            if (linear_or_log_combobox.SelectedIndex == 1)
            {
                chart_name.ChartAreas[0].AxisY.IsLogarithmic = true;
            }
            else
            {
                chart_name.ChartAreas[0].AxisY.IsLogarithmic = false;
            }

        }

        public void draw_vertical_annotations(Chart chart_name, VerticalLineAnnotation line1, VerticalLineAnnotation line2, List<double> time_data_list)
        {
            // the vertical line and its properties
            //line1 = new VerticalLineAnnotation();

            chart_name.Annotations.Remove(line1);

            line1.AxisX = chart_name.ChartAreas[0].AxisX;
            line1.AllowMoving = true;
            line1.IsInfinitive = true;
            line1.ClipToChartArea = chart_name.ChartAreas[0].Name;
            //line1.Name = "line 1";
            line1.LineColor = Color.Purple;
            line1.LineWidth = 3;         // use your numbers!
            line1.X = time_data_list[0];
            //add to the chart
            chart_name.Annotations.Add(line1);

            // the vertical line and its properties
            //line2 = new VerticalLineAnnotation();

            chart_name.Annotations.Remove(line2);

            line2.AxisX = chart_name.ChartAreas[0].AxisX;
            line2.AllowMoving = true;
            line2.IsInfinitive = true;
            line2.ClipToChartArea = chart_name.ChartAreas[0].Name;
            //line2.Name = "line 2";
            line2.LineColor = Color.Purple;
            line2.LineWidth = 3;         // use your numbers!
            line2.X = time_data_list[time_data_list.Count - 10];
            //add to the chart
            chart_name.Annotations.Add(line2);
        }

        //select folder functions

        private bool select_folder(out string fileName)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                fileName = dialog.FileName;
                return true;
            }
            else
            {
                fileName = "";
                return false;
            }
        }

        //event control functions
        private void x_data_chart_Click(object sender, MouseEventArgs e)
        {
            //clicked_x_pos_chart = x_data_chart.ChartAreas[0].AxisX.PixelPositionToValue(e.X);
            //clicked_y_pos_chart = x_data_chart.ChartAreas[0].AxisX.PixelPositionToValue(e.Y);
        }

        private void trim_data_button_Click(object sender, EventArgs e)
        {
            trim_data_function();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void calculate_damp_ratio_and_freq_button_Click(object sender, EventArgs e)
        {
            //clear plotting values
            real_spectrum = new List<List<double>>();
            freq_span = new List<List<double>>();

            //clear summary text
            results_summary_text = string.Empty;
            //empty the results box
            summary_results_textbox.Text = string.Empty;
            // clear the freq plot
            freq_peaks_chart.Series.Clear();

            List<List<double>> selected_data_sets = new List<List<double>>();
            List<string> selected_data_set_names = new List<string>();

            List<double> peak_freqs = new List<double>();


            //get cutoff freqs
            double low_cutoff_freq = Convert.ToDouble(low_freq_cutoff_numupdown.Value);
            double high_cutoff_freq = Convert.ToDouble(high_freq_cutoff_numupdown.Value);

            //get timestamps of trimmed data
            double first_timestamp = Math.Round(generic_input_data_double_clone[0][0], 1);
            double second_timestamp = Math.Round(generic_input_data_double_clone[0][generic_input_data_double_clone[0].Count - 1], 1);

            //get pixel length of
            string header_border = "/////////////////////////////////////////////////////////////////////////////////////////////////////////\r\n";

            //set header for text file
            results_summary_text = header_border;
            results_summary_text = results_summary_text + csv_input_filepaths_short[current_selected_csv_checkedlistbox_index] + "\r\n";
            results_summary_text = results_summary_text + header_border;
            results_summary_text = results_summary_text + "Trimmed from " + first_timestamp + " seconds to " + second_timestamp + " seconds.\r\n";
            if (is_data_filtered[select_data_set_tool_strip_combo_box.SelectedIndex] == true)
            {
                results_summary_text = results_summary_text + "The data sets were bandpass filtered with cutoff frequencies of " + low_cutoff_freq + " Hz and " + high_cutoff_freq + " Hz.\r\n";
            }
            results_summary_text = results_summary_text + "\r\n";

            //determine which data directions are currently selected add them to a list to be freq analyzed
            for (int data_direction_index = 0; data_direction_index < select_data_direction_check_list_box.Items.Count; data_direction_index++)
            {
                if (select_data_direction_check_list_box.GetItemCheckState(data_direction_index) == CheckState.Checked)
                {
                    selected_data_set_names.Add(data_direction_name[data_direction_index]);

                    if (is_data_filtered[select_data_set_tool_strip_combo_box.SelectedIndex] == true)
                    {
                        selected_data_sets.Add(generic_input_data_double_clone_filtered[data_direction_index + 1]);
                    }
                    else
                    {
                        selected_data_sets.Add(generic_input_data_double_clone[data_direction_index + 1]);
                    }
                }
            }

            List<double> natural_frequencies = dft_analysis(selected_data_sets, selected_data_set_names);

            //after the natural frequencies have been analyzed run loop again to get results
            for (int data_direction_index = 0; data_direction_index < natural_frequencies.Count; data_direction_index++)
            {

                List<double> selected_data_set_abs = new List<double>();
                for (int i = 0; i < selected_data_sets[data_direction_index].Count; i++)
                {
                    selected_data_set_abs.Add(Math.Abs(selected_data_sets[data_direction_index][i]));
                }

                int window_size = Convert.ToInt32(Math.Round(((1 / natural_frequencies[data_direction_index]) * input_data_sample_rate * 0.95) / 2));
                List<int> local_maximas = find_local_maximas(selected_data_set_abs, window_size);


                List<double> peak_amplitudes = plot_peaks_chart(local_maximas, selected_data_set_abs, selected_data_set_names[data_direction_index] + " Peaks");


                List<double> natural_frequncy_peaks = calculate_natural_frequency_peaks(local_maximas, input_data_sample_rate, selected_data_set_names[data_direction_index]);
                double average_natural_frequency_peaks = natural_frequncy_peaks.Average();
                peak_freqs.Add(average_natural_frequency_peaks);

                //gather the data points of the local maximas
                List<double> time_maximas = new List<double>();
                List<double> selected_data_set_maximas = new List<double>();

                for (int i = 0; i < local_maximas.Count; i++)
                {
                    time_maximas.Add(generic_input_data_double_clone[0][local_maximas[i]]);
                    selected_data_set_maximas.Add(selected_data_set_abs[local_maximas[i]]);
                }

                //calculate simplified damping ratio based on loagrithmic decrement
                List<double> damp_ratios = new List<double>();
                for (int i = 1; i < selected_data_set_maximas.Count; i++)
                {
                    double damp_ratio_temp = 1 / Math.Sqrt(1 + Math.Pow(2 * Math.PI / (Math.Log(selected_data_set_maximas[i - 1] / selected_data_set_maximas[i])), 2));
                    if (Double.IsNaN(damp_ratio_temp) != true)
                    {
                        damp_ratios.Add(damp_ratio_temp);
                    }
                }

                double damp_ratio_average = damp_ratios.Average();

                //y=p[0] e ^ (p[1] *x)
                //returns the coeffcienets of the fitted curve
                List<double> p_exp_coeff = exponential_curve_fit(time_maximas, selected_data_set_maximas);

                double damp_ratio_exp = 0;
                //using DFT frequency
                if (use_DFT_or_peaks_combobox.SelectedIndex == 0)
                {
                    damp_ratio_exp = Math.Abs(p_exp_coeff[1] / (2 * Math.PI * natural_frequencies[data_direction_index]));
                }
                //using peaks frequncy
                else
                {
                    damp_ratio_exp = Math.Abs(p_exp_coeff[1] / (2 * Math.PI * average_natural_frequency_peaks));
                }

                List<double> exp_curve_fit_values = plot_fitted_exponential_curve(p_exp_coeff[0], p_exp_coeff[1], selected_data_set_names[data_direction_index]);

                double coffecient_of_determination = calculate_coffecient_of_determination(peak_amplitudes, exp_curve_fit_values, local_maximas);

                results_summary_text = results_summary_text + "The natural frequency of the " + selected_data_set_names[data_direction_index] + " direction data set was calculated using 2 methods:\r\n";
                results_summary_text = results_summary_text + "DFT: " + Math.Round(natural_frequencies[data_direction_index], 6) + " Hz. \r\n";
                results_summary_text = results_summary_text + "Peaks: " + Math.Round(peak_freqs[data_direction_index], 6) + " Hz. \r\n\r\n";
                if (data_direction_index > 2)
                {
                    results_summary_text = results_summary_text + "Note that the vector sum freqs. were calculated using the average of the 2 component freqs.\r\n\r\n";
                }
                results_summary_text = results_summary_text + "The damping ratio of the " + selected_data_set_names[data_direction_index] + " direction data set was calculated using 2 methods:\r\n";
                results_summary_text = results_summary_text + "Log. Decrement: " + Math.Round(damp_ratio_average * 100, 3) + "%\r\n";
                //using DFT frequency
                if (use_DFT_or_peaks_combobox.SelectedIndex == 0)
                {
                    results_summary_text = results_summary_text + "Exp. Curve Fit (using DFT freq.): " + Math.Round(damp_ratio_exp * 100, 3) + "%\r\n\r\n";
                }
                //using peaks frequncy
                else
                {
                    results_summary_text = results_summary_text + "Exp. Curve Fit (using Peaks freq.): " + Math.Round(damp_ratio_exp * 100, 3) + "%\r\n\r\n";
                }
                results_summary_text = results_summary_text + "The R Squared value of the exp. curve fit is (" + selected_data_set_names[data_direction_index] + " direction): " + Math.Round(coffecient_of_determination, 3) + "\r\n\r\n";

                //summary_results_textbox.Text = summary_results_textbox.Text + results_summary_text;
            }
            summary_results_textbox.Text = results_summary_text;

            dataset_result_summary_text_list[select_data_set_tool_strip_combo_box.SelectedIndex] = results_summary_text;
        }

        private void reset_data_trimming_button_Click(object sender, EventArgs e)
        {

            //reset data so filtered data isnt filtered
            is_data_filtered[select_data_set_tool_strip_combo_box.SelectedIndex] = false;

            x_index_trim_lower_index_trimmed[select_data_set_tool_strip_combo_box.SelectedIndex] = 0;
            x_index_trim_upper_index_trimmed[select_data_set_tool_strip_combo_box.SelectedIndex] = 0;

            //load_data_of_selected_dataset_update_charts();

            //clone the master data set
            generic_input_data_double_clone = generic_input_data_double_master;

            //clear any filtered data
            generic_input_data_double_clone_filtered.Clear();

            //plot data on chart
            plot_data_on_chart(data_chart, data_direction_name, generic_input_data_double_clone, "Time (Seconds)", y_axis_label_data_chart);

            //plot the trimming annotations
            draw_vertical_annotations(data_chart, lower_data_boundary_vertical_line, upper_data_boundary_vertical_line, generic_input_data_double_clone[0]);

            check_checked_chart_series();
        }

        private void apply_filter_button_Click(object sender, EventArgs e)
        {
            is_data_filtered[select_data_set_tool_strip_combo_box.SelectedIndex] = true;

            generic_input_data_double_clone_filtered = new List<List<double>>(generic_input_data_double_master);

            //get cutoff freqs
            double low_cutoff_freq = Convert.ToDouble(low_freq_cutoff_numupdown.Value);
            double high_cutoff_freq = Convert.ToDouble(high_freq_cutoff_numupdown.Value);

            //save data to tracker for cutoff freqs
            low_cutoff_freq_tracker[select_data_set_tool_strip_combo_box.SelectedIndex] = low_cutoff_freq;
            high_cutoff_freq_tracker[select_data_set_tool_strip_combo_box.SelectedIndex] = high_cutoff_freq;

            //create filter object
            var bandpass = OnlineFirFilter.CreateBandpass(ImpulseResponse.Finite, input_data_sample_rate, low_cutoff_freq, high_cutoff_freq);
            //var bandpass = OnlineFirFilter.CreateLowpass(ImpulseResponse.Finite, input_data_sample_rate, high_cutoff_freq);

            //filter all datasets using the filter object
            for (int i = 0; i < generic_input_data_double_clone_filtered.Count; i++)
            {
                if (i == 0)
                {
                    if (x_index_trim_upper_index_trimmed[select_data_set_tool_strip_combo_box.SelectedIndex] > 0)
                    {
                        generic_input_data_double_clone_filtered[0] = generic_input_data_double_master[i].GetRange(x_index_trim_lower_index_master[select_data_set_tool_strip_combo_box.SelectedIndex], x_index_trim_upper_index_master[select_data_set_tool_strip_combo_box.SelectedIndex] - x_index_trim_lower_index_master[select_data_set_tool_strip_combo_box.SelectedIndex]);
                    }
                }
                else
                {
                    if (x_index_trim_upper_index_trimmed[select_data_set_tool_strip_combo_box.SelectedIndex] > 0)
                    {
                        generic_input_data_double_clone_filtered[i] = (bandpass.ProcessSamples(convert_double_list_to_array(generic_input_data_double_master[i])).ToList()).GetRange(x_index_trim_lower_index_master[select_data_set_tool_strip_combo_box.SelectedIndex], x_index_trim_upper_index_master[select_data_set_tool_strip_combo_box.SelectedIndex] - x_index_trim_lower_index_master[select_data_set_tool_strip_combo_box.SelectedIndex]);
                    }
                    else
                    {
                        generic_input_data_double_clone_filtered[i] = (bandpass.ProcessSamples(convert_double_list_to_array(generic_input_data_double_master[i])).ToList());
                    }
                }
            }



            //recalulate vector sums after filtering
            if (recalculateVectorSumDataAfterApplyingFilterToolStripMenuItem.Checked == true)
            {
                //remove the existing vector summed data
                generic_input_data_double_clone_filtered.RemoveAt(6);
                generic_input_data_double_clone_filtered.RemoveAt(5);
                generic_input_data_double_clone_filtered.RemoveAt(4);
                //vector sum sets of 2 directions of data and add to main data set
                generic_input_data_double_clone_filtered = vector_sum_xyz_datasets(generic_input_data_double_clone_filtered);
            }

            List<string> data_direction_name_filter = new List<string>();
            foreach (string name in data_direction_name)
            {
                data_direction_name_filter.Add(name + "(Filt.)");
            }


            //replot data
            plot_data_on_chart(data_chart, data_direction_name_filter, generic_input_data_double_clone_filtered, "Time (Seconds)", y_axis_label_data_chart);

            check_checked_chart_series();

            //add data to catalog
            generic_input_data_double_clone_filtered_catalog[select_data_set_tool_strip_combo_box.SelectedIndex] = generic_input_data_double_clone_filtered;

        }

        private void remove_filter_button_Click(object sender, EventArgs e)
        {
            //reset data so filtered data isnt filtered
            is_data_filtered[select_data_set_tool_strip_combo_box.SelectedIndex] = false;

            //replot data
            plot_data_on_chart(data_chart, data_direction_name, generic_input_data_double_clone, "Time (Seconds)", y_axis_label_data_chart);

            check_checked_chart_series();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void select_data_direction_check_list_box_SelectedIndexChanged(object sender, EventArgs e)
        {
            check_checked_chart_series();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void freq_chart_Click(object sender, EventArgs e)
        {

        }



        private void selectInputFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            update_program_after_input_folder_select();
        }

        private void exportResultsSummaryEditedDatasetsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string dataset_result_summary_text_concatenated = concat_dataset_results_summary();

            //check to see if results are ready for export
            if (String.IsNullOrEmpty(dataset_result_summary_text_concatenated))
            {
                return;
            }

            //save the results text
            System.IO.File.WriteAllText(save_results_folder + "Damping Reduction Results Summary" + ".txt", dataset_result_summary_text_concatenated);

            //save all data sets master , trimmed, trimmed filtered using the catalog

            //select all data sets for export
            Boolean export_master = true;
            Boolean export_clone = true;
            Boolean export_filter = true;

            export_acceleration_datasets_csv(export_master, export_clone, export_filter);
        }



        private void select_data_set_tool_strip_combo_box_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            populate_select_data_direction_checked_list();

            //reset data so filtered data isnt filtered
            is_data_filtered[select_data_set_tool_strip_combo_box.SelectedIndex] = false;

            //clear results window
            summary_results_textbox.Text = string.Empty;

            //clear data chart
            data_chart.Series.Clear();

            //clear freq plot
            freq_dft_chart.Series.Clear();
            freq_peaks_chart.Series.Clear();

            //set the current selected filepath to the global variable
            current_selected_dataset_filepath = csv_input_filepaths[select_data_set_tool_strip_combo_box.SelectedIndex];

            if (generic_input_data_double_master_catalog[select_data_set_tool_strip_combo_box.SelectedIndex].Count > 0)
            {
                //load the data from the current session if data has already been loaded
                load_data_of_selected_dataset_existing_session_update_charts();
            }
            else
            {
                //load the sleteced csv and plot (for unloaded data)
                load_data_of_selected_dataset_update_charts();
            }

            check_checked_chart_series();

            //autosave all data sets at the default location in the background
            save_session(false, false, true);
        }

        private void displayResultsSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string dataset_result_summary_text_concatenated = concat_dataset_results_summary();
            if (!String.IsNullOrEmpty(dataset_result_summary_text_concatenated))
            {
                string title = "Results Summary";
                MessageBox.Show(dataset_result_summary_text_concatenated, title);
            }
        }

        private void exportResultsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exportTrimmedDatasetsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //select all data sets for export
            Boolean export_master = false;
            Boolean export_clone = true;
            Boolean export_filter = false;

            export_acceleration_datasets_csv(export_master, export_clone, export_filter);
        }

        private void exportFilteredAndTrimmedDatasetsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //select all data sets for export
            Boolean export_master = false;
            Boolean export_clone = false;
            Boolean export_filter = true;

            export_acceleration_datasets_csv(export_master, export_clone, export_filter);
        }

        private void exportUneditedDatasetsToOutputFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //select all data sets for export
            Boolean export_master = true;
            Boolean export_clone = false;
            Boolean export_filter = false;

            export_acceleration_datasets_csv(export_master, export_clone, export_filter);
        }

        private void importcsvFilesFromOutputFolderWhenSelectingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (importcsvFilesFromOutputFolderWhenSelectingToolStripMenuItem.Checked == true)
            {
                importcsvFilesFromOutputFolderWhenSelectingToolStripMenuItem.Checked = false;
            }
            else
            {
                importcsvFilesFromOutputFolderWhenSelectingToolStripMenuItem.Checked = true;
            }
        }

        private void recalculateVectorSumDataAfterApplyingFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (recalculateVectorSumDataAfterApplyingFilterToolStripMenuItem.Checked == true)
            {
                recalculateVectorSumDataAfterApplyingFilterToolStripMenuItem.Checked = false;
            }
            else
            {
                recalculateVectorSumDataAfterApplyingFilterToolStripMenuItem.Checked = true;
            }
        }

        private void saveSessionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            save_session(true, true, false);

            //    if (check_if_list_list_double_is_empty(generic_input_data_double_master_catalog) && check_if_list_list_double_is_empty(generic_input_data_double_clone_catalog) && check_if_list_list_double_is_empty(generic_input_data_double_clone_filtered_catalog))
            //    {
            //        string message = "There is no data loaded into the current session";
            //        string title = "Error";
            //        MessageBox.Show(message, title);
            //        return;
            //    }

            //    //create session object (drs = damping reduction session)
            //    damping_reduction_session drs = new damping_reduction_session();
            //    drs.generic_input_data_double_master_catalog_drs = generic_input_data_double_master_catalog;
            //    drs.generic_input_data_double_clone_catalog_drs = generic_input_data_double_clone_catalog;
            //    drs.generic_input_data_double_clone_filtered_catalog_drs = generic_input_data_double_clone_filtered_catalog;
            //    drs.csv_input_filepaths_drs = csv_input_filepaths;
            //    drs.csv_input_filepaths_short_drs = csv_input_filepaths_short;
            //    drs.low_cutoff_freq_tracker_drs = low_cutoff_freq_tracker;
            //    drs.high_cutoff_freq_tracker_drs = high_cutoff_freq_tracker;
            //    drs.is_data_filtered_drs = is_data_filtered;
            //    drs.dataset_result_summary_text_list_drs = dataset_result_summary_text_list;
            //    drs.x_index_trim_lower_index_trimmed_drs = x_index_trim_lower_index_trimmed;
            //    drs.x_index_trim_upper_index_trimmed_drs = x_index_trim_upper_index_trimmed;
            //    drs.x_index_trim_lower_index_master_drs = x_index_trim_lower_index_master;
            //    drs.x_index_trim_upper_index_master_drs = x_index_trim_upper_index_master;


            ////get default session file name (using the last folder in the input folder filepath and append the filetype extension
            //string input_folder_wo_filepath = input_folder;
            //    if (input_folder_wo_filepath.LastIndexOf(@"\") == input_folder_wo_filepath.Length - 1)
            //    {
            //        input_folder_wo_filepath = input_folder.Remove(input_folder.Length - 1);
            //    }
            //    int index = input_folder_wo_filepath.LastIndexOf(@"\") + 1;
            //    int lng = (input_folder_wo_filepath.Length) - index;
            //    input_folder_wo_filepath = input_folder_wo_filepath.Substring(index, lng);
            //    string default_file_name = input_folder_wo_filepath + "-Damping Reduction Session" + save_session_filetype;

            //    //make user save file using file explorer
            //    SaveFileDialog save_session_file_dialog = new SaveFileDialog();
            //    save_session_file_dialog.Filter = "Damping Reduction Data Sets(" + save_session_filetype + ")| *" + save_session_filetype;
            //    save_session_file_dialog.Title = "Save Damping Reduction Session";
            //    save_session_file_dialog.InitialDirectory = input_folder + output_folder_name;
            //    save_session_file_dialog.FileName = default_file_name;
            //    save_session_file_dialog.ShowDialog();

            //    // If the file name is not an empty string open it for saving.
            //    if (!String.IsNullOrEmpty(save_session_file_dialog.FileName))
            //    {
            //        File.WriteAllText(save_session_file_dialog.FileName, JsonConvert.SerializeObject(drs));

            //    }
            //    else
            //    {
            //        string message = "The filepath/name was invalid and could not be saved";
            //        string title = "Error";
            //        MessageBox.Show(message, title);
            //        return;
            //    }
        }

        private void loadSessionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //make user open file using file explorer
            OpenFileDialog load_session_file_dialog = new OpenFileDialog();
            load_session_file_dialog.Filter = "Damping Reduction Data Sets(" + save_session_filetype + ")|*" + save_session_filetype;
            load_session_file_dialog.Title = "Load Damping Reduction Session";
            //load_session_file_dialog.InitialDirectory = input_folder + output_folder_name;
            load_session_file_dialog.CheckFileExists = true;
            load_session_file_dialog.ShowDialog();


            //clear all lists
            generic_input_data_double_master_catalog.Clear();
            generic_input_data_double_clone_catalog.Clear();
            generic_input_data_double_clone_filtered_catalog.Clear();

            csv_input_filepaths.Clear();
            csv_input_filepaths_short.Clear();

            low_cutoff_freq_tracker.Clear();
            high_cutoff_freq_tracker.Clear();



            string session_load_filepath = load_session_file_dialog.FileName;

            // If the file name is not an empty string open it for saving.
            if (!String.IsNullOrEmpty(session_load_filepath))
            {
                damping_reduction_session drs = JsonConvert.DeserializeObject<damping_reduction_session>(File.ReadAllText(session_load_filepath));

                //store datasets
                generic_input_data_double_master_catalog = drs.generic_input_data_double_master_catalog_drs;
                generic_input_data_double_clone_catalog = drs.generic_input_data_double_clone_catalog_drs;
                generic_input_data_double_clone_filtered_catalog = drs.generic_input_data_double_clone_filtered_catalog_drs;

                csv_input_filepaths = drs.csv_input_filepaths_drs;
                csv_input_filepaths_short = drs.csv_input_filepaths_short_drs;

                low_cutoff_freq_tracker = drs.low_cutoff_freq_tracker_drs;
                high_cutoff_freq_tracker = drs.high_cutoff_freq_tracker_drs;

                is_data_filtered = drs.is_data_filtered_drs;
                dataset_result_summary_text_list = drs.dataset_result_summary_text_list_drs;

                x_index_trim_lower_index_trimmed = drs.x_index_trim_lower_index_trimmed_drs;
                x_index_trim_upper_index_trimmed = drs.x_index_trim_upper_index_trimmed_drs;
                x_index_trim_lower_index_master = drs.x_index_trim_lower_index_master_drs;
                x_index_trim_upper_index_master = drs.x_index_trim_upper_index_master_drs;

                input_folder = drs.input_folder_drs;

                update_program_after_load_session();
            }
            else
            {
                string message = "The filepath/name was invalid and could not be loaded";
                string title = "Error";
                MessageBox.Show(message, title);
                return;
            }
        }


        private void freq_dft_chart_AxisViewChanged_1(object sender, ViewEventArgs e)
        {

        }

        private void upper_freq_plot_cutoff_numupdown_ValueChanged(object sender, EventArgs e)
        {
            plot_freq_response(freq_span, real_spectrum, data_direction_name);
        }

        private void lower_freq_plot_cutoff_numupdown_ValueChanged(object sender, EventArgs e)
        {
            plot_freq_response(freq_span, real_spectrum, data_direction_name);
        }

        private void linear_or_log_combobox_DropDownClosed(object sender, EventArgs e)
        {
            //change
            try
            {
                if (linear_or_log_combobox.SelectedIndex == 1)
                {
                    freq_dft_chart.ChartAreas[0].AxisY.IsLogarithmic = true;
                }
                else
                {
                    freq_dft_chart.ChartAreas[0].AxisY.IsLogarithmic = false;
                }
            }
            catch
            {

            }
        }
    }


    [Serializable]
    public class damping_reduction_session
    {
        //store datasets
        public List<List<List<double>>> generic_input_data_double_master_catalog_drs = new List<List<List<double>>>();
        public List<List<List<double>>> generic_input_data_double_clone_catalog_drs = new List<List<List<double>>>();
        public List<List<List<double>>> generic_input_data_double_clone_filtered_catalog_drs = new List<List<List<double>>>();

        //stores all csv filepath found in the slected input folder
        public List<string> csv_input_filepaths_drs = new List<string>();
        //stores all csv filepath found in the slected input folder (in short form for readability)
        public List<string> csv_input_filepaths_short_drs = new List<string>();

        //keep track of what cutoff frequencies are used
        public List<double> low_cutoff_freq_tracker_drs = new List<double>();
        public List<double> high_cutoff_freq_tracker_drs = new List<double>();

        public List<Boolean> is_data_filtered_drs = new List<Boolean>();

        public List<string> dataset_result_summary_text_list_drs = new List<string>();

        //holds the values where the annotation will be placed
        public List<int> x_index_trim_lower_index_trimmed_drs = new List<int>();
        public List<int> x_index_trim_upper_index_trimmed_drs = new List<int>();

        //holds the values where the annotation is placed relative to the original time dataset (not trimmed)
        //useful when applying a filter to a dataset that has been trimmed twice
        public List<int> x_index_trim_lower_index_master_drs = new List<int>();
        public List<int> x_index_trim_upper_index_master_drs = new List<int>();

        public string input_folder_drs = string.Empty;
    }


}
