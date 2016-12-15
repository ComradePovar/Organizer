namespace Organizer.UC.Statistic
{
    partial class EventItem
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tsEventItem = new System.Windows.Forms.ToolStrip();
            this.tslTitle = new System.Windows.Forms.ToolStripLabel();
            this.tslDate = new System.Windows.Forms.ToolStripLabel();
            this.tsEventItem.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsEventItem
            // 
            this.tsEventItem.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslTitle,
            this.tslDate});
            this.tsEventItem.Location = new System.Drawing.Point(0, 0);
            this.tsEventItem.Name = "tsEventItem";
            this.tsEventItem.Size = new System.Drawing.Size(328, 25);
            this.tsEventItem.TabIndex = 0;
            this.tsEventItem.Text = "toolStrip1";
            this.tsEventItem.Click += new System.EventHandler(this.tsEventItem_Click);
            // 
            // tslTitle
            // 
            this.tslTitle.Name = "tslTitle";
            this.tslTitle.Size = new System.Drawing.Size(30, 22);
            this.tslTitle.Text = "Title";
            // 
            // tslDate
            // 
            this.tslDate.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tslDate.Name = "tslDate";
            this.tslDate.Size = new System.Drawing.Size(32, 22);
            this.tslDate.Text = "Дата";
            // 
            // EventItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tsEventItem);
            this.Name = "EventItem";
            this.Size = new System.Drawing.Size(328, 25);
            this.Load += new System.EventHandler(this.EventItem_Load);
            this.tsEventItem.ResumeLayout(false);
            this.tsEventItem.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsEventItem;
        private System.Windows.Forms.ToolStripLabel tslTitle;
        private System.Windows.Forms.ToolStripLabel tslDate;
    }
}
