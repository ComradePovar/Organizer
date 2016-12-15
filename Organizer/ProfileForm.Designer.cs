namespace Organizer
{
    partial class ProfileForm
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
            this.lbName = new System.Windows.Forms.Label();
            this.lbSurname = new System.Windows.Forms.Label();
            this.lbPhone = new System.Windows.Forms.Label();
            this.lbCity = new System.Windows.Forms.Label();
            this.lbStreet = new System.Windows.Forms.Label();
            this.lbEmail = new System.Windows.Forms.Label();
            this.lbHome = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbSurname = new System.Windows.Forms.TextBox();
            this.tbCity = new System.Windows.Forms.TextBox();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.tbHome = new System.Windows.Forms.TextBox();
            this.tbStreet = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.mtbPhone = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Location = new System.Drawing.Point(13, 13);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(32, 13);
            this.lbName.TabIndex = 0;
            this.lbName.Text = "Имя:";
            // 
            // lbSurname
            // 
            this.lbSurname.AutoSize = true;
            this.lbSurname.Location = new System.Drawing.Point(13, 43);
            this.lbSurname.Name = "lbSurname";
            this.lbSurname.Size = new System.Drawing.Size(59, 13);
            this.lbSurname.TabIndex = 1;
            this.lbSurname.Text = "Фамилия:";
            // 
            // lbPhone
            // 
            this.lbPhone.AutoSize = true;
            this.lbPhone.Location = new System.Drawing.Point(13, 73);
            this.lbPhone.Name = "lbPhone";
            this.lbPhone.Size = new System.Drawing.Size(55, 13);
            this.lbPhone.TabIndex = 2;
            this.lbPhone.Text = "Телефон:";
            // 
            // lbCity
            // 
            this.lbCity.AutoSize = true;
            this.lbCity.Location = new System.Drawing.Point(13, 103);
            this.lbCity.Name = "lbCity";
            this.lbCity.Size = new System.Drawing.Size(40, 13);
            this.lbCity.TabIndex = 3;
            this.lbCity.Text = "Город:";
            // 
            // lbStreet
            // 
            this.lbStreet.AutoSize = true;
            this.lbStreet.Location = new System.Drawing.Point(13, 133);
            this.lbStreet.Name = "lbStreet";
            this.lbStreet.Size = new System.Drawing.Size(42, 13);
            this.lbStreet.TabIndex = 4;
            this.lbStreet.Text = "Улица:";
            // 
            // lbEmail
            // 
            this.lbEmail.AutoSize = true;
            this.lbEmail.Location = new System.Drawing.Point(13, 193);
            this.lbEmail.Name = "lbEmail";
            this.lbEmail.Size = new System.Drawing.Size(35, 13);
            this.lbEmail.TabIndex = 5;
            this.lbEmail.Text = "Email:";
            // 
            // lbHome
            // 
            this.lbHome.AutoSize = true;
            this.lbHome.Location = new System.Drawing.Point(13, 163);
            this.lbHome.Name = "lbHome";
            this.lbHome.Size = new System.Drawing.Size(33, 13);
            this.lbHome.TabIndex = 5;
            this.lbHome.Text = "Дом:";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(170, 13);
            this.tbName.MaxLength = 50;
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(100, 20);
            this.tbName.TabIndex = 6;
            // 
            // tbSurname
            // 
            this.tbSurname.Location = new System.Drawing.Point(170, 43);
            this.tbSurname.MaxLength = 50;
            this.tbSurname.Name = "tbSurname";
            this.tbSurname.Size = new System.Drawing.Size(100, 20);
            this.tbSurname.TabIndex = 7;
            // 
            // tbCity
            // 
            this.tbCity.Location = new System.Drawing.Point(170, 103);
            this.tbCity.MaxLength = 50;
            this.tbCity.Name = "tbCity";
            this.tbCity.Size = new System.Drawing.Size(100, 20);
            this.tbCity.TabIndex = 9;
            // 
            // tbEmail
            // 
            this.tbEmail.Location = new System.Drawing.Point(170, 193);
            this.tbEmail.MaxLength = 100;
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(100, 20);
            this.tbEmail.TabIndex = 12;
            // 
            // tbHome
            // 
            this.tbHome.Location = new System.Drawing.Point(170, 163);
            this.tbHome.MaxLength = 5;
            this.tbHome.Name = "tbHome";
            this.tbHome.Size = new System.Drawing.Size(100, 20);
            this.tbHome.TabIndex = 11;
            // 
            // tbStreet
            // 
            this.tbStreet.Location = new System.Drawing.Point(170, 133);
            this.tbStreet.MaxLength = 100;
            this.tbStreet.Name = "tbStreet";
            this.tbStreet.Size = new System.Drawing.Size(100, 20);
            this.tbStreet.TabIndex = 10;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(105, 226);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // mtbPhone
            // 
            this.mtbPhone.Location = new System.Drawing.Point(170, 73);
            this.mtbPhone.Mask = "+7-999-000-00-00";
            this.mtbPhone.Name = "mtbPhone";
            this.mtbPhone.Size = new System.Drawing.Size(100, 20);
            this.mtbPhone.TabIndex = 28;
            this.mtbPhone.Leave += new System.EventHandler(this.mtbPhone_Leave);
            // 
            // ProfileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.mtbPhone);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tbEmail);
            this.Controls.Add(this.tbHome);
            this.Controls.Add(this.tbStreet);
            this.Controls.Add(this.tbCity);
            this.Controls.Add(this.tbSurname);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.lbHome);
            this.Controls.Add(this.lbEmail);
            this.Controls.Add(this.lbStreet);
            this.Controls.Add(this.lbCity);
            this.Controls.Add(this.lbPhone);
            this.Controls.Add(this.lbSurname);
            this.Controls.Add(this.lbName);
            this.Name = "ProfileForm";
            this.Text = "ProfileForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Label lbSurname;
        private System.Windows.Forms.Label lbPhone;
        private System.Windows.Forms.Label lbCity;
        private System.Windows.Forms.Label lbStreet;
        private System.Windows.Forms.Label lbEmail;
        private System.Windows.Forms.Label lbHome;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TextBox tbSurname;
        private System.Windows.Forms.TextBox tbCity;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.TextBox tbHome;
        private System.Windows.Forms.TextBox tbStreet;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.MaskedTextBox mtbPhone;
    }
}