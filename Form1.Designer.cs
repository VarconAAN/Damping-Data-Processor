﻿
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
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
            this.freqResponseTransformPlotYAxisScaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.linear_or_log_combobox = new System.Windows.Forms.ToolStripComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.activity_log_textbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lower_freq_plot_cutoff_numupdown = new System.Windows.Forms.NumericUpDown();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.manual_freq_est_checkbox = new System.Windows.Forms.CheckBox();
            this.manual_freq_est_numupdown = new System.Windows.Forms.NumericUpDown();
            this.recalc_damp_ratio_freq_peak_button = new System.Windows.Forms.Button();
            this.peak_picking_method_combobox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.process_icon = new System.Windows.Forms.PictureBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.signal_data_chart_main)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.low_freq_cutoff_numupdown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.high_freq_cutoff_numupdown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.freq_dft_chart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upper_freq_plot_cutoff_numupdown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.freq_peaks_chart)).BeginInit();
            this.menu_strip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lower_freq_plot_cutoff_numupdown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.manual_freq_est_numupdown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.process_icon)).BeginInit();
            this.SuspendLayout();
            // 
            // signal_data_chart_main
            // 
            chartArea4.Name = "ChartArea1";
            this.signal_data_chart_main.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.signal_data_chart_main.Legends.Add(legend4);
            this.signal_data_chart_main.Location = new System.Drawing.Point(369, 32);
            this.signal_data_chart_main.Name = "signal_data_chart_main";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.signal_data_chart_main.Series.Add(series4);
            this.signal_data_chart_main.Size = new System.Drawing.Size(1382, 550);
            this.signal_data_chart_main.TabIndex = 0;
            this.signal_data_chart_main.Text = "chart1";
            this.signal_data_chart_main.Click += new System.EventHandler(this.data_chart_Click);
            this.signal_data_chart_main.MouseClick += new System.Windows.Forms.MouseEventHandler(this.x_data_chart_Click);
            // 
            // trim_data_button
            // 
            this.trim_data_button.Location = new System.Drawing.Point(0, 97);
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
            this.calculate_damp_ratio_and_freq_button.Location = new System.Drawing.Point(2, 319);
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
            this.input_folder_textbox.Location = new System.Drawing.Point(2, 44);
            this.input_folder_textbox.Multiline = true;
            this.input_folder_textbox.Name = "input_folder_textbox";
            this.input_folder_textbox.ReadOnly = true;
            this.input_folder_textbox.Size = new System.Drawing.Size(268, 47);
            this.input_folder_textbox.TabIndex = 5;
            // 
            // reset_data_trimming_button
            // 
            this.reset_data_trimming_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reset_data_trimming_button.Location = new System.Drawing.Point(135, 97);
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
            this.low_freq_cutoff_numupdown.Location = new System.Drawing.Point(2, 184);
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
            this.high_freq_cutoff_numupdown.Location = new System.Drawing.Point(183, 184);
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
            this.label2.Location = new System.Drawing.Point(2, 169);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Bandpass Low Freq.  Cutoff";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(215, 168);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "Bandpass High Freq.  Cutoff";
            // 
            // apply_filter_button
            // 
            this.apply_filter_button.Location = new System.Drawing.Point(2, 210);
            this.apply_filter_button.Name = "apply_filter_button";
            this.apply_filter_button.Size = new System.Drawing.Size(175, 26);
            this.apply_filter_button.TabIndex = 27;
            this.apply_filter_button.Text = "Apply Bandpass Filter to Data";
            this.apply_filter_button.UseVisualStyleBackColor = true;
            this.apply_filter_button.Click += new System.EventHandler(this.apply_filter_button_Click);
            // 
            // remove_filter_button
            // 
            this.remove_filter_button.Location = new System.Drawing.Point(183, 210);
            this.remove_filter_button.Name = "remove_filter_button";
            this.remove_filter_button.Size = new System.Drawing.Size(175, 26);
            this.remove_filter_button.TabIndex = 28;
            this.remove_filter_button.Text = "Remove Filter";
            this.remove_filter_button.UseVisualStyleBackColor = true;
            this.remove_filter_button.Click += new System.EventHandler(this.remove_filter_button_Click);
            // 
            // freq_dft_chart
            // 
            chartArea5.Name = "ChartArea1";
            this.freq_dft_chart.ChartAreas.Add(chartArea5);
            legend5.Name = "Legend1";
            this.freq_dft_chart.Legends.Add(legend5);
            this.freq_dft_chart.Location = new System.Drawing.Point(369, 609);
            this.freq_dft_chart.Name = "freq_dft_chart";
            series5.ChartArea = "ChartArea1";
            series5.Legend = "Legend1";
            series5.Name = "Series1";
            this.freq_dft_chart.Series.Add(series5);
            this.freq_dft_chart.Size = new System.Drawing.Size(723, 243);
            this.freq_dft_chart.TabIndex = 30;
            this.freq_dft_chart.Text = "chart1";
            this.freq_dft_chart.AxisViewChanged += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.ViewEventArgs>(this.freq_dft_chart_AxisViewChanged_1);
            this.freq_dft_chart.Click += new System.EventHandler(this.freq_chart_Click);
            // 
            // summary_results_textbox
            // 
            this.summary_results_textbox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.summary_results_textbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.summary_results_textbox.Location = new System.Drawing.Point(0, 390);
            this.summary_results_textbox.Multiline = true;
            this.summary_results_textbox.Name = "summary_results_textbox";
            this.summary_results_textbox.ReadOnly = true;
            this.summary_results_textbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.summary_results_textbox.Size = new System.Drawing.Size(361, 282);
            this.summary_results_textbox.TabIndex = 31;
            // 
            // upper_freq_plot_cutoff_numupdown
            // 
            this.upper_freq_plot_cutoff_numupdown.DecimalPlaces = 1;
            this.upper_freq_plot_cutoff_numupdown.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.upper_freq_plot_cutoff_numupdown.Location = new System.Drawing.Point(1035, 586);
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
            this.upper_freq_plot_cutoff_numupdown.Size = new System.Drawing.Size(55, 21);
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
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(830, 590);
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
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // freq_peaks_chart
            // 
            chartArea6.Name = "ChartArea1";
            this.freq_peaks_chart.ChartAreas.Add(chartArea6);
            legend6.Name = "Legend1";
            this.freq_peaks_chart.Legends.Add(legend6);
            this.freq_peaks_chart.Location = new System.Drawing.Point(1098, 609);
            this.freq_peaks_chart.Name = "freq_peaks_chart";
            series6.ChartArea = "ChartArea1";
            series6.Legend = "Legend1";
            series6.Name = "Series1";
            this.freq_peaks_chart.Series.Add(series6);
            this.freq_peaks_chart.Size = new System.Drawing.Size(656, 243);
            this.freq_peaks_chart.TabIndex = 44;
            this.freq_peaks_chart.Text = "chart1";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(371, 590);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(308, 13);
            this.label10.TabIndex = 45;
            this.label10.Text = "Frequency Response (Discrete Frequency Transform)";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(1100, 593);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(282, 13);
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
            this.freqResponseTransformPlotYAxisScaleToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 23);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // importcsvFilesFromOutputFolderWhenSelectingToolStripMenuItem
            // 
            this.importcsvFilesFromOutputFolderWhenSelectingToolStripMenuItem.Name = "importcsvFilesFromOutputFolderWhenSelectingToolStripMenuItem";
            this.importcsvFilesFromOutputFolderWhenSelectingToolStripMenuItem.Size = new System.Drawing.Size(411, 22);
            this.importcsvFilesFromOutputFolderWhenSelectingToolStripMenuItem.Text = "Import .csv files from output folder when selecting input folder?";
            this.importcsvFilesFromOutputFolderWhenSelectingToolStripMenuItem.Click += new System.EventHandler(this.importcsvFilesFromOutputFolderWhenSelectingToolStripMenuItem_Click);
            // 
            // recalculateVectorSumDataAfterApplyingFilterToolStripMenuItem
            // 
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
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(123, 370);
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
            this.activity_log_textbox.Location = new System.Drawing.Point(0, 695);
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
            this.label1.Location = new System.Drawing.Point(143, 675);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 17);
            this.label1.TabIndex = 53;
            this.label1.Text = "Activity Log";
            // 
            // lower_freq_plot_cutoff_numupdown
            // 
            this.lower_freq_plot_cutoff_numupdown.DecimalPlaces = 1;
            this.lower_freq_plot_cutoff_numupdown.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lower_freq_plot_cutoff_numupdown.Location = new System.Drawing.Point(978, 586);
            this.lower_freq_plot_cutoff_numupdown.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.lower_freq_plot_cutoff_numupdown.Name = "lower_freq_plot_cutoff_numupdown";
            this.lower_freq_plot_cutoff_numupdown.Size = new System.Drawing.Size(55, 21);
            this.lower_freq_plot_cutoff_numupdown.TabIndex = 54;
            this.lower_freq_plot_cutoff_numupdown.ValueChanged += new System.EventHandler(this.lower_freq_plot_cutoff_numupdown_ValueChanged);
            // 
            // manual_freq_est_checkbox
            // 
            this.manual_freq_est_checkbox.AutoSize = true;
            this.manual_freq_est_checkbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manual_freq_est_checkbox.Location = new System.Drawing.Point(0, 282);
            this.manual_freq_est_checkbox.Name = "manual_freq_est_checkbox";
            this.manual_freq_est_checkbox.Size = new System.Drawing.Size(287, 17);
            this.manual_freq_est_checkbox.TabIndex = 56;
            this.manual_freq_est_checkbox.Text = "Manual Freq. Estimation for Peak-Picking Window (Hz) ";
            this.toolTip1.SetToolTip(this.manual_freq_est_checkbox, "If not selected the fft peak frequency will be used in the peak-picking");
            this.manual_freq_est_checkbox.UseVisualStyleBackColor = true;
            // 
            // manual_freq_est_numupdown
            // 
            this.manual_freq_est_numupdown.DecimalPlaces = 3;
            this.manual_freq_est_numupdown.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manual_freq_est_numupdown.Location = new System.Drawing.Point(295, 281);
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
            this.recalc_damp_ratio_freq_peak_button.Location = new System.Drawing.Point(1388, 587);
            this.recalc_damp_ratio_freq_peak_button.Name = "recalc_damp_ratio_freq_peak_button";
            this.recalc_damp_ratio_freq_peak_button.Size = new System.Drawing.Size(320, 20);
            this.recalc_damp_ratio_freq_peak_button.TabIndex = 57;
            this.recalc_damp_ratio_freq_peak_button.Text = "Recaculate Damping Ratio with Trimmed Freq. Values";
            this.recalc_damp_ratio_freq_peak_button.UseVisualStyleBackColor = true;
            this.recalc_damp_ratio_freq_peak_button.Click += new System.EventHandler(this.recalc_damp_ratio_freq_peak_button_Click);
            // 
            // peak_picking_method_combobox
            // 
            this.peak_picking_method_combobox.FormattingEnabled = true;
            this.peak_picking_method_combobox.Location = new System.Drawing.Point(0, 257);
            this.peak_picking_method_combobox.Name = "peak_picking_method_combobox";
            this.peak_picking_method_combobox.Size = new System.Drawing.Size(358, 21);
            this.peak_picking_method_combobox.TabIndex = 58;
            this.peak_picking_method_combobox.SelectedIndexChanged += new System.EventHandler(this.peak_picking_method_combobox_SelectedIndexChanged_1);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(0, 241);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 13);
            this.label5.TabIndex = 59;
            this.label5.Text = "Peak Picking Method";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 300);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(176, 13);
            this.label7.TabIndex = 60;
            this.label7.Text = "Works with classic peak picker only";
            // 
            // process_icon
            // 
            this.process_icon.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.process_icon.Image = ((System.Drawing.Image)(resources.GetObject("process_icon.Image")));
            this.process_icon.Location = new System.Drawing.Point(299, 801);
            this.process_icon.Name = "process_icon";
            this.process_icon.Size = new System.Drawing.Size(60, 60);
            this.process_icon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.process_icon.TabIndex = 61;
            this.process_icon.TabStop = false;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(1763, 861);
            this.Controls.Add(this.process_icon);
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menu_strip;
            this.MaximizeBox = false;
            this.Name = "form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Structural Damping Reduction Processor";
            this.Load += new System.EventHandler(this.Form1_Load);
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
            ((System.ComponentModel.ISupportInitialize)(this.process_icon)).EndInit();
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
        private System.Windows.Forms.PictureBox process_icon;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

