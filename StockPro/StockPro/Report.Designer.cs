
namespace StockPro
{
    partial class Report
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.barchart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgv1 = new System.Windows.Forms.DataGridView();
            this.analysis = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.barchart)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            this.SuspendLayout();
            // 
            // barchart
            // 
            chartArea2.Name = "ChartArea1";
            this.barchart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.barchart.Legends.Add(legend2);
            this.barchart.Location = new System.Drawing.Point(592, 96);
            this.barchart.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.barchart.Name = "barchart";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.barchart.Series.Add(series2);
            this.barchart.Size = new System.Drawing.Size(461, 462);
            this.barchart.TabIndex = 0;
            this.barchart.Text = "chart1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgv1);
            this.groupBox1.Location = new System.Drawing.Point(15, 96);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(577, 462);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách xuất kho";
            // 
            // dgv1
            // 
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv1.Location = new System.Drawing.Point(2, 15);
            this.dgv1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgv1.Name = "dgv1";
            this.dgv1.RowHeadersWidth = 51;
            this.dgv1.RowTemplate.Height = 24;
            this.dgv1.Size = new System.Drawing.Size(571, 447);
            this.dgv1.TabIndex = 0;
            this.dgv1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv1_CellContentClick);
            // 
            // analysis
            // 
            this.analysis.BackColor = System.Drawing.SystemColors.Info;
            this.analysis.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.analysis.Location = new System.Drawing.Point(495, 562);
            this.analysis.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.analysis.Name = "analysis";
            this.analysis.Size = new System.Drawing.Size(93, 33);
            this.analysis.TabIndex = 2;
            this.analysis.Text = "THỐNG KÊ";
            this.analysis.UseVisualStyleBackColor = false;
            this.analysis.Click += new System.EventHandler(this.analysis_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.25F);
            this.label8.Location = new System.Drawing.Point(413, 29);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(218, 46);
            this.label8.TabIndex = 3;
            this.label8.Text = "THỐNG KÊ";
            // 
            // Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1056, 606);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.analysis);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.barchart);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Report";
            this.Text = "Report";
            this.Load += new System.EventHandler(this.Report_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barchart)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart barchart;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgv1;
        private System.Windows.Forms.Button analysis;
        private System.Windows.Forms.Label label8;
    }
}