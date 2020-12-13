namespace math_modeling
{
    partial class AnalizeForm2
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
            this.buttonSearch = new System.Windows.Forms.Button();
            this.buttonOutput = new System.Windows.Forms.Button();
            this.ResultChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.ResultChart)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(27, 12);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(161, 45);
            this.buttonSearch.TabIndex = 2;
            this.buttonSearch.Text = "Сгенерировать данные";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // buttonOutput
            // 
            this.buttonOutput.Location = new System.Drawing.Point(211, 12);
            this.buttonOutput.Name = "buttonOutput";
            this.buttonOutput.Size = new System.Drawing.Size(161, 45);
            this.buttonOutput.TabIndex = 3;
            this.buttonOutput.Text = "Показать графики";
            this.buttonOutput.UseVisualStyleBackColor = true;
            this.buttonOutput.Click += new System.EventHandler(this.buttonOutput_Click);
            // 
            // ResultChart
            // 
            chartArea1.Name = "ChartArea1";
            this.ResultChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.ResultChart.Legends.Add(legend1);
            this.ResultChart.Location = new System.Drawing.Point(72, 100);
            this.ResultChart.Name = "ResultChart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.ResultChart.Series.Add(series1);
            this.ResultChart.Size = new System.Drawing.Size(670, 318);
            this.ResultChart.TabIndex = 4;
            this.ResultChart.Text = "Результат";
            // 
            // AnalizeForm2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ResultChart);
            this.Controls.Add(this.buttonOutput);
            this.Controls.Add(this.buttonSearch);
            this.Name = "AnalizeForm2";
            this.Text = "AnalizeForm2";
            ((System.ComponentModel.ISupportInitialize)(this.ResultChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Button buttonOutput;
        private System.Windows.Forms.DataVisualization.Charting.Chart ResultChart;
    }
}