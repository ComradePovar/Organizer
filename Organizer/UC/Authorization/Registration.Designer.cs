namespace Organizer.UC.Authorization
{
    partial class Registration
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
            this.mtbPassword = new System.Windows.Forms.MaskedTextBox();
            this.lbPassword = new System.Windows.Forms.Label();
            this.lbLogin = new System.Windows.Forms.Label();
            this.tbLogin = new System.Windows.Forms.TextBox();
            this.btnRegistration = new System.Windows.Forms.Button();
            this.mtbPassConfirmation = new System.Windows.Forms.MaskedTextBox();
            this.lbPassConfirmation = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // mtbPassword
            // 
            this.mtbPassword.Location = new System.Drawing.Point(154, 53);
            this.mtbPassword.Name = "mtbPassword";
            this.mtbPassword.Size = new System.Drawing.Size(100, 20);
            this.mtbPassword.TabIndex = 12;
            this.mtbPassword.UseSystemPasswordChar = true;
            // 
            // lbPassword
            // 
            this.lbPassword.AutoSize = true;
            this.lbPassword.Location = new System.Drawing.Point(36, 56);
            this.lbPassword.Name = "lbPassword";
            this.lbPassword.Size = new System.Drawing.Size(45, 13);
            this.lbPassword.TabIndex = 11;
            this.lbPassword.Text = "Пароль";
            // 
            // lbLogin
            // 
            this.lbLogin.AutoSize = true;
            this.lbLogin.Location = new System.Drawing.Point(36, 20);
            this.lbLogin.Name = "lbLogin";
            this.lbLogin.Size = new System.Drawing.Size(38, 13);
            this.lbLogin.TabIndex = 10;
            this.lbLogin.Text = "Логин";
            // 
            // tbLogin
            // 
            this.tbLogin.Location = new System.Drawing.Point(154, 17);
            this.tbLogin.Name = "tbLogin";
            this.tbLogin.Size = new System.Drawing.Size(100, 20);
            this.tbLogin.TabIndex = 9;
            // 
            // btnRegistration
            // 
            this.btnRegistration.Location = new System.Drawing.Point(174, 131);
            this.btnRegistration.Name = "btnRegistration";
            this.btnRegistration.Size = new System.Drawing.Size(80, 25);
            this.btnRegistration.TabIndex = 8;
            this.btnRegistration.Text = "Регистрация";
            this.btnRegistration.UseVisualStyleBackColor = true;
            this.btnRegistration.Click += new System.EventHandler(this.btnRegistration_Click);
            // 
            // mtbPassConfirmation
            // 
            this.mtbPassConfirmation.Location = new System.Drawing.Point(154, 89);
            this.mtbPassConfirmation.Name = "mtbPassConfirmation";
            this.mtbPassConfirmation.Size = new System.Drawing.Size(100, 20);
            this.mtbPassConfirmation.TabIndex = 14;
            this.mtbPassConfirmation.UseSystemPasswordChar = true;
            // 
            // lbPassConfirmation
            // 
            this.lbPassConfirmation.AutoSize = true;
            this.lbPassConfirmation.Location = new System.Drawing.Point(36, 92);
            this.lbPassConfirmation.Name = "lbPassConfirmation";
            this.lbPassConfirmation.Size = new System.Drawing.Size(112, 13);
            this.lbPassConfirmation.TabIndex = 13;
            this.lbPassConfirmation.Text = "Подтвердите пароль";
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(39, 131);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 25);
            this.btnBack.TabIndex = 15;
            this.btnBack.Text = "Назад";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // Registration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.mtbPassConfirmation);
            this.Controls.Add(this.lbPassConfirmation);
            this.Controls.Add(this.mtbPassword);
            this.Controls.Add(this.lbPassword);
            this.Controls.Add(this.lbLogin);
            this.Controls.Add(this.tbLogin);
            this.Controls.Add(this.btnRegistration);
            this.Name = "Registration";
            this.Size = new System.Drawing.Size(308, 189);
            this.Load += new System.EventHandler(this.Registration_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox mtbPassword;
        private System.Windows.Forms.Label lbPassword;
        private System.Windows.Forms.Label lbLogin;
        private System.Windows.Forms.TextBox tbLogin;
        private System.Windows.Forms.Button btnRegistration;
        private System.Windows.Forms.MaskedTextBox mtbPassConfirmation;
        private System.Windows.Forms.Label lbPassConfirmation;
        private System.Windows.Forms.Button btnBack;
    }
}
