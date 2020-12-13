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
            this.buttonSearch = new System.Windows.Forms.Button();
            this.buttonOutput = new System.Windows.Forms.Button();
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
            // AnalizeForm2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonOutput);
            this.Controls.Add(this.buttonSearch);
            this.Name = "AnalizeForm2";
            this.Text = "AnalizeForm2";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Button buttonOutput;
    }
}