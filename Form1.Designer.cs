
namespace Damping_Data_Processor
{
    partial class select_input_folder_button
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea7 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend7 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea8 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend8 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.x_data_chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.trim_data_button = new System.Windows.Forms.Button();
            this.calculate_damp_ratio_and_freq_button = new System.Windows.Forms.Button();
            this.save_trim_data_csv_button = new System.Windows.Forms.Button();
            this.select_input_folder_button1 = new System.Windows.Forms.Button();
            this.input_folder_textbox = new System.Windows.Forms.TextBox();
            this.input_csv_checkedlistbox = new System.Windows.Forms.CheckedListBox();
            this.deselect_all_button = new System.Windows.Forms.Button();
            this.select_all_button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.select_data_set_combobox = new System.Windows.Forms.ComboBox();
            this.y_data_chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.z_data_chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.reset_data_trimming_button = new System.Windows.Forms.Button();
            this.display_z_checkbox = new System.Windows.Forms.CheckBox();
            this.display_y_checkbox = new System.Windows.Forms.CheckBox();
            this.psd_chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.low_freq_cutoff_numupdown = new System.Windows.Forms.NumericUpDown();
            this.high_freq_cutoff_numupdown = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.apply_filter_button = new System.Windows.Forms.Button();
            this.remove_filter_button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.x_data_chart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.y_data_chart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.z_data_chart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.psd_chart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.low_freq_cutoff_numupdown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.high_freq_cutoff_numupdown)).BeginInit();
            this.SuspendLayout();
            // 
            // x_data_chart
            // 
            chartArea5.Name = "ChartArea1";
            this.x_data_chart.ChartAreas.Add(chartArea5);
            legend5.Name = "Legend1";
            this.x_data_chart.Legends.Add(legend5);
            this.x_data_chart.Location = new System.Drawing.Point(404, 33);
            this.x_data_chart.Name = "x_data_chart";
            series5.ChartArea = "ChartArea1";
            series5.Legend = "Legend1";
            series5.Name = "Series1";
            this.x_data_chart.Series.Add(series5);
            this.x_data_chart.Size = new System.Drawing.Size(1350, 254);
            this.x_data_chart.TabIndex = 0;
            this.x_data_chart.Text = "chart1";
            this.x_data_chart.AnnotationPositionChanged += new System.EventHandler(this.x_data_chart_AnnotationPositionChanged);
            this.x_data_chart.MouseClick += new System.Windows.Forms.MouseEventHandler(this.x_data_chart_Click);
            // 
            // trim_data_button
            // 
            this.trim_data_button.Location = new System.Drawing.Point(3, 367);
            this.trim_data_button.Name = "trim_data_button";
            this.trim_data_button.Size = new System.Drawing.Size(175, 27);
            this.trim_data_button.TabIndex = 1;
            this.trim_data_button.Text = "Trim Data";
            this.trim_data_button.UseVisualStyleBackColor = true;
            this.trim_data_button.Click += new System.EventHandler(this.trim_data_button_Click);
            // 
            // calculate_damp_ratio_and_freq_button
            // 
            this.calculate_damp_ratio_and_freq_button.Location = new System.Drawing.Point(3, 604);
            this.calculate_damp_ratio_and_freq_button.Name = "calculate_damp_ratio_and_freq_button";
            this.calculate_damp_ratio_and_freq_button.Size = new System.Drawing.Size(356, 26);
            this.calculate_damp_ratio_and_freq_button.TabIndex = 2;
            this.calculate_damp_ratio_and_freq_button.Text = "Calculate Damping Ratio and Frequency";
            this.calculate_damp_ratio_and_freq_button.UseVisualStyleBackColor = true;
            this.calculate_damp_ratio_and_freq_button.Click += new System.EventHandler(this.calculate_damp_ratio_and_freq_button_Click);
            // 
            // save_trim_data_csv_button
            // 
            this.save_trim_data_csv_button.Location = new System.Drawing.Point(3, 767);
            this.save_trim_data_csv_button.Name = "save_trim_data_csv_button";
            this.save_trim_data_csv_button.Size = new System.Drawing.Size(356, 40);
            this.save_trim_data_csv_button.TabIndex = 3;
            this.save_trim_data_csv_button.Text = "Save Trimmed Data to .csv";
            this.save_trim_data_csv_button.UseVisualStyleBackColor = true;
            this.save_trim_data_csv_button.Click += new System.EventHandler(this.save_trim_data_csv_button_Click);
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
            // y_data_chart
            // 
            chartArea6.Name = "ChartArea1";
            this.y_data_chart.ChartAreas.Add(chartArea6);
            legend6.Name = "Legend1";
            this.y_data_chart.Legends.Add(legend6);
            this.y_data_chart.Location = new System.Drawing.Point(404, 293);
            this.y_data_chart.Name = "y_data_chart";
            series6.ChartArea = "ChartArea1";
            series6.Legend = "Legend1";
            series6.Name = "Series1";
            this.y_data_chart.Series.Add(series6);
            this.y_data_chart.Size = new System.Drawing.Size(1350, 254);
            this.y_data_chart.TabIndex = 11;
            this.y_data_chart.Text = "chart1";
            this.y_data_chart.AnnotationPositionChanged += new System.EventHandler(this.y_data_chart_AnnotationPositionChanged);
            // 
            // z_data_chart
            // 
            chartArea7.Name = "ChartArea1";
            this.z_data_chart.ChartAreas.Add(chartArea7);
            legend7.Name = "Legend1";
            this.z_data_chart.Legends.Add(legend7);
            this.z_data_chart.Location = new System.Drawing.Point(404, 553);
            this.z_data_chart.Name = "z_data_chart";
            series7.ChartArea = "ChartArea1";
            series7.Legend = "Legend1";
            series7.Name = "Series1";
            this.z_data_chart.Series.Add(series7);
            this.z_data_chart.Size = new System.Drawing.Size(1350, 254);
            this.z_data_chart.TabIndex = 12;
            this.z_data_chart.Text = "chart1";
            this.z_data_chart.AnnotationPositionChanged += new System.EventHandler(this.z_data_chart_AnnotationPositionChanged);
            // 
            // reset_data_trimming_button
            // 
            this.reset_data_trimming_button.Location = new System.Drawing.Point(184, 367);
            this.reset_data_trimming_button.Name = "reset_data_trimming_button";
            this.reset_data_trimming_button.Size = new System.Drawing.Size(175, 27);
            this.reset_data_trimming_button.TabIndex = 13;
            this.reset_data_trimming_button.Text = "Reset Data Trimming";
            this.reset_data_trimming_button.UseVisualStyleBackColor = true;
            this.reset_data_trimming_button.Click += new System.EventHandler(this.reset_data_trimming_button_Click);
            // 
            // display_z_checkbox
            // 
            this.display_z_checkbox.AutoSize = true;
            this.display_z_checkbox.Checked = true;
            this.display_z_checkbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.display_z_checkbox.Location = new System.Drawing.Point(365, 56);
            this.display_z_checkbox.Name = "display_z_checkbox";
            this.display_z_checkbox.Size = new System.Drawing.Size(33, 17);
            this.display_z_checkbox.TabIndex = 15;
            this.display_z_checkbox.Text = "Z";
            this.display_z_checkbox.UseVisualStyleBackColor = true;
            // 
            // display_y_checkbox
            // 
            this.display_y_checkbox.AutoSize = true;
            this.display_y_checkbox.Checked = true;
            this.display_y_checkbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.display_y_checkbox.Location = new System.Drawing.Point(365, 33);
            this.display_y_checkbox.Name = "display_y_checkbox";
            this.display_y_checkbox.Size = new System.Drawing.Size(33, 17);
            this.display_y_checkbox.TabIndex = 16;
            this.display_y_checkbox.Text = "Y";
            this.display_y_checkbox.UseVisualStyleBackColor = true;
            // 
            // psd_chart
            // 
            chartArea8.Name = "ChartArea1";
            this.psd_chart.ChartAreas.Add(chartArea8);
            legend8.Name = "Legend1";
            this.psd_chart.Legends.Add(legend8);
            this.psd_chart.Location = new System.Drawing.Point(3, 636);
            this.psd_chart.Name = "psd_chart";
            series8.ChartArea = "ChartArea1";
            series8.Legend = "Legend1";
            series8.Name = "Series1";
            this.psd_chart.Series.Add(series8);
            this.psd_chart.Size = new System.Drawing.Size(356, 125);
            this.psd_chart.TabIndex = 17;
            this.psd_chart.Text = "chart1";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(365, 316);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(33, 17);
            this.checkBox1.TabIndex = 19;
            this.checkBox1.Text = "Z";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Checked = true;
            this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox2.Location = new System.Drawing.Point(365, 293);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(33, 17);
            this.checkBox2.TabIndex = 18;
            this.checkBox2.Text = "X";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Checked = true;
            this.checkBox3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox3.Location = new System.Drawing.Point(365, 576);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(33, 17);
            this.checkBox3.TabIndex = 21;
            this.checkBox3.Text = "Y";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Checked = true;
            this.checkBox4.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox4.Location = new System.Drawing.Point(365, 553);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(33, 17);
            this.checkBox4.TabIndex = 20;
            this.checkBox4.Text = "X";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // low_freq_cutoff_numupdown
            // 
            this.low_freq_cutoff_numupdown.DecimalPlaces = 3;
            this.low_freq_cutoff_numupdown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.low_freq_cutoff_numupdown.Location = new System.Drawing.Point(3, 419);
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
            this.high_freq_cutoff_numupdown.Location = new System.Drawing.Point(184, 419);
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
            this.label2.Location = new System.Drawing.Point(3, 404);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Low Freq.  Cutoff";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(266, 403);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "High Freq.  Cutoff";
            // 
            // apply_filter_button
            // 
            this.apply_filter_button.Location = new System.Drawing.Point(3, 445);
            this.apply_filter_button.Name = "apply_filter_button";
            this.apply_filter_button.Size = new System.Drawing.Size(175, 26);
            this.apply_filter_button.TabIndex = 27;
            this.apply_filter_button.Text = "Apply Filter to Data";
            this.apply_filter_button.UseVisualStyleBackColor = true;
            this.apply_filter_button.Click += new System.EventHandler(this.apply_filter_button_Click);
            // 
            // remove_filter_button
            // 
            this.remove_filter_button.Location = new System.Drawing.Point(184, 445);
            this.remove_filter_button.Name = "remove_filter_button";
            this.remove_filter_button.Size = new System.Drawing.Size(175, 26);
            this.remove_filter_button.TabIndex = 28;
            this.remove_filter_button.Text = "Remove Filter";
            this.remove_filter_button.UseVisualStyleBackColor = true;
            // 
            // select_input_folder_button
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1763, 807);
            this.Controls.Add(this.remove_filter_button);
            this.Controls.Add(this.apply_filter_button);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.high_freq_cutoff_numupdown);
            this.Controls.Add(this.low_freq_cutoff_numupdown);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.checkBox4);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.psd_chart);
            this.Controls.Add(this.display_y_checkbox);
            this.Controls.Add(this.display_z_checkbox);
            this.Controls.Add(this.reset_data_trimming_button);
            this.Controls.Add(this.z_data_chart);
            this.Controls.Add(this.y_data_chart);
            this.Controls.Add(this.select_data_set_combobox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.select_all_button);
            this.Controls.Add(this.deselect_all_button);
            this.Controls.Add(this.input_csv_checkedlistbox);
            this.Controls.Add(this.input_folder_textbox);
            this.Controls.Add(this.select_input_folder_button1);
            this.Controls.Add(this.save_trim_data_csv_button);
            this.Controls.Add(this.calculate_damp_ratio_and_freq_button);
            this.Controls.Add(this.trim_data_button);
            this.Controls.Add(this.x_data_chart);
            this.Name = "select_input_folder_button";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.x_data_chart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.y_data_chart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.z_data_chart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.psd_chart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.low_freq_cutoff_numupdown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.high_freq_cutoff_numupdown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart x_data_chart;
        private System.Windows.Forms.Button trim_data_button;
        private System.Windows.Forms.Button calculate_damp_ratio_and_freq_button;
        private System.Windows.Forms.Button save_trim_data_csv_button;
        private System.Windows.Forms.Button select_input_folder_button1;
        private System.Windows.Forms.TextBox input_folder_textbox;
        private System.Windows.Forms.CheckedListBox input_csv_checkedlistbox;
        private System.Windows.Forms.Button deselect_all_button;
        private System.Windows.Forms.Button select_all_button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox select_data_set_combobox;
        private System.Windows.Forms.DataVisualization.Charting.Chart y_data_chart;
        private System.Windows.Forms.DataVisualization.Charting.Chart z_data_chart;
        private System.Windows.Forms.Button reset_data_trimming_button;
        private System.Windows.Forms.CheckBox display_z_checkbox;
        private System.Windows.Forms.CheckBox display_y_checkbox;
        private System.Windows.Forms.DataVisualization.Charting.Chart psd_chart;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.NumericUpDown low_freq_cutoff_numupdown;
        private System.Windows.Forms.NumericUpDown high_freq_cutoff_numupdown;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button apply_filter_button;
        private System.Windows.Forms.Button remove_filter_button;
    }
}

