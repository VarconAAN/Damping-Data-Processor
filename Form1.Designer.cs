
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
            this.freq_plot_cutoff_numupdown = new System.Windows.Forms.NumericUpDown();
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
            this.clearSessionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label12 = new System.Windows.Forms.Label();
            this.exportResultsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportResultsSummaryEditedDatasetsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label4 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.selected_data_set_textbox = new System.Windows.Forms.TextBox();
            this.select_data_set_tool_strip_combo_box = new System.Windows.Forms.ToolStripComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.data_chart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.low_freq_cutoff_numupdown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.high_freq_cutoff_numupdown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.freq_dft_chart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.freq_plot_cutoff_numupdown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.freq_peaks_chart)).BeginInit();
            this.menu_strip.SuspendLayout();
            this.SuspendLayout();
            // 
            // data_chart
            // 
            chartArea4.Name = "ChartArea1";
            this.data_chart.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.data_chart.Legends.Add(legend4);
            this.data_chart.Location = new System.Drawing.Point(369, 32);
            this.data_chart.Name = "data_chart";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.data_chart.Series.Add(series4);
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
            this.input_folder_textbox.Size = new System.Drawing.Size(268, 56);
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
            chartArea5.Name = "ChartArea1";
            this.freq_dft_chart.ChartAreas.Add(chartArea5);
            legend5.Name = "Legend1";
            this.freq_dft_chart.Legends.Add(legend5);
            this.freq_dft_chart.Location = new System.Drawing.Point(369, 668);
            this.freq_dft_chart.Name = "freq_dft_chart";
            series5.ChartArea = "ChartArea1";
            series5.Legend = "Legend1";
            series5.Name = "Series1";
            this.freq_dft_chart.Series.Add(series5);
            this.freq_dft_chart.Size = new System.Drawing.Size(723, 184);
            this.freq_dft_chart.TabIndex = 30;
            this.freq_dft_chart.Text = "chart1";
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
            this.summary_results_textbox.Size = new System.Drawing.Size(361, 490);
            this.summary_results_textbox.TabIndex = 31;
            // 
            // freq_plot_cutoff_numupdown
            // 
            this.freq_plot_cutoff_numupdown.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.freq_plot_cutoff_numupdown.Location = new System.Drawing.Point(300, 277);
            this.freq_plot_cutoff_numupdown.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.freq_plot_cutoff_numupdown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.freq_plot_cutoff_numupdown.Name = "freq_plot_cutoff_numupdown";
            this.freq_plot_cutoff_numupdown.Size = new System.Drawing.Size(55, 26);
            this.freq_plot_cutoff_numupdown.TabIndex = 33;
            this.freq_plot_cutoff_numupdown.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
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
            this.label6.Size = new System.Drawing.Size(114, 13);
            this.label6.TabIndex = 35;
            this.label6.Text = " Plot CutOff Frequency";
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
            chartArea6.Name = "ChartArea1";
            this.freq_peaks_chart.ChartAreas.Add(chartArea6);
            legend6.Name = "Legend1";
            this.freq_peaks_chart.Legends.Add(legend6);
            this.freq_peaks_chart.Location = new System.Drawing.Point(1098, 668);
            this.freq_peaks_chart.Name = "freq_peaks_chart";
            series6.ChartArea = "ChartArea1";
            series6.Legend = "Legend1";
            series6.Name = "Series1";
            this.freq_peaks_chart.Series.Add(series6);
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
            this.exportResultsToolStripMenuItem});
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
            this.loadSessionToolStripMenuItem,
            this.clearSessionToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 23);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // selectInputFolderToolStripMenuItem
            // 
            this.selectInputFolderToolStripMenuItem.Name = "selectInputFolderToolStripMenuItem";
            this.selectInputFolderToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.selectInputFolderToolStripMenuItem.Text = "Select Input Folder";
            this.selectInputFolderToolStripMenuItem.Click += new System.EventHandler(this.selectInputFolderToolStripMenuItem_Click);
            // 
            // saveSessionToolStripMenuItem
            // 
            this.saveSessionToolStripMenuItem.Name = "saveSessionToolStripMenuItem";
            this.saveSessionToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveSessionToolStripMenuItem.Text = "Save Session";
            // 
            // loadSessionToolStripMenuItem
            // 
            this.loadSessionToolStripMenuItem.Name = "loadSessionToolStripMenuItem";
            this.loadSessionToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.loadSessionToolStripMenuItem.Text = "Load Session";
            // 
            // clearSessionToolStripMenuItem
            // 
            this.clearSessionToolStripMenuItem.Name = "clearSessionToolStripMenuItem";
            this.clearSessionToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.clearSessionToolStripMenuItem.Text = "Clear Session";
            this.clearSessionToolStripMenuItem.Click += new System.EventHandler(this.clearSessionToolStripMenuItem_Click);
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
            // exportResultsToolStripMenuItem
            // 
            this.exportResultsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportResultsSummaryEditedDatasetsToolStripMenuItem});
            this.exportResultsToolStripMenuItem.Name = "exportResultsToolStripMenuItem";
            this.exportResultsToolStripMenuItem.Size = new System.Drawing.Size(93, 23);
            this.exportResultsToolStripMenuItem.Text = "Export Results";
            // 
            // exportResultsSummaryEditedDatasetsToolStripMenuItem
            // 
            this.exportResultsSummaryEditedDatasetsToolStripMenuItem.Name = "exportResultsSummaryEditedDatasetsToolStripMenuItem";
            this.exportResultsSummaryEditedDatasetsToolStripMenuItem.Size = new System.Drawing.Size(308, 22);
            this.exportResultsSummaryEditedDatasetsToolStripMenuItem.Text = "Export Results Summary and Edited Datasets";
            this.exportResultsSummaryEditedDatasetsToolStripMenuItem.Click += new System.EventHandler(this.exportResultsSummaryEditedDatasetsToolStripMenuItem_Click);
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
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(86, 103);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(94, 13);
            this.label13.TabIndex = 51;
            this.label13.Text = "Selected Data Set";
            // 
            // selected_data_set_textbox
            // 
            this.selected_data_set_textbox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.selected_data_set_textbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selected_data_set_textbox.Location = new System.Drawing.Point(2, 119);
            this.selected_data_set_textbox.Multiline = true;
            this.selected_data_set_textbox.Name = "selected_data_set_textbox";
            this.selected_data_set_textbox.ReadOnly = true;
            this.selected_data_set_textbox.Size = new System.Drawing.Size(268, 38);
            this.selected_data_set_textbox.TabIndex = 50;
            // 
            // select_data_set_tool_strip_combo_box
            // 
            this.select_data_set_tool_strip_combo_box.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.select_data_set_tool_strip_combo_box.MaxDropDownItems = 100;
            this.select_data_set_tool_strip_combo_box.Name = "select_data_set_tool_strip_combo_box";
            this.select_data_set_tool_strip_combo_box.Size = new System.Drawing.Size(400, 23);
            this.select_data_set_tool_strip_combo_box.SelectedIndexChanged += new System.EventHandler(this.select_data_set_tool_strip_combo_box_SelectedIndexChanged_1);
            // 
            // form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1763, 861);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.selected_data_set_textbox);
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
            this.Controls.Add(this.freq_plot_cutoff_numupdown);
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
            this.Text = "Structrual Damping Data Processor";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.data_chart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.low_freq_cutoff_numupdown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.high_freq_cutoff_numupdown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.freq_dft_chart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.freq_plot_cutoff_numupdown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.freq_peaks_chart)).EndInit();
            this.menu_strip.ResumeLayout(false);
            this.menu_strip.PerformLayout();
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
        private System.Windows.Forms.NumericUpDown freq_plot_cutoff_numupdown;
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
        private System.Windows.Forms.ToolStripMenuItem clearSessionToolStripMenuItem;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ToolStripMenuItem exportResultsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportResultsSummaryEditedDatasetsToolStripMenuItem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox selected_data_set_textbox;
        private System.Windows.Forms.ToolStripComboBox select_data_set_tool_strip_combo_box;
    }
}

