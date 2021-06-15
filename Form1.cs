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
using FFTW.NET;
using MathNet.Filtering.FIR;
using MathNet.Filtering;


namespace Damping_Data_Processor
{
    public partial class select_input_folder_button : Form
    {

        //GLOBAL VARIABLES

        //allocate vertical annotation
        VerticalLineAnnotation lower_data_boundary_vertical_line_x = new VerticalLineAnnotation();
        VerticalLineAnnotation upper_data_boundary_vertical_line_x = new VerticalLineAnnotation();

        VerticalLineAnnotation lower_data_boundary_vertical_line_y = new VerticalLineAnnotation();
        VerticalLineAnnotation upper_data_boundary_vertical_line_y = new VerticalLineAnnotation();

        VerticalLineAnnotation lower_data_boundary_vertical_line_z = new VerticalLineAnnotation();
        VerticalLineAnnotation upper_data_boundary_vertical_line_z = new VerticalLineAnnotation();

        string current_selected_dataset_filepath = string.Empty;

        //pixel width of charts, used to samplke data for plotting
        int chart_width = 1389;

        //the imported string list from csv
        List<List<string>> generic_input_data_string = new List<List<string>>();
        //the converted and processed data save as a master copy (kept as an original in case user wants to revert to original data)
        List<List<double>> generic_input_data_double_master = new List<List<double>>();
        //a copy of the master data but edit and trimming can be made to this data set (will be reset when user reverts to master)
        List<List<double>> generic_input_data_double_clone = new List<List<double>>();
        //same as cloned dataset but with applied filter
        List<List<double>> generic_input_data_double_clone_filtered = new List<List<double>>();

        string output_folder = @"C:\Users\aanderson\OneDrive - Varcon Inc\Documents\Projects\Damping Data Processor\Output\";

        //folder picked by user with all input data
        string input_folder = string.Empty;

        //stores all csv filepath found in the slected input folder
        List<string> csv_input_filepaths = new List<string>();
        //stores all csv filepath found in the slected input folder (in short form for readability)
        List<string> csv_input_filepaths_short = new List<string>();

        double input_data_sample_rate = 1024;

        public select_input_folder_button()
        {

            InitializeComponent();
        }

        //generic program functions

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
                j=j+2;
            }


            double[] double_array = new double[Convert.ToInt32(Math.Pow(j, 2))];

            for (int i = 0; i < data.Count; i++)
            {
                double_array[i] = data[i];
            }
            return double_array;
        }

        public double[] convert_double_list_to_array (List<double> data)
        {
            double[] double_array = new double[data.Count];
            for(int i = 0; i<data.Count; i++)
            {
                double_array[i] = data[i];
            }
            return double_array;
        }

        public void calculate_natural_frequency (List<double> data)
        {
            ////Complex[] output = new Complex[data.Count];

            //using (var pinIn = new PinnedArray<double>(convert_double_list_to_array(data)))
            ////using (var pinOut = new PinnedArray<Complex>(output))
            //using (var output = new FftwArrayComplex(DFT.GetComplexBufferSize(pinIn.GetSize())))
            //{
            //    DFT.FFT(pinIn, output);
            //}

            //double max_freq = 0;
            //List<double> test = new List<double>();

            //// Use the same arrays for as many transformations as you like.
            //// If you can use the same arrays for your transformations, this is faster than calling DFT.FFT / DFT.IFFT
            //using (var timeDomain = new FftwArrayComplex(data.Count))
            //using (var frequencyDomain = new FftwArrayComplex(timeDomain.GetSize()))
            //using (var fft = FftwPlanC2C.Create(timeDomain, frequencyDomain, DftDirection.Forwards))
            ////using (var ifft = FftwPlanC2C.Create(frequencyDomain, timeDomain, DftDirection.Backwards))
            //{
            //    // Set the input after the plan was created as the input may be overwritten
            //    // during planning
            //    for (int i = 0; i < timeDomain.Length; i++)
            //    {
            //        timeDomain[i] = data[i];
            //    }

            //    // timeDomain -> frequencyDomain
            //    fft.Execute();

            //    for (int i = frequencyDomain.Length / 2; i < frequencyDomain.Length; i++)
            //        frequencyDomain[i] = 0;


            //    for (int i = 0; i < frequencyDomain.Length; i++)
            //    {
            //        test.Add(Convert.ToDouble(frequencyDomain[i]));
            //    }

            //}
            //max_freq = test.Max();

        }

        public List<List<double>> sample_plotting_data(List<double> X, List<double> Y, int max_samples)
        {
            //X & Y muust be same length
            //if(X.Count != Y.Count)
            //{

            //}

            List<List<double>> sampled_data = new List<List<double>>();

            if (X.Count <= max_samples)
            {
                sampled_data.Add(X);
                sampled_data.Add(Y);
                return sampled_data;
            }

            int sample_rate = X.Count / max_samples;

            List<double> X_sampled = new List<double>();
            List<double> Y_sampled = new List<double>();

            for(int i=0; i<X.Count; i = i + sample_rate)
            {
                X_sampled.Add(X[i]);
                Y_sampled.Add(Y[i]);
            }

            sampled_data.Add(X_sampled);
            sampled_data.Add(Y_sampled);

            return sampled_data;

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
                generic_input_data_double_master[0][i] = generic_input_data_double_master[0][i] / 1024;
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
            //convert_ticks_to_seconds();

            //remove data offsets
            for (int i = 1; i < generic_input_data_double_master.Count; i++)
            {
                generic_input_data_double_master[i] = remove_data_offset(generic_input_data_double_master[i]);
            }

            generic_input_data_double_clone = generic_input_data_double_master;

            //add trimmed time data (from integration
            //generic_input_data_double_integrated.Add(generic_input_data_double[0].GetRange(2, generic_input_data_double[0].Count - 2));
            ////double integration of acceleration data to get displacement
            //generic_input_data_double_integrated.Add(compute_integration_list(generic_input_data_double[0], compute_integration_list(generic_input_data_double[0], generic_input_data_double[1])));

            clear_and_plot_chart(x_data_chart, "X", generic_input_data_double_clone[0], generic_input_data_double_clone[1]);
            clear_and_plot_chart(y_data_chart, "Y", generic_input_data_double_clone[0], generic_input_data_double_clone[2]);
            clear_and_plot_chart(z_data_chart, "Z", generic_input_data_double_clone[0], generic_input_data_double_clone[3]);
            
            draw_vertical_annotations(x_data_chart, lower_data_boundary_vertical_line_x, upper_data_boundary_vertical_line_x, generic_input_data_double_clone[0]);
            draw_vertical_annotations(y_data_chart, lower_data_boundary_vertical_line_y, upper_data_boundary_vertical_line_y, generic_input_data_double_clone[0]);
            draw_vertical_annotations(z_data_chart, lower_data_boundary_vertical_line_z, upper_data_boundary_vertical_line_z, generic_input_data_double_clone[0]);

        }

        public void update_program_after_input_folder_select()
        {
            select_folder(out input_folder);
            input_folder_textbox.Text = input_folder;
            csv_input_filepaths = (Directory.GetFiles(input_folder, "*.csv", System.IO.SearchOption.AllDirectories)).ToList();

            csv_input_filepaths_short = new List<string>();
            for (int i = 0; i < csv_input_filepaths.Count; i++)
            {
                csv_input_filepaths_short.Add(csv_input_filepaths[i].Replace(input_folder, String.Empty));
            }

            for (int i = 0; i < csv_input_filepaths.Count; i++)
            {
                input_csv_checkedlistbox.Items.Add(csv_input_filepaths_short[i], CheckState.Checked);
                select_data_set_combobox.Items.Add(csv_input_filepaths_short[i]);
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

        public void update_all_annotation_positions (double annotation_1_pos, double annotation_2_pos)
        {
            lower_data_boundary_vertical_line_x.X = annotation_1_pos;
            upper_data_boundary_vertical_line_x.X = annotation_2_pos;

            lower_data_boundary_vertical_line_y.X = annotation_1_pos;
            upper_data_boundary_vertical_line_y.X = annotation_2_pos;

            lower_data_boundary_vertical_line_z.X = annotation_1_pos;
            upper_data_boundary_vertical_line_z.X = annotation_2_pos;
        }

        public void clear_and_plot_chart(Chart chart_name, string data_name, List<double> data_x, List<double> data_y)
        {
            //sample data to reduce lag in program
            List<List<double>> sampled_data = sample_plotting_data(data_x, data_y, chart_width);
            List<double> sampled_data_x = sampled_data[0];
            List<double> sampled_data_y = sampled_data[1];


            //create series and plot
            chart_name.Series.Clear();
            System.Windows.Forms.DataVisualization.Charting.Series series = chart_name.Series.Add(data_name);
            series.ChartType = SeriesChartType.Line;
            series.Points.DataBindXY(sampled_data_x, sampled_data_y);
            series.BorderWidth = 2;
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
            line1.LineColor = Color.Red;
            line1.LineWidth = 2;         // use your numbers!
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
            line2.LineColor = Color.Red;
            line2.LineWidth = 2;         // use your numbers!
            line2.X = time_data_list[time_data_list.Count - 3];
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
            double x_index_trim_lower = 0;
            double x_index_trim_upper = 0;

            //get boundary values from vertical annotations
            if (upper_data_boundary_vertical_line_x.X > lower_data_boundary_vertical_line_x.X)
            {
                x_index_trim_lower = Convert.ToInt32(lower_data_boundary_vertical_line_x.X);
                x_index_trim_upper = Convert.ToInt32(upper_data_boundary_vertical_line_x.X) ;
            }
            else
            {
                x_index_trim_upper = Convert.ToInt32(lower_data_boundary_vertical_line_x.X) ;
                x_index_trim_lower = Convert.ToInt32(upper_data_boundary_vertical_line_x.X) ;
            }

            int x_index_trim_lower_index = generic_input_data_double_clone[0].IndexOf(x_index_trim_lower);
            int x_index_trim_upper_index = generic_input_data_double_clone[0].IndexOf(x_index_trim_upper);

            update_trimmed_input_data(x_index_trim_lower_index, x_index_trim_upper_index);

            clear_and_plot_chart(x_data_chart, "X", generic_input_data_double_clone[0], generic_input_data_double_clone[1]);
            clear_and_plot_chart(y_data_chart, "Y", generic_input_data_double_clone[0], generic_input_data_double_clone[2]);
            clear_and_plot_chart(z_data_chart, "Z", generic_input_data_double_clone[0], generic_input_data_double_clone[3]);
            draw_vertical_annotations(x_data_chart, lower_data_boundary_vertical_line_x, upper_data_boundary_vertical_line_x, generic_input_data_double_clone[0]);
            draw_vertical_annotations(y_data_chart, lower_data_boundary_vertical_line_y, upper_data_boundary_vertical_line_y, generic_input_data_double_clone[0]);
            draw_vertical_annotations(z_data_chart, lower_data_boundary_vertical_line_z, upper_data_boundary_vertical_line_z, generic_input_data_double_clone[0]);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void calculate_damp_ratio_and_freq_button_Click(object sender, EventArgs e)
        {
            calculate_natural_frequency(generic_input_data_double_clone[1]);



            List<int> zero_crossings = calculate_amount_zero_crossings(generic_input_data_double_clone[1]);
            List<int> local_maximas = find_local_maximas(generic_input_data_double_clone[1], 200);
            double frequency = calculate_freq_based_zero_crossings(generic_input_data_double_clone[0], local_maximas);
        }

        private void save_trim_data_csv_button_Click(object sender, EventArgs e)
        {
            List<List<string>> csv_data = new List<List<string>>();
            csv_data.Add(generic_input_data_double_clone[0].Select(x => (x.ToString())).ToList());
            csv_data.Add(generic_input_data_double_clone[1].Select(x => (x.ToString())).ToList());

            string output_file_path = output_folder + "trimmed data.csv";
            save_list_of_list_string_as_csv(csv_data, output_file_path);
        }

        private void select_input_folder_button1_Click(object sender, EventArgs e)
        {
            update_program_after_input_folder_select();
        }

        private void deselect_all_button_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < input_csv_checkedlistbox.Items.Count; i++)
            {
                input_csv_checkedlistbox.SetItemChecked(i, false);
            }
        }

        private void select_all_button_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < input_csv_checkedlistbox.Items.Count; i++)
            {
                input_csv_checkedlistbox.SetItemChecked(i, true);
            }
        }

        private void select_data_set_combobox_DropDown(object sender, EventArgs e)
        {
            select_data_set_combobox.Items.Clear();

            for (int i = 0; i < csv_input_filepaths_short.Count; i++)
            {
                if (input_csv_checkedlistbox.GetItemCheckState(i) == CheckState.Checked)
                {
                    select_data_set_combobox.Items.Add(csv_input_filepaths_short[i]);
                }
            }
        }

        private void select_data_set_combobox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            for(int i=0; i< csv_input_filepaths_short.Count; i++)
            {
                if(csv_input_filepaths_short[i] == select_data_set_combobox.SelectedItem.ToString())
                {
                    current_selected_dataset_filepath = csv_input_filepaths[i];
                    break;
                }
            }
            load_data_of_selected_dataset_update_charts();
        }

        private void x_data_chart_AnnotationPositionChanged(object sender, EventArgs e)
        {
            update_all_annotation_positions(lower_data_boundary_vertical_line_x.X, upper_data_boundary_vertical_line_x.X);
        }

        private void y_data_chart_AnnotationPositionChanged(object sender, EventArgs e)
        {
            update_all_annotation_positions(lower_data_boundary_vertical_line_y.X, upper_data_boundary_vertical_line_y.X);
        }

        private void z_data_chart_AnnotationPositionChanged(object sender, EventArgs e)
        {
            update_all_annotation_positions(lower_data_boundary_vertical_line_z.X, upper_data_boundary_vertical_line_z.X);
        }

        private void reset_data_trimming_button_Click(object sender, EventArgs e)
        {
            load_data_of_selected_dataset_update_charts();
        }

        private void apply_filter_button_Click(object sender, EventArgs e)
        {

            ////signal + noise
            //double fs = 1000; //sampling rate
            //double fw = 5; //signal frequency
            //double fn = 50; //noise frequency
            //double n = 5; //number of periods to show
            //double A = 10; //signal amplitude
            //double N = 1; //noise amplitude
            //int size = (int)(n * fs / fw); //sample size

            //var t = Enumerable.Range(1, size).Select(p => p * 1 / fs).ToArray();
            //var y = t.Select(p => (A * Math.Sin(2 * Math.PI * fw * p)) + (N * Math.Sin(2 * Math.PI * fn * p))).ToArray(); //Original

            ////lowpass filter
            //double fc = 10; //cutoff frequency
            //var lowpass = OnlineFirFilter.CreateLowpass(ImpulseResponse.Finite, fs, fc);

            ////bandpass filter
            //double fc1 = 0; //low cutoff frequency
            //double fc2 = 10; //high cutoff frequency
            //var bandpass = OnlineFirFilter.CreateBandpass(ImpulseResponse.Finite, fs, fc1, fc2);

            //double[] yf1 = lowpass.ProcessSamples(y); //Lowpass
            //double[] yf2 = bandpass.ProcessSamples(y); //Bandpass

            //clear_and_plot_chart(x_data_chart, "X", t.ToList(), y.ToList());
            //clear_and_plot_chart(y_data_chart, "Y", t.ToList(), yf1.ToList());
            //clear_and_plot_chart(z_data_chart, "Z", t.ToList(), yf2.ToList());


            generic_input_data_double_clone_filtered = generic_input_data_double_clone;

            //get cutoff freqs
            double low_cutoff_freq = Convert.ToDouble(low_freq_cutoff_numupdown.Value);
            double high_cutoff_freq = Convert.ToDouble(high_freq_cutoff_numupdown.Value);

            //create filter object
            //var bandpass = OnlineFirFilter.CreateBandpass(ImpulseResponse.Finite, input_data_sample_rate, low_cutoff_freq, high_cutoff_freq);
            var bandpass = OnlineFirFilter.CreateLowpass(ImpulseResponse.Finite, input_data_sample_rate, high_cutoff_freq);

            //filter all datasets using the filter object
            for (int i = 1; i < generic_input_data_double_clone.Count; i++)
            {
                generic_input_data_double_clone_filtered[i] = bandpass.ProcessSamples(convert_double_list_to_array(generic_input_data_double_clone[i])).ToList();
            }


            //replot data
            clear_and_plot_chart(x_data_chart, "X", generic_input_data_double_clone_filtered[0], generic_input_data_double_clone_filtered[1]);
            clear_and_plot_chart(y_data_chart, "Y", generic_input_data_double_clone_filtered[0], generic_input_data_double_clone_filtered[2]);
            clear_and_plot_chart(z_data_chart, "Z", generic_input_data_double_clone_filtered[0], generic_input_data_double_clone_filtered[3]);
        }
    }
}
