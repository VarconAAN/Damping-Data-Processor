
namespace Damping_Data_Processor
{
    partial class form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(form1));
            this.signal_data_chart_main = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.trim_data_button = new System.Windows.Forms.Button();
            this.calculate_damp_ratio_and_freq_button = new System.Windows.Forms.Button();
            this.input_folder_textbox = new System.Windows.Forms.TextBox();
            this.reset_data_trimming_button = new System.Windows.Forms.Button();
            this.low_freq_cutoff_numupdown = new System.Windows.Forms.NumericUpDown();
            this.high_freq_cutoff_numupdown = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.apply_filter_button = new System.Windows.Forms.Button();
            this.remove_filter_button = new System.Windows.Forms.Button();
            this.freq_dft_chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.summary_results_textbox = new System.Windows.Forms.TextBox();
            this.upper_freq_plot_cutoff_numupdown = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.select_data_direction_check_list_box = new System.Windows.Forms.CheckedListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.freq_peaks_chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.menu_strip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectInputFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.select_data_set_tool_strip_combo_box = new System.Windows.Forms.ToolStripComboBox();
            this.saveDatasetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportResultsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportResultsSummaryEditedDatasetsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportResultDataFromCurrentSlelectedDatasetObjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importcsvFilesFromOutputFolderWhenSelectingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recalculateVectorSumDataAfterApplyingFilterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.freqResponseTransformPlotYAxisScaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.linear_or_log_combobox = new System.Windows.Forms.ToolStripComboBox();
            this.automaticFilterFrequencySelectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bandpass_freq_buffer_choices_combobox = new System.Windows.Forms.ToolStripComboBox();
            this.exportTemplateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.documentationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutStructuralDampingReductionProcessorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label12 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.activity_log_textbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lower_freq_plot_cutoff_numupdown = new System.Windows.Forms.NumericUpDown();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.manual_freq_est_checkbox = new System.Windows.Forms.CheckBox();
            this.freq_estimation_reject_freq_checkbox = new System.Windows.Forms.CheckBox();
            this.label16 = new System.Windows.Forms.Label();
            this.manual_freq_est_numupdown = new System.Windows.Forms.NumericUpDown();
            this.recalc_damp_ratio_freq_peak_button = new System.Windows.Forms.Button();
            this.peak_picking_method_combobox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.reset_trim_lines_button = new System.Windows.Forms.Button();
            this.freq_estimation_high_cutoff_freq_numupdown = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.current_dataset_filepath_label = new System.Windows.Forms.Label();
            this.nat_freq_textbox = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.input_data_sample_rate_numupdown = new System.Windows.Forms.NumericUpDown();
            this.next_dataset_button = new System.Windows.Forms.ToolStripMenuItem();
            this.prev_dataset_button = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.signal_data_chart_main)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.low_freq_cutoff_numupdown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.high_freq_cutoff_numupdown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.freq_dft_chart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upper_freq_plot_cutoff_numupdown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.freq_peaks_chart)).BeginInit();
            this.menu_strip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lower_freq_plot_cutoff_numupdown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.manual_freq_est_numupdown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.freq_estimation_high_cutoff_freq_numupdown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.input_data_sample_rate_numupdown)).BeginInit();
            this.SuspendLayout();
            // 
            // signal_data_chart_main
            // 
            this.signal_data_chart_main.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.signal_data_chart_main.BackColor = System.Drawing.Color.Gainsboro;
            this.signal_data_chart_main.BorderlineColor = System.Drawing.Color.Black;
            this.signal_data_chart_main.BorderlineWidth = 2;
            chartArea1.Name = "ChartArea1";
            this.signal_data_chart_main.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.signal_data_chart_main.Legends.Add(legend1);
            this.signal_data_chart_main.Location = new System.Drawing.Point(367, 41);
            this.signal_data_chart_main.Name = "signal_data_chart_main";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.signal_data_chart_main.Series.Add(series1);
            this.signal_data_chart_main.Size = new System.Drawing.Size(1076, 488);
            this.signal_data_chart_main.TabIndex = 0;
            this.signal_data_chart_main.Text = "chart1";
            this.signal_data_chart_main.AnnotationPositionChanged += new System.EventHandler(this.signal_data_chart_main_AnnotationPositionChanged);
            this.signal_data_chart_main.Click += new System.EventHandler(this.data_chart_Click);
            this.signal_data_chart_main.MouseClick += new System.Windows.Forms.MouseEventHandler(this.x_data_chart_Click);
            // 
            // trim_data_button
            // 
            this.trim_data_button.Location = new System.Drawing.Point(0, 131);
            this.trim_data_button.Name = "trim_data_button";
            this.trim_data_button.Size = new System.Drawing.Size(129, 44);
            this.trim_data_button.TabIndex = 1;
            this.trim_data_button.Text = "Trim Data";
            this.trim_data_button.UseVisualStyleBackColor = true;
            this.trim_data_button.Click += new System.EventHandler(this.trim_data_button_Click);
            // 
            // calculate_damp_ratio_and_freq_button
            // 
            this.calculate_damp_ratio_and_freq_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.calculate_damp_ratio_and_freq_button.Location = new System.Drawing.Point(2, 340);
            this.calculate_damp_ratio_and_freq_button.Name = "calculate_damp_ratio_and_freq_button";
            this.calculate_damp_ratio_and_freq_button.Size = new System.Drawing.Size(361, 49);
            this.calculate_damp_ratio_and_freq_button.TabIndex = 2;
            this.calculate_damp_ratio_and_freq_button.Text = "Calculate Damping Ratio and Frequency";
            this.calculate_damp_ratio_and_freq_button.UseVisualStyleBackColor = true;
            this.calculate_damp_ratio_and_freq_button.Click += new System.EventHandler(this.calculate_damp_ratio_and_freq_button_Click);
            // 
            // input_folder_textbox
            // 
            this.input_folder_textbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.input_folder_textbox.Location = new System.Drawing.Point(2, 78);
            this.input_folder_textbox.Multiline = true;
            this.input_folder_textbox.Name = "input_folder_textbox";
            this.input_folder_textbox.ReadOnly = true;
            this.input_folder_textbox.Size = new System.Drawing.Size(268, 47);
            this.input_folder_textbox.TabIndex = 5;
            // 
            // reset_data_trimming_button
            // 
            this.reset_data_trimming_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reset_data_trimming_button.Location = new System.Drawing.Point(135, 131);
            this.reset_data_trimming_button.Name = "reset_data_trimming_button";
            this.reset_data_trimming_button.Size = new System.Drawing.Size(135, 44);
            this.reset_data_trimming_button.TabIndex = 13;
            this.reset_data_trimming_button.Text = "Reset to Original Dataset";
            this.reset_data_trimming_button.UseVisualStyleBackColor = true;
            this.reset_data_trimming_button.Click += new System.EventHandler(this.reset_data_trimming_button_Click);
            // 
            // low_freq_cutoff_numupdown
            // 
            this.low_freq_cutoff_numupdown.DecimalPlaces = 3;
            this.low_freq_cutoff_numupdown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.low_freq_cutoff_numupdown.Location = new System.Drawing.Point(2, 205);
            this.low_freq_cutoff_numupdown.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.low_freq_cutoff_numupdown.Name = "low_freq_cutoff_numupdown";
            this.low_freq_cutoff_numupdown.Size = new System.Drawing.Size(175, 20);
            this.low_freq_cutoff_numupdown.TabIndex = 23;
            this.low_freq_cutoff_numupdown.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            // 
            // high_freq_cutoff_numupdown
            // 
            this.high_freq_cutoff_numupdown.DecimalPlaces = 3;
            this.high_freq_cutoff_numupdown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.high_freq_cutoff_numupdown.Location = new System.Drawing.Point(183, 205);
            this.high_freq_cutoff_numupdown.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.high_freq_cutoff_numupdown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.high_freq_cutoff_numupdown.Name = "high_freq_cutoff_numupdown";
            this.high_freq_cutoff_numupdown.Size = new System.Drawing.Size(175, 20);
            this.high_freq_cutoff_numupdown.TabIndex = 24;
            this.high_freq_cutoff_numupdown.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 190);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Bandpass Low Freq.  Cutoff";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(215, 189);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "Bandpass High Freq.  Cutoff";
            // 
            // apply_filter_button
            // 
            this.apply_filter_button.Location = new System.Drawing.Point(2, 231);
            this.apply_filter_button.Name = "apply_filter_button";
            this.apply_filter_button.Size = new System.Drawing.Size(175, 26);
            this.apply_filter_button.TabIndex = 27;
            this.apply_filter_button.Text = "Apply Bandpass Filter to Data";
            this.apply_filter_button.UseVisualStyleBackColor = true;
            this.apply_filter_button.Click += new System.EventHandler(this.apply_filter_button_Click);
            // 
            // remove_filter_button
            // 
            this.remove_filter_button.Location = new System.Drawing.Point(183, 231);
            this.remove_filter_button.Name = "remove_filter_button";
            this.remove_filter_button.Size = new System.Drawing.Size(175, 26);
            this.remove_filter_button.TabIndex = 28;
            this.remove_filter_button.Text = "Remove Filter";
            this.remove_filter_button.UseVisualStyleBackColor = true;
            this.remove_filter_button.Click += new System.EventHandler(this.remove_filter_button_Click);
            // 
            // freq_dft_chart
            // 
            this.freq_dft_chart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.freq_dft_chart.BackColor = System.Drawing.Color.Gainsboro;
            chartArea2.Name = "ChartArea1";
            this.freq_dft_chart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.freq_dft_chart.Legends.Add(legend2);
            this.freq_dft_chart.Location = new System.Drawing.Point(480, 576);
            this.freq_dft_chart.Name = "freq_dft_chart";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.freq_dft_chart.Series.Add(series2);
            this.freq_dft_chart.Size = new System.Drawing.Size(444, 184);
            this.freq_dft_chart.TabIndex = 30;
            this.freq_dft_chart.Text = "chart1";
            this.freq_dft_chart.AxisViewChanged += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.ViewEventArgs>(this.freq_dft_chart_AxisViewChanged_1);
            this.freq_dft_chart.Click += new System.EventHandler(this.freq_chart_Click);
            // 
            // summary_results_textbox
            // 
            this.summary_results_textbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.summary_results_textbox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.summary_results_textbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.summary_results_textbox.Location = new System.Drawing.Point(2, 409);
            this.summary_results_textbox.Multiline = true;
            this.summary_results_textbox.Name = "summary_results_textbox";
            this.summary_results_textbox.ReadOnly = true;
            this.summary_results_textbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.summary_results_textbox.Size = new System.Drawing.Size(358, 215);
            this.summary_results_textbox.TabIndex = 31;
            this.summary_results_textbox.DoubleClick += new System.EventHandler(this.summary_results_textbox_DoubleClick);
            // 
            // upper_freq_plot_cutoff_numupdown
            // 
            this.upper_freq_plot_cutoff_numupdown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.upper_freq_plot_cutoff_numupdown.DecimalPlaces = 3;
            this.upper_freq_plot_cutoff_numupdown.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.upper_freq_plot_cutoff_numupdown.Location = new System.Drawing.Point(846, 547);
            this.upper_freq_plot_cutoff_numupdown.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.upper_freq_plot_cutoff_numupdown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.upper_freq_plot_cutoff_numupdown.Name = "upper_freq_plot_cutoff_numupdown";
            this.upper_freq_plot_cutoff_numupdown.Size = new System.Drawing.Size(78, 21);
            this.upper_freq_plot_cutoff_numupdown.TabIndex = 33;
            this.upper_freq_plot_cutoff_numupdown.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.upper_freq_plot_cutoff_numupdown.ValueChanged += new System.EventHandler(this.upper_freq_plot_cutoff_numupdown_ValueChanged);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(607, 551);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(147, 13);
            this.label6.TabIndex = 35;
            this.label6.Text = " Plot Cut-Off Frequencies (Hz)";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // select_data_direction_check_list_box
            // 
            this.select_data_direction_check_list_box.CheckOnClick = true;
            this.select_data_direction_check_list_box.FormattingEnabled = true;
            this.select_data_direction_check_list_box.Location = new System.Drawing.Point(276, 66);
            this.select_data_direction_check_list_box.Name = "select_data_direction_check_list_box";
            this.select_data_direction_check_list_box.Size = new System.Drawing.Size(87, 109);
            this.select_data_direction_check_list_box.TabIndex = 41;
            this.select_data_direction_check_list_box.SelectedIndexChanged += new System.EventHandler(this.select_data_direction_check_list_box_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(278, 178);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 13);
            this.label8.TabIndex = 42;
            this.label8.Text = "VS= Vector Sum";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(2, 747);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(232, 13);
            this.label9.TabIndex = 43;
            this.label9.Text = "Created by Atlin Anderson for Varcon Inc (2021)";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // freq_peaks_chart
            // 
            this.freq_peaks_chart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.freq_peaks_chart.BackColor = System.Drawing.Color.Gainsboro;
            chartArea3.Name = "ChartArea1";
            this.freq_peaks_chart.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.freq_peaks_chart.Legends.Add(legend3);
            this.freq_peaks_chart.Location = new System.Drawing.Point(932, 576);
            this.freq_peaks_chart.Name = "freq_peaks_chart";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.freq_peaks_chart.Series.Add(series3);
            this.freq_peaks_chart.Size = new System.Drawing.Size(511, 184);
            this.freq_peaks_chart.TabIndex = 44;
            this.freq_peaks_chart.Text = "chart1";
            this.freq_peaks_chart.AnnotationPositionChanged += new System.EventHandler(this.freq_peaks_chart_AnnotationPositionChanged);
            this.freq_peaks_chart.Click += new System.EventHandler(this.freq_peaks_chart_Click);
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(366, 535);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(126, 13);
            this.label10.TabIndex = 45;
            this.label10.Text = "Frequency Response";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(929, 535);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(128, 13);
            this.label11.TabIndex = 46;
            this.label11.Text = "Frequency Estimation";
            // 
            // menu_strip
            // 
            this.menu_strip.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.menu_strip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.prev_dataset_button,
            this.select_data_set_tool_strip_combo_box,
            this.next_dataset_button,
            this.saveDatasetToolStripMenuItem,
            this.exportResultsToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menu_strip.Location = new System.Drawing.Point(0, 0);
            this.menu_strip.Name = "menu_strip";
            this.menu_strip.Size = new System.Drawing.Size(1447, 40);
            this.menu_strip.TabIndex = 48;
            this.menu_strip.Text = "menuStrip1";
            this.menu_strip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menu_strip_ItemClicked);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectInputFolderToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 36);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // selectInputFolderToolStripMenuItem
            // 
            this.selectInputFolderToolStripMenuItem.Name = "selectInputFolderToolStripMenuItem";
            this.selectInputFolderToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.selectInputFolderToolStripMenuItem.Text = "Select input folder";
            this.selectInputFolderToolStripMenuItem.Click += new System.EventHandler(this.selectInputFolderToolStripMenuItem_Click);
            // 
            // select_data_set_tool_strip_combo_box
            // 
            this.select_data_set_tool_strip_combo_box.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.select_data_set_tool_strip_combo_box.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.select_data_set_tool_strip_combo_box.MaxDropDownItems = 100;
            this.select_data_set_tool_strip_combo_box.Name = "select_data_set_tool_strip_combo_box";
            this.select_data_set_tool_strip_combo_box.Size = new System.Drawing.Size(1000, 36);
            this.select_data_set_tool_strip_combo_box.SelectedIndexChanged += new System.EventHandler(this.select_data_set_tool_strip_combo_box_SelectedIndexChanged_1);
            // 
            // saveDatasetToolStripMenuItem
            // 
            this.saveDatasetToolStripMenuItem.Name = "saveDatasetToolStripMenuItem";
            this.saveDatasetToolStripMenuItem.Size = new System.Drawing.Size(85, 36);
            this.saveDatasetToolStripMenuItem.Text = "Save Dataset";
            this.saveDatasetToolStripMenuItem.ToolTipText = "Saves automatically when switching dataset file";
            this.saveDatasetToolStripMenuItem.Click += new System.EventHandler(this.saveDatasetToolStripMenuItem_Click);
            // 
            // exportResultsToolStripMenuItem
            // 
            this.exportResultsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportResultsSummaryEditedDatasetsToolStripMenuItem,
            this.exportResultDataFromCurrentSlelectedDatasetObjectToolStripMenuItem});
            this.exportResultsToolStripMenuItem.Name = "exportResultsToolStripMenuItem";
            this.exportResultsToolStripMenuItem.Size = new System.Drawing.Size(93, 36);
            this.exportResultsToolStripMenuItem.Text = "Export Results";
            this.exportResultsToolStripMenuItem.Click += new System.EventHandler(this.exportResultsToolStripMenuItem_Click);
            // 
            // exportResultsSummaryEditedDatasetsToolStripMenuItem
            // 
            this.exportResultsSummaryEditedDatasetsToolStripMenuItem.Name = "exportResultsSummaryEditedDatasetsToolStripMenuItem";
            this.exportResultsSummaryEditedDatasetsToolStripMenuItem.Size = new System.Drawing.Size(370, 22);
            this.exportResultsSummaryEditedDatasetsToolStripMenuItem.Text = "Export result data from all dataset objects in input folder";
            this.exportResultsSummaryEditedDatasetsToolStripMenuItem.Click += new System.EventHandler(this.exportResultsSummaryEditedDatasetsToolStripMenuItem_Click);
            // 
            // exportResultDataFromCurrentSlelectedDatasetObjectToolStripMenuItem
            // 
            this.exportResultDataFromCurrentSlelectedDatasetObjectToolStripMenuItem.Name = "exportResultDataFromCurrentSlelectedDatasetObjectToolStripMenuItem";
            this.exportResultDataFromCurrentSlelectedDatasetObjectToolStripMenuItem.Size = new System.Drawing.Size(370, 22);
            this.exportResultDataFromCurrentSlelectedDatasetObjectToolStripMenuItem.Text = "Export result data from current selected dataset object";
            this.exportResultDataFromCurrentSlelectedDatasetObjectToolStripMenuItem.Click += new System.EventHandler(this.exportResultDataFromCurrentSlelectedDatasetObjectToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importcsvFilesFromOutputFolderWhenSelectingToolStripMenuItem,
            this.recalculateVectorSumDataAfterApplyingFilterToolStripMenuItem,
            this.freqResponseTransformPlotYAxisScaleToolStripMenuItem,
            this.automaticFilterFrequencySelectionToolStripMenuItem,
            this.exportTemplateToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 36);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // importcsvFilesFromOutputFolderWhenSelectingToolStripMenuItem
            // 
            this.importcsvFilesFromOutputFolderWhenSelectingToolStripMenuItem.CheckOnClick = true;
            this.importcsvFilesFromOutputFolderWhenSelectingToolStripMenuItem.Name = "importcsvFilesFromOutputFolderWhenSelectingToolStripMenuItem";
            this.importcsvFilesFromOutputFolderWhenSelectingToolStripMenuItem.Size = new System.Drawing.Size(411, 22);
            this.importcsvFilesFromOutputFolderWhenSelectingToolStripMenuItem.Text = "Import .csv files from output folder when selecting input folder?";
            this.importcsvFilesFromOutputFolderWhenSelectingToolStripMenuItem.Click += new System.EventHandler(this.importcsvFilesFromOutputFolderWhenSelectingToolStripMenuItem_Click);
            // 
            // recalculateVectorSumDataAfterApplyingFilterToolStripMenuItem
            // 
            this.recalculateVectorSumDataAfterApplyingFilterToolStripMenuItem.Checked = true;
            this.recalculateVectorSumDataAfterApplyingFilterToolStripMenuItem.CheckOnClick = true;
            this.recalculateVectorSumDataAfterApplyingFilterToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.recalculateVectorSumDataAfterApplyingFilterToolStripMenuItem.Name = "recalculateVectorSumDataAfterApplyingFilterToolStripMenuItem";
            this.recalculateVectorSumDataAfterApplyingFilterToolStripMenuItem.Size = new System.Drawing.Size(411, 22);
            this.recalculateVectorSumDataAfterApplyingFilterToolStripMenuItem.Text = "Recalculate Vector sum data after applying filter?";
            this.recalculateVectorSumDataAfterApplyingFilterToolStripMenuItem.Click += new System.EventHandler(this.recalculateVectorSumDataAfterApplyingFilterToolStripMenuItem_Click);
            // 
            // freqResponseTransformPlotYAxisScaleToolStripMenuItem
            // 
            this.freqResponseTransformPlotYAxisScaleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.linear_or_log_combobox});
            this.freqResponseTransformPlotYAxisScaleToolStripMenuItem.Name = "freqResponseTransformPlotYAxisScaleToolStripMenuItem";
            this.freqResponseTransformPlotYAxisScaleToolStripMenuItem.Size = new System.Drawing.Size(411, 22);
            this.freqResponseTransformPlotYAxisScaleToolStripMenuItem.Text = "Freq Response Transform plot Y axis scale";
            // 
            // linear_or_log_combobox
            // 
            this.linear_or_log_combobox.Items.AddRange(new object[] {
            "Linear",
            "Log"});
            this.linear_or_log_combobox.Name = "linear_or_log_combobox";
            this.linear_or_log_combobox.Size = new System.Drawing.Size(121, 23);
            this.linear_or_log_combobox.DropDownClosed += new System.EventHandler(this.linear_or_log_combobox_DropDownClosed);
            // 
            // automaticFilterFrequencySelectionToolStripMenuItem
            // 
            this.automaticFilterFrequencySelectionToolStripMenuItem.Checked = true;
            this.automaticFilterFrequencySelectionToolStripMenuItem.CheckOnClick = true;
            this.automaticFilterFrequencySelectionToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.automaticFilterFrequencySelectionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bandpass_freq_buffer_choices_combobox});
            this.automaticFilterFrequencySelectionToolStripMenuItem.Name = "automaticFilterFrequencySelectionToolStripMenuItem";
            this.automaticFilterFrequencySelectionToolStripMenuItem.Size = new System.Drawing.Size(411, 22);
            this.automaticFilterFrequencySelectionToolStripMenuItem.Text = "Automatic Bandpass Filter Frequencies Buffer Selection (Hz)";
            this.automaticFilterFrequencySelectionToolStripMenuItem.Click += new System.EventHandler(this.automaticFilterFrequencySelectionToolStripMenuItem_Click);
            // 
            // bandpass_freq_buffer_choices_combobox
            // 
            this.bandpass_freq_buffer_choices_combobox.Name = "bandpass_freq_buffer_choices_combobox";
            this.bandpass_freq_buffer_choices_combobox.Size = new System.Drawing.Size(121, 23);
            // 
            // exportTemplateToolStripMenuItem
            // 
            this.exportTemplateToolStripMenuItem.Name = "exportTemplateToolStripMenuItem";
            this.exportTemplateToolStripMenuItem.Size = new System.Drawing.Size(411, 22);
            this.exportTemplateToolStripMenuItem.Text = "Export .xlsx template filepath";
            this.exportTemplateToolStripMenuItem.Click += new System.EventHandler(this.exportTemplateToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.documentationToolStripMenuItem,
            this.aboutStructuralDampingReductionProcessorToolStripMenuItem});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 36);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // documentationToolStripMenuItem
            // 
            this.documentationToolStripMenuItem.Name = "documentationToolStripMenuItem";
            this.documentationToolStripMenuItem.Size = new System.Drawing.Size(324, 22);
            this.documentationToolStripMenuItem.Text = "Documentation";
            // 
            // aboutStructuralDampingReductionProcessorToolStripMenuItem
            // 
            this.aboutStructuralDampingReductionProcessorToolStripMenuItem.Name = "aboutStructuralDampingReductionProcessorToolStripMenuItem";
            this.aboutStructuralDampingReductionProcessorToolStripMenuItem.Size = new System.Drawing.Size(324, 22);
            this.aboutStructuralDampingReductionProcessorToolStripMenuItem.Text = "About Structural Damping Reduction Processor";
            this.aboutStructuralDampingReductionProcessorToolStripMenuItem.Click += new System.EventHandler(this.aboutStructuralDampingReductionProcessorToolStripMenuItem_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(116, 389);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(118, 17);
            this.label12.TabIndex = 32;
            this.label12.Text = "Results Summary";
            this.label12.Click += new System.EventHandler(this.label4_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(86, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 13);
            this.label4.TabIndex = 49;
            this.label4.Text = "Selected Input Folder";
            // 
            // activity_log_textbox
            // 
            this.activity_log_textbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.activity_log_textbox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.activity_log_textbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.activity_log_textbox.Location = new System.Drawing.Point(2, 647);
            this.activity_log_textbox.Multiline = true;
            this.activity_log_textbox.Name = "activity_log_textbox";
            this.activity_log_textbox.ReadOnly = true;
            this.activity_log_textbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.activity_log_textbox.Size = new System.Drawing.Size(358, 97);
            this.activity_log_textbox.TabIndex = 52;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(140, 627);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 17);
            this.label1.TabIndex = 53;
            this.label1.Text = "Activity Log";
            // 
            // lower_freq_plot_cutoff_numupdown
            // 
            this.lower_freq_plot_cutoff_numupdown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lower_freq_plot_cutoff_numupdown.DecimalPlaces = 3;
            this.lower_freq_plot_cutoff_numupdown.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lower_freq_plot_cutoff_numupdown.Location = new System.Drawing.Point(760, 547);
            this.lower_freq_plot_cutoff_numupdown.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.lower_freq_plot_cutoff_numupdown.Name = "lower_freq_plot_cutoff_numupdown";
            this.lower_freq_plot_cutoff_numupdown.Size = new System.Drawing.Size(80, 21);
            this.lower_freq_plot_cutoff_numupdown.TabIndex = 54;
            this.lower_freq_plot_cutoff_numupdown.ValueChanged += new System.EventHandler(this.lower_freq_plot_cutoff_numupdown_ValueChanged);
            // 
            // manual_freq_est_checkbox
            // 
            this.manual_freq_est_checkbox.AutoSize = true;
            this.manual_freq_est_checkbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manual_freq_est_checkbox.Location = new System.Drawing.Point(0, 303);
            this.manual_freq_est_checkbox.Name = "manual_freq_est_checkbox";
            this.manual_freq_est_checkbox.Size = new System.Drawing.Size(287, 17);
            this.manual_freq_est_checkbox.TabIndex = 56;
            this.manual_freq_est_checkbox.Text = "Manual Freq. Estimation for Peak-Picking Window (Hz) ";
            this.toolTip1.SetToolTip(this.manual_freq_est_checkbox, "If not selected the fft peak frequency will be used in the peak-picking");
            this.manual_freq_est_checkbox.UseVisualStyleBackColor = true;
            // 
            // freq_estimation_reject_freq_checkbox
            // 
            this.freq_estimation_reject_freq_checkbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.freq_estimation_reject_freq_checkbox.AutoSize = true;
            this.freq_estimation_reject_freq_checkbox.Checked = true;
            this.freq_estimation_reject_freq_checkbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.freq_estimation_reject_freq_checkbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.freq_estimation_reject_freq_checkbox.Location = new System.Drawing.Point(1196, 553);
            this.freq_estimation_reject_freq_checkbox.Name = "freq_estimation_reject_freq_checkbox";
            this.freq_estimation_reject_freq_checkbox.Size = new System.Drawing.Size(177, 17);
            this.freq_estimation_reject_freq_checkbox.TabIndex = 65;
            this.freq_estimation_reject_freq_checkbox.Text = "Reject Frequencies Above: (Hz)";
            this.toolTip1.SetToolTip(this.freq_estimation_reject_freq_checkbox, "Only rejects frequencies when \"calculate damping ratio and frequency\" is clicked." +
        "");
            this.freq_estimation_reject_freq_checkbox.UseVisualStyleBackColor = true;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(2, 45);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(251, 13);
            this.label16.TabIndex = 71;
            this.label16.Text = "Input Data Sample Rate (Samples/Second)";
            this.toolTip1.SetToolTip(this.label16, "Only applied when first importing .csv dataset");
            // 
            // manual_freq_est_numupdown
            // 
            this.manual_freq_est_numupdown.DecimalPlaces = 3;
            this.manual_freq_est_numupdown.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manual_freq_est_numupdown.Location = new System.Drawing.Point(295, 302);
            this.manual_freq_est_numupdown.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.manual_freq_est_numupdown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.manual_freq_est_numupdown.Name = "manual_freq_est_numupdown";
            this.manual_freq_est_numupdown.Size = new System.Drawing.Size(63, 20);
            this.manual_freq_est_numupdown.TabIndex = 55;
            this.manual_freq_est_numupdown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.manual_freq_est_numupdown.ValueChanged += new System.EventHandler(this.manual_freq_est_numupdown_ValueChanged);
            // 
            // recalc_damp_ratio_freq_peak_button
            // 
            this.recalc_damp_ratio_freq_peak_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.recalc_damp_ratio_freq_peak_button.Location = new System.Drawing.Point(1092, 531);
            this.recalc_damp_ratio_freq_peak_button.Name = "recalc_damp_ratio_freq_peak_button";
            this.recalc_damp_ratio_freq_peak_button.Size = new System.Drawing.Size(238, 20);
            this.recalc_damp_ratio_freq_peak_button.TabIndex = 57;
            this.recalc_damp_ratio_freq_peak_button.Text = "Recaculate Damping Ratio with Trimmed Freq. Values";
            this.recalc_damp_ratio_freq_peak_button.UseVisualStyleBackColor = true;
            this.recalc_damp_ratio_freq_peak_button.Click += new System.EventHandler(this.recalc_damp_ratio_freq_peak_button_Click);
            // 
            // peak_picking_method_combobox
            // 
            this.peak_picking_method_combobox.FormattingEnabled = true;
            this.peak_picking_method_combobox.Location = new System.Drawing.Point(0, 278);
            this.peak_picking_method_combobox.Name = "peak_picking_method_combobox";
            this.peak_picking_method_combobox.Size = new System.Drawing.Size(358, 21);
            this.peak_picking_method_combobox.TabIndex = 58;
            this.peak_picking_method_combobox.SelectedIndexChanged += new System.EventHandler(this.peak_picking_method_combobox_SelectedIndexChanged_1);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(0, 262);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 13);
            this.label5.TabIndex = 59;
            this.label5.Text = "Peak Picking Method";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 321);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(176, 13);
            this.label7.TabIndex = 60;
            this.label7.Text = "Works with classic peak picker only";
            // 
            // reset_trim_lines_button
            // 
            this.reset_trim_lines_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.reset_trim_lines_button.Location = new System.Drawing.Point(1336, 530);
            this.reset_trim_lines_button.Name = "reset_trim_lines_button";
            this.reset_trim_lines_button.Size = new System.Drawing.Size(104, 20);
            this.reset_trim_lines_button.TabIndex = 62;
            this.reset_trim_lines_button.Text = "Reset Trim Lines";
            this.reset_trim_lines_button.UseVisualStyleBackColor = true;
            this.reset_trim_lines_button.Click += new System.EventHandler(this.reset_trim_lines_button_Click);
            // 
            // freq_estimation_high_cutoff_freq_numupdown
            // 
            this.freq_estimation_high_cutoff_freq_numupdown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.freq_estimation_high_cutoff_freq_numupdown.DecimalPlaces = 3;
            this.freq_estimation_high_cutoff_freq_numupdown.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.freq_estimation_high_cutoff_freq_numupdown.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.freq_estimation_high_cutoff_freq_numupdown.Location = new System.Drawing.Point(1376, 550);
            this.freq_estimation_high_cutoff_freq_numupdown.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.freq_estimation_high_cutoff_freq_numupdown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.freq_estimation_high_cutoff_freq_numupdown.Name = "freq_estimation_high_cutoff_freq_numupdown";
            this.freq_estimation_high_cutoff_freq_numupdown.Size = new System.Drawing.Size(65, 21);
            this.freq_estimation_high_cutoff_freq_numupdown.TabIndex = 63;
            this.freq_estimation_high_cutoff_freq_numupdown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(929, 550);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(157, 13);
            this.label13.TabIndex = 67;
            this.label13.Text = "(Distance Between Peaks)";
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(366, 550);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(185, 13);
            this.label14.TabIndex = 66;
            this.label14.Text = "(Discrete Frequency Transform)";
            // 
            // current_dataset_filepath_label
            // 
            this.current_dataset_filepath_label.AutoSize = true;
            this.current_dataset_filepath_label.BackColor = System.Drawing.Color.Transparent;
            this.current_dataset_filepath_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.current_dataset_filepath_label.Location = new System.Drawing.Point(371, 511);
            this.current_dataset_filepath_label.Name = "current_dataset_filepath_label";
            this.current_dataset_filepath_label.Size = new System.Drawing.Size(98, 13);
            this.current_dataset_filepath_label.TabIndex = 68;
            this.current_dataset_filepath_label.Text = "dataset_filepath";
            this.current_dataset_filepath_label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.current_dataset_filepath_label.Visible = false;
            this.current_dataset_filepath_label.Click += new System.EventHandler(this.current_dataset_filepath_label_Click);
            // 
            // nat_freq_textbox
            // 
            this.nat_freq_textbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.nat_freq_textbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nat_freq_textbox.Location = new System.Drawing.Point(367, 593);
            this.nat_freq_textbox.Multiline = true;
            this.nat_freq_textbox.Name = "nat_freq_textbox";
            this.nat_freq_textbox.Size = new System.Drawing.Size(107, 167);
            this.nat_freq_textbox.TabIndex = 69;
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(366, 577);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(64, 13);
            this.label15.TabIndex = 70;
            this.label15.Text = "Peak Freqs.";
            // 
            // input_data_sample_rate_numupdown
            // 
            this.input_data_sample_rate_numupdown.DecimalPlaces = 6;
            this.input_data_sample_rate_numupdown.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.input_data_sample_rate_numupdown.Location = new System.Drawing.Point(259, 43);
            this.input_data_sample_rate_numupdown.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.input_data_sample_rate_numupdown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            393216});
            this.input_data_sample_rate_numupdown.Name = "input_data_sample_rate_numupdown";
            this.input_data_sample_rate_numupdown.Size = new System.Drawing.Size(104, 20);
            this.input_data_sample_rate_numupdown.TabIndex = 72;
            this.input_data_sample_rate_numupdown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.input_data_sample_rate_numupdown.Value = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            // 
            // next_dataset_button
            // 
            this.next_dataset_button.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.next_dataset_button.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.next_dataset_button.Name = "next_dataset_button";
            this.next_dataset_button.Size = new System.Drawing.Size(38, 36);
            this.next_dataset_button.Text = ">";
            this.next_dataset_button.ToolTipText = "Next Dataset";
            this.next_dataset_button.Click += new System.EventHandler(this.next_dataset_button_Click);
            // 
            // prev_dataset_button
            // 
            this.prev_dataset_button.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.prev_dataset_button.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.prev_dataset_button.Name = "prev_dataset_button";
            this.prev_dataset_button.Size = new System.Drawing.Size(38, 36);
            this.prev_dataset_button.Text = "<";
            this.prev_dataset_button.ToolTipText = "Previous Dataset";
            this.prev_dataset_button.Click += new System.EventHandler(this.prev_dataset_button_Click);
            // 
            // form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(1447, 766);
            this.Controls.Add(this.input_data_sample_rate_numupdown);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.nat_freq_textbox);
            this.Controls.Add(this.current_dataset_filepath_label);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.freq_estimation_reject_freq_checkbox);
            this.Controls.Add(this.freq_estimation_high_cutoff_freq_numupdown);
            this.Controls.Add(this.reset_trim_lines_button);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.peak_picking_method_combobox);
            this.Controls.Add(this.recalc_damp_ratio_freq_peak_button);
            this.Controls.Add(this.manual_freq_est_checkbox);
            this.Controls.Add(this.manual_freq_est_numupdown);
            this.Controls.Add(this.lower_freq_plot_cutoff_numupdown);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.activity_log_textbox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.freq_peaks_chart);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.select_data_direction_check_list_box);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.upper_freq_plot_cutoff_numupdown);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.summary_results_textbox);
            this.Controls.Add(this.freq_dft_chart);
            this.Controls.Add(this.remove_filter_button);
            this.Controls.Add(this.apply_filter_button);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.high_freq_cutoff_numupdown);
            this.Controls.Add(this.low_freq_cutoff_numupdown);
            this.Controls.Add(this.reset_data_trimming_button);
            this.Controls.Add(this.input_folder_textbox);
            this.Controls.Add(this.calculate_damp_ratio_and_freq_button);
            this.Controls.Add(this.trim_data_button);
            this.Controls.Add(this.signal_data_chart_main);
            this.Controls.Add(this.menu_strip);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menu_strip;
            this.MinimumSize = new System.Drawing.Size(1463, 805);
            this.Name = "form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Structural Damping Reduction Processor";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.signal_data_chart_main)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.low_freq_cutoff_numupdown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.high_freq_cutoff_numupdown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.freq_dft_chart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upper_freq_plot_cutoff_numupdown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.freq_peaks_chart)).EndInit();
            this.menu_strip.ResumeLayout(false);
            this.menu_strip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lower_freq_plot_cutoff_numupdown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.manual_freq_est_numupdown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.freq_estimation_high_cutoff_freq_numupdown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.input_data_sample_rate_numupdown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart signal_data_chart_main;
        private System.Windows.Forms.Button trim_data_button;
        private System.Windows.Forms.Button calculate_damp_ratio_and_freq_button;
        private System.Windows.Forms.TextBox input_folder_textbox;
        private System.Windows.Forms.Button reset_data_trimming_button;
        private System.Windows.Forms.NumericUpDown low_freq_cutoff_numupdown;
        private System.Windows.Forms.NumericUpDown high_freq_cutoff_numupdown;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button apply_filter_button;
        private System.Windows.Forms.Button remove_filter_button;
        private System.Windows.Forms.DataVisualization.Charting.Chart freq_dft_chart;
        private System.Windows.Forms.TextBox summary_results_textbox;
        private System.Windows.Forms.NumericUpDown upper_freq_plot_cutoff_numupdown;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckedListBox select_data_direction_check_list_box;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataVisualization.Charting.Chart freq_peaks_chart;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.MenuStrip menu_strip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectInputFolderToolStripMenuItem;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ToolStripMenuItem exportResultsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportResultsSummaryEditedDatasetsToolStripMenuItem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStripComboBox select_data_set_tool_strip_combo_box;
        private System.Windows.Forms.TextBox activity_log_textbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importcsvFilesFromOutputFolderWhenSelectingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recalculateVectorSumDataAfterApplyingFilterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem freqResponseTransformPlotYAxisScaleToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox linear_or_log_combobox;
        private System.Windows.Forms.NumericUpDown lower_freq_plot_cutoff_numupdown;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.NumericUpDown manual_freq_est_numupdown;
        private System.Windows.Forms.CheckBox manual_freq_est_checkbox;
        private System.Windows.Forms.Button recalc_damp_ratio_freq_peak_button;
        private System.Windows.Forms.ComboBox peak_picking_method_combobox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button reset_trim_lines_button;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem documentationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutStructuralDampingReductionProcessorToolStripMenuItem;
        private System.Windows.Forms.NumericUpDown freq_estimation_high_cutoff_freq_numupdown;
        private System.Windows.Forms.CheckBox freq_estimation_reject_freq_checkbox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ToolStripMenuItem saveDatasetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportResultDataFromCurrentSlelectedDatasetObjectToolStripMenuItem;
        private System.Windows.Forms.Label current_dataset_filepath_label;
        private System.Windows.Forms.ToolStripMenuItem automaticFilterFrequencySelectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox bandpass_freq_buffer_choices_combobox;
        private System.Windows.Forms.TextBox nat_freq_textbox;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.NumericUpDown input_data_sample_rate_numupdown;
        private System.Windows.Forms.ToolStripMenuItem exportTemplateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem prev_dataset_button;
        private System.Windows.Forms.ToolStripMenuItem next_dataset_button;
    }
}

