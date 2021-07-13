
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
            this.data_chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
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
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.select_data_direction_check_list_box = new System.Windows.Forms.CheckedListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.freq_peaks_chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.menu_strip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectInputFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveSessionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadSessionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.select_data_set_tool_strip_combo_box = new System.Windows.Forms.ToolStripComboBox();
            this.exportResultsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportResultsSummaryEditedDatasetsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayResultsSummaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportUneditedDatasetsToOutputFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportTrimmedDatasetsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportFilteredAndTrimmedDatasetsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importcsvFilesFromOutputFolderWhenSelectingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recalculateVectorSumDataAfterApplyingFilterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.useDFTOrPeaksFrequencyToCalculateDampingRatioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.use_DFT_or_peaks_combobox = new System.Windows.Forms.ToolStripComboBox();
            this.freqResponseTransformPlotYAxisScaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.linear_or_log_combobox = new System.Windows.Forms.ToolStripComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.activity_log_textbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lower_freq_plot_cutoff_numupdown = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.data_chart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.low_freq_cutoff_numupdown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.high_freq_cutoff_numupdown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.freq_dft_chart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upper_freq_plot_cutoff_numupdown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.freq_peaks_chart)).BeginInit();
            this.menu_strip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lower_freq_plot_cutoff_numupdown)).BeginInit();
            this.SuspendLayout();
            // 
            // data_chart
            // 
            chartArea1.Name = "ChartArea1";
            this.data_chart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.data_chart.Legends.Add(legend1);
            this.data_chart.Location = new System.Drawing.Point(369, 32);
            this.data_chart.Name = "data_chart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.data_chart.Series.Add(series1);
            this.data_chart.Size = new System.Drawing.Size(1382, 610);
            this.data_chart.TabIndex = 0;
            this.data_chart.Text = "chart1";
            this.data_chart.MouseClick += new System.Windows.Forms.MouseEventHandler(this.x_data_chart_Click);
            // 
            // trim_data_button
            // 
            this.trim_data_button.Location = new System.Drawing.Point(2, 163);
            this.trim_data_button.Name = "trim_data_button";
            this.trim_data_button.Size = new System.Drawing.Size(175, 27);
            this.trim_data_button.TabIndex = 1;
            this.trim_data_button.Text = "Trim Data";
            this.trim_data_button.UseVisualStyleBackColor = true;
            this.trim_data_button.Click += new System.EventHandler(this.trim_data_button_Click);
            // 
            // calculate_damp_ratio_and_freq_button
            // 
            this.calculate_damp_ratio_and_freq_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.calculate_damp_ratio_and_freq_button.Location = new System.Drawing.Point(2, 273);
            this.calculate_damp_ratio_and_freq_button.Name = "calculate_damp_ratio_and_freq_button";
            this.calculate_damp_ratio_and_freq_button.Size = new System.Drawing.Size(175, 49);
            this.calculate_damp_ratio_and_freq_button.TabIndex = 2;
            this.calculate_damp_ratio_and_freq_button.Text = "Calculate Damping Ratio and Frequency";
            this.calculate_damp_ratio_and_freq_button.UseVisualStyleBackColor = true;
            this.calculate_damp_ratio_and_freq_button.Click += new System.EventHandler(this.calculate_damp_ratio_and_freq_button_Click);
            // 
            // input_folder_textbox
            // 
            this.input_folder_textbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.input_folder_textbox.Location = new System.Drawing.Point(2, 44);
            this.input_folder_textbox.Multiline = true;
            this.input_folder_textbox.Name = "input_folder_textbox";
            this.input_folder_textbox.ReadOnly = true;
            this.input_folder_textbox.Size = new System.Drawing.Size(268, 113);
            this.input_folder_textbox.TabIndex = 5;
            // 
            // reset_data_trimming_button
            // 
            this.reset_data_trimming_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reset_data_trimming_button.Location = new System.Drawing.Point(183, 163);
            this.reset_data_trimming_button.Name = "reset_data_trimming_button";
            this.reset_data_trimming_button.Size = new System.Drawing.Size(175, 27);
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
            this.low_freq_cutoff_numupdown.Location = new System.Drawing.Point(2, 215);
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
            this.high_freq_cutoff_numupdown.Location = new System.Drawing.Point(183, 215);
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
            this.label2.Location = new System.Drawing.Point(2, 200);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Low Freq.  Cutoff";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(265, 199);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "High Freq.  Cutoff";
            // 
            // apply_filter_button
            // 
            this.apply_filter_button.Location = new System.Drawing.Point(2, 241);
            this.apply_filter_button.Name = "apply_filter_button";
            this.apply_filter_button.Size = new System.Drawing.Size(175, 26);
            this.apply_filter_button.TabIndex = 27;
            this.apply_filter_button.Text = "Apply Filter to Data";
            this.apply_filter_button.UseVisualStyleBackColor = true;
            this.apply_filter_button.Click += new System.EventHandler(this.apply_filter_button_Click);
            // 
            // remove_filter_button
            // 
            this.remove_filter_button.Location = new System.Drawing.Point(183, 241);
            this.remove_filter_button.Name = "remove_filter_button";
            this.remove_filter_button.Size = new System.Drawing.Size(175, 26);
            this.remove_filter_button.TabIndex = 28;
            this.remove_filter_button.Text = "Remove Filter";
            this.remove_filter_button.UseVisualStyleBackColor = true;
            this.remove_filter_button.Click += new System.EventHandler(this.remove_filter_button_Click);
            // 
            // freq_dft_chart
            // 
            chartArea2.Name = "ChartArea1";
            this.freq_dft_chart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.freq_dft_chart.Legends.Add(legend2);
            this.freq_dft_chart.Location = new System.Drawing.Point(369, 668);
            this.freq_dft_chart.Name = "freq_dft_chart";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.freq_dft_chart.Series.Add(series2);
            this.freq_dft_chart.Size = new System.Drawing.Size(723, 184);
            this.freq_dft_chart.TabIndex = 30;
            this.freq_dft_chart.Text = "chart1";
            this.freq_dft_chart.AxisViewChanged += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.ViewEventArgs>(this.freq_dft_chart_AxisViewChanged_1);
            this.freq_dft_chart.Click += new System.EventHandler(this.freq_chart_Click);
            // 
            // summary_results_textbox
            // 
            this.summary_results_textbox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.summary_results_textbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.summary_results_textbox.Location = new System.Drawing.Point(2, 345);
            this.summary_results_textbox.Multiline = true;
            this.summary_results_textbox.Name = "summary_results_textbox";
            this.summary_results_textbox.ReadOnly = true;
            this.summary_results_textbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.summary_results_textbox.Size = new System.Drawing.Size(361, 354);
            this.summary_results_textbox.TabIndex = 31;
            // 
            // upper_freq_plot_cutoff_numupdown
            // 
            this.upper_freq_plot_cutoff_numupdown.DecimalPlaces = 1;
            this.upper_freq_plot_cutoff_numupdown.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.upper_freq_plot_cutoff_numupdown.Location = new System.Drawing.Point(300, 306);
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
            this.upper_freq_plot_cutoff_numupdown.Size = new System.Drawing.Size(55, 26);
            this.upper_freq_plot_cutoff_numupdown.TabIndex = 33;
            this.upper_freq_plot_cutoff_numupdown.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.upper_freq_plot_cutoff_numupdown.ValueChanged += new System.EventHandler(this.upper_freq_plot_cutoff_numupdown_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(183, 277);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 13);
            this.label5.TabIndex = 34;
            this.label5.Text = "Frequency Response";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(180, 291);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(122, 13);
            this.label6.TabIndex = 35;
            this.label6.Text = " Plot CutOff Frequencies";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(180, 306);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 13);
            this.label7.TabIndex = 36;
            this.label7.Text = " (Hz)";
            // 
            // select_data_direction_check_list_box
            // 
            this.select_data_direction_check_list_box.CheckOnClick = true;
            this.select_data_direction_check_list_box.FormattingEnabled = true;
            this.select_data_direction_check_list_box.Location = new System.Drawing.Point(276, 32);
            this.select_data_direction_check_list_box.Name = "select_data_direction_check_list_box";
            this.select_data_direction_check_list_box.Size = new System.Drawing.Size(87, 109);
            this.select_data_direction_check_list_box.TabIndex = 41;
            this.select_data_direction_check_list_box.SelectedIndexChanged += new System.EventHandler(this.select_data_direction_check_list_box_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(278, 144);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 13);
            this.label8.TabIndex = 42;
            this.label8.Text = "VS= Vector Sum";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(11, 839);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(232, 13);
            this.label9.TabIndex = 43;
            this.label9.Text = "Created by Atlin Anderson for Varcon Inc (2021)";
            // 
            // freq_peaks_chart
            // 
            chartArea3.Name = "ChartArea1";
            this.freq_peaks_chart.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.freq_peaks_chart.Legends.Add(legend3);
            this.freq_peaks_chart.Location = new System.Drawing.Point(1098, 668);
            this.freq_peaks_chart.Name = "freq_peaks_chart";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.freq_peaks_chart.Series.Add(series3);
            this.freq_peaks_chart.Size = new System.Drawing.Size(656, 184);
            this.freq_peaks_chart.TabIndex = 44;
            this.freq_peaks_chart.Text = "chart1";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(589, 652);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(259, 13);
            this.label10.TabIndex = 45;
            this.label10.Text = "Frequency Response (Discrete Frequency Transform)";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(1288, 652);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(237, 13);
            this.label11.TabIndex = 46;
            this.label11.Text = "Frequency Estimation (Distance Between Peaks)";
            // 
            // menu_strip
            // 
            this.menu_strip.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.menu_strip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.select_data_set_tool_strip_combo_box,
            this.exportResultsToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.menu_strip.Location = new System.Drawing.Point(0, 0);
            this.menu_strip.Name = "menu_strip";
            this.menu_strip.Size = new System.Drawing.Size(1763, 27);
            this.menu_strip.TabIndex = 48;
            this.menu_strip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectInputFolderToolStripMenuItem,
            this.saveSessionToolStripMenuItem,
            this.loadSessionToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 23);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // selectInputFolderToolStripMenuItem
            // 
            this.selectInputFolderToolStripMenuItem.Name = "selectInputFolderToolStripMenuItem";
            this.selectInputFolderToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.selectInputFolderToolStripMenuItem.Text = "Select input folder";
            this.selectInputFolderToolStripMenuItem.Click += new System.EventHandler(this.selectInputFolderToolStripMenuItem_Click);
            // 
            // saveSessionToolStripMenuItem
            // 
            this.saveSessionToolStripMenuItem.Name = "saveSessionToolStripMenuItem";
            this.saveSessionToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.saveSessionToolStripMenuItem.Text = "Save session";
            this.saveSessionToolStripMenuItem.Click += new System.EventHandler(this.saveSessionToolStripMenuItem_Click);
            // 
            // loadSessionToolStripMenuItem
            // 
            this.loadSessionToolStripMenuItem.Name = "loadSessionToolStripMenuItem";
            this.loadSessionToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.loadSessionToolStripMenuItem.Text = "Load session";
            this.loadSessionToolStripMenuItem.Click += new System.EventHandler(this.loadSessionToolStripMenuItem_Click);
            // 
            // select_data_set_tool_strip_combo_box
            // 
            this.select_data_set_tool_strip_combo_box.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.select_data_set_tool_strip_combo_box.MaxDropDownItems = 100;
            this.select_data_set_tool_strip_combo_box.Name = "select_data_set_tool_strip_combo_box";
            this.select_data_set_tool_strip_combo_box.Size = new System.Drawing.Size(600, 23);
            this.select_data_set_tool_strip_combo_box.SelectedIndexChanged += new System.EventHandler(this.select_data_set_tool_strip_combo_box_SelectedIndexChanged_1);
            // 
            // exportResultsToolStripMenuItem
            // 
            this.exportResultsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportResultsSummaryEditedDatasetsToolStripMenuItem,
            this.displayResultsSummaryToolStripMenuItem,
            this.exportUneditedDatasetsToOutputFolderToolStripMenuItem,
            this.exportTrimmedDatasetsToolStripMenuItem,
            this.exportFilteredAndTrimmedDatasetsToolStripMenuItem});
            this.exportResultsToolStripMenuItem.Name = "exportResultsToolStripMenuItem";
            this.exportResultsToolStripMenuItem.Size = new System.Drawing.Size(93, 23);
            this.exportResultsToolStripMenuItem.Text = "Export Results";
            this.exportResultsToolStripMenuItem.Click += new System.EventHandler(this.exportResultsToolStripMenuItem_Click);
            // 
            // exportResultsSummaryEditedDatasetsToolStripMenuItem
            // 
            this.exportResultsSummaryEditedDatasetsToolStripMenuItem.Name = "exportResultsSummaryEditedDatasetsToolStripMenuItem";
            this.exportResultsSummaryEditedDatasetsToolStripMenuItem.Size = new System.Drawing.Size(369, 22);
            this.exportResultsSummaryEditedDatasetsToolStripMenuItem.Text = "Export results summary and all datasets to output folder";
            this.exportResultsSummaryEditedDatasetsToolStripMenuItem.Click += new System.EventHandler(this.exportResultsSummaryEditedDatasetsToolStripMenuItem_Click);
            // 
            // displayResultsSummaryToolStripMenuItem
            // 
            this.displayResultsSummaryToolStripMenuItem.Name = "displayResultsSummaryToolStripMenuItem";
            this.displayResultsSummaryToolStripMenuItem.Size = new System.Drawing.Size(369, 22);
            this.displayResultsSummaryToolStripMenuItem.Text = "Display total results summary";
            this.displayResultsSummaryToolStripMenuItem.Click += new System.EventHandler(this.displayResultsSummaryToolStripMenuItem_Click);
            // 
            // exportUneditedDatasetsToOutputFolderToolStripMenuItem
            // 
            this.exportUneditedDatasetsToOutputFolderToolStripMenuItem.Name = "exportUneditedDatasetsToOutputFolderToolStripMenuItem";
            this.exportUneditedDatasetsToOutputFolderToolStripMenuItem.Size = new System.Drawing.Size(369, 22);
            this.exportUneditedDatasetsToOutputFolderToolStripMenuItem.Text = "Export unedited datasets to output folder";
            this.exportUneditedDatasetsToOutputFolderToolStripMenuItem.Click += new System.EventHandler(this.exportUneditedDatasetsToOutputFolderToolStripMenuItem_Click);
            // 
            // exportTrimmedDatasetsToolStripMenuItem
            // 
            this.exportTrimmedDatasetsToolStripMenuItem.Name = "exportTrimmedDatasetsToolStripMenuItem";
            this.exportTrimmedDatasetsToolStripMenuItem.Size = new System.Drawing.Size(369, 22);
            this.exportTrimmedDatasetsToolStripMenuItem.Text = "Export trimmed datasets to output folder";
            this.exportTrimmedDatasetsToolStripMenuItem.Click += new System.EventHandler(this.exportTrimmedDatasetsToolStripMenuItem_Click);
            // 
            // exportFilteredAndTrimmedDatasetsToolStripMenuItem
            // 
            this.exportFilteredAndTrimmedDatasetsToolStripMenuItem.Name = "exportFilteredAndTrimmedDatasetsToolStripMenuItem";
            this.exportFilteredAndTrimmedDatasetsToolStripMenuItem.Size = new System.Drawing.Size(369, 22);
            this.exportFilteredAndTrimmedDatasetsToolStripMenuItem.Text = "Export filtered and trimmed datasets to output folder";
            this.exportFilteredAndTrimmedDatasetsToolStripMenuItem.Click += new System.EventHandler(this.exportFilteredAndTrimmedDatasetsToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importcsvFilesFromOutputFolderWhenSelectingToolStripMenuItem,
            this.recalculateVectorSumDataAfterApplyingFilterToolStripMenuItem,
            this.useDFTOrPeaksFrequencyToCalculateDampingRatioToolStripMenuItem,
            this.freqResponseTransformPlotYAxisScaleToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 23);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // importcsvFilesFromOutputFolderWhenSelectingToolStripMenuItem
            // 
            this.importcsvFilesFromOutputFolderWhenSelectingToolStripMenuItem.Name = "importcsvFilesFromOutputFolderWhenSelectingToolStripMenuItem";
            this.importcsvFilesFromOutputFolderWhenSelectingToolStripMenuItem.Size = new System.Drawing.Size(451, 22);
            this.importcsvFilesFromOutputFolderWhenSelectingToolStripMenuItem.Text = "Import .csv files from output folder when selecting input folder?";
            this.importcsvFilesFromOutputFolderWhenSelectingToolStripMenuItem.Click += new System.EventHandler(this.importcsvFilesFromOutputFolderWhenSelectingToolStripMenuItem_Click);
            // 
            // recalculateVectorSumDataAfterApplyingFilterToolStripMenuItem
            // 
            this.recalculateVectorSumDataAfterApplyingFilterToolStripMenuItem.Name = "recalculateVectorSumDataAfterApplyingFilterToolStripMenuItem";
            this.recalculateVectorSumDataAfterApplyingFilterToolStripMenuItem.Size = new System.Drawing.Size(451, 22);
            this.recalculateVectorSumDataAfterApplyingFilterToolStripMenuItem.Text = "Recalculate Vector sum data after applying filter?";
            this.recalculateVectorSumDataAfterApplyingFilterToolStripMenuItem.Click += new System.EventHandler(this.recalculateVectorSumDataAfterApplyingFilterToolStripMenuItem_Click);
            // 
            // useDFTOrPeaksFrequencyToCalculateDampingRatioToolStripMenuItem
            // 
            this.useDFTOrPeaksFrequencyToCalculateDampingRatioToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.use_DFT_or_peaks_combobox});
            this.useDFTOrPeaksFrequencyToCalculateDampingRatioToolStripMenuItem.Name = "useDFTOrPeaksFrequencyToCalculateDampingRatioToolStripMenuItem";
            this.useDFTOrPeaksFrequencyToCalculateDampingRatioToolStripMenuItem.Size = new System.Drawing.Size(451, 22);
            this.useDFTOrPeaksFrequencyToCalculateDampingRatioToolStripMenuItem.Text = "Use DFT method or Peaks method frequency to calculate damping ratio";
            // 
            // use_DFT_or_peaks_combobox
            // 
            this.use_DFT_or_peaks_combobox.Items.AddRange(new object[] {
            "DFT",
            "Peaks"});
            this.use_DFT_or_peaks_combobox.Name = "use_DFT_or_peaks_combobox";
            this.use_DFT_or_peaks_combobox.Size = new System.Drawing.Size(121, 23);
            // 
            // freqResponseTransformPlotYAxisScaleToolStripMenuItem
            // 
            this.freqResponseTransformPlotYAxisScaleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.linear_or_log_combobox});
            this.freqResponseTransformPlotYAxisScaleToolStripMenuItem.Name = "freqResponseTransformPlotYAxisScaleToolStripMenuItem";
            this.freqResponseTransformPlotYAxisScaleToolStripMenuItem.Size = new System.Drawing.Size(451, 22);
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
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(125, 325);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(118, 17);
            this.label12.TabIndex = 32;
            this.label12.Text = "Results Summary";
            this.label12.Click += new System.EventHandler(this.label4_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(86, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 13);
            this.label4.TabIndex = 49;
            this.label4.Text = "Selected Input Folder";
            // 
            // activity_log_textbox
            // 
            this.activity_log_textbox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.activity_log_textbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.activity_log_textbox.Location = new System.Drawing.Point(2, 733);
            this.activity_log_textbox.Multiline = true;
            this.activity_log_textbox.Name = "activity_log_textbox";
            this.activity_log_textbox.ReadOnly = true;
            this.activity_log_textbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.activity_log_textbox.Size = new System.Drawing.Size(361, 103);
            this.activity_log_textbox.TabIndex = 52;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(145, 713);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 17);
            this.label1.TabIndex = 53;
            this.label1.Text = "Activity Log";
            // 
            // lower_freq_plot_cutoff_numupdown
            // 
            this.lower_freq_plot_cutoff_numupdown.DecimalPlaces = 1;
            this.lower_freq_plot_cutoff_numupdown.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lower_freq_plot_cutoff_numupdown.Location = new System.Drawing.Point(300, 274);
            this.lower_freq_plot_cutoff_numupdown.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.lower_freq_plot_cutoff_numupdown.Name = "lower_freq_plot_cutoff_numupdown";
            this.lower_freq_plot_cutoff_numupdown.Size = new System.Drawing.Size(55, 26);
            this.lower_freq_plot_cutoff_numupdown.TabIndex = 54;
            this.lower_freq_plot_cutoff_numupdown.ValueChanged += new System.EventHandler(this.lower_freq_plot_cutoff_numupdown_ValueChanged);
            // 
            // form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1763, 861);
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
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
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
            this.Controls.Add(this.data_chart);
            this.Controls.Add(this.menu_strip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menu_strip;
            this.Name = "form1";
            this.Text = "Structrual Damping Reduction Processor";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.data_chart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.low_freq_cutoff_numupdown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.high_freq_cutoff_numupdown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.freq_dft_chart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upper_freq_plot_cutoff_numupdown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.freq_peaks_chart)).EndInit();
            this.menu_strip.ResumeLayout(false);
            this.menu_strip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lower_freq_plot_cutoff_numupdown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart data_chart;
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
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckedListBox select_data_direction_check_list_box;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataVisualization.Charting.Chart freq_peaks_chart;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.MenuStrip menu_strip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectInputFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveSessionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadSessionToolStripMenuItem;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ToolStripMenuItem exportResultsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportResultsSummaryEditedDatasetsToolStripMenuItem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStripComboBox select_data_set_tool_strip_combo_box;
        private System.Windows.Forms.ToolStripMenuItem displayResultsSummaryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportTrimmedDatasetsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportFilteredAndTrimmedDatasetsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportUneditedDatasetsToOutputFolderToolStripMenuItem;
        private System.Windows.Forms.TextBox activity_log_textbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importcsvFilesFromOutputFolderWhenSelectingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recalculateVectorSumDataAfterApplyingFilterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem useDFTOrPeaksFrequencyToCalculateDampingRatioToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox use_DFT_or_peaks_combobox;
        private System.Windows.Forms.ToolStripMenuItem freqResponseTransformPlotYAxisScaleToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox linear_or_log_combobox;
        private System.Windows.Forms.NumericUpDown lower_freq_plot_cutoff_numupdown;
    }
}

