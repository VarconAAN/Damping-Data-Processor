
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.data_chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.trim_data_button = new System.Windows.Forms.Button();
            this.calculate_damp_ratio_and_freq_button = new System.Windows.Forms.Button();
            this.select_input_folder_button1 = new System.Windows.Forms.Button();
            this.input_folder_textbox = new System.Windows.Forms.TextBox();
            this.input_csv_checkedlistbox = new System.Windows.Forms.CheckedListBox();
            this.deselect_all_button = new System.Windows.Forms.Button();
            this.select_all_button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.select_data_set_combobox = new System.Windows.Forms.ComboBox();
            this.reset_data_trimming_button = new System.Windows.Forms.Button();
            this.low_freq_cutoff_numupdown = new System.Windows.Forms.NumericUpDown();
            this.high_freq_cutoff_numupdown = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.apply_filter_button = new System.Windows.Forms.Button();
            this.remove_filter_button = new System.Windows.Forms.Button();
            this.freq_chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.summary_results_textbox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.freq_plot_cutoff_numupdown = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.select_data_direction_check_list_box = new System.Windows.Forms.CheckedListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.data_chart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.low_freq_cutoff_numupdown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.high_freq_cutoff_numupdown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.freq_chart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.freq_plot_cutoff_numupdown)).BeginInit();
            this.SuspendLayout();
            // 
            // data_chart
            // 
            chartArea3.Name = "ChartArea1";
            this.data_chart.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.data_chart.Legends.Add(legend3);
            this.data_chart.Location = new System.Drawing.Point(456, 33);
            this.data_chart.Name = "data_chart";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.data_chart.Series.Add(series3);
            this.data_chart.Size = new System.Drawing.Size(1298, 578);
            this.data_chart.TabIndex = 0;
            this.data_chart.Text = "chart1";
            this.data_chart.MouseClick += new System.Windows.Forms.MouseEventHandler(this.x_data_chart_Click);
            // 
            // trim_data_button
            // 
            this.trim_data_button.Location = new System.Drawing.Point(43, 390);
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
            this.calculate_damp_ratio_and_freq_button.Location = new System.Drawing.Point(43, 500);
            this.calculate_damp_ratio_and_freq_button.Name = "calculate_damp_ratio_and_freq_button";
            this.calculate_damp_ratio_and_freq_button.Size = new System.Drawing.Size(175, 49);
            this.calculate_damp_ratio_and_freq_button.TabIndex = 2;
            this.calculate_damp_ratio_and_freq_button.Text = "Calculate Damping Ratio and Frequency";
            this.calculate_damp_ratio_and_freq_button.UseVisualStyleBackColor = true;
            this.calculate_damp_ratio_and_freq_button.Click += new System.EventHandler(this.calculate_damp_ratio_and_freq_button_Click);
            // 
            // select_input_folder_button1
            // 
            this.select_input_folder_button1.Location = new System.Drawing.Point(3, 3);
            this.select_input_folder_button1.Name = "select_input_folder_button1";
            this.select_input_folder_button1.Size = new System.Drawing.Size(356, 28);
            this.select_input_folder_button1.TabIndex = 4;
            this.select_input_folder_button1.Text = "Select Input Folder";
            this.select_input_folder_button1.UseVisualStyleBackColor = true;
            this.select_input_folder_button1.Click += new System.EventHandler(this.select_input_folder_button1_Click);
            // 
            // input_folder_textbox
            // 
            this.input_folder_textbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.input_folder_textbox.Location = new System.Drawing.Point(3, 37);
            this.input_folder_textbox.Multiline = true;
            this.input_folder_textbox.Name = "input_folder_textbox";
            this.input_folder_textbox.ReadOnly = true;
            this.input_folder_textbox.Size = new System.Drawing.Size(356, 32);
            this.input_folder_textbox.TabIndex = 5;
            // 
            // input_csv_checkedlistbox
            // 
            this.input_csv_checkedlistbox.FormattingEnabled = true;
            this.input_csv_checkedlistbox.Location = new System.Drawing.Point(3, 75);
            this.input_csv_checkedlistbox.Name = "input_csv_checkedlistbox";
            this.input_csv_checkedlistbox.Size = new System.Drawing.Size(356, 259);
            this.input_csv_checkedlistbox.TabIndex = 6;
            this.input_csv_checkedlistbox.SelectedIndexChanged += new System.EventHandler(this.input_csv_checkedlistbox_SelectedIndexChanged);
            // 
            // deselect_all_button
            // 
            this.deselect_all_button.Location = new System.Drawing.Point(3, 340);
            this.deselect_all_button.Name = "deselect_all_button";
            this.deselect_all_button.Size = new System.Drawing.Size(175, 21);
            this.deselect_all_button.TabIndex = 7;
            this.deselect_all_button.Text = "Deselect All";
            this.deselect_all_button.UseVisualStyleBackColor = true;
            this.deselect_all_button.Click += new System.EventHandler(this.deselect_all_button_Click);
            // 
            // select_all_button
            // 
            this.select_all_button.Location = new System.Drawing.Point(184, 340);
            this.select_all_button.Name = "select_all_button";
            this.select_all_button.Size = new System.Drawing.Size(175, 21);
            this.select_all_button.TabIndex = 8;
            this.select_all_button.Text = "Select All";
            this.select_all_button.UseVisualStyleBackColor = true;
            this.select_all_button.Click += new System.EventHandler(this.select_all_button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(366, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Select Data Set";
            // 
            // select_data_set_combobox
            // 
            this.select_data_set_combobox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.select_data_set_combobox.FormattingEnabled = true;
            this.select_data_set_combobox.Location = new System.Drawing.Point(495, 3);
            this.select_data_set_combobox.Name = "select_data_set_combobox";
            this.select_data_set_combobox.Size = new System.Drawing.Size(526, 26);
            this.select_data_set_combobox.TabIndex = 10;
            this.select_data_set_combobox.DropDown += new System.EventHandler(this.select_data_set_combobox_DropDown);
            this.select_data_set_combobox.SelectionChangeCommitted += new System.EventHandler(this.select_data_set_combobox_SelectionChangeCommitted);
            // 
            // reset_data_trimming_button
            // 
            this.reset_data_trimming_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reset_data_trimming_button.Location = new System.Drawing.Point(224, 390);
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
            this.low_freq_cutoff_numupdown.Location = new System.Drawing.Point(43, 442);
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
            this.high_freq_cutoff_numupdown.Location = new System.Drawing.Point(224, 442);
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
            this.label2.Location = new System.Drawing.Point(43, 427);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Low Freq.  Cutoff";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(306, 426);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "High Freq.  Cutoff";
            // 
            // apply_filter_button
            // 
            this.apply_filter_button.Location = new System.Drawing.Point(43, 468);
            this.apply_filter_button.Name = "apply_filter_button";
            this.apply_filter_button.Size = new System.Drawing.Size(175, 26);
            this.apply_filter_button.TabIndex = 27;
            this.apply_filter_button.Text = "Apply Filter to Data";
            this.apply_filter_button.UseVisualStyleBackColor = true;
            this.apply_filter_button.Click += new System.EventHandler(this.apply_filter_button_Click);
            // 
            // remove_filter_button
            // 
            this.remove_filter_button.Location = new System.Drawing.Point(224, 468);
            this.remove_filter_button.Name = "remove_filter_button";
            this.remove_filter_button.Size = new System.Drawing.Size(175, 26);
            this.remove_filter_button.TabIndex = 28;
            this.remove_filter_button.Text = "Remove Filter";
            this.remove_filter_button.UseVisualStyleBackColor = true;
            this.remove_filter_button.Click += new System.EventHandler(this.remove_filter_button_Click);
            // 
            // freq_chart
            // 
            chartArea4.Name = "ChartArea1";
            this.freq_chart.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.freq_chart.Legends.Add(legend4);
            this.freq_chart.Location = new System.Drawing.Point(456, 617);
            this.freq_chart.Name = "freq_chart";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.freq_chart.Series.Add(series4);
            this.freq_chart.Size = new System.Drawing.Size(1298, 188);
            this.freq_chart.TabIndex = 30;
            this.freq_chart.Text = "chart1";
            // 
            // summary_results_textbox
            // 
            this.summary_results_textbox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.summary_results_textbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.summary_results_textbox.Location = new System.Drawing.Point(3, 578);
            this.summary_results_textbox.Multiline = true;
            this.summary_results_textbox.Name = "summary_results_textbox";
            this.summary_results_textbox.ReadOnly = true;
            this.summary_results_textbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.summary_results_textbox.Size = new System.Drawing.Size(444, 227);
            this.summary_results_textbox.TabIndex = 31;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(166, 558);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 17);
            this.label4.TabIndex = 32;
            this.label4.Text = "Results Summary";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // freq_plot_cutoff_numupdown
            // 
            this.freq_plot_cutoff_numupdown.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.freq_plot_cutoff_numupdown.Location = new System.Drawing.Point(341, 504);
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
            this.label5.Location = new System.Drawing.Point(224, 504);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 13);
            this.label5.TabIndex = 34;
            this.label5.Text = "Frequency Response";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(221, 518);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 13);
            this.label6.TabIndex = 35;
            this.label6.Text = " Plot CutOff Frequency";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(221, 533);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 13);
            this.label7.TabIndex = 36;
            this.label7.Text = " (Hz)";
            // 
            // select_data_direction_check_list_box
            // 
            this.select_data_direction_check_list_box.CheckOnClick = true;
            this.select_data_direction_check_list_box.FormattingEnabled = true;
            this.select_data_direction_check_list_box.Location = new System.Drawing.Point(365, 30);
            this.select_data_direction_check_list_box.Name = "select_data_direction_check_list_box";
            this.select_data_direction_check_list_box.Size = new System.Drawing.Size(87, 304);
            this.select_data_direction_check_list_box.TabIndex = 41;
            this.select_data_direction_check_list_box.SelectedIndexChanged += new System.EventHandler(this.select_data_direction_check_list_box_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(365, 337);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 13);
            this.label8.TabIndex = 42;
            this.label8.Text = "VS= Vector Sum";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(1522, 806);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(232, 13);
            this.label9.TabIndex = 43;
            this.label9.Text = "Created by Atlin Anderson for Varcon Inc (2021)";
            // 
            // form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1763, 828);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.select_data_direction_check_list_box);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.freq_plot_cutoff_numupdown);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.summary_results_textbox);
            this.Controls.Add(this.freq_chart);
            this.Controls.Add(this.remove_filter_button);
            this.Controls.Add(this.apply_filter_button);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.high_freq_cutoff_numupdown);
            this.Controls.Add(this.low_freq_cutoff_numupdown);
            this.Controls.Add(this.reset_data_trimming_button);
            this.Controls.Add(this.select_data_set_combobox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.select_all_button);
            this.Controls.Add(this.deselect_all_button);
            this.Controls.Add(this.input_csv_checkedlistbox);
            this.Controls.Add(this.input_folder_textbox);
            this.Controls.Add(this.select_input_folder_button1);
            this.Controls.Add(this.calculate_damp_ratio_and_freq_button);
            this.Controls.Add(this.trim_data_button);
            this.Controls.Add(this.data_chart);
            this.Name = "form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.data_chart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.low_freq_cutoff_numupdown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.high_freq_cutoff_numupdown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.freq_chart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.freq_plot_cutoff_numupdown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart data_chart;
        private System.Windows.Forms.Button trim_data_button;
        private System.Windows.Forms.Button calculate_damp_ratio_and_freq_button;
        private System.Windows.Forms.Button select_input_folder_button1;
        private System.Windows.Forms.TextBox input_folder_textbox;
        private System.Windows.Forms.CheckedListBox input_csv_checkedlistbox;
        private System.Windows.Forms.Button deselect_all_button;
        private System.Windows.Forms.Button select_all_button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox select_data_set_combobox;
        private System.Windows.Forms.Button reset_data_trimming_button;
        private System.Windows.Forms.NumericUpDown low_freq_cutoff_numupdown;
        private System.Windows.Forms.NumericUpDown high_freq_cutoff_numupdown;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button apply_filter_button;
        private System.Windows.Forms.Button remove_filter_button;
        private System.Windows.Forms.DataVisualization.Charting.Chart freq_chart;
        private System.Windows.Forms.TextBox summary_results_textbox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown freq_plot_cutoff_numupdown;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckedListBox select_data_direction_check_list_box;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
    }
}

