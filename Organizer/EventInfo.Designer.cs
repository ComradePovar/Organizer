namespace Organizer
{
    partial class EventInfo
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
            this.lbHome = new System.Windows.Forms.Label();
            this.lbStreet = new System.Windows.Forms.Label();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.lbCity = new System.Windows.Forms.Label();
            this.lbDescription = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.lbEventDescription = new System.Windows.Forms.Label();
            this.lbEventCity = new System.Windows.Forms.Label();
            this.lbEventStreet = new System.Windows.Forms.Label();
            this.lbEventHome = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbHome
            // 
            this.lbHome.AutoSize = true;
            this.lbHome.Location = new System.Drawing.Point(12, 169);
            this.lbHome.Name = "lbHome";
            this.lbHome.Size = new System.Drawing.Size(33, 13);
            this.lbHome.TabIndex = 23;
            this.lbHome.Text = "Дом:";
            // 
            // lbStreet
            // 
            this.lbStreet.AutoSize = true;
            this.lbStreet.Location = new System.Drawing.Point(12, 123);
            this.lbStreet.Name = "lbStreet";
            this.lbStreet.Size = new System.Drawing.Size(42, 13);
            this.lbStreet.TabIndex = 22;
            this.lbStreet.Text = "Улица:";
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Enabled = false;
            this.dateTimePicker.Location = new System.Drawing.Point(53, 209);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(194, 20);
            this.dateTimePicker.TabIndex = 18;
            // 
            // lbCity
            // 
            this.lbCity.AutoSize = true;
            this.lbCity.Location = new System.Drawing.Point(12, 94);
            this.lbCity.Name = "lbCity";
            this.lbCity.Size = new System.Drawing.Size(40, 13);
            this.lbCity.TabIndex = 21;
            this.lbCity.Text = "Город:";
            // 
            // lbDescription
            // 
            this.lbDescription.AutoSize = true;
            this.lbDescription.Location = new System.Drawing.Point(12, 19);
            this.lbDescription.Name = "lbDescription";
            this.lbDescription.Size = new System.Drawing.Size(60, 13);
            this.lbDescription.TabIndex = 19;
            this.lbDescription.Text = "Описание:";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(112, 235);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 20;
            this.btnOk.Text = "ОК";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // lbEventDescription
            // 
            this.lbEventDescription.Location = new System.Drawing.Point(88, 17);
            this.lbEventDescription.Name = "lbEventDescription";
            this.lbEventDescription.Size = new System.Drawing.Size(184, 74);
            this.lbEventDescription.TabIndex = 25;
            // 
            // lbEventCity
            // 
            this.lbEventCity.Location = new System.Drawing.Point(88, 94);
            this.lbEventCity.Name = "lbEventCity";
            this.lbEventCity.Size = new System.Drawing.Size(184, 23);
            this.lbEventCity.TabIndex = 26;
            // 
            // lbEventStreet
            // 
            this.lbEventStreet.Location = new System.Drawing.Point(88, 123);
            this.lbEventStreet.Name = "lbEventStreet";
            this.lbEventStreet.Size = new System.Drawing.Size(184, 37);
            this.lbEventStreet.TabIndex = 27;
            // 
            // lbEventHome
            // 
            this.lbEventHome.Location = new System.Drawing.Point(88, 168);
            this.lbEventHome.Name = "lbEventHome";
            this.lbEventHome.Size = new System.Drawing.Size(181, 23);
            this.lbEventHome.TabIndex = 28;
            // 
            // EventInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.lbEventHome);
            this.Controls.Add(this.lbEventStreet);
            this.Controls.Add(this.lbEventCity);
            this.Controls.Add(this.lbEventDescription);
            this.Controls.Add(this.lbHome);
            this.Controls.Add(this.lbStreet);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.lbCity);
            this.Controls.Add(this.lbDescription);
            this.Controls.Add(this.btnOk);
            this.Name = "EventInfo";
            this.Text = "EventInfo";
            this.Load += new System.EventHandler(this.EventInfo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbHome;
        private System.Windows.Forms.Label lbStreet;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Label lbCity;
        private System.Windows.Forms.Label lbDescription;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label lbEventDescription;
        private System.Windows.Forms.Label lbEventCity;
        private System.Windows.Forms.Label lbEventStreet;
        private System.Windows.Forms.Label lbEventHome;
    }
}