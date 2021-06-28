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

        //folder picked by user with all input data
        string input_folder = string.Empty;

        //stores all csv filepath found in the slected input folder
        List<string> csv_input_filepaths = new List<string>();
        //stores all csv filepath found in the slected input folder (in short form for readability)
        List<string> csv_input_filepaths_short = new List<string>();

        double input_data_sample_rate = 1024;

        List<string> data_direction_name = new List<string>();

        string results_summary_text = string.Empty;

        Boolean is_data_filtered = false;

        int x_index_trim_lower_index = 0;
        int x_index_trim_upper_index = 0;

        string y_axis_label_data_chart = @"Acceleration [m/s^2]";

        List<string> dataset_result_summary_text_list = new List<string>();

        int current_selected_csv_checkedlistbox_index = 0;


        public form1()
        {
            InitializeComponent();

  
        }

        //generic program functions

        public double calculate_coffecient_of_determination(List<double> sample_data, List<double> fitted_data_full, List<int> index_of_sample_data)
        {
            double coffecient_of_determination = 0;
            //total sum of squares
            double ss_tot = 0;
            //residual sum of squares
            double ss_res = 0;

            double sample_average = sample_data.Average();
            for(int i =0; i< sample_data.Count; i++)
            {
                ss_tot += Math.Pow((sample_data[i] - sample_average), 2);

                ss_res += Math.Pow((sample_data[i]- fitted_data_full[index_of_sample_data[i]]), 2);
            }

            coffecient_of_determination = 1 - ss_res / ss_tot;
            return coffecient_of_determination;
        }

        public string get_filename_from_filepath (string filepath)
        {
            int slash_index = filepath.LastIndexOf(@"\");
            int dot_index = filepath.LastIndexOf(@".");

            //remove filepath and filetype and keep raw filename
            string filename = filepath.Substring(slash_index+1, dot_index- slash_index-1);

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
        }

        public List<List<string>> transpose_list_of_list_string (List<List<string>> data)
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

        public void plot_freq_peaks_response(List<int> time_peaks, List<double> frequency_peaks, string series_name)
        {
            System.Windows.Forms.DataVisualization.Charting.Series series = freq_peaks_chart.Series.Add(series_name + " Freq. Resp.");
            series.ChartType = SeriesChartType.Point;
            series.Points.DataBindXY(time_peaks, frequency_peaks);
            series.BorderWidth = 1;


            freq_peaks_chart.ChartAreas[0].AxisX.Title = "Freq. Calc. #";
            freq_peaks_chart.ChartAreas[0].AxisY.Title = "Frequency (Hz)";

            //rescale y axis
            freq_peaks_chart.ChartAreas[0].AxisY.IsStartedFromZero = false;

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
            double plot_cuttoff_freq = Convert.ToDouble(freq_plot_cutoff_numupdown.Value);



            //cycle through and grab trimmed value
            for (int list_index = 0; list_index < freq_span.Count; list_index++)
            {
                //temp lists
                List<double> freq_temp = new List<double>();
                List<double> mag_temp = new List<double>();

                for (int i = 0; i < freq_span[list_index].Count; i++)
                {
                    freq_temp.Add(freq_span[list_index][i]);
                    mag_temp.Add(real_spectrum[list_index][i]);

                    if (freq_span[list_index][i] > plot_cuttoff_freq)
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

            List<List<double>> real_spectrum = new List<List<double>>();
            List<List<double>> freq_span = new List<List<double>>();

            for (int list_index = 0; list_index < signal_data.Count; list_index++)
            {
                // Instantiate a new DFT
                DFT dft = new DFT();

                // Initialize the DFT
                // You only need to do this once or if you change any of the DFT parameters.
                dft.Initialize(Convert.ToUInt32(signal_data[list_index].Count));

                // Call the DFT and get the scaled spectrum back
                Complex[] complex_spectrum = dft.Execute(convert_double_list_to_array(signal_data[list_index]));

                // Convert the complex spectrum to magnitude
                real_spectrum.Add(DSP.ConvertComplex.ToMagnitude(complex_spectrum).ToList());

                // contains a properly scaled Spectrum from 0 - 50,000 Hz (1/2 the Sampling Frequency)

                // For plotting on an XY Scatter plot, generate the X Axis frequency Span
                freq_span.Add(dft.FrequencySpan(input_data_sample_rate).ToList());

                //remove first entry of 0Hz
                real_spectrum[list_index].RemoveAt(0);
                freq_span[list_index].RemoveAt(0);

                natural_frequncy.Add(freq_span[list_index][real_spectrum[list_index].IndexOf(real_spectrum[list_index].Max())]);
            }

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
                    sampled_data.Add(data_sets[list_index][i]);

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
            List<List<double>> temp_list = new List<List<double>>();
            foreach (List<double> data in generic_input_data_double_clone)
            {
                temp_list.Add(data.GetRange(lower_boundary_index, upper_boundary_index - lower_boundary_index));
            }
            generic_input_data_double_clone = temp_list;
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

            //plot data on chart
            plot_data_on_chart(data_chart, data_direction_name, generic_input_data_double_clone, "Time (Seconds)", y_axis_label_data_chart);

            //plot the trimming annotations
            draw_vertical_annotations(data_chart, lower_data_boundary_vertical_line, upper_data_boundary_vertical_line, generic_input_data_double_clone[0]);

        }

        public void update_program_after_input_folder_select()
        {
            //clear select data set combobox
            select_data_set_tool_strip_combo_box.Items.Clear();

            //clear results textbox
            summary_results_textbox.Clear();

            //clear all saved summaries
            dataset_result_summary_text_list.Clear();

            //open windows explorer to retrieve user folder
            select_folder(out input_folder);

            if (input_folder == string.Empty)
            {
                return;
            }
            input_folder = input_folder + @"\";

            //set selected input folder textbox to user selected folder
            input_folder_textbox.Text = input_folder;

            //get all dataset files (within user folder) and save to a list
            csv_input_filepaths = (Directory.GetFiles(input_folder, "*.csv", System.IO.SearchOption.AllDirectories)).ToList();

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

        public void trim_data_function ()
        {
            double x_index_trim_lower = 0;
            double x_index_trim_upper = 0;

            //get boundary values from vertical annotations
            if (upper_data_boundary_vertical_line.X > lower_data_boundary_vertical_line.X)
            {
                //x_index_trim_lower = Convert.ToInt32(lower_data_boundary_vertical_line.X);
                //x_index_trim_upper = Convert.ToInt32(upper_data_boundary_vertical_line.X) ;                
                x_index_trim_lower = lower_data_boundary_vertical_line.X;
                x_index_trim_upper = upper_data_boundary_vertical_line.X;
            }
            else
            {
                //x_index_trim_upper = Convert.ToInt32(lower_data_boundary_vertical_line.X) ;
                //x_index_trim_lower = Convert.ToInt32(upper_data_boundary_vertical_line.X) ;
                x_index_trim_upper = lower_data_boundary_vertical_line.X;
                x_index_trim_lower = upper_data_boundary_vertical_line.X;
            }

            //int x_index_trim_lower_index = generic_input_data_double_clone[0].IndexOf(x_index_trim_lower);
            //int x_index_trim_upper_index = generic_input_data_double_clone[0].IndexOf(x_index_trim_upper);

            x_index_trim_lower_index = find_closest_value(x_index_trim_lower, generic_input_data_double_clone[0]);
            x_index_trim_upper_index = find_closest_value(x_index_trim_upper, generic_input_data_double_clone[0]);

            if (Math.Abs(x_index_trim_upper_index - x_index_trim_lower_index) < 15)
            {
                string message = "Cannot trim data to less than 15 data points";
                string title = "Error";
                MessageBox.Show(message, title);
                return;
            }

            update_trimmed_input_data(x_index_trim_lower_index, x_index_trim_upper_index);

            plot_data_on_chart(data_chart, data_direction_name, generic_input_data_double_clone, "Time (Seconds)", y_axis_label_data_chart);
            draw_vertical_annotations(data_chart, lower_data_boundary_vertical_line, upper_data_boundary_vertical_line, generic_input_data_double_clone[0]);

            check_checked_chart_series();
        }

        public List<double>  plot_fitted_exponential_curve(double A, double k, string dataset_name)
        {
            List<double> exp_curve_values = new List<double>();

            for (int i =0; i< generic_input_data_double_clone[0].Count; i++)
            {
                exp_curve_values.Add(A * Math.Exp(k * generic_input_data_double_clone[0][i]));
            }

            string series_name = dataset_name+" Exp. Fit";

            //plot with settings
            try
            {
                System.Windows.Forms.DataVisualization.Charting.Series series = data_chart.Series.Add(series_name);
                data_chart.Series[series_name].Points.Clear();
                series.ChartType = SeriesChartType.Line;
                series.Color = Color.DarkRed;
                series.Points.DataBindXY(generic_input_data_double_clone[0], exp_curve_values);
                series.BorderWidth = 2;
            }
            catch
            {
                data_chart.Series[series_name].Points.Clear();
                data_chart.Series[series_name].ChartType = SeriesChartType.Line;
                data_chart.Series[series_name].Color = Color.DarkRed;
                data_chart.Series[series_name].Points.DataBindXY(generic_input_data_double_clone[0], exp_curve_values);
                data_chart.Series[series_name].BorderWidth = 2;
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
            for(int i =0; i< peak_indexs.Count-1; i++)
            {
                    peak_times.Add(generic_input_data_double_clone_filtered[0][peak_indexs[i]]);
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
            }
            catch
            {
                data_chart.Series[series_name].Points.Clear();
                data_chart.Series[series_name].ChartType = SeriesChartType.Point;
                data_chart.Series[series_name].Color = Color.Red;
                data_chart.Series[series_name].Points.DataBindXY(peak_times, peak_amplitudes);
                data_chart.Series[series_name].BorderWidth = 3;
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
            }

            chart_name.ChartAreas[0].AxisX.Title = x_axis_label;
            chart_name.ChartAreas[0].AxisY.Title = y_axis_label;

            chart_name.ChartAreas[0].AxisX.LabelStyle.Format = "0.00";
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

            //clear summary text
            results_summary_text = string.Empty;
            //empty the results box
            summary_results_textbox.Text = string.Empty;
            // clear the freq plot
            freq_peaks_chart.Series.Clear();

            List<List<double>> selected_data_sets = new List<List<double>>();
            List<string> selected_data_set_names = new List<string>();

            //get cutoff freqs
            double low_cutoff_freq = Convert.ToDouble(low_freq_cutoff_numupdown.Value);
            double high_cutoff_freq = Convert.ToDouble(high_freq_cutoff_numupdown.Value);

            //get timestamps of trimmed data
            double first_timestamp = Math.Round(generic_input_data_double_clone[0][0], 1);
            double second_timestamp = Math.Round(generic_input_data_double_clone[0][generic_input_data_double_clone[0].Count - 1], 1);

            //set header for text file
            results_summary_text = "/////////////////////////////////////////////////////////////////////////////\r\n";
            results_summary_text = results_summary_text + csv_input_filepaths_short[current_selected_csv_checkedlistbox_index] + "\r\n";
            results_summary_text = results_summary_text + "/////////////////////////////////////////////////////////////////////////////\r\n";
            results_summary_text = results_summary_text + "Trimmed from " +first_timestamp+" seconds to "+ second_timestamp + " seconds.\r\n";
            if (is_data_filtered==true) 
            {
                results_summary_text = results_summary_text + "The data sets were bandpass filtered with cutoff frequencies of " + low_cutoff_freq + " Hz and " + high_cutoff_freq + " Hz.\r\n";
            }

            //determine which data directions are currently selected add them to a list to be freq analyzed
            for (int data_direction_index = 0; data_direction_index < select_data_direction_check_list_box.Items.Count; data_direction_index++)
            {
                if (select_data_direction_check_list_box.GetItemCheckState(data_direction_index) == CheckState.Checked)
                {
                    selected_data_set_names.Add(data_direction_name[data_direction_index]);

                    if (is_data_filtered == true)
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

                int window_size = Convert.ToInt32(Math.Round((natural_frequencies[data_direction_index] * input_data_sample_rate * 0.95) / 2));
                List<int> local_maximas = find_local_maximas(selected_data_set_abs, window_size);


                List<double> peak_amplitudes = plot_peaks_chart(local_maximas, selected_data_set_abs, selected_data_set_names[data_direction_index]+ " Peaks");
            

                List<double> natural_frequncy_peaks = calculate_natural_frequency_peaks(local_maximas, input_data_sample_rate, selected_data_set_names[data_direction_index]);
                double average_natural_frequency_peaks = natural_frequncy_peaks.Average();

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
                double damp_ratio_exp = Math.Abs(p_exp_coeff[1] / (2 * Math.PI * natural_frequencies[data_direction_index]));

                List<double> exp_curve_fit_values = plot_fitted_exponential_curve(p_exp_coeff[0], p_exp_coeff[1], selected_data_set_names[data_direction_index]);

                double coffecient_of_determination = calculate_coffecient_of_determination(peak_amplitudes, exp_curve_fit_values, local_maximas);

                results_summary_text = results_summary_text + "The natural frequency of the " + selected_data_set_names[data_direction_index] + " direction data set was calculated using 2 methods:\r\n";
                results_summary_text = results_summary_text + "DFT: " + Math.Round(natural_frequencies[data_direction_index], 6) + " Hz. \r\n";
                results_summary_text = results_summary_text + "Peaks: " + Math.Round(average_natural_frequency_peaks, 6) + " Hz. \r\n";
                results_summary_text = results_summary_text + "The damping ratio of the " + selected_data_set_names[data_direction_index] + " direction data set was calculated using 2 methods:\r\n";
                results_summary_text = results_summary_text + "Log. Decrement: " + Math.Round(damp_ratio_average * 100, 3) + "%\r\n";
                results_summary_text = results_summary_text + "Exp. Curve Fit: " + Math.Round(damp_ratio_exp * 100, 3) + "%\r\n";
                results_summary_text = results_summary_text + "The R Sqaured value was found as: " + Math.Round(coffecient_of_determination, 3) + "\r\n\r\n";

                //summary_results_textbox.Text = summary_results_textbox.Text + results_summary_text;
            }
            summary_results_textbox.Text = results_summary_text;

            dataset_result_summary_text_list[select_data_set_tool_strip_combo_box.SelectedIndex] = results_summary_text;
        }

        private void reset_data_trimming_button_Click(object sender, EventArgs e)
        {
            //reset data so filtered data isnt filtered
            is_data_filtered = false;

            x_index_trim_lower_index = 0;
            x_index_trim_upper_index = 0;

            load_data_of_selected_dataset_update_charts();

            check_checked_chart_series();
        }

        private void apply_filter_button_Click(object sender, EventArgs e)
        {
            is_data_filtered = true;

            generic_input_data_double_clone_filtered = new List<List<double>>(generic_input_data_double_master);

            //get cutoff freqs
            double low_cutoff_freq = Convert.ToDouble(low_freq_cutoff_numupdown.Value);
            double high_cutoff_freq = Convert.ToDouble(high_freq_cutoff_numupdown.Value);

            //create filter object
            var bandpass = OnlineFirFilter.CreateBandpass(ImpulseResponse.Finite, input_data_sample_rate, low_cutoff_freq, high_cutoff_freq);
            //var bandpass = OnlineFirFilter.CreateLowpass(ImpulseResponse.Finite, input_data_sample_rate, high_cutoff_freq);

            //filter all datasets using the filter object
            for (int i = 0; i < generic_input_data_double_clone_filtered.Count; i++)
            {
                if (i == 0)
                {
                    if (x_index_trim_upper_index > 0)
                    {
                        generic_input_data_double_clone_filtered[0] = generic_input_data_double_master[i].GetRange(x_index_trim_lower_index, x_index_trim_upper_index - x_index_trim_lower_index);
                    }
                }
                else
                {
                    if (x_index_trim_upper_index > 0)
                    {
                        generic_input_data_double_clone_filtered[i] = (bandpass.ProcessSamples(convert_double_list_to_array(generic_input_data_double_master[i])).ToList()).GetRange(x_index_trim_lower_index, x_index_trim_upper_index - x_index_trim_lower_index);
                    }
                    else
                    {
                        generic_input_data_double_clone_filtered[i] = (bandpass.ProcessSamples(convert_double_list_to_array(generic_input_data_double_master[i])).ToList());
                    }
                }
            }


            //replot data
            plot_data_on_chart(data_chart, data_direction_name, generic_input_data_double_clone_filtered, "Time (Seconds)", y_axis_label_data_chart);

            check_checked_chart_series();

        }

        private void remove_filter_button_Click(object sender, EventArgs e)
        {
            //reset data so filtered data isnt filtered
            is_data_filtered = false;

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

        private void clearSessionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            this.InitializeComponent();
            clear_all_global_variables();
        }

        private void exportResultsSummaryEditedDatasetsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string dataset_result_summary_text_concatenated = string.Empty;

            for (int i = 0; i < dataset_result_summary_text_list.Count; i++)
            {
                dataset_result_summary_text_concatenated = dataset_result_summary_text_concatenated + dataset_result_summary_text_list[i];
            }

            //check if there is no results
            if (String.IsNullOrEmpty(dataset_result_summary_text_concatenated))
            {
                string message = "There are no results to export. The results are generated after clicking -" + calculate_damp_ratio_and_freq_button.Text+ "- Button";
                string title = "Error";
                MessageBox.Show(message, title);
                return;
            }

            string save_results_folder = string.Empty;

            //open windows explorer to retrieve the save folder folder
            select_folder(out save_results_folder);

            if (save_results_folder == string.Empty)
            {
                return;
            }
            save_results_folder = save_results_folder + @"\";

            //save the results text
            System.IO.File.WriteAllText(save_results_folder + "Damping Data Results Summary" + ".txt", dataset_result_summary_text_concatenated);

            //save all data sets master , trimmed, trimmed filtered

            //create header for data exports
            List<string> header = new List<string>();
            header.Add("Time (Seconds)");
            header.Add("X " + y_axis_label_data_chart);
            header.Add("Y " + y_axis_label_data_chart);
            header.Add("Z " + y_axis_label_data_chart);
            header.Add("XY VS" + y_axis_label_data_chart);
            header.Add("XZ VS" + y_axis_label_data_chart);
            header.Add("YZ VS" + y_axis_label_data_chart);

            //CONVERT DATA SETS TO STRINGS
            List<List<string>> csv_data_master = convert_list_of_list_double_to_string(generic_input_data_double_master);
            List<List<string>> csv_data_clone = convert_list_of_list_double_to_string(generic_input_data_double_clone);
            List<List<string>> csv_data_clone_filter = convert_list_of_list_double_to_string(generic_input_data_double_clone_filtered);

            //add headers to data sets
            for(int i= 0; i< header.Count; i++)
            {
                csv_data_master[i].Insert(0, header[i]);
                csv_data_clone[i].Insert(0, header[i]);
                if (is_data_filtered == true)
                {
                    csv_data_clone_filter[i].Insert(0, header[i]);
                }
            }

            csv_data_master = transpose_list_of_list_string(csv_data_master);
            csv_data_clone = transpose_list_of_list_string(csv_data_clone);
            if (is_data_filtered == true)
            {
                csv_data_clone_filter = transpose_list_of_list_string(csv_data_clone_filter);
            }

            //get cutoff freqs
            double low_cutoff_freq = Convert.ToDouble(low_freq_cutoff_numupdown.Value);
            double high_cutoff_freq = Convert.ToDouble(high_freq_cutoff_numupdown.Value);

            //get timestamps of trimmed data
            double first_timestamp = Math.Round(generic_input_data_double_clone[0][0],1);
            double second_timestamp = Math.Round(generic_input_data_double_clone[0][generic_input_data_double_clone[0].Count-1],1);

            string dataset_name = get_filename_from_filepath(csv_input_filepaths_short[select_data_set_tool_strip_combo_box.SelectedIndex]);
            string dataset_name_trimmed = dataset_name +"["+ first_timestamp+"s - "+ second_timestamp+"s]";
            string dataset_name_trimmed_filtered = dataset_name_trimmed +"["+ low_cutoff_freq+ "Hz - " + high_cutoff_freq +"Hz]";

            //save the files at their filepath
            save_list_of_list_string_as_csv(csv_data_master, save_results_folder + "Acceleration Datasets " + dataset_name + " [Unedited].csv");
            save_list_of_list_string_as_csv(csv_data_clone, save_results_folder + "Acceleration Datasets " + dataset_name_trimmed + " [Trimmed].csv");
            if (is_data_filtered == true)
            {
                save_list_of_list_string_as_csv(csv_data_clone_filter, save_results_folder + "Acceleration Datasets " + dataset_name_trimmed_filtered + " [Trimmed & Filtered].csv");
            }

        }

        private void select_data_set_tool_strip_combo_box_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            populate_select_data_direction_checked_list();

            //reset data so filtered data isnt filtered
            is_data_filtered = false;

            //clear results window
            summary_results_textbox.Text = string.Empty;

            //clear freq plot
            freq_dft_chart.Series.Clear();
            freq_peaks_chart.Series.Clear();

            //set the current selected filepath to the global variable
            current_selected_dataset_filepath = csv_input_filepaths[select_data_set_tool_strip_combo_box.SelectedIndex];

            //set textbox to display the current selected data set
            selected_data_set_textbox.Text = csv_input_filepaths_short[select_data_set_tool_strip_combo_box.SelectedIndex];

            //load the sleteced csv and plot
            load_data_of_selected_dataset_update_charts();

            check_checked_chart_series();
        }
    }
}
