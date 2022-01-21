namespace PomodoroTimer
{
    partial class Setting
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
            this.upDownLifePomodor = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBoxAutoRest = new System.Windows.Forms.CheckBox();
            this.checkBoxAutoPomodor = new System.Windows.Forms.CheckBox();
            this.cancel = new System.Windows.Forms.Button();
            this.save = new System.Windows.Forms.Button();
            this.UpDownLifeSpanRest = new System.Windows.Forms.NumericUpDown();
            this.UpDownSpanLongRest = new System.Windows.Forms.NumericUpDown();
            this.UpDownCountPomodor = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.upDownLifePomodor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UpDownLifeSpanRest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UpDownSpanLongRest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UpDownCountPomodor)).BeginInit();
            this.SuspendLayout();
            // 
            // upDownLifePomodor
            // 
            this.upDownLifePomodor.Location = new System.Drawing.Point(148, 18);
            this.upDownLifePomodor.Name = "upDownLifePomodor";
            this.upDownLifePomodor.Size = new System.Drawing.Size(47, 20);
            this.upDownLifePomodor.TabIndex = 0;
            this.upDownLifePomodor.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "Продолжительность \r\nпомидра, мин.:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 26);
            this.label2.TabIndex = 2;
            this.label2.Text = "Продолжительность \r\nкороткого перерыва";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 26);
            this.label3.TabIndex = 3;
            this.label3.Text = "Продолжительность \r\nдлинного перерыва";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 26);
            this.label4.TabIndex = 4;
            this.label4.Text = "Количество подиров \r\nдо длинного перерыва";
            // 
            // checkBoxAutoRest
            // 
            this.checkBoxAutoRest.AutoSize = true;
            this.checkBoxAutoRest.Location = new System.Drawing.Point(15, 203);
            this.checkBoxAutoRest.Name = "checkBoxAutoRest";
            this.checkBoxAutoRest.Size = new System.Drawing.Size(131, 17);
            this.checkBoxAutoRest.TabIndex = 5;
            this.checkBoxAutoRest.Text = "Автостарт перерыва";
            this.checkBoxAutoRest.UseVisualStyleBackColor = true;
            // 
            // checkBoxAutoPomodor
            // 
            this.checkBoxAutoPomodor.AutoSize = true;
            this.checkBoxAutoPomodor.Location = new System.Drawing.Point(15, 226);
            this.checkBoxAutoPomodor.Name = "checkBoxAutoPomodor";
            this.checkBoxAutoPomodor.Size = new System.Drawing.Size(131, 17);
            this.checkBoxAutoPomodor.TabIndex = 6;
            this.checkBoxAutoPomodor.Text = "Автостарт помидора";
            this.checkBoxAutoPomodor.UseVisualStyleBackColor = true;
            // 
            // cancel
            // 
            this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel.Location = new System.Drawing.Point(15, 276);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 7;
            this.cancel.Text = "Отмена";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(120, 276);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(75, 23);
            this.save.TabIndex = 8;
            this.save.Text = "Сохранить";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // UpDownLifeSpanRest
            // 
            this.UpDownLifeSpanRest.Location = new System.Drawing.Point(148, 66);
            this.UpDownLifeSpanRest.Name = "UpDownLifeSpanRest";
            this.UpDownLifeSpanRest.Size = new System.Drawing.Size(47, 20);
            this.UpDownLifeSpanRest.TabIndex = 9;
            this.UpDownLifeSpanRest.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // UpDownSpanLongRest
            // 
            this.UpDownSpanLongRest.Location = new System.Drawing.Point(148, 121);
            this.UpDownSpanLongRest.Name = "UpDownSpanLongRest";
            this.UpDownSpanLongRest.Size = new System.Drawing.Size(47, 20);
            this.UpDownSpanLongRest.TabIndex = 10;
            this.UpDownSpanLongRest.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // UpDownCountPomodor
            // 
            this.UpDownCountPomodor.Location = new System.Drawing.Point(148, 161);
            this.UpDownCountPomodor.Name = "UpDownCountPomodor";
            this.UpDownCountPomodor.Size = new System.Drawing.Size(47, 20);
            this.UpDownCountPomodor.TabIndex = 11;
            this.UpDownCountPomodor.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // Setting
            // 
            this.AcceptButton = this.save;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancel;
            this.ClientSize = new System.Drawing.Size(215, 321);
            this.Controls.Add(this.UpDownCountPomodor);
            this.Controls.Add(this.UpDownSpanLongRest);
            this.Controls.Add(this.UpDownLifeSpanRest);
            this.Controls.Add(this.save);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.checkBoxAutoPomodor);
            this.Controls.Add(this.checkBoxAutoRest);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.upDownLifePomodor);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(231, 360);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(231, 360);
            this.Name = "Setting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Настройки";
            ((System.ComponentModel.ISupportInitialize)(this.upDownLifePomodor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UpDownLifeSpanRest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UpDownSpanLongRest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UpDownCountPomodor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown upDownLifePomodor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBoxAutoRest;
        private System.Windows.Forms.CheckBox checkBoxAutoPomodor;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.NumericUpDown UpDownLifeSpanRest;
        private System.Windows.Forms.NumericUpDown UpDownSpanLongRest;
        private System.Windows.Forms.NumericUpDown UpDownCountPomodor;
    }
}