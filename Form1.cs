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
using MathNet.Numerics.LinearRegression;
using MathNet.Numerics;
using DSPLib;
using Newtonsoft.Json;
using MathNet.Filtering;
using System.Threading;
using JR.Utils.GUI.Forms;
using ClosedXML.Report;
using ClosedXML;




namespace Damping_Data_Processor
{


    public partial class form1 : Form
    {

        //GLOBAL VARIABLES

        //this class variable stores all current info for the current selected dataset
        public damping_reduction_dataset drd = new damping_reduction_dataset();

        //allocate vertical annotation
        VerticalLineAnnotation lower_data_boundary_vertical_line = new VerticalLineAnnotation();
        VerticalLineAnnotation upper_data_boundary_vertical_line = new VerticalLineAnnotation();

        VerticalLineAnnotation freq_peaks_trim_vertical_line_1 = new VerticalLineAnnotation();
        VerticalLineAnnotation freq_peaks_trim_vertical_line_2 = new VerticalLineAnnotation();
        HorizontalLineAnnotation freq_peaks_trim_horizontal_line_1 = new HorizontalLineAnnotation();
        HorizontalLineAnnotation freq_peaks_trim_horizontal_line_2 = new HorizontalLineAnnotation();

        string current_selected_dataset_filepath = string.Empty;

        //pixel width of charts, used to samplke data for plotting
        int chart_width = 1389;

        //variables that holds the freq response of for all direction for the current csv
        List<List<double>> real_spectrum = new List<List<double>>();
        List<List<double>> freq_span = new List<List<double>>();



        //folder picked by user with all input data
        string input_folder = string.Empty;

        //stores all csv filepath found in the slected input folder
        List<string> dataset_input_filepaths = new List<string>();
        //stores all csv filepath found in the slected input folder (in short form for readability)
        List<string> dataset_input_filepaths_short = new List<string>();

        //holds the header when exportimng data
        List<string> acceleration_dataset_csv_header = new List<string>();

        //sample rate of input data
        double input_data_sample_rate = 1024;

        //List that holds data direction names
        List<string> data_direction_name = new List<string>();

        //hold the text of the results for the current csv
        string results_summary_text = string.Empty;

        //y label of data chart
        string y_axis_label_data_chart = "Acceleration (m/s^2)";

        List<string> dataset_result_summary_text_list = new List<string>();

        int current_selected_csv_checkedlistbox_index = 0;

        string save_results_folder = string.Empty;

        string output_folder_name = @"Damping Reduction Output\";

        string damping_reduction_data_object_storage_folder = @"Damping Datset Object Data Storage\";

        //the file extension (custom to this software) (damping reduction data sets)
        string dataset_object_file_extension = ".json";

        //stores all peak freq estimations for miltiple data directions (used for trimming)
        //List<List<double>> peak_amplitudes_storage = new List<List<double>>();
        //List<List<double>> freq_peaks_storage = new List<List<double>>();
        //List<List<int>> local_maximas_indexs_storage = new List<List<int>>();
        //List<List<double>> local_maximas_time_values_storage = new List<List<double>>();


        //colors for plotting
        List<Color> peak_point_colors = new List<Color>();
        List<Color> exp_curve_colors = new List<Color>();
        List<Color> signal_colors = new List<Color>();

        //keeps track of all calculated results for session
        List<List<List<double>>> session_results_tracker = new List<List<List<double>>>();

        string header_border = "/////////////////////////////////////////////////////////////////////////////////////////////////////////\r\n";




        public form1()
        {


            //dataset_result_row test1 = new dataset_result_row();
            //test1.val1 = "data1";
            //test1.val2 = "data2";
            //test1.val3 = "data3";

            //dataset_result_row test2 = new dataset_result_row();
            //test1.val1 = "data4";
            //test1.val2 = "data5";
            //test1.val3 = "data6";

            //datasets_result_object dataset_object = new datasets_result_object();
            //dataset_object.dataset_result_rows.Add(test1);
            //dataset_object.dataset_result_rows.Add(test2);

            //List<string> test4 = new List<string>();
            //test4.Add( "data1");
            //test4.Add( "data2");
            //test4.Add( "data3");


            ////test
            //string filepath_test = @"C:\Users\aanderson\OneDrive - Varcon Inc\Documents\Projects\Damping Data Processor\ClosedXML\closedXMLtest.xlsx";
            //string filepath_test1 = @"C:\Users\aanderson\OneDrive - Varcon Inc\Documents\Projects\Damping Data Processor\ClosedXML\closedXMLtest1.xlsx";
            //var template = new XLTemplate(filepath_test);

            //template.AddVariable("val1", test4); 

            //template.Generate();

            //template.SaveAs(filepath_test1);
            ////Process.Start(new ProcessStartInfo(filepath_test1) { UseShellExecute = true });



            InitializeComponent();
            //scaling the app view
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;

            acceleration_dataset_csv_header.Add("Time (Seconds)");
            acceleration_dataset_csv_header.Add("X " + y_axis_label_data_chart);
            acceleration_dataset_csv_header.Add("Y " + y_axis_label_data_chart);
            acceleration_dataset_csv_header.Add("Z " + y_axis_label_data_chart);
            acceleration_dataset_csv_header.Add("XY_VS" + y_axis_label_data_chart);
            acceleration_dataset_csv_header.Add("XZ_VS" + y_axis_label_data_chart);
            acceleration_dataset_csv_header.Add("YZ_VS" + y_axis_label_data_chart);

            peak_picking_method_combobox.Items.Add("1. Fast Peak Picker (works best on filtered data)");
            peak_picking_method_combobox.Items.Add("2. Classic Peak Picker (Slow)");
            peak_picking_method_combobox.SelectedIndex = 0;

            data_direction_name.Add("X");
            data_direction_name.Add("Y");
            data_direction_name.Add("Z");
            data_direction_name.Add("XY_VS");
            data_direction_name.Add("XZ_VS");
            data_direction_name.Add("YZ_VS");

            //disable manual freq estimation
            manual_freq_est_checkbox.Enabled = false;
            manual_freq_est_numupdown.Enabled = false;
            label7.Enabled = false;


            //set default value in the comboboxs;
            linear_or_log_combobox.SelectedIndex = 0;


            peak_point_colors.Add(Color.Blue);
            peak_point_colors.Add(Color.Green);
            peak_point_colors.Add(Color.Red);
            peak_point_colors.Add(Color.Cyan);
            peak_point_colors.Add(Color.Purple);
            peak_point_colors.Add(Color.Brown);

            exp_curve_colors.Add(Color.DarkBlue);
            exp_curve_colors.Add(Color.DarkGreen);
            exp_curve_colors.Add(Color.DarkRed);
            exp_curve_colors.Add(Color.DarkCyan);
            exp_curve_colors.Add(Color.Purple);
            exp_curve_colors.Add(Color.Brown);

            signal_colors.Add(System.Drawing.ColorTranslator.FromHtml("#6495ed"));
            signal_colors.Add(System.Drawing.ColorTranslator.FromHtml("#556b2f"));
            signal_colors.Add(System.Drawing.ColorTranslator.FromHtml("#b22222"));
            signal_colors.Add(Color.DarkCyan);
            signal_colors.Add(Color.Violet);
            signal_colors.Add(Color.SaddleBrown);


            bandpass_freq_buffer_choices_combobox.Items.Add(0.05);
            bandpass_freq_buffer_choices_combobox.Items.Add(0.1);
            bandpass_freq_buffer_choices_combobox.Items.Add(0.2);
            bandpass_freq_buffer_choices_combobox.Items.Add(0.3);
            bandpass_freq_buffer_choices_combobox.Items.Add(0.4);
            bandpass_freq_buffer_choices_combobox.Items.Add(0.5);
            bandpass_freq_buffer_choices_combobox.Items.Add(0.6);

            bandpass_freq_buffer_choices_combobox.SelectedIndex = 1;

            input_data_sample_rate = Convert.ToDouble(input_data_sample_rate_numupdown.Value);

            enable_all_user_controls(false);

            signal_data_chart_main.Titles.Add("Absolute Signal Data");
            freq_dft_chart.Titles.Add("DFT Frequency Response");
            freq_peaks_chart.Titles.Add("Frequency Samples based on Distance btwn Peaks");
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

            for (int i = 0; i < mag_span.Count; i++)
            {
                //found span
                if (mag_span[i] > std_deviation * 2)
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

        public void export_session_results_to_csv(string folder_filepath, string filename)
        {
            List<List<string>> csv_data = new List<List<string>>();
            const string quote = "\"";

            List<string> header_row = new List<string>();
            header_row.Add("Dataset Name");
            header_row.Add("Dataset Direction");
            header_row.Add("Natural Frequency DFT (Hz)");
            header_row.Add("Natural Frequency Peaks (Hz)");
            header_row.Add("Damping Ratio DFT frequency (%)");
            header_row.Add("Damping Ratio Peaks frequency (%)");
            header_row.Add("R_squared");
            header_row.Add("Max Displacement (m)");
            header_row.Add("");
            header_row.Add("Natural Frequency DFT (Hz) Average");
            header_row.Add("Natural Frequency Peaks (Hz) Average");
            header_row.Add("Damping Ratio DFT frequency (%) Average");
            header_row.Add("Damping Ratio Peaks frequency (%) Average");
            //header_row.Add("");
            //header_row.Add("Minimum R_Squared Thresehold");

            List<string> row1 = new List<string>();
            row1.Add("");
            row1.Add("");
            row1.Add("");
            row1.Add("");
            row1.Add("");
            row1.Add("");
            row1.Add("");
            row1.Add("");
            row1.Add("");
            row1.Add("=AVERAGE(C2:C999)");
            row1.Add("=AVERAGE(D2:D999)");
            row1.Add("=AVERAGE(E2:E999)");
            row1.Add("=AVERAGE(F2:F999)");
            //row1.Add("");
            //row1.Add("0.95");

            List<string> row2 = new List<string>();
            row2.Add("");
            row2.Add("");
            row2.Add("");
            row2.Add("");
            row2.Add("");
            row2.Add("");
            row2.Add("");
            row2.Add("");
            row2.Add("");
            row2.Add("Natural Frequency Average (Hz)");
            row2.Add("");
            row2.Add("Damping Ratio Average (%)");
            row2.Add("");

            List<string> row3 = new List<string>();
            row3.Add("");
            row3.Add("");
            row3.Add("");
            row3.Add("");
            row3.Add("");
            row3.Add("");
            row3.Add("");
            row3.Add("");
            row3.Add("");
            row3.Add(@"=AVERAGE(J2:K2)");
            row3.Add("");
            row3.Add(@"=AVERAGE(L2:M2)");
            row3.Add("");

            List<string> empty_row = new List<string>();
            empty_row.Add("");


            csv_data.Add(header_row);
            csv_data.Add(row1);
            csv_data.Add(row2);
            csv_data.Add(row3);

            for (int i = 0; i < session_results_tracker.Count; i++)
            {
                string dataset_name = dataset_input_filepaths_short[i];

                if (session_results_tracker[i].Count > 0)
                {
                    for (int data_direction_index = 0; data_direction_index < 6; data_direction_index++)
                    {
                        if (session_results_tracker[i][data_direction_index].Count > 0)
                        {
                            List<string> temp_row = convert_list_double_to_list_string(session_results_tracker[i][data_direction_index]);
                            temp_row.Insert(0, data_direction_name[data_direction_index]);
                            temp_row.Insert(0, dataset_name);

                            csv_data.Add(temp_row);
                        }
                        else
                        {
                            //csv_data.Add(empty_row);
                        }
                    }
                    csv_data.Add(empty_row);
                }

            }
            process_save_dataset_as_csv(csv_data, folder_filepath + filename + ".csv");
        }

        public List<string> convert_list_double_to_list_string(List<double> list_double)
        {
            List<string> list_string = new List<string>();
            for (int i = 0; i < list_double.Count; i++)
            {
                list_string.Add(list_double[i].ToString());

            }
            return list_string;
        }

        public Boolean check_if_list_list_double_is_empty(List<List<List<double>>> list)
        {
            Boolean is_empty = true;
            for (int i = 0; i < list.Count; i++)
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

        public List<List<string>> export_peaks_csv(damping_reduction_dataset cur_drd)
        {
            List<List<string>> peak_csv = new List<List<string>>();

            for (int i = 0; i < cur_drd.local_maximas_times.Count; i++)
            {
                if (cur_drd.local_maximas_times[i].Count != 0)
                {
                    List<string> peak_times = convert_list_double_to_list_string(cur_drd.local_maximas_times[i]);
                    List<string> peak_amplitudes = convert_list_double_to_list_string(cur_drd.local_maximas_amplitudes[i]);

                    peak_times.Insert(0, "Peak Time (s) [" + data_direction_name[i] + "]");
                    peak_amplitudes.Insert(0, "Peak Amp. (s) [" + data_direction_name[i] + "]");

                    peak_csv.Add(peak_times);
                    peak_csv.Add(peak_amplitudes);
                }
            }
            peak_csv = transpose_list_of_list_string(peak_csv);

            return (peak_csv);
            
            //process_save_dataset_as_csv(peak_csv, filepath);
        }

        public List<double> calculate_max_displacement_XYZ(damping_reduction_dataset c_drd)
        {
            List<List<double>> displacement_datasets = c_drd.datasets_trim;
            List<double> natural_freqs = c_drd.natural_freq_fft;

            List<double> max_displacements = new List<double>();
            int freq_index = 0;

            for (int i = 1; i <= 3; i++)
            {
                double max_displacement = Math.Abs((displacement_datasets[i].Max()) / Math.Pow((2 * Math.PI * natural_freqs[freq_index]), 2));
                max_displacements.Add(max_displacement);

                freq_index++;
            }
            max_displacements.Add(Math.Abs(Math.Sqrt(Math.Pow(max_displacements[0], 2) + Math.Pow(max_displacements[1], 2))));
            max_displacements.Add(Math.Abs(Math.Sqrt(Math.Pow(max_displacements[0], 2) + Math.Pow(max_displacements[2], 2))));
            max_displacements.Add(Math.Abs(Math.Sqrt(Math.Pow(max_displacements[1], 2) + Math.Pow(max_displacements[2], 2))));

            c_drd.max_displacement = max_displacements;


            return max_displacements;
        }

        public void constrain_freq_dft_plot_cutoff_freqs()
        {
            decimal low_cutoff = lower_freq_plot_cutoff_numupdown.Value;
            decimal high_cutoff = upper_freq_plot_cutoff_numupdown.Value;

            if (low_cutoff >= high_cutoff)
            {
                low_cutoff = high_cutoff - Convert.ToDecimal(0.001);
            }

            lower_freq_plot_cutoff_numupdown.Value = low_cutoff;
            upper_freq_plot_cutoff_numupdown.Value = high_cutoff;

        }

        public T Clamp<T>(T val, T min, T max) where T : IComparable<T>
        {
            if (val.CompareTo(min) < 0) return min;
            else if (val.CompareTo(max) > 0) return max;
            else return val;
        }

        public void update_csv_dropdown_filename_with_tag(string tag)
        {
            int i = select_data_set_tool_strip_combo_box.SelectedIndex;
            if (!dataset_input_filepaths_short[i].Contains(tag))
            {
                dataset_input_filepaths_short[i] = dataset_input_filepaths_short[i] + tag;
                select_data_set_tool_strip_combo_box.Items[i] = select_data_set_tool_strip_combo_box.Items[i] + tag;
            }

        }

        public List<double> automatically_update_freq_repsonse_plot()
        {
            //get the data set to perfom analysis on (filter or unfiltered)
            List<List<double>> selected_data_sets = new List<List<double>>();
            if (drd.is_data_filtered == true)
            {
                selected_data_sets = new List<List<double>>(drd.datasets_filter_trim);
            }
            else
            {
                selected_data_sets = new List<List<double>>(drd.datasets_trim);
            }
            if (selected_data_sets.Count <= 0)
            {
                return new List<double>();
            }
            //remove the time list from data to be porocessed
            selected_data_sets.RemoveAt(0);

            //preform fft freq response analysis on all data sets
            List<double> natural_frequencies = fft_analysis(selected_data_sets, data_direction_name);
            drd.natural_freq_fft = natural_frequencies;

            //update text
            string ta1_text = string.Empty;
            for (int i = 0; i < natural_frequencies.Count; i++)
            {
                ta1_text += data_direction_name[i] + ": " + Math.Round(natural_frequencies[i], 3) + " Hz\r\n";
            }
            nat_freq_textbox.Text = ta1_text;

            return natural_frequencies;
        }

        public void changes_cursor_icon_to_loading(Boolean processing)
        {
            //updating the processing icons based on the input
            //true now preocessing
            //false stop processing
            if (processing)
            {
                //process_icon.Visible = true;
                //process_icon.Refresh();
                System.Windows.Forms.Cursor.Current = Cursors.AppStarting;
            }
            else
            {
                //process_icon.Visible = false;
                //process_icon.Refresh();
                System.Windows.Forms.Cursor.Current = Cursors.Default;
            }
        }

        public void activity_log(string log)
        {
            activity_log_textbox.AppendText(log + "\n\r\n\r");
        }

        public void export_image_streams_chart_screenshot_tracker(damping_reduction_dataset c_drd, string output_folder_filepath)
        {
            //output_folder_filepath= output_folder_filepath+ @"\";

            string dataset_name = get_filename_from_filepath(c_drd.dataset_input_filepath_short);

            //save screenshots
            if (c_drd.chart_screenshot_tracker_byte_array.Count > 0)
            {
                //save images from stream

                string chart_filepath_1 = output_folder_filepath + "Signal Data Plot " + dataset_name + ".png";
                string chart_filepath_2 = output_folder_filepath + "DFT Plot " + dataset_name + ".png";
                string chart_filepath_3 = output_folder_filepath + "Freq Estimation Plot " + dataset_name + ".png";

                File.WriteAllBytes(chart_filepath_1, c_drd.chart_screenshot_tracker_byte_array[0]);
                File.WriteAllBytes(chart_filepath_2, c_drd.chart_screenshot_tracker_byte_array[1]);
                File.WriteAllBytes(chart_filepath_3, c_drd.chart_screenshot_tracker_byte_array[2]);

            }

            //create and save a  plot showing the relative area of timmed area comapred to the whole dataset (for user reference)
            // create 2 plots: filtered and unfiltered

            generate_trim_location_plot(c_drd, c_drd.datasets_master, output_folder_filepath, dataset_name, "Unfiltered Trim Location");
            generate_trim_location_plot(c_drd, c_drd.datasets_master_filtered, output_folder_filepath, dataset_name, "Filtered Trim Location");


        }

        public void generate_trim_location_plot(damping_reduction_dataset c_drd, List<List<double>> dataset_values, string output_folder_filepath, string dataset_name, string image_filename)
        {
            using (var chart_trim_section_view = new Chart())
            {
                chart_trim_section_view.ChartAreas.Add(new ChartArea());

                chart_trim_section_view.Titles.Add(image_filename);

                chart_trim_section_view.Legends.Add("Legend");

                List<List<double>> master_preview_data_list = new List<List<double>>();
                List<string> master_preview_data_names = new List<string>();

                master_preview_data_list.Add((c_drd.datasets_master[0]));

                for (int ddi = 1; ddi <= c_drd.data_direction_checkmark_tracker.Count; ddi++)
                {
                    if (c_drd.data_direction_checkmark_tracker[ddi - 1] == true)
                    {
                        //copy the master data
                        List<double> master_preview_data = new List<double>(dataset_values[ddi]);

                        ////set default values for clipping/trimming the master dataset
                        //int min_clip_index = 0;
                        //int max_clip_index = master_preview_data.Count - 1;

                        //clip the data
                        //List<double> master_preview_data_clipped = master_preview_data.GetRange(min_clip_index, max_clip_index - min_clip_index);

                        master_preview_data_list.Add(master_preview_data);
                        master_preview_data_names.Add(data_direction_name[ddi - 1]);
                    }
                }

                //annotation placement indexs
                double lower_annotation_index = c_drd.datasets_master[0][c_drd.lower_trim_index_x_relative_master_dataset];
                double upper_annoation_index = c_drd.datasets_master[0][c_drd.upper_trim_index_x_relative_master_dataset];

                //setup annoatation lines
                VerticalLineAnnotation line1 = new VerticalLineAnnotation();
                VerticalLineAnnotation line2 = new VerticalLineAnnotation();

                line1.AxisX = chart_trim_section_view.ChartAreas[0].AxisX;
                line1.AllowMoving = true;
                line1.IsInfinitive = true;
                line1.ClipToChartArea = chart_trim_section_view.ChartAreas[0].Name;
                //line1.Name = "line 1";
                line1.LineColor = Color.Purple;
                line1.LineWidth = 3;         // use your numbers!
                line1.X = lower_annotation_index;
                //add to the chart
                chart_trim_section_view.Annotations.Add(line1);

                // the vertical line and its properties
                //line2 = new VerticalLineAnnotation();

                chart_trim_section_view.Annotations.Remove(line2);

                line2.AxisX = chart_trim_section_view.ChartAreas[0].AxisX;
                line2.AllowMoving = true;
                line2.IsInfinitive = true;
                line2.ClipToChartArea = chart_trim_section_view.ChartAreas[0].Name;
                //line2.Name = "line 2";
                line2.LineColor = Color.Purple;
                line2.LineWidth = 3;         // use your numbers!
                line2.X = upper_annoation_index;
                //add to the chart
                chart_trim_section_view.Annotations.Add(line2);

                plot_data_on_chart(chart_trim_section_view, master_preview_data_names, master_preview_data_list, "Time (Seconds)", y_axis_label_data_chart);
                chart_trim_section_view.Size = new Size(1000, 500);


                //foreach (var pnt in series) s.Points.Add(pnt);
                //chart_trim_section_view.Series.Add(s);
                string filepath_img = output_folder_filepath + image_filename + " " + dataset_name + ".png";
                chart_trim_section_view.SaveImage(filepath_img, ChartImageFormat.Png);
            }
        }

        public Boolean process_save_dataset_as_csv(List<List<double>> dataset_double, string save_filepath)
        {
            //check if data set is empty
            if (dataset_double.Count == 0)
            {
                //string message = "There is no dataset to export";
                //string title = "Error";
                //FlexibleMessageBox.Show(message, title);
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

        public Boolean process_save_dataset_as_csv(List<List<string>> dataset_string, string save_filepath)
        {
            //string list overload

            //check if data set is empty
            if (dataset_string.Count == 0)
            {
                //string message = "There is no dataset to export";
                //string title = "Error";
                //FlexibleMessageBox.Show(message, title);
                return false;
            }

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
                FlexibleMessageBox.Show(message, title);
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

        public List<List<string>> transpose_list_of_list_string(List<List<string>> data)
        {
            List<List<string>> transposed_data = data.SelectMany(inner => inner.Select((item, index) => new { item, index }))
            .GroupBy(i => i.index, i => i.item)
            .Select(g => g.ToList())
            .ToList();

            return transposed_data;
        }

        public void populate_select_data_direction_checked_list(List<Boolean> data_direction_checked_tracker)
        {
            select_data_direction_check_list_box.Items.Clear();

            data_direction_name.Clear();

            data_direction_name.Add("X");
            data_direction_name.Add("Y");
            data_direction_name.Add("Z");
            data_direction_name.Add("XY_VS");
            data_direction_name.Add("XZ_VS");
            data_direction_name.Add("YZ_VS");

            //check is the list has 6 items , one for each direction, and populate the list with the exisitng checkmarks
            if (data_direction_checked_tracker.Count == 6)
            {
                for (int i = 0; i < data_direction_checked_tracker.Count; i++)
                {
                    if (data_direction_checked_tracker[i] == true)
                    {
                        select_data_direction_check_list_box.Items.Add(data_direction_name[i], CheckState.Checked);
                    }
                    else
                    {
                        select_data_direction_check_list_box.Items.Add(data_direction_name[i], CheckState.Unchecked);
                    }
                }
            }
            //if not use the default (XYZ are checked, rest are not)
            else
            {
                for (int i = 0; i < data_direction_name.Count; i++)
                {
                    if (i < 3)
                    {
                        select_data_direction_check_list_box.Items.Add(data_direction_name[i], CheckState.Checked);
                    }
                    else
                    {
                        select_data_direction_check_list_box.Items.Add(data_direction_name[i], CheckState.Unchecked);
                    }
                }
            }

        }

        public void average_remove_outliers(ref List<double> data_x, ref List<double> data_y)
        {
            //remove outliers that are higher than 90% of average and less than 10 % of averag
            List<double> data_y_trimmed = new List<double>();
            List<double> data_x_trimmed = new List<double>();

            double x = 0;

            for (int i = 0; i < data_y.Count; i++)
            {
                x = x + Math.Pow(data_y[i] - data_y.Average(), 2);
            }
            double std_deviation = Math.Sqrt(x / data_y.Count);

            for (int i = 0; i < data_y.Count; i++)
            {
                if (data_y[i] < data_y.Average() + std_deviation * 3 && data_y[i] > data_y.Average() - std_deviation * 3)
                {
                    if (freq_estimation_reject_freq_checkbox.Checked == true)
                    {
                        if (data_y[i] <= Convert.ToDouble(freq_estimation_high_cutoff_freq_numupdown.Value))
                        {
                            data_y_trimmed.Add(data_y[i]);
                            data_x_trimmed.Add(data_x[i]);
                        }
                    }
                    else
                    {
                        data_y_trimmed.Add(data_y[i]);
                        data_x_trimmed.Add(data_x[i]);
                    }


                }
            }

            data_x = data_x_trimmed;
            data_y = data_y_trimmed;


            if (data_y_trimmed.Count > 0)
            {
                return;
            }
            else
            {
                string message = "Could not reject all frequencies above " + freq_estimation_high_cutoff_freq_numupdown.Value + " Hz, as all data points were rejected. Rejection parameters ignored.";
                string title = "Error";
                FlexibleMessageBox.Show(message, title);
                return;
            }


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

        public List<double> calculate_natural_frequency_peaks(ref List<double> time_values_peak, List<int> peak_int_indexs, double sample_rate, string series_name)
        {
            //get the freqs by using the integer indecies of the maximas and the sample rate
            List<double> frequency_peaks = new List<double>();

            for (int i = 1; i < peak_int_indexs.Count; i++)
            {
                double samples_between_peaks = Convert.ToDouble(peak_int_indexs[i] - peak_int_indexs[i - 1]);
                frequency_peaks.Add((1 / (samples_between_peaks / 1024)) / 2);
            }

            average_remove_outliers(ref time_values_peak, ref frequency_peaks);

            if (frequency_peaks.Count == 0)
            {
                return frequency_peaks;
            }


            //remove last data point as signal is not usually trimmed perfectly
            //frequency_peaks.RemoveAt(frequency_peaks.Count - 1);

            //abitrary list to display clauclated frequencies
            List<int> count_list = new List<int>();
            for (int i = 1; i < frequency_peaks.Count + 1; i++)
            {
                count_list.Add(i);
            }




            ////remove last data point to match lengths for plotting (list not used anymnore)
            //peak_int_indexs.RemoveAt(peak_int_indexs.Count - 1);

            plot_freq_peaks_response(time_values_peak, frequency_peaks, series_name);

            return frequency_peaks;
        }

        public List<List<double>> vector_sum_xyz_datasets(List<List<double>> datasets_xyz)
        {
            List<double> xy = new List<double>();
            List<double> xz = new List<double>();
            List<double> yz = new List<double>();

            for (int i = 0; i < datasets_xyz[0].Count; i++)
            {
                //xy.Add(Math.Sqrt(Math.Pow(datasets_xyz[1][i], 2) + Math.Pow(datasets_xyz[2][i], 2)));
                //xz.Add(Math.Sqrt(Math.Pow(datasets_xyz[1][i], 2) + Math.Pow(datasets_xyz[3][i], 2)));
                //yz.Add(Math.Sqrt(Math.Pow(datasets_xyz[2][i], 2) + Math.Pow(datasets_xyz[3][i], 2)));

                xy.Add(vector_sum_two_points(datasets_xyz[1][i], datasets_xyz[2][i]));
                xz.Add(vector_sum_two_points(datasets_xyz[1][i], datasets_xyz[3][i]));
                yz.Add(vector_sum_two_points(datasets_xyz[2][i], datasets_xyz[3][i]));
            }

            datasets_xyz.Add(xy);
            datasets_xyz.Add(xz);
            datasets_xyz.Add(yz);

            return datasets_xyz;
        }

        public double vector_sum_two_points(double p1, double p2)
        {
            if (p1 == p2)
            {
                return p1;
            }
            if (p1 == -p2)
            {
                return 0;
            }

            if (Math.Abs(p1) > Math.Abs(p2))
            {
                if (p1 < 0)
                {
                    return -Math.Sqrt(Math.Pow(p1, 2) + Math.Pow(p2, 2));
                }
            }
            else
            {
                if (p2 < 0)
                {
                    return -Math.Sqrt(Math.Pow(p1, 2) + Math.Pow(p2, 2));
                }
            }
            return Math.Sqrt(Math.Pow(p1, 2) + Math.Pow(p2, 2));
        }

        public void plot_freq_response(List<List<double>> freq_span, List<List<double>> real_spectrum, List<string> data_direction_names)
        {
            //created trimmed data based on the user selected cutoff plot freq
            List<List<double>> freq = new List<List<double>>();
            List<List<double>> mag = new List<List<double>>();

            //data direction names (onl;y plotted names)
            List<string> data_direction_names_plot = new List<string>();

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
                if (drd.data_direction_checkmark_tracker[list_index] == true)
                {

                    data_direction_names_plot.Add(data_direction_names[list_index]);

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
            }


            //plot the data
            plot_data_on_freq_chart(freq_dft_chart, data_direction_names_plot, freq, mag, "Frequency (Hz)", "Amplitude");
        }

        public List<double> fft_analysis(List<List<double>> signal_data, List<string> data_direction_name)
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
                UInt32 zero_pad = Convert.ToUInt32(signal_data[list_index].Count * 3);

                Boolean padding_not_found = true;
                int i = 0;
                while (padding_not_found)
                {
                    i = i + 2;
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
                //absolute the data without sampling if the data  points are less then the max samples
                sampled_data_sets.Add(data_sets[0]);

                for (int list_index = 1; list_index < data_sets.Count; list_index++)
                {

                    List<double> sampled_data = new List<double>();

                    for (int i = 0; i < data_sets[list_index].Count; i++)
                    {
                        sampled_data.Add(Math.Abs(data_sets[list_index][i]));
                    }
                    sampled_data_sets.Add(sampled_data);
                }

                return sampled_data_sets;
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

        public static List<int> find_local_maximas1(List<double> values, int range_of_peaks)
        {
            List<int> peaks = new List<int>();

            int checksOnEachSide = range_of_peaks / 2;
            for (int i = 0; i < values.Count; i++)
            {
                double current = values[i];
                IEnumerable<double> range = values;
                if (i > checksOnEachSide)
                    range = range.Skip(i - checksOnEachSide);
                range = range.Take(range_of_peaks);
                if (current == range.Max())
                    peaks.Add(i);
            }
            return peaks;
        }

        public List<List<double>> convert_ticks_to_seconds(List<List<double>> csv_datasets)
        {


            List<List<double>> csv_datasets_ticks_converted = csv_datasets;

            for (int i = 0; i < csv_datasets_ticks_converted[0].Count; i++)
            {
                csv_datasets_ticks_converted[0][i] = Convert.ToDouble(i + 1) / input_data_sample_rate;
            }
            return csv_datasets_ticks_converted;
        }

        public List<List<double>> convert_list_of_list_string_to_double(List<List<string>> list_of_lists_data, Boolean return_zeros_if_invalid = false)
        {
            List<List<double>> double_data = new List<List<double>>();

            foreach (List<string> list_of_data in list_of_lists_data)
            {
                try // will throw error if data is not in double format
                {
                    double_data.Add(list_of_data.Select(x => double.Parse(x)).ToList());
                }
                catch //in that case fill with zeros if enabled
                {
                    if (return_zeros_if_invalid)
                    {
                        double_data.Add(Enumerable.Repeat(0.00, list_of_data.Count).ToList());
                    }
                }
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
            foreach (List<double> data in drd.datasets_trim)
            {
                temp_list1.Add(data.GetRange(lower_boundary_index, upper_boundary_index - lower_boundary_index));
            }
            //generic_input_data_double_clone = temp_list1;
            drd.datasets_trim = temp_list1;

            foreach (List<double> data in drd.datasets_filter_trim)
            {
                temp_list2.Add(data.GetRange(lower_boundary_index, upper_boundary_index - lower_boundary_index));
            }
            //generic_input_data_double_clone_filtered = temp_list2;
            drd.datasets_filter_trim = temp_list2;
        }

        public void check_if_annotations_in_chartview(Chart chart_to_be_checked)
        {
            //get chart boundries
            double xmin = chart_to_be_checked.ChartAreas[0].AxisX.Minimum;
            double xmax = chart_to_be_checked.ChartAreas[0].AxisX.Maximum;
            double ymin = chart_to_be_checked.ChartAreas[0].AxisY.Minimum;
            double ymax = chart_to_be_checked.ChartAreas[0].AxisY.Maximum;

            for (int i = 0; i <= chart_to_be_checked.Annotations.Count - 1; i++)
            {
                if (chart_to_be_checked.Annotations[i].AnnotationType == "VerticalLine")
                {
                    if (chart_to_be_checked.Annotations[i].X < xmin)
                    {
                        chart_to_be_checked.Annotations[i].X = xmin;
                    }
                    if (chart_to_be_checked.Annotations[i].X > xmax)
                    {
                        chart_to_be_checked.Annotations[i].X = xmax;
                    }
                }
                if (chart_to_be_checked.Annotations[i].AnnotationType == "HorizontalLine")
                {
                    if (chart_to_be_checked.Annotations[i].Y < ymin)
                    {
                        chart_to_be_checked.Annotations[i].Y = ymin;
                    }
                    if (chart_to_be_checked.Annotations[i].Y > ymax)
                    {
                        chart_to_be_checked.Annotations[i].Y = ymax;
                    }
                }
            }
        }

        public void check_checked_chart_series()
        {
            for (int i = 0; i < select_data_direction_check_list_box.Items.Count; i++)
            {
                //check each data direction if it checked
                if (select_data_direction_check_list_box.GetItemCheckState(i) == CheckState.Checked)
                {
                    check_charted_series_subfunction(true, i);
                }
                else
                {
                    check_charted_series_subfunction(false, i);
                }
            }
        }

        public void check_charted_series_subfunction(Boolean enable, int i)
        {
            signal_data_chart_main.Series[i].Enabled = enable;
            drd.data_direction_checkmark_tracker[i] = enable;

            if (i < freq_dft_chart.Series.Count)
            {
                freq_dft_chart.Series[i].Enabled = enable;
            }

            if (i < freq_peaks_chart.Series.Count)
            {
                freq_peaks_chart.Series[i].Enabled = enable;
            }

            for (int j = 0; j < signal_data_chart_main.Series.Count; j++)
            {
                string checked_direction = select_data_direction_check_list_box.Items[i].ToString();
                string current_series_name = signal_data_chart_main.Series[j].Name;

                int trim_index = (current_series_name.IndexOf(" "));

                if (trim_index != -1)
                {
                    //isolate direction name
                    current_series_name = current_series_name.Substring(0, trim_index);

                    if (checked_direction == current_series_name)
                    {
                        signal_data_chart_main.Series[j].Enabled = enable;
                    }
                }
            }
        }

        public void enable_all_user_controls(Boolean enable)
        {
            if (enable)
            {
                trim_data_button.Enabled = true;
                reset_data_trimming_button.Enabled = true;
                apply_filter_button.Enabled = true;
                remove_filter_button.Enabled = true;
                calculate_damp_ratio_and_freq_button.Enabled = true;
                recalc_damp_ratio_freq_peak_button.Enabled = true;
                reset_trim_lines_button.Enabled = true;
            }
            else
            {
                trim_data_button.Enabled = false;
                reset_data_trimming_button.Enabled = false;
                apply_filter_button.Enabled = false;
                remove_filter_button.Enabled = false;
                calculate_damp_ratio_and_freq_button.Enabled = false;
                recalc_damp_ratio_freq_peak_button.Enabled = false;
                reset_trim_lines_button.Enabled = false;
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
            string message = "Cannot save " + filepath + " as an exsiting file with the same name cannot be accessed. Try closing the specified file and try again";
            string title = "Error";

            ////check if file is locked
            //if (IsFileLocked(new FileInfo(filepath)))
            //{
            //    FlexibleMessageBox.Show(message, title);
            //    return;
            //}


            //try
            //{


            //const string SEPARATOR = ",";
            //using (StreamWriter writer = new StreamWriter(filepath))
            //{
            //    data.ForEach(line =>
            //    {
            //        var lineArray = line.Select(c => c.Contains(SEPARATOR) ? c.Replace(SEPARATOR.ToString(), "\\" + SEPARATOR) : c).ToArray();
            //        writer.WriteLine(string.Join(SEPARATOR, lineArray));
            //    });
            //}

            const string quote = "\"";
            const string SEPARATOR = ",";
            using (StreamWriter writer = new StreamWriter(filepath))
            {
                for (int i = 0; i < data.Count; i++)
                {
                    ////wrap every cell with quotes
                    //for (int j = 0; j < data[i].Count; j++)
                    //{
                    //    data[i][j] = data[i][j];
                    //}
                    //add a comma between every cell
                    writer.WriteLine(string.Join(SEPARATOR, data[i]));
                }

            }
            //}
            //catch
            //{
            //    FlexibleMessageBox.Show(message, title);
            //    return;
            //}
        }

        //manipulate chart functions

        public void update_tooltip_average_freqs_est()
        {
            //get index/values of annotation trim lines and do some boundry checking

            int xmax = 0;
            int xmin = 0;
            double ymax = 0;
            double ymin = 0;

            if (freq_peaks_trim_vertical_line_1.X > freq_peaks_trim_vertical_line_2.X)
            {
                xmax = Convert.ToInt32(Math.Floor(freq_peaks_trim_vertical_line_1.X));
                xmin = Convert.ToInt32(Math.Ceiling(freq_peaks_trim_vertical_line_2.X));
            }
            else
            {
                xmax = Convert.ToInt32(Math.Floor(freq_peaks_trim_vertical_line_2.X));
                xmin = Convert.ToInt32(Math.Ceiling(freq_peaks_trim_vertical_line_1.X));
            }


            if (freq_peaks_trim_horizontal_line_1.Y > freq_peaks_trim_horizontal_line_2.Y)
            {
                ymax = freq_peaks_trim_horizontal_line_1.Y;
                ymin = freq_peaks_trim_horizontal_line_2.Y;
            }
            else
            {
                ymax = freq_peaks_trim_horizontal_line_2.Y;
                ymin = freq_peaks_trim_horizontal_line_1.Y;
            }








            string tooltip_text = String.Empty;

            for (int i = 0; i < freq_peaks_chart.Series.Count(); i++)
            {
                List<double> temp_average_Y = new List<double>();
                List<double> temp_average_X = new List<double>();

                for (int j = 0; j < freq_peaks_chart.Series[i].Points.Count(); j++)
                {
                    temp_average_Y.Add(freq_peaks_chart.Series[i].Points[j].YValues[0]);
                    temp_average_X.Add(freq_peaks_chart.Series[i].Points[j].XValue);
                }

                for (int k = temp_average_Y.Count - 1; k >= 0; k--)
                {
                    if (temp_average_X[k] > xmax || temp_average_X[k] < xmin)
                    {
                        temp_average_Y.RemoveAt(k);
                        continue;
                    }
                    if (temp_average_Y[k] > ymax || temp_average_Y[k] < ymin)
                    {
                        temp_average_Y.RemoveAt(k);
                        continue;
                    }
                }
                tooltip_text += freq_peaks_chart.Series[i].Name + " (Avg): " + Math.Round(temp_average_Y.Average(), 4) + "Hz\r\n";
            }
            toolTip1.SetToolTip(freq_peaks_chart, tooltip_text);
        }

        public void plot_freq_peaks_response(List<double> time_value, List<double> frequency_peaks, string series_name)
        {
            if (time_value.Count > frequency_peaks.Count)
            {
                time_value.RemoveAt(time_value.Count - 1);
            }

            if (time_value.Count() != frequency_peaks.Count())
            {
                string message = "freq peaks plot data is not same length";
                string title = "Error";
                FlexibleMessageBox.Show(message, title);
                return;
            }

            System.Windows.Forms.DataVisualization.Charting.Series series = freq_peaks_chart.Series.Add(series_name + " Freq. Resp.");
            series.ChartType = SeriesChartType.Point;
            //series.Points.DataBindXY(time_peaks, frequency_peaks);
            series.Points.DataBindXY(time_value, frequency_peaks);
            series.BorderWidth = 1;
            series.Color = signal_colors[data_direction_name.IndexOf(series_name)];
            series.ToolTip = "#SERIESNAME\nX: #VALX\nY: #VAL";


            freq_peaks_chart.ChartAreas[0].AxisX.Title = "Time Value of Peak (Seconds)";
            freq_peaks_chart.ChartAreas[0].AxisY.Title = "Frequency (Hz)";

            //rescale y axis
            freq_peaks_chart.ChartAreas[0].AxisY.IsStartedFromZero = false;

            freq_peaks_chart.ChartAreas[0].AxisX.LabelStyle.Format = "0.00";




        }

        public List<double> plot_fitted_exponential_curve(double A, double k, string dataset_name, int data_direction_index = 0)
        {
            List<double> exp_curve_values = new List<double>();
            List<double> exp_curve_values_sampled = new List<double>();
            List<double> exp_time_values = new List<double>();

            int data_point_interval = drd.datasets_trim[0].Count / chart_width;

            for (int i = 0; i < drd.datasets_trim[0].Count; i++)
            {
                exp_curve_values.Add(A * Math.Exp(k * drd.datasets_trim[0][i]));
            }

            for (int i = 0; i < drd.datasets_trim[0].Count; i = i + data_point_interval)
            {
                exp_curve_values_sampled.Add(A * Math.Exp(k * drd.datasets_trim[0][i]));
                exp_time_values.Add(drd.datasets_trim[0][i]);
            }

            string series_name = dataset_name + " Exp. Fit";

            //plot with settings
            try
            {
                System.Windows.Forms.DataVisualization.Charting.Series series = signal_data_chart_main.Series.Add(series_name);
                signal_data_chart_main.Series[series_name].Points.Clear();
                series.ChartType = SeriesChartType.Line;
                series.Color = exp_curve_colors[data_direction_index];
                series.Points.DataBindXY(exp_time_values, exp_curve_values_sampled);
                series.BorderWidth = 2;
                series.ToolTip = "#SERIESNAME\nX: #VALX\nY: #VAL";
            }
            catch
            {
                signal_data_chart_main.Series[series_name].Points.Clear();
                signal_data_chart_main.Series[series_name].ChartType = SeriesChartType.Line;
                signal_data_chart_main.Series[series_name].Color = exp_curve_colors[data_direction_index];
                signal_data_chart_main.Series[series_name].Points.DataBindXY(exp_time_values, exp_curve_values_sampled);
                signal_data_chart_main.Series[series_name].BorderWidth = 2;
                signal_data_chart_main.Series[series_name].ToolTip = "#SERIESNAME\nX: #VALX\nY: #VAL";
            }


            return exp_curve_values;
        }

        public List<double> plot_peaks_chart(List<int> peak_indexs, List<double> abs_data, string series_name, int data_direction_index = 0)
        {

            List<double> peak_times = new List<double>();
            List<double> peak_amplitudes = new List<double>();

            //dont include last point it can be a bad data point
            for (int i = 0; i <= peak_indexs.Count - 1; i++)
            {
                if (peak_indexs[i] < abs_data.Count - 1)
                {
                    peak_times.Add(drd.datasets_trim[0][peak_indexs[i]]);
                    peak_amplitudes.Add(abs_data[peak_indexs[i]]);
                }
            }



            try
            {
                System.Windows.Forms.DataVisualization.Charting.Series series = signal_data_chart_main.Series.Add(series_name);
                signal_data_chart_main.Series[series_name].Points.Clear();
                series.ChartType = SeriesChartType.Point;
                series.Color = peak_point_colors[data_direction_index];
                series.Points.DataBindXY(peak_times, peak_amplitudes);
                series.BorderWidth = 3;
                series.ToolTip = "#SERIESNAME\nX: #VALX\nY: #VAL";
            }
            catch
            {
                signal_data_chart_main.Series[series_name].Points.Clear();
                signal_data_chart_main.Series[series_name].ChartType = SeriesChartType.Point;
                signal_data_chart_main.Series[series_name].Color = peak_point_colors[data_direction_index];
                signal_data_chart_main.Series[series_name].Points.DataBindXY(peak_times, peak_amplitudes);
                signal_data_chart_main.Series[series_name].BorderWidth = 3;
                signal_data_chart_main.Series[series_name].ToolTip = "#SERIESNAME\nX: #VALX\nY: #VAL";
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



                if (i <= signal_colors.Count)
                {
                    series.Color = signal_colors[i - 1];
                }

            }
            //set the x-axis min to the first time data
            chart_name.ChartAreas[0].AxisX.Minimum = sampled_data_sets[0][0];

            chart_name.ChartAreas[0].AxisX.Title = x_axis_label;
            chart_name.ChartAreas[0].AxisY.Title = y_axis_label;

            chart_name.ChartAreas[0].AxisX.LabelStyle.Format = "0.00";
        }

        public void plot_data_on_freq_chart(Chart chart_name, List<string> data_sets_names, List<List<double>> freq_span, List<List<double>> mag_values, string x_axis_label, string y_axis_label)
        {
            chart_name.Annotations.Clear();

            //List<List<double>> sampled_data_sets = sample_plotting_data(data_sets, chart_width);

            List<double> max_freqs = new List<double>();

            //create series and plot
            chart_name.Series.Clear();

            for (int i = 0; i < freq_span.Count; i++)
            {
                List<double> freq_temp = freq_span[i];
                freq_temp.RemoveAt(0);
                List<double> mag_temp = mag_values[i];
                mag_temp.RemoveAt(0);

                max_freqs.Add(get_actual_max_freq(freq_temp, mag_temp));

                System.Windows.Forms.DataVisualization.Charting.Series series = chart_name.Series.Add(data_sets_names[i] + " Freq. Resp.");
                series.ChartType = SeriesChartType.Line;
                series.Points.DataBindXY(freq_span[i], mag_values[i]);
                series.BorderWidth = 2;
                series.Color = signal_colors[data_direction_name.IndexOf(data_sets_names[i])];
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

            ////string ta1_text = string.Empty;
            ////for(int i =0; i< data_sets_names.Count;i++)
            ////{
            ////    ta1_text += data_sets_names[i] + ": " + max_freqs[i] + "Hz\n";
            ////}
            ////TextAnnotation ta1 = new TextAnnotation();
            ////ta1.Text = ta1_text;
            //////ta1.Alignment = ContentAlignment.TopRight;
            ////ta1.AnchorX = 70;
            ////ta1.AnchorY = 20;
            ////ta1.IsMultiline = true;
            ////ta1.ClipToChartArea=chart_name.ChartAreas[0].ToString();
            ////chart_name.Annotations.Add(ta1);

            //nat_freq_textbox.Text = ta1_text;
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
            line2.X = time_data_list[time_data_list.Count - 2];
            //add to the chart
            chart_name.Annotations.Add(line2);
        }

        public void draw_annotation_trim_lines_freq_plot(Chart chart_name, VerticalLineAnnotation line1, VerticalLineAnnotation line2, HorizontalLineAnnotation line3, HorizontalLineAnnotation line4)
        {
            double xmin = chart_name.ChartAreas[0].AxisX.Minimum;
            double xmax = chart_name.ChartAreas[0].AxisX.Maximum;

            double ymin = chart_name.ChartAreas[0].AxisY.Minimum;
            double ymax = chart_name.ChartAreas[0].AxisY.Maximum;

            chart_name.Annotations.Remove(line1);

            line1.AxisX = chart_name.ChartAreas[0].AxisX;
            line1.AllowMoving = true;
            line1.IsInfinitive = true;
            line1.ClipToChartArea = chart_name.ChartAreas[0].Name;
            //line1.Name = "line 1";
            line1.LineColor = Color.Purple;
            line1.LineWidth = 3;         // use your numbers!
            line1.X = xmin;
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
            line2.X = xmax;
            //add to the chart
            chart_name.Annotations.Add(line2);



            chart_name.Annotations.Remove(line3);

            line3.AxisY = chart_name.ChartAreas[0].AxisY;
            line3.AllowMoving = true;
            line3.IsInfinitive = true;
            line3.ClipToChartArea = chart_name.ChartAreas[0].Name;
            //line3.Name = "line 1";
            line3.LineColor = Color.Blue;
            line3.LineWidth = 3;         // use your numbers!
            line3.Y = ymin;
            //add to the chart
            chart_name.Annotations.Add(line3);

            // the vertical line and its properties
            //line2 = new VerticalLineAnnotation();

            chart_name.Annotations.Remove(line4);

            line4.AxisY = chart_name.ChartAreas[0].AxisY;
            line4.AllowMoving = true;
            line4.IsInfinitive = true;
            line4.ClipToChartArea = chart_name.ChartAreas[0].Name;
            //line4.Name = "line 2";
            line4.LineColor = Color.Blue;
            line4.LineWidth = 3;         // use your numbers!
            line4.Y = ymax;
            //add to the chart
            chart_name.Annotations.Add(line4);
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

        public void display_results_message_box()
        {
            string dataset_result_summary_text_concatenated = concat_dataset_results_summary();
            if (!String.IsNullOrEmpty(dataset_result_summary_text_concatenated))
            {
                string title = "Results Summary";
                FlexibleMessageBox.Show(dataset_result_summary_text_concatenated, title);
                //FlexibleMessageBox.
            }
        }

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

        public void update_program_after_input_folder_select()
        {


            //clear all visible UI elements
            summary_results_textbox.Clear();
            activity_log_textbox.Clear();
            signal_data_chart_main.Series.Clear();
            freq_dft_chart.Series.Clear();
            freq_peaks_chart.Series.Clear();

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

            Directory.CreateDirectory(input_folder + damping_reduction_data_object_storage_folder);

            activity_log("Input folder selected: " + input_folder);

            //update the output folder
            save_results_folder = input_folder + output_folder_name;

            //set selected input folder textbox to user selected folder
            input_folder_textbox.Text = input_folder;

            changes_cursor_icon_to_loading(true);

            //get user sample rate
            input_data_sample_rate = Convert.ToDouble(input_data_sample_rate_numupdown.Value);

            //scan_input_folder_for_datasets();
            scan_input_folder_for_datasets_and_convert_to_dataset_objects();

            //ALLOCATE BLANK LIST (not related to csv_input_filepaths_short)
            for (int i = 0; i < dataset_input_filepaths.Count; i++)
            {

                //add blank enrties for each possible loaded dataset (for the summary results list)
                dataset_result_summary_text_list.Add(string.Empty);
            }



            changes_cursor_icon_to_loading(false);
        }

        public void new_dataset_selected(int dataset_index)
        {
            nat_freq_textbox.Text = String.Empty;

            changes_cursor_icon_to_loading(true);

            current_dataset_filepath_label.Visible = true;
            current_dataset_filepath_label.Text = dataset_input_filepaths_short[dataset_index];

            //autosave the last dataset (if one loaded) and seriliaze it to a file
            //remove the corresponding csv from the combolist dropdown and add the new json file version of the last dataset
            save_dataset_object();

            //clear exsiting drd object
            drd = new damping_reduction_dataset();

            string dataset_filepath = dataset_input_filepaths[dataset_index];
            drd.dataset_input_filepath = dataset_input_filepaths[dataset_index];

            ////exisitng data set (.json file)
            //if (dataset_filepath.Contains(save_session_filetype))
            //{
            drd = deserialize_damping_reduction_dataset(dataset_filepath);
            //}
            ////if a csv (new dataset)
            //else
            //{
            //    //reset the global datset object
            //    drd = new damping_reduction_dataset();
            //    process_data_from_csv_file(dataset_filepath, ref drd);

            //    //allocate other variables of drd
            //    drd.data_direction_checkmark_tracker.Add(true);
            //    drd.data_direction_checkmark_tracker.Add(true);
            //    drd.data_direction_checkmark_tracker.Add(true);
            //    drd.data_direction_checkmark_tracker.Add(false);
            //    drd.data_direction_checkmark_tracker.Add(false);
            //    drd.data_direction_checkmark_tracker.Add(false);

            //}

            //send data to plot based on how much data has been processed recently
            if (drd.datasets_filter_trim.Count > 0)
            {
                plot_data_on_chart(signal_data_chart_main, data_direction_name, drd.datasets_filter_trim, "Time (Seconds)", y_axis_label_data_chart);
                //plot the trimming annotations
                draw_vertical_annotations(signal_data_chart_main, lower_data_boundary_vertical_line, upper_data_boundary_vertical_line, drd.datasets_filter_trim[0]);

                additonal_plots_manager(drd.datasets_filter_trim, drd.natural_freq_fft);

            }
            else if (drd.datasets_trim.Count > 0)
            {
                plot_data_on_chart(signal_data_chart_main, data_direction_name, drd.datasets_trim, "Time (Seconds)", y_axis_label_data_chart);
                //plot the trimming annotations
                draw_vertical_annotations(signal_data_chart_main, lower_data_boundary_vertical_line, upper_data_boundary_vertical_line, drd.datasets_trim[0]);

                additonal_plots_manager(drd.datasets_trim, drd.natural_freq_fft);
            }
            else
            {
                plot_data_on_chart(signal_data_chart_main, data_direction_name, drd.datasets_master, "Time (Seconds)", y_axis_label_data_chart);
                //plot the trimming annotations
                draw_vertical_annotations(signal_data_chart_main, lower_data_boundary_vertical_line, upper_data_boundary_vertical_line, drd.datasets_master[0]);

                additonal_plots_manager(drd.datasets_master, drd.natural_freq_fft);
            }





            enable_all_user_controls(true);

            //sets which data directions enabled (X,Y,Z directions only by default)
            populate_select_data_direction_checked_list(drd.data_direction_checkmark_tracker);

            //enable/disable the series in the main signal and few plots based on which data directions are checkmarked
            check_checked_chart_series();

            //clear results window
            summary_results_textbox.Text = string.Empty;

            //preform fft freq response analysis on all data sets
            List<double> nat_freqs = automatically_update_freq_repsonse_plot();

            update_bandpass_filter_cutoff_frequencies();

            scan_input_folder_for_datasets();

            for (int i = 0; i < freq_peaks_chart.Series.Count; i++)
            {
                freq_peaks_chart.Series[i].Enabled = true;
            }

            changes_cursor_icon_to_loading(false);
        }

        public void update_bandpass_filter_cutoff_frequencies()
        {
            List<double> selected_nat_freqs = new List<double>();

            for (int i = 0; i < drd.data_direction_checkmark_tracker.Count; i++)
            {
                if (drd.data_direction_checkmark_tracker[i] == true)
                {
                    selected_nat_freqs.Add(drd.natural_freq_fft[i]);
                }
            }

            if (selected_nat_freqs.Count == 0)
            {
                return;
            }

            //auto update the bandpass freqs is selected
            if (automaticFilterFrequencySelectionToolStripMenuItem.Checked == true)
            {



                low_freq_cutoff_numupdown.Value = Clamp(Convert.ToDecimal(selected_nat_freqs.Average() - Convert.ToDouble(bandpass_freq_buffer_choices_combobox.SelectedItem)), low_freq_cutoff_numupdown.Minimum, low_freq_cutoff_numupdown.Maximum);
                high_freq_cutoff_numupdown.Value = Clamp(Convert.ToDecimal(selected_nat_freqs.Average() + Convert.ToDouble(bandpass_freq_buffer_choices_combobox.SelectedItem)), high_freq_cutoff_numupdown.Minimum, high_freq_cutoff_numupdown.Maximum);
            }
        }

        public void process_data_from_csv_file(string current_selected_dataset_filepath, ref damping_reduction_dataset drs_dataset)
        {

            List<List<string>> csv_data_raw_string = load_csv_as_2d_list_string_cols(current_selected_dataset_filepath);

            //remove header row from data
            foreach (List<string> data in csv_data_raw_string)
            {
                data.RemoveAt(0);
            }
            //convert from string list to double list
            List<List<double>> csv_data_raw_double = convert_list_of_list_string_to_double(csv_data_raw_string, true);

            //converts the time data from ticks to seconds (1 tick = 1/1024 seconds)
            List<List<double>> csv_data_processed_double = convert_ticks_to_seconds(csv_data_raw_double);

            //remove data offsets
            for (int i = 1; i < csv_data_processed_double.Count; i++)
            {
                csv_data_processed_double[i] = remove_data_offset(csv_data_processed_double[i]);
            }

            //vector sum sets of 2 directions of data and add to main data set
            csv_data_processed_double = vector_sum_xyz_datasets(csv_data_processed_double);

            //store data into class object
            drs_dataset.datasets_master = csv_data_processed_double;
            drs_dataset.datasets_trim = csv_data_processed_double;


        }

        public void trim_data_function()
        {
            changes_cursor_icon_to_loading(true);

            clear_result_data_from_dataset_object(drd);

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

            if (drd.is_data_filtered == true && drd.datasets_filter_trim.Count > 0)
            {
                drd.lower_trim_index_x = find_closest_value(x_index_trim_lower, drd.datasets_filter_trim[0]);
                drd.upper_trim_index_x = find_closest_value(x_index_trim_upper, drd.datasets_filter_trim[0]);

                //get time value of of the horiz annotation and get the index of the time from the master time list
                drd.lower_trim_index_x_relative_master_dataset = drd.datasets_master[0].IndexOf(drd.datasets_filter_trim[0][find_closest_value(x_index_trim_lower, drd.datasets_trim[0])]);
                drd.upper_trim_index_x_relative_master_dataset = drd.datasets_master[0].IndexOf(drd.datasets_filter_trim[0][find_closest_value(x_index_trim_upper, drd.datasets_trim[0])]);
            }
            else
            {
                drd.lower_trim_index_x = find_closest_value(x_index_trim_lower, drd.datasets_trim[0]);
                drd.upper_trim_index_x = find_closest_value(x_index_trim_upper, drd.datasets_trim[0]);

                //get time value of of the horiz annotation and get the index of the time from the master time list
                drd.lower_trim_index_x_relative_master_dataset = drd.datasets_master[0].IndexOf(drd.datasets_trim[0][find_closest_value(x_index_trim_lower, drd.datasets_trim[0])]);
                drd.upper_trim_index_x_relative_master_dataset = drd.datasets_master[0].IndexOf(drd.datasets_trim[0][find_closest_value(x_index_trim_upper, drd.datasets_trim[0])]);
            }

            if (Math.Abs(drd.upper_trim_index_x - drd.lower_trim_index_x) < 15)
            {
                string message = "Cannot trim data to less than 15 data points";
                string title = "Error";
                FlexibleMessageBox.Show(message, title);
                return;
            }

            update_trimmed_input_data(drd.lower_trim_index_x, drd.upper_trim_index_x);

            ////add data to catalog
            //generic_input_data_double_clone_catalog[select_data_set_tool_strip_combo_box.SelectedIndex] = generic_input_data_double_clone;
            ////add data to catalog
            //if (is_data_filtered[select_data_set_tool_strip_combo_box.SelectedIndex])
            //{
            //    generic_input_data_double_clone_filtered_catalog[select_data_set_tool_strip_combo_box.SelectedIndex] = new List<List<double>>(generic_input_data_double_clone_filtered);
            //}

            if (drd.is_data_filtered == true && drd.datasets_filter_trim.Count > 0)
            {
                List<string> data_direction_name_filter = new List<string>();
                foreach (string name in data_direction_name)
                {
                    data_direction_name_filter.Add(name + " (Filt.)");
                }

                plot_data_on_chart(signal_data_chart_main, data_direction_name_filter, drd.datasets_filter_trim, "Time (Seconds)", y_axis_label_data_chart);
            }
            else
            {
                plot_data_on_chart(signal_data_chart_main, data_direction_name, drd.datasets_trim, "Time (Seconds)", y_axis_label_data_chart);
            }


            draw_vertical_annotations(signal_data_chart_main, lower_data_boundary_vertical_line, upper_data_boundary_vertical_line, drd.datasets_trim[0]);

            check_checked_chart_series();

            changes_cursor_icon_to_loading(false);
        }

        public void reset_to_master_dataset()
        {
            changes_cursor_icon_to_loading(true);

            clear_result_data_from_dataset_object(drd);

            //clear all visible UI elements
            summary_results_textbox.Clear();
            freq_dft_chart.Series.Clear();
            freq_peaks_chart.Series.Clear();


            //reset data so filtered data isnt filtered
            drd.is_data_filtered = false;

            drd.upper_trim_index_x = 0;
            drd.lower_trim_index_x = 0;

            drd.upper_trim_index_x_relative_master_dataset = 0;
            drd.lower_trim_index_x_relative_master_dataset = 0;

            //clone the master data set
            drd.datasets_trim = drd.datasets_master;

            //clear any filtered data
            drd.datasets_filter_trim.Clear();

            //plot data on chart
            plot_data_on_chart(signal_data_chart_main, data_direction_name, drd.datasets_trim, "Time (Seconds)", y_axis_label_data_chart);

            //plot the trimming annotations
            draw_vertical_annotations(signal_data_chart_main, lower_data_boundary_vertical_line, upper_data_boundary_vertical_line, drd.datasets_master[0]);

            check_checked_chart_series();

            //preform fft freq response analysis on all data sets
            automatically_update_freq_repsonse_plot();

            changes_cursor_icon_to_loading(false);
        }

        public void apply_bandpass_filter()
        {


            changes_cursor_icon_to_loading(true);

            drd.is_data_filtered = true;

            //copy trim data to filterted data for processing
            drd.datasets_filter_trim = new List<List<double>>(drd.datasets_trim);
            drd.datasets_master_filtered = new List<List<double>>(drd.datasets_master);

            //get cutoff freqs
            drd.low_cutoff_freq = Convert.ToDouble(low_freq_cutoff_numupdown.Value);
            drd.high_cutoff_freq = Convert.ToDouble(high_freq_cutoff_numupdown.Value);

            //create filter object
            var bandpass = MathNet.Filtering.IIR.OnlineIirFilter.CreateBandpass(ImpulseResponse.Finite, input_data_sample_rate, drd.low_cutoff_freq, drd.high_cutoff_freq, 0);

            //filter all datasets using the filter object
            for (int i = 0; i < drd.datasets_filter_trim.Count; i++)
            {
                if (i == 0)
                {
                    //if data set was actually trimmed the get the trimmed time set otherwise leave as is
                    if (drd.upper_trim_index_x > 0)
                    {
                        //drd.datasets_master_filtered.Add(drd.datasets_master[i]);
                        drd.datasets_filter_trim[0] = drd.datasets_master[i].GetRange(drd.lower_trim_index_x_relative_master_dataset, drd.upper_trim_index_x_relative_master_dataset - drd.lower_trim_index_x_relative_master_dataset);
                    }
                }
                else
                {
                    if (drd.upper_trim_index_x > 0)
                    {

                        //drd.datasets_filter_trim[i] = (bandpass.ProcessSamples(convert_double_list_to_array(drd.datasets_master[i])).ToList()).GetRange(drd.lower_trim_index_x_relative_master_dataset, drd.upper_trim_index_x_relative_master_dataset - drd.lower_trim_index_x_relative_master_dataset);
                        drd.datasets_master_filtered[i] = bandpass.ProcessSamples(convert_double_list_to_array(drd.datasets_master[i])).ToList();
                        drd.datasets_filter_trim[i] = drd.datasets_master_filtered[i].GetRange(drd.lower_trim_index_x_relative_master_dataset, drd.upper_trim_index_x_relative_master_dataset - drd.lower_trim_index_x_relative_master_dataset);
                    }
                    else
                    {

                        //drd.datasets_filter_trim[i] = (bandpass.ProcessSamples(convert_double_list_to_array(drd.datasets_trim[i])).ToList());
                        drd.datasets_master_filtered[i] = (bandpass.ProcessSamples(convert_double_list_to_array(drd.datasets_trim[i])).ToList());
                        drd.datasets_filter_trim[i] = drd.datasets_master_filtered[i];
                    }
                }
            }



            //recalulate vector sums after filtering
            if (recalculateVectorSumDataAfterApplyingFilterToolStripMenuItem.Checked == true)
            {
                //remove the existing vector summed data
                drd.datasets_filter_trim.RemoveAt(6);
                drd.datasets_filter_trim.RemoveAt(5);
                drd.datasets_filter_trim.RemoveAt(4);
                //vector sum sets of 2 directions of data and add to main data set
                drd.datasets_filter_trim = vector_sum_xyz_datasets(drd.datasets_filter_trim);
            }

            List<string> data_direction_name_filter = new List<string>();
            foreach (string name in data_direction_name)
            {
                data_direction_name_filter.Add(name + " (Filt.)");
            }


            //replot data
            plot_data_on_chart(signal_data_chart_main, data_direction_name_filter, drd.datasets_filter_trim, "Time (Seconds)", y_axis_label_data_chart);

            check_checked_chart_series();

            //add data to catalog
            //generic_input_data_double_clone_filtered_catalog[select_data_set_tool_strip_combo_box.SelectedIndex] = new List<List<double>>(generic_input_data_double_clone_filtered);

            changes_cursor_icon_to_loading(false);
        }

        public void remove_filter()
        {
            //reset data so filtered data isnt filtered
            drd.is_data_filtered = false;

            //replot data
            plot_data_on_chart(signal_data_chart_main, data_direction_name, drd.datasets_trim, "Time (Seconds)", y_axis_label_data_chart);

            check_checked_chart_series();
        }

        public void calculate_damping_ratio_and_frequency(Boolean recalculate_damp_ratio_trimmed_freq_values = false)
        {
            changes_cursor_icon_to_loading(true);

            current_selected_csv_checkedlistbox_index = select_data_set_tool_strip_combo_box.SelectedIndex;



            //start a timer to track how long calculations take
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();

            //results session tracker and sublists used for allocating data
            List<List<double>> session_results_tracker_sub_list = new List<List<double>>();
            List<double> session_results_tracker_sub_sub_list = new List<double>();

            //empty the results box
            summary_results_textbox.Text = string.Empty;
            // clear the freq plot
            freq_peaks_chart.Series.Clear();

            //keep the data if reculating the damping ratio with rtimmed frequency values
            if (recalculate_damp_ratio_trimmed_freq_values == false)
            {
                ////clear the freq plot data
                drd.natural_freq_dist_btwn_peaks.Clear();
                drd.local_maximas_indicies.Clear();
                drd.local_maximas_amplitudes.Clear();
                drd.local_maximas_times.Clear();
            }

            remove_non_signal_series_plot();

            //clear plotting values
            real_spectrum = new List<List<double>>();
            freq_span = new List<List<double>>();
            //create a list to store time values for plotting in the freq estimation window (peaks)
            List<double> time_dataset = new List<double>();

            results_summary_text = setup_dataset_results_string();


            //get the data set to perfom analysis on (filter or unfiltered)
            List<List<double>> selected_data_sets = new List<List<double>>();
            if (drd.is_data_filtered == true)
            {
                selected_data_sets = new List<List<double>>(drd.datasets_filter_trim);
                time_dataset = selected_data_sets[0];
            }
            else
            {
                selected_data_sets = new List<List<double>>(drd.datasets_trim);
                time_dataset = selected_data_sets[0];
            }
            //remove the time list from data to be processed
            selected_data_sets.RemoveAt(0);

            //preform fft freq response analysis on all data sets
            List<double> natural_frequencies = fft_analysis(selected_data_sets, data_direction_name);

            Console.WriteLine($"FFT Execution Time: {watch.ElapsedMilliseconds} ms");

            //recalculate the vector sum freqs by using the average of the compenent freqs
            natural_frequencies[3] = (natural_frequencies[0] + natural_frequencies[1]) / 2;
            natural_frequencies[4] = (natural_frequencies[0] + natural_frequencies[2]) / 2;
            natural_frequencies[5] = (natural_frequencies[1] + natural_frequencies[2]) / 2;

            drd.natural_freq_fft = natural_frequencies;

            //calulate dispalcements after calculating the natural frequencies                                          
            calculate_max_displacement_XYZ(drd);

            //add placeholder entries for directions that may not be calculated
            drd.natural_freq_dist_btwn_peaks_average.Clear();
            drd.damp_ratio_exp_fft_freq.Clear();
            drd.damp_ratio_exp_peaks.Clear();
            drd.cofefficient_of_determination.Clear();
            for (int i = 0; i < 6; i++)
            {
                drd.natural_freq_dist_btwn_peaks_average.Add(-1);
                drd.damp_ratio_exp_fft_freq.Add(-1);
                drd.damp_ratio_exp_peaks.Add(-1);
                drd.cofefficient_of_determination.Add(-1);
            }


            //add blank data for indexing purposes
            if (drd.natural_freq_dist_btwn_peaks.Count != 6)
            {
                for (int i = 0; i < selected_data_sets.Count; i++)
                {
                    drd.natural_freq_dist_btwn_peaks.Add(new List<double>());
                    drd.local_maximas_indicies.Add(new List<int>());
                    drd.local_maximas_amplitudes.Add(new List<double>());
                    drd.local_maximas_times.Add(new List<double>());
                }
            }

            //after the natural frequencies have been analyzed run loop to get results
            //ddi = data_direction_index
            for (int ddi = 0; ddi < selected_data_sets.Count; ddi++)
            {


                //checked to see if the data direction is checked if not skip the calculation
                if (drd.data_direction_checkmark_tracker[ddi] == true)
                {
                    //create an absoluted data set for the analysis
                    List<double> selected_data_set_abs = new List<double>();
                    for (int i = 0; i < selected_data_sets[ddi].Count; i++)
                    {
                        selected_data_set_abs.Add(Math.Abs(selected_data_sets[ddi][i]));
                    }

                    //alloacate variables
                    int window_size = 0;

                    //if the trimmed freq est. window has been trimmed then dont recalculate the peaks freqs
                    if (recalculate_damp_ratio_trimmed_freq_values == false)
                    {

                        //window size to is the range to search for the local maximas
                        //windows size is determined by the freq/2 since the data is absolutred

                        //check if user wants to use their manual frequency for window size of peak picker
                        if (manual_freq_est_checkbox.Checked == true)
                        {
                            window_size = Convert.ToInt32(Math.Round(((1 / Convert.ToDouble(manual_freq_est_numupdown.Value)) * input_data_sample_rate * 0.95) / 2));
                        }
                        else
                        {
                            window_size = Convert.ToInt32(Math.Round(((1 / natural_frequencies[ddi]) * input_data_sample_rate * 0.95) / 2));
                        }

                        Console.WriteLine($"Timestamp before maximas calculation: {watch.ElapsedMilliseconds} ms");

                        //calaculte the local maxima indicies of  thedataset
                        if (peak_picking_method_combobox.SelectedIndex == 1)
                        {
                            drd.local_maximas_indicies[ddi] = find_local_maximas1(selected_data_set_abs, window_size);
                        }
                        else
                        {
                            drd.local_maximas_indicies[ddi] = (Accord.Audio.Tools.FindPeaks(selected_data_set_abs.ToArray())).ToList();
                        }

                        //get the corresponding time values for the maxima indeicies
                        for (int i = 0; i < drd.local_maximas_indicies[ddi].Count; i++)
                        {
                            drd.local_maximas_times[ddi].Add(time_dataset[drd.local_maximas_indicies[ddi][i]]);
                        }

                        Console.WriteLine($"Local Maximas Execution Time: {watch.ElapsedMilliseconds} ms");

                        //poor data quality with onlyy three indices, quit and move onto the next dataset
                        if (drd.local_maximas_indicies[ddi].Count <= 3)
                        {
                            results_summary_text = results_summary_text + "The poor quality of the " + data_direction_name[ddi] + " direction data resulted in no meaningful peaks extracted and the calculations were skipped.\r\n\r\n";
                            continue;
                        }

                        //plot the peak values and return the amplitudes
                        drd.local_maximas_amplitudes[ddi] = plot_peaks_chart(drd.local_maximas_indicies[ddi], selected_data_set_abs, data_direction_name[ddi] + " Peaks", ddi);

                        //create a temp list for drd.local_maximas_times[ddi] (cannot pass a property)
                        List<double> local_maximas_times_temp = new List<double>(drd.local_maximas_times[ddi]);
                        //calaculate the freqs based upon the distance between the located local peaks (also removes outlier data)
                        drd.natural_freq_dist_btwn_peaks[ddi] = calculate_natural_frequency_peaks(ref local_maximas_times_temp, drd.local_maximas_indicies[ddi], input_data_sample_rate, data_direction_name[ddi]);
                        //reassign the temp value back to the dataset object
                        drd.local_maximas_times[ddi] = new List<double>(local_maximas_times_temp);

                        Console.WriteLine($"Plot found peaks and their freqs Execution Time: {watch.ElapsedMilliseconds} ms");

                    }
                    else
                    {

                        plot_peaks_chart(drd.local_maximas_indicies[ddi], selected_data_set_abs, data_direction_name[ddi] + " Peaks", ddi);

                        plot_freq_peaks_response(drd.local_maximas_times[ddi], drd.natural_freq_dist_btwn_peaks[ddi], data_direction_name[ddi]);


                        if (drd.natural_freq_dist_btwn_peaks[ddi].Count == 0 || drd.local_maximas_indicies[ddi].Count == 0 || drd.local_maximas_amplitudes[ddi].Count == 0)
                        {
                            string title = "Error";
                            FlexibleMessageBox.Show("Not enough trimmed points in the selected frequency estimation plot window", title);
                            return;
                        }

                    }

                    if (drd.natural_freq_dist_btwn_peaks[ddi].Count == 0)
                    {
                        string message = "There was an error with the quality of the frequency estimation data " + data_direction_name[ddi] + "(distance between peaks).";
                        string title = "Error";
                        FlexibleMessageBox.Show(message, title);
                        return;
                    }

                    //average all calculated freqs
                    double average_natural_frequency_peaks = drd.natural_freq_dist_btwn_peaks[ddi].Average();
                    drd.natural_freq_dist_btwn_peaks_average[ddi] = average_natural_frequency_peaks;

                    ////gather the data points of the local maximas for the absoluted dataset
                    exp_curve_fit_and_plot(ddi, selected_data_set_abs, natural_frequencies);

                    Console.WriteLine($"Plot Exp. curve Execution Time: {watch.ElapsedMilliseconds} ms");

                    results_summary_text = results_summary_text + append_dataset_results_string(ddi);


                    ////save resulsts into resulst session tracker
                    //session_results_tracker_sub_sub_list.Add(natural_frequencies[ddi]);
                    //session_results_tracker_sub_sub_list.Add(peak_freqs[ddi]);
                    //session_results_tracker_sub_sub_list.Add(damp_ratio_exp_fft_freq * 100);
                    //session_results_tracker_sub_sub_list.Add(damp_ratio_exp_peaks * 100);
                    //session_results_tracker_sub_sub_list.Add(coffecient_of_determination);
                }
                else
                {
                    //when the data direction is not selected
                    session_results_tracker_sub_sub_list = new List<double>();
                    //for(int ind=0;ind<5; ind++)
                    //{
                    //    //add empty null data
                    //    session_results_tracker_sub_sub_list.Add(0);
                    //}
                }
                session_results_tracker_sub_list.Add(session_results_tracker_sub_sub_list);
                session_results_tracker_sub_sub_list = new List<double>();

            }
            //session_results_tracker[current_selected_csv_checkedlistbox_index] = session_results_tracker_sub_list;
            session_results_tracker_sub_list = new List<List<double>>();

            drd.dataset_result_summary = results_summary_text; ;
            summary_results_textbox.Text = results_summary_text;

            Console.WriteLine($"Finished Execution Time: {watch.ElapsedMilliseconds} ms");

            //draw the annoation trim lines on the peaks freqs plot
            draw_annotation_trim_lines_freq_plot(freq_peaks_chart, freq_peaks_trim_vertical_line_1, freq_peaks_trim_vertical_line_2, freq_peaks_trim_horizontal_line_1, freq_peaks_trim_horizontal_line_2);

            update_chart_screenshot_tracker();

            changes_cursor_icon_to_loading(false);
        }

        public void recalculate_damping_ratio_and_frequency()
        {
            //check if there is data loaded into the freq estimation (distance between peaks window)
            if (freq_peaks_chart.Series.Count <= 0)
            {
                string message = "The ' " + calculate_damp_ratio_and_freq_button.Text + " ' button must be clicked first for the current dataset first before trimming frequency dataset(s)";
                string title = "Error";
                FlexibleMessageBox.Show(message, title);
                return;
            }


            //get index/values of annotation trim lines and do some boundry checking

            int xmax = 0;
            int xmin = 0;
            double ymax = 0;
            double ymin = 0;

            if (freq_peaks_trim_vertical_line_1.X > freq_peaks_trim_vertical_line_2.X)
            {
                xmax = Convert.ToInt32(Math.Floor(freq_peaks_trim_vertical_line_1.X));
                xmin = Convert.ToInt32(Math.Ceiling(freq_peaks_trim_vertical_line_2.X));
            }
            else
            {
                xmax = Convert.ToInt32(Math.Floor(freq_peaks_trim_vertical_line_2.X));
                xmin = Convert.ToInt32(Math.Ceiling(freq_peaks_trim_vertical_line_1.X));
            }


            if (freq_peaks_trim_horizontal_line_1.Y > freq_peaks_trim_horizontal_line_2.Y)
            {
                ymax = freq_peaks_trim_horizontal_line_1.Y;
                ymin = freq_peaks_trim_horizontal_line_2.Y;
            }
            else
            {
                ymax = freq_peaks_trim_horizontal_line_2.Y;
                ymin = freq_peaks_trim_horizontal_line_1.Y;
            }



            //trim values
            for (int i = 0; i < drd.natural_freq_dist_btwn_peaks.Count; i++)
            {
                for (int j = drd.natural_freq_dist_btwn_peaks[i].Count - 1; j >= 0; j--)
                {
                    if (drd.local_maximas_times[i][j] > xmax || drd.local_maximas_times[i][j] < xmin)
                    {
                        drd.local_maximas_indicies[i].RemoveAt(j);
                        drd.natural_freq_dist_btwn_peaks[i].RemoveAt(j);
                        drd.local_maximas_amplitudes[i].RemoveAt(j);
                        drd.local_maximas_times[i].RemoveAt(j);

                        continue;
                    }
                    if (drd.natural_freq_dist_btwn_peaks[i][j] > ymax || drd.natural_freq_dist_btwn_peaks[i][j] < ymin)
                    {

                        drd.local_maximas_indicies[i].RemoveAt(j);
                        drd.natural_freq_dist_btwn_peaks[i].RemoveAt(j);
                        drd.local_maximas_amplitudes[i].RemoveAt(j);
                        drd.local_maximas_times[i].RemoveAt(j);
                        continue;
                    }
                }
            }

            calculate_damping_ratio_and_frequency(true);


            //draw the annoation trim lines on the peaks freqs plot
            draw_annotation_trim_lines_freq_plot(freq_peaks_chart, freq_peaks_trim_vertical_line_1, freq_peaks_trim_vertical_line_2, freq_peaks_trim_horizontal_line_1, freq_peaks_trim_horizontal_line_2);
        }

        //export data functions
        public void export_results_dataset_object(damping_reduction_dataset c_drd)
        {
            //if (c_drd.datasets_master.Count == 0 || c_drd.natural_freq_fft.Count == 0 )
            //{
            //    string message = "There is no dataset to export for "+c_drd.dataset_input_filepath_short;
            //    string title = "Error";
            //    FlexibleMessageBox.Show(message, title);
            //    return;
            //}

            //get timestamps of trimmed data
            double first_timestamp = Math.Round(c_drd.datasets_trim[0][0], 1);
            double second_timestamp = Math.Round(c_drd.datasets_trim[0][c_drd.datasets_trim[0].Count - 1], 1);

            //round the cutoff freqs
            double cutoff_freq_1 = Math.Round(c_drd.low_cutoff_freq, 1);
            double cutoff_freq_2 = Math.Round(c_drd.high_cutoff_freq, 2);

            //get dataset name
            string dataset_name = get_filename_from_filepath(c_drd.dataset_input_filepath_short);
            string dataset_name_trimmed = dataset_name + "[" + first_timestamp + "s - " + second_timestamp + "s]";
            string dataset_name_trimmed_filtered = dataset_name_trimmed + "[" + cutoff_freq_1 + "Hz - " + cutoff_freq_2 + "Hz]";

            //create the folder
            Directory.CreateDirectory(save_results_folder);

            string save_results_folder_subfolder = save_results_folder + dataset_name + @"\";
            //create the folder
            Directory.CreateDirectory(save_results_folder_subfolder);

            save_results_folder_subfolder = save_results_folder_subfolder + (DateTime.Now.ToString().Replace(":", "_")).Replace("/", "_") + @"\";
            Directory.CreateDirectory(save_results_folder_subfolder);

            if (!Directory.Exists(save_results_folder_subfolder))
            {
                return;
            }

            //export the datasets

            //unedited dataset
            process_save_dataset_as_csv(c_drd.datasets_master, save_results_folder_subfolder + dataset_name + " Acc Data[Unedited].csv");
            //if (c_drd.datasets_trim.Count > 0)
            //{
            //    //trimmed dataset
            //    process_save_dataset_as_csv(c_drd.datasets_trim, save_results_folder_subfolder + dataset_name_trimmed + " Acc Data[Trim].csv");
            //}
            //if (c_drd.datasets_filter_trim.Count > 0)
            //{
            //    //trimed/filtered dataset
            //    process_save_dataset_as_csv(c_drd.datasets_filter_trim, save_results_folder_subfolder + dataset_name_trimmed_filtered + " Acc Data[Filt Trim].csv");
            //}

            //export peaks as csv file
            List<List<string>> peaks_string_data = export_peaks_csv(c_drd);
            process_save_dataset_as_csv(peaks_string_data, save_results_folder_subfolder + dataset_name + " Peaks.csv");


            //string dataset_result_summary_text_concatenated = concat_dataset_results_summary();
            File.WriteAllText(save_results_folder_subfolder + "Summary Results.txt", c_drd.dataset_result_summary);

            //string dataset_name = get_filename_from_filepath(csv_input_filepaths_short[catalog_index]);  

            //try catch is temeportray until it stopps calling uncproccesed datasets to be exported
            //try
            //{
            export_image_streams_chart_screenshot_tracker(c_drd, save_results_folder_subfolder);
            //}
            //catch { }

        }

        public void export_results_all_dataset_objects()
        {
            session_results_tracker.Clear();

            //store which datasets arent exported
            string datasets_not_exported = string.Empty;

            for (int i = 0; i < dataset_input_filepaths.Count; i++)
            {
                if (dataset_input_filepaths[i].Contains(dataset_object_file_extension))
                {
                    damping_reduction_dataset drd_temp = deserialize_damping_reduction_dataset(dataset_input_filepaths[i]);

                    //check if the dataset is valid to export (contains data)
                    if (drd_temp.datasets_master.Count == 0 || drd_temp.natural_freq_fft.Count == 0)
                    {
                        datasets_not_exported += drd_temp.dataset_input_filepath_short + "\n\r";
                    }
                    else
                    {
                        //grab the data from loaded drd and save to session tracker
                        get_session_result_data_from_drd(drd_temp);
                        export_results_dataset_object(drd_temp);
                    }
                }
            }
            //if datasets were found to not be exported make a message box
            if (!String.IsNullOrEmpty(datasets_not_exported))
            {
                string message = "There is no dataset to export for: \n\r " + datasets_not_exported;
                string title = "Error";
                FlexibleMessageBox.Show(message, title);
            }
            export_session_results_to_csv(input_folder + output_folder_name, "Damping Reduction Results");
        }

        public void get_session_result_data_from_drd(damping_reduction_dataset drd_temp)
        {
            List<List<double>> session_results_tracker_sub_list = new List<List<double>>();

            if (drd_temp.natural_freq_fft.Count == 6)
            {
                for (int i = 0; i < 6; i++)
                {
                    List<double> session_results_tracker_sub_sub_list = new List<double>();
                    //save resulsts into resulst session tracker
                    session_results_tracker_sub_sub_list.Add(drd_temp.natural_freq_fft[i]);
                    session_results_tracker_sub_sub_list.Add(drd_temp.natural_freq_dist_btwn_peaks_average[i]);
                    session_results_tracker_sub_sub_list.Add(drd_temp.damp_ratio_exp_fft_freq[i]);
                    session_results_tracker_sub_sub_list.Add(drd_temp.damp_ratio_exp_peaks[i]);
                    session_results_tracker_sub_sub_list.Add(drd_temp.cofefficient_of_determination[i]);
                    session_results_tracker_sub_sub_list.Add(drd_temp.max_displacement[i]);

                    if (session_results_tracker_sub_sub_list.Contains(-1))
                    {
                        //add a zero if there is any uncalculated values
                        session_results_tracker_sub_list.Add(new List<double>(0));
                    }
                    else
                    {
                        session_results_tracker_sub_list.Add(new List<double>(session_results_tracker_sub_sub_list));
                    }

                }
                session_results_tracker.Add(session_results_tracker_sub_list);
            }

        }


        //program control sub functions

        public void scan_input_folder_for_datasets()
        {
            if (string.IsNullOrEmpty(input_folder))
            {
                return;
            }

            dataset_input_filepaths.Clear();
            //get all dataset files (within user folder) and save to a list
            dataset_input_filepaths = Directory.GetFiles(input_folder, "*.*", System.IO.SearchOption.AllDirectories).Where(s => s.EndsWith(dataset_object_file_extension) || s.EndsWith(".csv")).ToList();

            //removes output files if option is selected
            if (importcsvFilesFromOutputFolderWhenSelectingToolStripMenuItem.Checked == false)
            {
                //remove files located in the output folder
                for (int i = dataset_input_filepaths.Count - 1; i >= 0; i--)
                {
                    if (dataset_input_filepaths[i].Contains(output_folder_name) == true)
                    {
                        dataset_input_filepaths.RemoveAt(i);
                    }
                }
            }

            //save list of old csv_filepaths short
            List<string> csv_input_filepaths_short_old = new List<string>(dataset_input_filepaths_short);

            //create a short version of all found csv files
            dataset_input_filepaths_short.Clear();
            dataset_input_filepaths_short = new List<string>();
            for (int i = 0; i < dataset_input_filepaths.Count; i++)
            {
                //add a text tag to indicate to user that its a pre existing dataset file
                string file_path_short_temp = dataset_input_filepaths[i].Replace(input_folder, String.Empty);
                //if (file_path_short_temp.Contains(dataset_object_file_extension))
                //{
                //    file_path_short_temp += " [Dataset Object]";
                //}
                dataset_input_filepaths_short.Add(file_path_short_temp);
            }


            List<int> index_remove_list = new List<int>();
            for (int i = (dataset_input_filepaths.Count - 1); i >= 0; i--)
            {
                //remove csv files that already have a corresponding json file
                if (dataset_input_filepaths[i].Contains(dataset_object_file_extension))
                {
                    string json_filename = get_filename_from_filepath(dataset_input_filepaths[i]);

                    for (int j = 0; j < dataset_input_filepaths.Count; j++)
                    {

                        string csv_filename = get_filename_from_filepath(dataset_input_filepaths[j]);

                        if (j != i && json_filename == csv_filename)
                        {
                            index_remove_list.Add(j);
                            //csv_input_filepaths.RemoveAt(j);
                            //csv_input_filepaths_short.RemoveAt(j);
                        }
                    }
                }
            }
            //remove the repeated input files
            foreach (int index in index_remove_list)
            {
                dataset_input_filepaths.RemoveAt(index);
                dataset_input_filepaths_short.RemoveAt(index);
            }

            ////save the selected data names
            //string temp_dataset_name = String.Empty;
            //if (select_data_set_tool_strip_combo_box.Items.Count > 0)
            //{
            //    temp_dataset_name= select_data_set_tool_strip_combo_box.SelectedItem.ToString();
            //}
            //int temp_dataset_index = -1;

            //add short csv files names to combolist dropdown box
            select_data_set_tool_strip_combo_box.Items.Clear();
            for (int i = 0; i < dataset_input_filepaths.Count; i++)
            {
                select_data_set_tool_strip_combo_box.Items.Add(dataset_input_filepaths_short[i]);
            }

        }

        public void scan_input_folder_for_datasets_and_convert_to_dataset_objects()
        {
            if (string.IsNullOrEmpty(input_folder))
            {
                return;
            }

            dataset_input_filepaths.Clear();
            //get all dataset files (within user folder) and save to a list
            //csv_input_filepaths = Directory.GetFiles(input_folder, "*.*", System.IO.SearchOption.AllDirectories).Where(s => s.EndsWith(save_session_filetype) || s.EndsWith(".csv")).ToList();
            dataset_input_filepaths = Directory.GetFiles(input_folder, "*.*", System.IO.SearchOption.AllDirectories).Where(s => s.EndsWith(".csv") || s.EndsWith(dataset_object_file_extension)).ToList();



            //removes output files if option is selected
            if (importcsvFilesFromOutputFolderWhenSelectingToolStripMenuItem.Checked == false)
            {
                //remove files located in the output folder
                for (int i = dataset_input_filepaths.Count - 1; i >= 0; i--)
                {
                    if (dataset_input_filepaths[i].Contains(output_folder_name) == true)
                    {
                        dataset_input_filepaths.RemoveAt(i);
                    }
                }
            }

            ////save list of old csv_filepaths short
            //List<string> csv_input_filepaths_short_old = new List<string>(csv_input_filepaths_short);

            //create a short version of all found csv files
            dataset_input_filepaths_short.Clear();
            dataset_input_filepaths_short = new List<string>();
            for (int i = 0; i < dataset_input_filepaths.Count; i++)
            {
                //add a text tag to indicate to user that its a pre existing dataset file
                string file_path_short_temp = dataset_input_filepaths[i].Replace(input_folder, String.Empty);
                //if (file_path_short_temp.Contains(save_session_filetype))
                //{
                //    file_path_short_temp += " [Dataset Object]";
                //}
                dataset_input_filepaths_short.Add(file_path_short_temp);
            }


            List<int> index_remove_list = new List<int>();
            for (int i = (dataset_input_filepaths.Count - 1); i >= 0; i--)
            {
                //remove csv files that already have a corresponding json file
                if (dataset_input_filepaths[i].Contains(dataset_object_file_extension))
                {
                    string json_filename = get_filename_from_filepath(dataset_input_filepaths[i]);

                    for (int j = 0; j < dataset_input_filepaths.Count; j++)
                    {

                        string csv_filename = get_filename_from_filepath(dataset_input_filepaths[j]);

                        if (j != i && json_filename == csv_filename)
                        {
                            index_remove_list.Add(j);
                            //csv_input_filepaths.RemoveAt(j);
                            //csv_input_filepaths_short.RemoveAt(j);
                        }
                    }
                }
            }
            //remove the repeated input files
            foreach (int index in index_remove_list)
            {
                dataset_input_filepaths.RemoveAt(index);
                dataset_input_filepaths_short.RemoveAt(index);
            }

            //count the ramining csv files found
            int remaining_csv_files = 0;
            for (int i = 0; i < dataset_input_filepaths.Count; i++)
            {
                if (dataset_input_filepaths[i].Contains(".csv"))
                {
                    remaining_csv_files += 1;
                }
            }

            if (remaining_csv_files > 0)
            {
                //cycle through each csv dataset and convert it to a drd object and save it the drd object folder
                for (int i = 0; i < dataset_input_filepaths.Count; i++)
                {
                    load_csv_dataset_and_save_as_dataset_object(dataset_input_filepaths[i], dataset_input_filepaths_short[i]);
                }
            }

            //search folder again for only .drd objects (json) and add them to the combolist dropdown
            dataset_input_filepaths.Clear();
            dataset_input_filepaths_short.Clear();
            //get all dataset files (within user folder) and save to a list
            dataset_input_filepaths = Directory.GetFiles(input_folder, "*.*", System.IO.SearchOption.AllDirectories).Where(s => s.EndsWith(dataset_object_file_extension)).ToList();

            if (dataset_input_filepaths.Count == 0)
            {
                string message = "There are no compatible datasets in the input folder";
                string title = "Error";
                FlexibleMessageBox.Show(message, title);
                return;
            }

            for (int i = 0; i < dataset_input_filepaths.Count; i++)
            {
                string file_path_short_temp = dataset_input_filepaths[i].Replace(input_folder, String.Empty);
                dataset_input_filepaths_short.Add(file_path_short_temp);
            }

            //add short csv files names to combolist dropdown box
            select_data_set_tool_strip_combo_box.Items.Clear();
            for (int i = 0; i < dataset_input_filepaths.Count; i++)
            {
                select_data_set_tool_strip_combo_box.Items.Add(dataset_input_filepaths_short[i]);
            }

        }

        public void save_dataset_on_form_close()
        {
            //if there is valid data
            if (drd.datasets_trim.Count > 0 || drd.datasets_filter_trim.Count > 0)
            {
                string message = "Did you want save your dataset object?";
                string title = "Exit";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.Yes)
                {
                    save_dataset_object();
                }

            }
        }

        public void clear_result_data_from_dataset_object(damping_reduction_dataset c_drd)
        {
            c_drd.natural_freq_dist_btwn_peaks = new List<List<double>>();

            c_drd.local_maximas_indicies = new List<List<int>>();
            c_drd.local_maximas_amplitudes = new List<List<double>>();
            c_drd.local_maximas_times = new List<List<double>>();


            c_drd.natural_freq_dist_btwn_peaks_average = new List<double>();
            c_drd.damp_ratio_exp_fft_freq = new List<double>();
            c_drd.damp_ratio_exp_peaks = new List<double>();
            c_drd.cofefficient_of_determination = new List<double>();

            c_drd.dataset_result_summary = string.Empty;
        }

        //utility functions

        public void additonal_plots_manager(List<List<double>> selected_data_sets, List<double> natural_frequencies)
        {
            freq_peaks_chart.Series.Clear();


            //List<List<double>> all_selected_data_set_abs = new List<double>();
            for (int ddi = 0; ddi < 6; ddi++)
            {
                if (drd.local_maximas_indicies.Count > 0 && drd.local_maximas_indicies[ddi].Count > 0 && drd.local_maximas_amplitudes[ddi].Count > 0 && drd.local_maximas_times[ddi].Count > 0)
                {
                    //create an absoluted data set for the analysis
                    List<double> single_selected_data_set_abs = new List<double>();
                    for (int i = 0; i < selected_data_sets[ddi + 1].Count; i++)
                    {
                        single_selected_data_set_abs.Add(Math.Abs(selected_data_sets[ddi + 1][i]));
                    }
                    //all_selected_data_set_abs.Add(single_selected_data_set_abs);

                    //plot peaks
                    plot_peaks_chart(drd.local_maximas_indicies[ddi], single_selected_data_set_abs, data_direction_name[ddi] + " Peaks", ddi);

                    //exp curve fit plot
                    exp_curve_fit_and_plot(ddi, single_selected_data_set_abs, natural_frequencies);

                    //plot the freq peaks response
                    plot_freq_peaks_response(drd.local_maximas_times[ddi], drd.natural_freq_dist_btwn_peaks[ddi], data_direction_name[ddi]);
                }

            }
        }

        public void remove_non_signal_series_plot()
        {
            for (int i = signal_data_chart_main.Series.Count - 1; i > 5; i--)
            {
                //signal_data_chart_main.Series[i].Points.Clear();
                signal_data_chart_main.Series.RemoveAt(i);
            }
        }

        public void update_chart_screenshot_tracker()
        {
            //List<MemoryStream> temp_list = new List<MemoryStream>();

            //test//
            //List<Image> temp_list2 = new List<Image>();
            List<Byte[]> temp_list3 = new List<Byte[]>();

            //allocating streams
            MemoryStream image_stream_1 = new MemoryStream();
            MemoryStream image_stream_2 = new MemoryStream();
            MemoryStream image_stream_3 = new MemoryStream();

            signal_data_chart_main.SaveImage(image_stream_1, ChartImageFormat.Png);
            freq_dft_chart.SaveImage(image_stream_2, ChartImageFormat.Png);
            freq_peaks_chart.SaveImage(image_stream_3, ChartImageFormat.Png);

            drd.chart_screenshot_tracker_byte_array.Clear();

            drd.chart_screenshot_tracker_byte_array.Add((image_stream_1).ToArray());
            drd.chart_screenshot_tracker_byte_array.Add((image_stream_2).ToArray());
            drd.chart_screenshot_tracker_byte_array.Add((image_stream_3).ToArray());

        }

        public void exp_curve_fit_and_plot(int ddi, List<double> selected_data_set_abs, List<double> natural_frequencies)
        {
            //gather the data points of the local maximas for the absoluted dataset
            List<double> time_maximas = new List<double>();
            List<double> selected_data_set_maximas = new List<double>();
            for (int i = 0; i < drd.local_maximas_indicies[ddi].Count; i++)
            {
                if (drd.local_maximas_indicies[ddi][i] < drd.datasets_trim[0].Count - 1 && drd.local_maximas_indicies[ddi][i] < selected_data_set_abs.Count - 1)
                {
                    time_maximas.Add(drd.datasets_trim[0][drd.local_maximas_indicies[ddi][i]]);
                    selected_data_set_maximas.Add(selected_data_set_abs[drd.local_maximas_indicies[ddi][i]]);
                }
            }

            //y=p[0] e ^ (p[1] *x)
            //returns the coeffcienets of the fitted curve
            List<double> p_exp_coeff = exponential_curve_fit(time_maximas, selected_data_set_maximas);

            double damp_ratio_exp_fft_freq = 0;
            double damp_ratio_exp_peaks = 0;
            //using fft freq
            damp_ratio_exp_fft_freq = Math.Abs(p_exp_coeff[1] / (2 * Math.PI * natural_frequencies[ddi]));
            //using peaks freq
            damp_ratio_exp_peaks = Math.Abs(p_exp_coeff[1] / (2 * Math.PI * drd.natural_freq_dist_btwn_peaks_average[ddi]));

            drd.damp_ratio_exp_fft_freq[ddi] = damp_ratio_exp_fft_freq * 100;
            drd.damp_ratio_exp_peaks[ddi] = damp_ratio_exp_peaks * 100;

            List<double> exp_curve_fit_values = plot_fitted_exponential_curve(p_exp_coeff[0], p_exp_coeff[1], data_direction_name[ddi], ddi);

            double coffecient_of_determination = calculate_coffecient_of_determination(drd.local_maximas_amplitudes[ddi], exp_curve_fit_values, drd.local_maximas_indicies[ddi]);
            drd.cofefficient_of_determination[ddi] = coffecient_of_determination;
        }

        public string setup_dataset_results_string()
        {
            //get timestamps of trimmed data
            double first_timestamp = Math.Round(drd.datasets_trim[0][0], 1);
            double second_timestamp = Math.Round(drd.datasets_trim[0][drd.datasets_trim[0].Count - 1], 1);

            //set header for text file
            string results_summary_text = header_border;
            results_summary_text = results_summary_text + drd.dataset_input_filepath_short + "\r\n";
            results_summary_text = results_summary_text + header_border;
            results_summary_text = results_summary_text + "Trimmed from " + first_timestamp + " seconds to " + second_timestamp + " seconds.\r\n";
            if (drd.is_data_filtered == true)
            {
                results_summary_text = results_summary_text + "The data sets were bandpass filtered with cutoff frequencies of " + Math.Round(drd.low_cutoff_freq, 3) + " Hz and " + Math.Round(drd.high_cutoff_freq, 3) + " Hz.\r\n";
                results_summary_text = results_summary_text + header_border;
            }
            results_summary_text = results_summary_text + "\r\n";
            return results_summary_text;
        }

        public string append_dataset_results_string(int ddi)
        {
            //compile the resuluts into a a string
            string results_summary_text = "The natural frequency of the " + data_direction_name[ddi] + " direction data set was calculated using 2 methods:\r\n";
            results_summary_text = results_summary_text + "DFT: " + Math.Round(drd.natural_freq_fft[ddi], 6) + " Hz. \r\n";
            results_summary_text = results_summary_text + "Peaks: " + Math.Round(drd.natural_freq_dist_btwn_peaks_average[ddi], 6) + " Hz. \r\n\r\n";
            if (ddi > 2)
            {
                results_summary_text = results_summary_text + "Note that the vector sum freqs. were calculated using the average of the 2 component freqs. for the dft method\r\n\r\n";
            }
            results_summary_text = results_summary_text + "The damping ratio of the " + data_direction_name[ddi] + " direction data set was calculated using 2 methods:\r\n";

            results_summary_text = results_summary_text + "Exp. Curve Fit (using DFT freq.): " + Math.Round(drd.damp_ratio_exp_fft_freq[ddi], 3) + "%\r\n";
            results_summary_text = results_summary_text + "Exp. Curve Fit (using Peaks freq.): " + Math.Round(drd.damp_ratio_exp_peaks[ddi], 3) + "%\r\n\r\n";

            results_summary_text = results_summary_text + "Max Displacement (using DFT freq.): " + Math.Round(drd.max_displacement[ddi], 3) + " m\r\n\r\n";

            results_summary_text = results_summary_text + "The R Squared value of the exp. curve fit is (" + data_direction_name[ddi] + " direction): " + Math.Round(drd.cofefficient_of_determination[ddi], 3) + "\r\n\r\n";
            results_summary_text = results_summary_text + header_border + "\r\n\r\n";
            return results_summary_text;
        }

        public void save_dataset_object()
        {
            //check if existing drd object has signal data and a valid csv_filepath

            if (drd.datasets_master.Count > 0 && !String.IsNullOrEmpty(drd.dataset_input_filepath))
            {
                string save_filepath = input_folder + damping_reduction_data_object_storage_folder + get_filename_from_filepath(drd.dataset_input_filepath_short) + dataset_object_file_extension;
                serialize_damping_reduction_dataset(drd, save_filepath);
            }

            activity_log(drd.dataset_input_filepath_short + " saved");
        }

        public void load_csv_dataset_and_save_as_dataset_object(string csv_filepath, string csv_filepath_short)
        {
            //check if csv file
            if (csv_filepath.Contains(".csv") != true)
            {
                return;
            }

            //reset the global datset object
            damping_reduction_dataset drd_temp = new damping_reduction_dataset();
            process_data_from_csv_file(csv_filepath, ref drd_temp);


            drd_temp.dataset_input_filepath = csv_filepath;
            drd_temp.dataset_input_filepath_short = csv_filepath_short;

            //allocate other variables of drd
            drd_temp.data_direction_checkmark_tracker.Add(true);
            drd_temp.data_direction_checkmark_tracker.Add(true);
            drd_temp.data_direction_checkmark_tracker.Add(true);
            drd_temp.data_direction_checkmark_tracker.Add(false);
            drd_temp.data_direction_checkmark_tracker.Add(false);
            drd_temp.data_direction_checkmark_tracker.Add(false);

            //check if existing drd object has signal data and a valid csv_filepath
            if (drd_temp.datasets_master.Count > 0 && !String.IsNullOrEmpty(drd_temp.dataset_input_filepath))
            {
                string save_filepath = input_folder + damping_reduction_data_object_storage_folder + get_filename_from_filepath(csv_filepath_short) + dataset_object_file_extension;
                serialize_damping_reduction_dataset(drd_temp, save_filepath);
            }

        }

        public static void serialize_damping_reduction_dataset(damping_reduction_dataset drd, string serialization_path)
        {
            using (Stream stream = File.Open(serialization_path, FileMode.Create))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                binaryFormatter.Serialize(stream, drd);
                stream.Close();
            }
        }

        public static damping_reduction_dataset deserialize_damping_reduction_dataset(string serialization_file_path)
        {
            using (Stream stream = File.Open(serialization_file_path, FileMode.Open))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                //damping_reduction_dataset drs = (damping_reduction_dataset)binaryFormatter.Deserialize(stream);
                return (damping_reduction_dataset)binaryFormatter.Deserialize(stream);

                //return drs;
            }
        }

        //UI control functions (button clicked ex.)

        private void calculate_damp_ratio_and_freq_button_Click(object sender, EventArgs e)
        {
            calculate_damping_ratio_and_frequency();
        }

        private void reset_data_trimming_button_Click(object sender, EventArgs e)
        {
            reset_to_master_dataset();
        }

        private void apply_filter_button_Click(object sender, EventArgs e)
        {
            apply_bandpass_filter();
        }

        private void remove_filter_button_Click(object sender, EventArgs e)
        {
            remove_filter();
        }

        private void select_data_direction_check_list_box_SelectedIndexChanged(object sender, EventArgs e)
        {
            check_checked_chart_series();
            update_bandpass_filter_cutoff_frequencies();
        }

        private void recalc_damp_ratio_freq_peak_button_Click(object sender, EventArgs e)
        {
            recalculate_damping_ratio_and_frequency();
        }

        private void saveDatasetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            changes_cursor_icon_to_loading(true);

            save_dataset_object();

            //        //play sound to allert user
            System.Media.SystemSounds.Beep.Play();

            changes_cursor_icon_to_loading(false);
        }

        private void exportResultDataFromCurrentSlelectedDatasetObjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            changes_cursor_icon_to_loading(true);
            export_results_dataset_object(drd);
            changes_cursor_icon_to_loading(false);
        }

        private void exportResultsSummaryEditedDatasetsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            changes_cursor_icon_to_loading(true);
            save_dataset_object(); //save current object so it gets exported
            export_results_all_dataset_objects();
            changes_cursor_icon_to_loading(false);
        }

        private void freq_peaks_chart_AnnotationPositionChanged(object sender, EventArgs e)
        {
            check_if_annotations_in_chartview(freq_peaks_chart);

            //update_tooltip_average_freqs_est();
        }

        private void signal_data_chart_main_AnnotationPositionChanged(object sender, EventArgs e)
        {
            check_if_annotations_in_chartview(signal_data_chart_main);
        }

        private void aboutStructuralDampingReductionProcessorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string message = "Structural Damping Reduction Processor was developed by Atlin Anderson (2021). Copyright of Atlin Anderson. Special thanks to Matt Mills, Kevin Scherbatiuk, Yashar Ghari, Saptarshi Datta ";
            string title = "About";
            FlexibleMessageBox.Show(message, title);
        }

        private void reset_trim_lines_button_Click(object sender, EventArgs e)
        {
            //draw the annoation trim lines on the peaks freqs plot
            draw_annotation_trim_lines_freq_plot(freq_peaks_chart, freq_peaks_trim_vertical_line_1, freq_peaks_trim_vertical_line_2, freq_peaks_trim_horizontal_line_1, freq_peaks_trim_horizontal_line_2);
        }

        private void peak_picking_method_combobox_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            //using fast peak picker?
            if (peak_picking_method_combobox.SelectedIndex == 1)
            {
                //enable manual freq estimation
                manual_freq_est_checkbox.Enabled = true;
                manual_freq_est_numupdown.Enabled = true;
                label7.Enabled = true;
            }
            else
            {
                //disable manual freq estimation
                manual_freq_est_checkbox.Enabled = false;
                manual_freq_est_numupdown.Enabled = false;
                label7.Enabled = false;
            }
        }

        private void upper_freq_plot_cutoff_numupdown_ValueChanged(object sender, EventArgs e)
        {
            constrain_freq_dft_plot_cutoff_freqs();
            plot_freq_response(freq_span, real_spectrum, data_direction_name);
        }

        private void lower_freq_plot_cutoff_numupdown_ValueChanged(object sender, EventArgs e)
        {
            constrain_freq_dft_plot_cutoff_freqs();
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

        private void importcsvFilesFromOutputFolderWhenSelectingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (importcsvFilesFromOutputFolderWhenSelectingToolStripMenuItem.Checked == true)
            //{
            //    importcsvFilesFromOutputFolderWhenSelectingToolStripMenuItem.Checked = false;
            //}
            //else
            //{
            //    importcsvFilesFromOutputFolderWhenSelectingToolStripMenuItem.Checked = true;
            //}
        }

        private void recalculateVectorSumDataAfterApplyingFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (recalculateVectorSumDataAfterApplyingFilterToolStripMenuItem.Checked == true)
            //{
            //    recalculateVectorSumDataAfterApplyingFilterToolStripMenuItem.Checked = false;
            //}
            //else
            //{
            //    recalculateVectorSumDataAfterApplyingFilterToolStripMenuItem.Checked = true;
            //}
        }

        private void select_data_set_tool_strip_combo_box_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            new_dataset_selected(select_data_set_tool_strip_combo_box.SelectedIndex);
        }

        private void selectInputFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            update_program_after_input_folder_select();
        }

        private void form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            save_dataset_on_form_close();
        }

        //useless control functions

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void freq_chart_Click(object sender, EventArgs e)
        {

        }

        private void exportResultsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void select_data_direction_check_list_box_QueryAccessibilityHelp(object sender, QueryAccessibilityHelpEventArgs e)
        {

        }

        private void summary_results_textbox_DoubleClick(object sender, EventArgs e)
        {
            display_results_message_box();
        }

        private void freq_peaks_chart_Click(object sender, EventArgs e)
        {

        }

        private void manual_freq_est_numupdown_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void data_chart_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void freq_dft_chart_AxisViewChanged_1(object sender, ViewEventArgs e)
        {

        }

        private void current_dataset_filepath_label_Click(object sender, EventArgs e)
        {

        }

        private void automaticFilterFrequencySelectionToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


    }


    public class datasets_result_object
    {
        //public List<dataset_result_row> dataset_result_rows { get; set; }
        public List<dataset_result_row> dataset_result_rows = new List<dataset_result_row>();

    }

    public class dataset_result_row
    {
        public string val1 { get; set; } // text(30)
        public string val2 { get; set; } // text(30)
        public string val3 { get; set; } // text(7)
    }


    [Serializable]
    public class damping_reduction_dataset
    {
        //store datasets
        public List<List<double>> datasets_master = new List<List<double>>();
        public List<List<double>> datasets_trim = new List<List<double>>();
        public List<List<double>> datasets_filter_trim = new List<List<double>>();
        public List<List<double>> datasets_master_filtered = new List<List<double>>();

        //store other data related to calcualting damping ratio 
        public List<List<double>> natural_freq_dist_btwn_peaks = new List<List<double>>();

        //found maximas
        public List<List<int>> local_maximas_indicies = new List<List<int>>();
        public List<List<double>> local_maximas_amplitudes = new List<List<double>>();
        public List<List<double>> local_maximas_times = new List<List<double>>();

        //data results
        public List<double> natural_freq_fft = new List<double>();
        public List<double> natural_freq_dist_btwn_peaks_average = new List<double>();
        public List<double> damp_ratio_exp_fft_freq = new List<double>();
        public List<double> damp_ratio_exp_peaks = new List<double>();
        public List<double> cofefficient_of_determination = new List<double>();

        //user readable results
        public string dataset_result_summary = String.Empty;

        //stores all csv filepath found in the slected input folder
        public string dataset_input_filepath = String.Empty;
        //stores all csv filepath found in the slected input folder (in short form for readability)
        public string dataset_input_filepath_short = string.Empty;

        //keep track of what cutoff frequencies are used
        public double low_cutoff_freq = -1;
        public double high_cutoff_freq = -1;

        public Boolean is_data_filtered = false;

        //holds the values where the annotation will be placed (relative to the trimmed dataset)
        public int lower_trim_index_x = -1;
        public int upper_trim_index_x = -1;

        //holds the values where the annotation is placed relative to the original time dataset (not trimmed)
        //useful when applying a filter to a dataset that has been trimmed twice
        public int lower_trim_index_x_relative_master_dataset = -1;
        public int upper_trim_index_x_relative_master_dataset = -1;

        //stroed checked directions
        public List<Boolean> data_direction_checkmark_tracker = new List<Boolean>();

        //store screencaps of the three plots
        public List<Byte[]> chart_screenshot_tracker_byte_array = new List<Byte[]>();


        //store the per direction
        public List<double> max_displacement = new List<double>();

    }

}

