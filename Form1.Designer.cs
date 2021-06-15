
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
            this.data_chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
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
            this.reset_data_trimming_button = new System.Windows.Forms.Button();
            this.display_z_checkbox = new System.Windows.Forms.CheckBox();
            this.display_y_checkbox = new System.Windows.Forms.CheckBox();
            this.low_freq_cutoff_numupdown = new System.Windows.Forms.NumericUpDown();
            this.high_freq_cutoff_numupdown = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.apply_filter_button = new System.Windows.Forms.Button();
            this.remove_filter_button = new System.Windows.Forms.Button();
            this.display_x_checkbox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.data_chart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.low_freq_cutoff_numupdown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.high_freq_cutoff_numupdown)).BeginInit();
            this.SuspendLayout();
            // 
            // data_chart
            // 
            chartArea1.Name = "ChartArea1";
            this.data_chart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.data_chart.Legends.Add(legend1);
            this.data_chart.Location = new System.Drawing.Point(370, 33);
            this.data_chart.Name = "data_chart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.data_chart.Series.Add(series1);
            this.data_chart.Size = new System.Drawing.Size(1384, 737);
            this.data_chart.TabIndex = 0;
            this.data_chart.Text = "chart1";
            this.data_chart.MouseClick += new System.Windows.Forms.MouseEventHandler(this.x_data_chart_Click);
            // 
            // trim_data_button
            // 
            this.trim_data_button.Location = new System.Drawing.Point(3, 390);
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
            this.calculate_damp_ratio_and_freq_button.Location = new System.Drawing.Point(3, 500);
            this.calculate_damp_ratio_and_freq_button.Name = "calculate_damp_ratio_and_freq_button";
            this.calculate_damp_ratio_and_freq_button.Size = new System.Drawing.Size(356, 26);
            this.calculate_damp_ratio_and_freq_button.TabIndex = 2;
            this.calculate_damp_ratio_and_freq_button.Text = "Calculate Damping Ratio and Frequency";
            this.calculate_damp_ratio_and_freq_button.UseVisualStyleBackColor = true;
            this.calculate_damp_ratio_and_freq_button.Click += new System.EventHandler(this.calculate_damp_ratio_and_freq_button_Click);
            // 
            // save_trim_data_csv_button
            // 
            this.save_trim_data_csv_button.Location = new System.Drawing.Point(0, 617);
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
            // reset_data_trimming_button
            // 
            this.reset_data_trimming_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reset_data_trimming_button.Location = new System.Drawing.Point(184, 390);
            this.reset_data_trimming_button.Name = "reset_data_trimming_button";
            this.reset_data_trimming_button.Size = new System.Drawing.Size(175, 27);
            this.reset_data_trimming_button.TabIndex = 13;
            this.reset_data_trimming_button.Text = "Reset to Original Dataset";
            this.reset_data_trimming_button.UseVisualStyleBackColor = true;
            this.reset_data_trimming_button.Click += new System.EventHandler(this.reset_data_trimming_button_Click);
            // 
            // display_z_checkbox
            // 
            this.display_z_checkbox.AutoSize = true;
            this.display_z_checkbox.Checked = true;
            this.display_z_checkbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.display_z_checkbox.Location = new System.Drawing.Point(1105, 12);
            this.display_z_checkbox.Name = "display_z_checkbox";
            this.display_z_checkbox.Size = new System.Drawing.Size(33, 17);
            this.display_z_checkbox.TabIndex = 15;
            this.display_z_checkbox.Text = "Z";
            this.display_z_checkbox.UseVisualStyleBackColor = true;
            this.display_z_checkbox.CheckedChanged += new System.EventHandler(this.display_z_checkbox_CheckedChanged);
            // 
            // display_y_checkbox
            // 
            this.display_y_checkbox.AutoSize = true;
            this.display_y_checkbox.Checked = true;
            this.display_y_checkbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.display_y_checkbox.Location = new System.Drawing.Point(1066, 10);
            this.display_y_checkbox.Name = "display_y_checkbox";
            this.display_y_checkbox.Size = new System.Drawing.Size(33, 17);
            this.display_y_checkbox.TabIndex = 16;
            this.display_y_checkbox.Text = "Y";
            this.display_y_checkbox.UseVisualStyleBackColor = true;
            this.display_y_checkbox.CheckedChanged += new System.EventHandler(this.display_y_checkbox_CheckedChanged);
            // 
            // low_freq_cutoff_numupdown
            // 
            this.low_freq_cutoff_numupdown.DecimalPlaces = 3;
            this.low_freq_cutoff_numupdown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.low_freq_cutoff_numupdown.Location = new System.Drawing.Point(3, 442);
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
            this.high_freq_cutoff_numupdown.Location = new System.Drawing.Point(184, 442);
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
            this.label2.Location = new System.Drawing.Point(3, 427);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Low Freq.  Cutoff";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(266, 426);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "High Freq.  Cutoff";
            // 
            // apply_filter_button
            // 
            this.apply_filter_button.Location = new System.Drawing.Point(3, 468);
            this.apply_filter_button.Name = "apply_filter_button";
            this.apply_filter_button.Size = new System.Drawing.Size(175, 26);
            this.apply_filter_button.TabIndex = 27;
            this.apply_filter_button.Text = "Apply Filter to Data";
            this.apply_filter_button.UseVisualStyleBackColor = true;
            this.apply_filter_button.Click += new System.EventHandler(this.apply_filter_button_Click);
            // 
            // remove_filter_button
            // 
            this.remove_filter_button.Location = new System.Drawing.Point(184, 468);
            this.remove_filter_button.Name = "remove_filter_button";
            this.remove_filter_button.Size = new System.Drawing.Size(175, 26);
            this.remove_filter_button.TabIndex = 28;
            this.remove_filter_button.Text = "Remove Filter";
            this.remove_filter_button.UseVisualStyleBackColor = true;
            this.remove_filter_button.Click += new System.EventHandler(this.remove_filter_button_Click);
            // 
            // display_x_checkbox
            // 
            this.display_x_checkbox.AutoSize = true;
            this.display_x_checkbox.Checked = true;
            this.display_x_checkbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.display_x_checkbox.Location = new System.Drawing.Point(1027, 10);
            this.display_x_checkbox.Name = "display_x_checkbox";
            this.display_x_checkbox.Size = new System.Drawing.Size(33, 17);
            this.display_x_checkbox.TabIndex = 29;
            this.display_x_checkbox.Text = "X";
            this.display_x_checkbox.UseVisualStyleBackColor = true;
            this.display_x_checkbox.CheckedChanged += new System.EventHandler(this.display_x_checkbox_CheckedChanged);
            // 
            // form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1763, 807);
            this.Controls.Add(this.display_x_checkbox);
            this.Controls.Add(this.remove_filter_button);
            this.Controls.Add(this.apply_filter_button);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.high_freq_cutoff_numupdown);
            this.Controls.Add(this.low_freq_cutoff_numupdown);
            this.Controls.Add(this.display_y_checkbox);
            this.Controls.Add(this.display_z_checkbox);
            this.Controls.Add(this.reset_data_trimming_button);
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
            this.Controls.Add(this.data_chart);
            this.Name = "form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.data_chart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.low_freq_cutoff_numupdown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.high_freq_cutoff_numupdown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart data_chart;
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
        private System.Windows.Forms.Button reset_data_trimming_button;
        private System.Windows.Forms.CheckBox display_z_checkbox;
        private System.Windows.Forms.CheckBox display_y_checkbox;
        private System.Windows.Forms.NumericUpDown low_freq_cutoff_numupdown;
        private System.Windows.Forms.NumericUpDown high_freq_cutoff_numupdown;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button apply_filter_button;
        private System.Windows.Forms.Button remove_filter_button;
        private System.Windows.Forms.CheckBox display_x_checkbox;
    }
}

