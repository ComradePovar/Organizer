namespace Organizer
{
    partial class ContactsForm
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
            this.pnlContactList = new System.Windows.Forms.Panel();
            this.lbNewContact = new System.Windows.Forms.Label();
            this.tbNewContact = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pnlContactList
            // 
            this.pnlContactList.AutoScroll = true;
            this.pnlContactList.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlContactList.Location = new System.Drawing.Point(0, 31);
            this.pnlContactList.Name = "pnlContactList";
            this.pnlContactList.Size = new System.Drawing.Size(284, 230);
            this.pnlContactList.TabIndex = 7;
            // 
            // lbNewContact
            // 
            this.lbNewContact.AutoSize = true;
            this.lbNewContact.Location = new System.Drawing.Point(6, 9);
            this.lbNewContact.Name = "lbNewContact";
            this.lbNewContact.Size = new System.Drawing.Size(87, 13);
            this.lbNewContact.TabIndex = 0;
            this.lbNewContact.Text = "Новый контакт:";
            // 
            // tbNewContact
            // 
            this.tbNewContact.Location = new System.Drawing.Point(99, 6);
            this.tbNewContact.Name = "tbNewContact";
            this.tbNewContact.Size = new System.Drawing.Size(95, 20);
            this.tbNewContact.TabIndex = 1;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(200, 4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Добавить";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // ContactsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.pnlContactList);
            this.Controls.Add(this.tbNewContact);
            this.Controls.Add(this.lbNewContact);
            this.Name = "ContactsForm";
            this.Text = "ContactsForm";
            this.Load += new System.EventHandler(this.ContactsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlContactList;
        private System.Windows.Forms.Label lbNewContact;
        private System.Windows.Forms.TextBox tbNewContact;
        private System.Windows.Forms.Button btnAdd;
    }
}