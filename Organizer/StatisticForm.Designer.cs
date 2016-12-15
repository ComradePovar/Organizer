namespace Organizer
{
    partial class StatisticForm
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
            this.dateTimePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerUntil = new System.Windows.Forms.DateTimePicker();
            this.lbTitle = new System.Windows.Forms.Label();
            this.lbFrom = new System.Windows.Forms.Label();
            this.lblUntil = new System.Windows.Forms.Label();
            this.pnlEventList = new System.Windows.Forms.Panel();
            this.rbCompleted = new System.Windows.Forms.RadioButton();
            this.rbCanceled = new System.Windows.Forms.RadioButton();
            this.btnFind = new System.Windows.Forms.Button();
            this.lbCount = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dateTimePickerFrom
            // 
            this.dateTimePickerFrom.Location = new System.Drawing.Point(24, 30);
            this.dateTimePickerFrom.Name = "dateTimePickerFrom";
            this.dateTimePickerFrom.Size = new System.Drawing.Size(132, 20);
            this.dateTimePickerFrom.TabIndex = 0;
            this.dateTimePickerFrom.ValueChanged += new System.EventHandler(this.dateTimePickerFrom_ValueChanged);
            // 
            // dateTimePickerUntil
            // 
            this.dateTimePickerUntil.Location = new System.Drawing.Point(187, 30);
            this.dateTimePickerUntil.Name = "dateTimePickerUntil";
            this.dateTimePickerUntil.Size = new System.Drawing.Size(132, 20);
            this.dateTimePickerUntil.TabIndex = 1;
            this.dateTimePickerUntil.ValueChanged += new System.EventHandler(this.dateTimePickerUntil_ValueChanged);
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Location = new System.Drawing.Point(106, 11);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(99, 13);
            this.lbTitle.TabIndex = 2;
            this.lbTitle.Text = "Выберите период:";
            // 
            // lbFrom
            // 
            this.lbFrom.AutoSize = true;
            this.lbFrom.Location = new System.Drawing.Point(5, 33);
            this.lbFrom.Name = "lbFrom";
            this.lbFrom.Size = new System.Drawing.Size(14, 13);
            this.lbFrom.TabIndex = 3;
            this.lbFrom.Text = "C";
            // 
            // lblUntil
            // 
            this.lblUntil.AutoSize = true;
            this.lblUntil.Location = new System.Drawing.Point(162, 33);
            this.lblUntil.Name = "lblUntil";
            this.lblUntil.Size = new System.Drawing.Size(19, 13);
            this.lblUntil.TabIndex = 4;
            this.lblUntil.Text = "по";
            // 
            // pnlEventList
            // 
            this.pnlEventList.AutoScroll = true;
            this.pnlEventList.Location = new System.Drawing.Point(0, 113);
            this.pnlEventList.Name = "pnlEventList";
            this.pnlEventList.Size = new System.Drawing.Size(329, 147);
            this.pnlEventList.TabIndex = 8;
            // 
            // rbCompleted
            // 
            this.rbCompleted.AutoSize = true;
            this.rbCompleted.Checked = true;
            this.rbCompleted.Location = new System.Drawing.Point(8, 56);
            this.rbCompleted.Name = "rbCompleted";
            this.rbCompleted.Size = new System.Drawing.Size(96, 17);
            this.rbCompleted.TabIndex = 10;
            this.rbCompleted.TabStop = true;
            this.rbCompleted.Text = "Выполненные";
            this.rbCompleted.UseVisualStyleBackColor = true;
            // 
            // rbCanceled
            // 
            this.rbCanceled.AutoSize = true;
            this.rbCanceled.Location = new System.Drawing.Point(187, 56);
            this.rbCanceled.Name = "rbCanceled";
            this.rbCanceled.Size = new System.Drawing.Size(90, 17);
            this.rbCanceled.TabIndex = 11;
            this.rbCanceled.TabStop = true;
            this.rbCanceled.Text = "Отмененные";
            this.rbCanceled.UseVisualStyleBackColor = true;
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(109, 79);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(96, 23);
            this.btnFind.TabIndex = 12;
            this.btnFind.Text = "Найти";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // lbCount
            // 
            this.lbCount.AutoSize = true;
            this.lbCount.Location = new System.Drawing.Point(5, 270);
            this.lbCount.Name = "lbCount";
            this.lbCount.Size = new System.Drawing.Size(0, 13);
            this.lbCount.TabIndex = 13;
            // 
            // StatisticForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 287);
            this.Controls.Add(this.lbCount);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.rbCanceled);
            this.Controls.Add(this.rbCompleted);
            this.Controls.Add(this.pnlEventList);
            this.Controls.Add(this.lblUntil);
            this.Controls.Add(this.lbFrom);
            this.Controls.Add(this.lbTitle);
            this.Controls.Add(this.dateTimePickerUntil);
            this.Controls.Add(this.dateTimePickerFrom);
            this.Name = "StatisticForm";
            this.Text = "StatisticForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePickerFrom;
        private System.Windows.Forms.DateTimePicker dateTimePickerUntil;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.Label lbFrom;
        private System.Windows.Forms.Label lblUntil;
        private System.Windows.Forms.Panel pnlEventList;
        private System.Windows.Forms.RadioButton rbCompleted;
        private System.Windows.Forms.RadioButton rbCanceled;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Label lbCount;
    }
}