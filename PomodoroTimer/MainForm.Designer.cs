namespace PomodoroTimer
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.taskTimer = new System.Windows.Forms.Timer(this.components);
            this.timeIndicator = new System.Windows.Forms.Label();
            this.buttonStop = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.startPausePomodor = new System.Windows.Forms.Button();
            this.groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // taskTimer
            // 
            this.taskTimer.Interval = 1000;
            this.taskTimer.Tick += new System.EventHandler(this.taskTimer_Tick);
            // 
            // timeIndicator
            // 
            this.timeIndicator.AutoSize = true;
            this.timeIndicator.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.timeIndicator.ForeColor = System.Drawing.Color.White;
            this.timeIndicator.Location = new System.Drawing.Point(38, 26);
            this.timeIndicator.Name = "timeIndicator";
            this.timeIndicator.Size = new System.Drawing.Size(289, 108);
            this.timeIndicator.TabIndex = 0;
            this.timeIndicator.Text = "25:00";
            this.timeIndicator.DoubleClick += new System.EventHandler(this.timeIndicator_DoubleClick);
            // 
            // buttonStop
            // 
            this.buttonStop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStop.ForeColor = System.Drawing.Color.White;
            this.buttonStop.Location = new System.Drawing.Point(202, 178);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(84, 23);
            this.buttonStop.TabIndex = 2;
            this.buttonStop.Text = "Стоп";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            this.buttonStop.MouseLeave += new System.EventHandler(this.buttonStop_MouseLeave);
            this.buttonStop.MouseMove += new System.Windows.Forms.MouseEventHandler(this.buttonStop_MouseMove);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(55, 134);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Задача:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(55, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Категория:";
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.startPausePomodor);
            this.groupBox.Controls.Add(this.timeIndicator);
            this.groupBox.Controls.Add(this.label2);
            this.groupBox.Controls.Add(this.label1);
            this.groupBox.Controls.Add(this.buttonStop);
            this.groupBox.Location = new System.Drawing.Point(12, 12);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(352, 231);
            this.groupBox.TabIndex = 5;
            this.groupBox.TabStop = false;
            // 
            // startPausePomodor
            // 
            this.startPausePomodor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.startPausePomodor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startPausePomodor.ForeColor = System.Drawing.Color.White;
            this.startPausePomodor.Location = new System.Drawing.Point(56, 178);
            this.startPausePomodor.Name = "startPausePomodor";
            this.startPausePomodor.Size = new System.Drawing.Size(89, 23);
            this.startPausePomodor.TabIndex = 5;
            this.startPausePomodor.Text = "Запуск";
            this.startPausePomodor.UseVisualStyleBackColor = true;
            this.startPausePomodor.Click += new System.EventHandler(this.startPomodor_Click);
            this.startPausePomodor.MouseLeave += new System.EventHandler(this.startPausePomodor_MouseLeave);
            this.startPausePomodor.MouseMove += new System.Windows.Forms.MouseEventHandler(this.startPausePomodor_MouseMove);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.IndianRed;
            this.ClientSize = new System.Drawing.Size(375, 255);
            this.Controls.Add(this.groupBox);
            this.MinimumSize = new System.Drawing.Size(391, 294);
            this.Name = "Form1";
            this.Text = "Таймер помодора";
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDoubleClick);
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer taskTimer;
        private System.Windows.Forms.Label timeIndicator;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.Button startPausePomodor;
    }
}

