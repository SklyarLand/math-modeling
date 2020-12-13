namespace math_modeling
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.Picture = new System.Windows.Forms.PictureBox();
            this.PointsGenerated = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.AlgoritmsList = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SearchedPoints = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.PointsCount = new System.Windows.Forms.TextBox();
            this.ResultTime = new System.Windows.Forms.TextBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.start = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Picture)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.Picture);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.button1);
            this.splitContainer1.Panel2.Controls.Add(this.PointsGenerated);
            this.splitContainer1.Panel2.Controls.Add(this.label5);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Panel2.Controls.Add(this.AlgoritmsList);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.SearchedPoints);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.PointsCount);
            this.splitContainer1.Panel2.Controls.Add(this.ResultTime);
            this.splitContainer1.Panel2.Controls.Add(this.buttonSearch);
            this.splitContainer1.Panel2.Controls.Add(this.start);
            this.splitContainer1.Size = new System.Drawing.Size(914, 515);
            this.splitContainer1.SplitterDistance = 671;
            this.splitContainer1.TabIndex = 0;
            // 
            // Picture
            // 
            this.Picture.BackColor = System.Drawing.SystemColors.Control;
            this.Picture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Picture.Location = new System.Drawing.Point(0, 0);
            this.Picture.Name = "Picture";
            this.Picture.Size = new System.Drawing.Size(671, 515);
            this.Picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Picture.TabIndex = 0;
            this.Picture.TabStop = false;
            // 
            // PointsGenerated
            // 
            this.PointsGenerated.Location = new System.Drawing.Point(12, 149);
            this.PointsGenerated.Name = "PointsGenerated";
            this.PointsGenerated.Size = new System.Drawing.Size(131, 20);
            this.PointsGenerated.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 133);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Сгенерировано точек:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 192);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Выберите Алгоритм";
            // 
            // AlgoritmsList
            // 
            this.AlgoritmsList.FormattingEnabled = true;
            this.AlgoritmsList.Location = new System.Drawing.Point(12, 208);
            this.AlgoritmsList.Name = "AlgoritmsList";
            this.AlgoritmsList.Size = new System.Drawing.Size(120, 56);
            this.AlgoritmsList.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 357);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Точек в окне";
            // 
            // SearchedPoints
            // 
            this.SearchedPoints.Location = new System.Drawing.Point(12, 373);
            this.SearchedPoints.Name = "SearchedPoints";
            this.SearchedPoints.Size = new System.Drawing.Size(131, 20);
            this.SearchedPoints.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 318);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "затраченное время, мс";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Количество точек для генерации";
            // 
            // PointsCount
            // 
            this.PointsCount.Location = new System.Drawing.Point(12, 92);
            this.PointsCount.Name = "PointsCount";
            this.PointsCount.Size = new System.Drawing.Size(131, 20);
            this.PointsCount.TabIndex = 3;
            // 
            // ResultTime
            // 
            this.ResultTime.Location = new System.Drawing.Point(12, 334);
            this.ResultTime.Name = "ResultTime";
            this.ResultTime.Size = new System.Drawing.Size(131, 20);
            this.ResultTime.TabIndex = 2;
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(46, 270);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(129, 45);
            this.buttonSearch.TabIndex = 1;
            this.buttonSearch.Text = "Поиск";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.Search);
            // 
            // start
            // 
            this.start.Location = new System.Drawing.Point(46, 26);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(133, 35);
            this.start.TabIndex = 0;
            this.start.Text = "Сгенерировать";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.Generate);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 458);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(215, 45);
            this.button1.TabIndex = 12;
            this.button1.Text = "Перейти к анализу";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.To_Analize_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 515);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.LoadForm);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Picture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PictureBox Picture;
        private System.Windows.Forms.Button start;
        private System.Windows.Forms.TextBox ResultTime;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.TextBox PointsCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox SearchedPoints;
        private System.Windows.Forms.ListBox AlgoritmsList;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox PointsGenerated;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
    }
}

