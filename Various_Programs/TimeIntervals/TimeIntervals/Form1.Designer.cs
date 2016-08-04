namespace TimeIntervals
{
    partial class Form1
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
            this.dgvTimeIntervals = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimeIntervals)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTimeIntervals
            // 
            this.dgvTimeIntervals.AllowUserToAddRows = false;
            this.dgvTimeIntervals.AllowUserToDeleteRows = false;
            this.dgvTimeIntervals.AllowUserToResizeColumns = false;
            this.dgvTimeIntervals.AllowUserToResizeRows = false;
            this.dgvTimeIntervals.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTimeIntervals.Location = new System.Drawing.Point(259, 13);
            this.dgvTimeIntervals.Name = "dgvTimeIntervals";
            this.dgvTimeIntervals.ReadOnly = true;
            this.dgvTimeIntervals.RowHeadersVisible = false;
            this.dgvTimeIntervals.Size = new System.Drawing.Size(484, 229);
            this.dgvTimeIntervals.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(755, 336);
            this.Controls.Add(this.dgvTimeIntervals);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimeIntervals)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTimeIntervals;
    }
}

