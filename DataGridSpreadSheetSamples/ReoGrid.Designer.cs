namespace DataGridSpreadSheetSamples
{
    partial class ReoGrid
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
            this.reoGrd = new unvell.ReoGrid.ReoGridControl();
            this.SuspendLayout();
            // 
            // reoGrd
            // 
            this.reoGrd.BackColor = System.Drawing.Color.White;
            this.reoGrd.ColumnHeaderContextMenuStrip = null;
            this.reoGrd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reoGrd.LeadHeaderContextMenuStrip = null;
            this.reoGrd.Location = new System.Drawing.Point(0, 0);
            this.reoGrd.Name = "reoGrd";
            this.reoGrd.RowHeaderContextMenuStrip = null;
            this.reoGrd.Script = null;
            this.reoGrd.SheetTabContextMenuStrip = null;
            this.reoGrd.SheetTabNewButtonVisible = true;
            this.reoGrd.SheetTabVisible = true;
            this.reoGrd.SheetTabWidth = 60;
            this.reoGrd.ShowScrollEndSpacing = true;
            this.reoGrd.Size = new System.Drawing.Size(919, 511);
            this.reoGrd.TabIndex = 0;
            this.reoGrd.Text = "reoGridControl1";
            // 
            // ReoGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(919, 511);
            this.Controls.Add(this.reoGrd);
            this.Name = "ReoGrid";
            this.Text = "ReoGrid";
            this.Load += new System.EventHandler(this.ReoGrid_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private unvell.ReoGrid.ReoGridControl reoGrd;
    }
}