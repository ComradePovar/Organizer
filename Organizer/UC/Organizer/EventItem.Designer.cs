namespace Organizer.UC.Organizer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EventItem));
            this.eventMenu = new System.Windows.Forms.ToolStrip();
            this.tslEventTitle = new System.Windows.Forms.ToolStripLabel();
            this.tsbDel = new System.Windows.Forms.ToolStripButton();
            this.tsbComplete = new System.Windows.Forms.ToolStripButton();
            this.eventMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // eventMenu
            // 
            this.eventMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.eventMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslEventTitle,
            this.tsbDel,
            this.tsbComplete});
            this.eventMenu.Location = new System.Drawing.Point(0, 0);
            this.eventMenu.Name = "eventMenu";
            this.eventMenu.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.eventMenu.Size = new System.Drawing.Size(160, 25);
            this.eventMenu.TabIndex = 0;
            this.eventMenu.Text = "toolStrip1";
            // 
            // tslEventTitle
            // 
            this.tslEventTitle.Name = "tslEventTitle";
            this.tslEventTitle.Size = new System.Drawing.Size(30, 22);
            this.tslEventTitle.Text = "Title";
            // 
            // tsbDel
            // 
            this.tsbDel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbDel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbDel.Image = ((System.Drawing.Image)(resources.GetObject("tsbDel.Image")));
            this.tsbDel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDel.Name = "tsbDel";
            this.tsbDel.Size = new System.Drawing.Size(23, 22);
            this.tsbDel.Text = "toolStripButton1";
            this.tsbDel.Click += new System.EventHandler(this.tsbDel_Click);
            // 
            // tsbComplete
            // 
            this.tsbComplete.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbComplete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbComplete.Image = ((System.Drawing.Image)(resources.GetObject("tsbComplete.Image")));
            this.tsbComplete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbComplete.Name = "tsbComplete";
            this.tsbComplete.Size = new System.Drawing.Size(23, 22);
            this.tsbComplete.Click += new System.EventHandler(this.tsbComplete_Click);
            // 
            // EventItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.eventMenu);
            this.Name = "EventItem";
            this.Size = new System.Drawing.Size(160, 25);
            this.Load += new System.EventHandler(this.EventItem_Load);
            this.eventMenu.ResumeLayout(false);
            this.eventMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip eventMenu;
        private System.Windows.Forms.ToolStripLabel tslEventTitle;
        private System.Windows.Forms.ToolStripButton tsbComplete;
        private System.Windows.Forms.ToolStripButton tsbDel;
    }
}
