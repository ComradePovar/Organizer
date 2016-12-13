namespace Organizer.UC.Organizer
{
    partial class AddEditEvent
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
            this.tbHome = new System.Windows.Forms.TextBox();
            this.btnAddEditEvent = new System.Windows.Forms.Button();
            this.tbStreet = new System.Windows.Forms.TextBox();
            this.tbCity = new System.Windows.Forms.TextBox();
            this.lbDescription = new System.Windows.Forms.Label();
            this.lbCity = new System.Windows.Forms.Label();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.tbDescription = new System.Windows.Forms.RichTextBox();
            this.lbStreet = new System.Windows.Forms.Label();
            this.lbHome = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbHome
            // 
            this.tbHome.Location = new System.Drawing.Point(65, 109);
            this.tbHome.MaxLength = 5;
            this.tbHome.Name = "tbHome";
            this.tbHome.Size = new System.Drawing.Size(128, 20);
            this.tbHome.TabIndex = 4;
            // 
            // btnAddEditEvent
            // 
            this.btnAddEditEvent.Location = new System.Drawing.Point(104, 158);
            this.btnAddEditEvent.Name = "btnAddEditEvent";
            this.btnAddEditEvent.Size = new System.Drawing.Size(75, 23);
            this.btnAddEditEvent.TabIndex = 6;
            this.btnAddEditEvent.Text = "Создать";
            this.btnAddEditEvent.UseVisualStyleBackColor = true;
            this.btnAddEditEvent.Click += new System.EventHandler(this.btnAddEditEvent_Click);
            // 
            // tbStreet
            // 
            this.tbStreet.Location = new System.Drawing.Point(65, 83);
            this.tbStreet.MaxLength = 100;
            this.tbStreet.Name = "tbStreet";
            this.tbStreet.Size = new System.Drawing.Size(128, 20);
            this.tbStreet.TabIndex = 2;
            // 
            // tbCity
            // 
            this.tbCity.Location = new System.Drawing.Point(65, 57);
            this.tbCity.MaxLength = 50;
            this.tbCity.Name = "tbCity";
            this.tbCity.Size = new System.Drawing.Size(128, 20);
            this.tbCity.TabIndex = 3;
            // 
            // lbDescription
            // 
            this.lbDescription.AutoSize = true;
            this.lbDescription.Location = new System.Drawing.Point(4, 9);
            this.lbDescription.Name = "lbDescription";
            this.lbDescription.Size = new System.Drawing.Size(60, 13);
            this.lbDescription.TabIndex = 6;
            this.lbDescription.Text = "Описание:";
            // 
            // lbCity
            // 
            this.lbCity.AutoSize = true;
            this.lbCity.Location = new System.Drawing.Point(4, 57);
            this.lbCity.Name = "lbCity";
            this.lbCity.Size = new System.Drawing.Size(40, 13);
            this.lbCity.TabIndex = 7;
            this.lbCity.Text = "Город:";
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(0, 135);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(194, 20);
            this.dateTimePicker.TabIndex = 5;
            // 
            // tbDescription
            // 
            this.tbDescription.Location = new System.Drawing.Point(65, 6);
            this.tbDescription.MaxLength = 50;
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Size = new System.Drawing.Size(128, 48);
            this.tbDescription.TabIndex = 1;
            this.tbDescription.Text = "";
            // 
            // lbStreet
            // 
            this.lbStreet.AutoSize = true;
            this.lbStreet.Location = new System.Drawing.Point(4, 86);
            this.lbStreet.Name = "lbStreet";
            this.lbStreet.Size = new System.Drawing.Size(42, 13);
            this.lbStreet.TabIndex = 11;
            this.lbStreet.Text = "Улица:";
            // 
            // lbHome
            // 
            this.lbHome.AutoSize = true;
            this.lbHome.Location = new System.Drawing.Point(4, 112);
            this.lbHome.Name = "lbHome";
            this.lbHome.Size = new System.Drawing.Size(33, 13);
            this.lbHome.TabIndex = 12;
            this.lbHome.Text = "Дом:";
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(23, 158);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 13;
            this.btnBack.Text = "Назад";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // AddEditEvent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.lbHome);
            this.Controls.Add(this.lbStreet);
            this.Controls.Add(this.tbDescription);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.lbCity);
            this.Controls.Add(this.lbDescription);
            this.Controls.Add(this.tbCity);
            this.Controls.Add(this.tbStreet);
            this.Controls.Add(this.btnAddEditEvent);
            this.Controls.Add(this.tbHome);
            this.Name = "AddEditEvent";
            this.Size = new System.Drawing.Size(197, 181);
            this.Load += new System.EventHandler(this.NewEvent_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbHome;
        private System.Windows.Forms.Button btnAddEditEvent;
        private System.Windows.Forms.TextBox tbStreet;
        private System.Windows.Forms.TextBox tbCity;
        private System.Windows.Forms.Label lbDescription;
        private System.Windows.Forms.Label lbCity;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.RichTextBox tbDescription;
        private System.Windows.Forms.Label lbStreet;
        private System.Windows.Forms.Label lbHome;
        private System.Windows.Forms.Button btnBack;
    }
}
