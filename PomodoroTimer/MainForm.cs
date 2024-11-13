using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace PomodoroTimer
{
    public partial class MainForm : Form
    {
                

        TimeSpan time = new TimeSpan();

        TimeSpan oneSecond = TimeSpan.FromSeconds(1); //одна секунда

        bool timerIsWork = false;

        //Флаг говорящий какое время. Время отдыха или время работы
        bool timeIsTask = true; 

        int counPomodor = 4; //Количесво помодор подряд

        //Продолжительность помидора
        TimeSpan lifeSpanPomodor = TimeSpan.FromMinutes(25);

        //Продолжительность короткого перерыва
        TimeSpan lifeSpanRest = TimeSpan.FromMinutes(5);

        //Продолжительность длинного перерыва
        TimeSpan lifeSpanLongRest = TimeSpan.FromMinutes(15);

        //Количество помидоров до длинного перерыва
        int countPomodorForLongRest = 4;

        //Автостарт перерыва
        bool autoStartRest = true;

        //Автостарт помидора
        bool autoStartPomodor = false;

        public MainForm()
        {
            InitializeComponent();            

            buttonStop.Enabled = false;

            //нужно считать данные из файла            
            InitializePomodor();

            time = lifeSpanPomodor;
            timeIndicator.Text = TimeToString(time);

            counPomodor = countPomodorForLongRest;
        }

        //Инициализация помодора из файла
        private void InitializePomodor()
        {        
            string settingFile = Directory.GetCurrentDirectory() + "\\setting"; //файл с настройками

            Txt txt = new Txt();

            int lifePomodor;
            int lifeRest;
            int longRest;
            int countPomodor;
            bool autoRest;
            bool autoPomodor;

            if (txt.SetPathToFile(settingFile))
            {
                //если файл настроек существует, то считываем данные
                try
                {
                    lifePomodor = Int32.Parse(txt.Select("<lifePomodor>", "</lifePomodor>"));    //получаем время жизни помодора

                    lifeRest = Int32.Parse(txt.Select("<lifeSpanRest>", "</lifeSpanRest>")); //получаем 

                    longRest = Int32.Parse(txt.Select("<lifeSpanLongRest>", "</lifeSpanLongRest>"));        //получаем 

                    countPomodor = Int32.Parse(txt.Select("<countPomodorForLongRest>", "</countPomodorForLongRest>")); //получаем 

                    autoRest = Boolean.Parse(txt.Select("<autoStartRest>", "</autoStartRest>")); //получаем 

                    autoPomodor = Boolean.Parse(txt.Select("<autoStartPomodor>", "</autoStartPomodor>")); //получаем 

                    lifeSpanPomodor = TimeSpan.FromMinutes(lifePomodor);
                    lifeSpanRest = TimeSpan.FromMinutes(lifeRest);
                    lifeSpanLongRest = TimeSpan.FromMinutes(longRest);

                    countPomodorForLongRest = countPomodor;

                    autoStartRest = autoRest;
                    autoStartPomodor = autoPomodor;
                }
                catch
                {
                    MessageBox.Show("Некорректные данные в файле инициализации", "Ошибка");
                }                              

            }
            else
            {
                //если файла не существует, то создаем

                txt.text = string.Empty; //"обнулим" текс

                txt.text += "<lifePomodor>" + lifeSpanPomodor.Minutes + "</lifePomodor>";
                txt.text += "\n\n";
                txt.text += "<lifeSpanRest>" + lifeSpanRest.Minutes + "</lifeSpanRest>";
                txt.text += "\n\n";
                txt.text += "<lifeSpanLongRest>" + lifeSpanLongRest.Minutes + "</lifeSpanLongRest>";
                txt.text += "\n\n";
                txt.text += "<countPomodorForLongRest>" + countPomodorForLongRest.ToString() + "</countPomodorForLongRest>";
                txt.text += "\n\n";
                txt.text += "<autoStartRest>" + autoStartRest.ToString() + "</autoStartRest>";
                txt.text += "\n\n";
                txt.text += "<autoStartPomodor>" + autoStartPomodor.ToString() + "</autoStartPomodor>";
                txt.text += "\n\n";

                if (txt.CreateFile(settingFile)) //Если удалось создать файл
                {
                    txt.WriteBlock();
                }

            }     
        }

        
        private void startPomodor_Click(object sender, EventArgs e)
        {
            buttonStop.Enabled = true;
            if (timerIsWork)
            {
                //Если задача
                if (timeIsTask)
                {
                    //если таймер работаем то ставим его на паузу
                    taskTimer.Stop();
                    startPausePomodor.Text = "Продолжить";
                    buttonStop.Text = "Сделано";
                    timerIsWork = false;
                }
                //Если отдых
                else
                {
                    //если таймер работаем то ставим его на паузу
                    taskTimer.Stop();
                    startPausePomodor.Text = "Продолжить";
                    timerIsWork = false;
                }
                
            }
            else
            {                
                //Если задача
                if (timeIsTask)
                {
                    //если не работает то запускам                
                    taskTimer.Start();
                    startPausePomodor.Text = "Пауза";
                    buttonStop.Text = "Стоп";
                    timerIsWork = true;

                    //buttonStop.Enabled = true;
                }
                //Если отдых
                else
                {
                    //если таймер не работаем то запускаем его
                    taskTimer.Start();
                    startPausePomodor.Text = "Пауза";
                    timerIsWork = true;

                    //buttonStop.Enabled = true;
                }
            }
            
            
        }

        //Таймер "тик-так"
        private void taskTimer_Tick(object sender, EventArgs e)
        {            

            //Если время вышло, то ..
            if (time == TimeSpan.FromSeconds(0)) {
                taskTimer.Stop();

                startPausePomodor.Text = "Запуск";
                buttonStop.Text = "Стоп";
                buttonStop.Enabled = false;

                timerIsWork = false;

                time = time - oneSecond;

                timeIndicator.Text = TimeToString(time);

                //Если это была задача. То включаем музыку
                if (timeIsTask)
                {
                    MissionImpossible();
                    counPomodor--; //минус один помидор
                }                    

                if (timeIsTask)  //Если это была задача
                {
                    ColorTimeRelax();

                    //Если помодоры закончились, то длинный перерыв. Иначе короткий перерыв
                    if(counPomodor == 0)
                    {
                        time = lifeSpanLongRest;           //Длинный перерыв
                        counPomodor = countPomodorForLongRest;
                    }                                                         
                    else
                        time = lifeSpanRest; //короткий перерыв

                    timeIndicator.Text = TimeToString(time);

                    

                    if (autoStartRest)
                    {
                        taskTimer.Start();
                        timerIsWork = true;

                        startPausePomodor.Text = "Пауза";
                        buttonStop.Text = "Пропустить";

                        buttonStop.Enabled = true;
                    }
                    
                    timeIsTask = false;

                }
                else //если после перерыва
                {
                    timeIsTask = true; //говорим что будет задача
                    ColorTimeTask();
                    time = lifeSpanPomodor;
                    timeIndicator.Text = TimeToString(time);

                    if (autoStartPomodor)
                    {
                        //если не работает то запускам                
                        taskTimer.Start();
                        startPausePomodor.Text = "Пауза";
                        buttonStop.Text = "Стоп";
                        timerIsWork = true;

                        buttonStop.Enabled = true;
                    }
                                        
                }

                return;
            }

            time = time - oneSecond;

            timeIndicator.Text = TimeToString(time);

        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            


            if (timeIsTask)
            {
                //Если помодор, то.. остановим его

                taskTimer.Stop();
                timerIsWork = false;
                
                buttonStop.Enabled = false;
                
                startPausePomodor.Text = "Запуск";
                buttonStop.Text = "Стоп";
            }
            else
            {
                //перейдем на задачу
                timeIsTask = true;                
                ColorTimeTask();

                timerIsWork = true;


                startPausePomodor.Text = "Пауза";
                buttonStop.Text = "Стоп";


                //Если нет автозапуска помодора, то...остановим помодор
                if (!autoStartPomodor)
                {
                    taskTimer.Stop();
                    buttonStop.Enabled = false;
                }
            }
            
            time = lifeSpanPomodor;
            timeIndicator.Text = TimeToString(time);
            
        }

        private string TimeToString(TimeSpan time)
        {
            string nullSecond = string.Empty;
            string nullMinutes = string.Empty;

            if (time.Seconds < 10)
            {
                nullSecond = "0";
            }

            if (time.Minutes < 10)
            {
                nullMinutes = "0";
            }

            return nullMinutes + time.Minutes.ToString() + ":" + nullSecond + time.Seconds.ToString();

        }

        //Jingle Bells
        static void refrenSolo()
        {
            Console.Beep(659, 300);
            Console.Beep(659, 300);
            Console.Beep(659, 300);
            Thread.Sleep(300);
            Console.Beep(659, 300);
            Console.Beep(659, 300);
            Console.Beep(659, 300);
            Thread.Sleep(300);
            Console.Beep(659, 300);
            Console.Beep(783, 300);
            Console.Beep(523, 300);
            Console.Beep(587, 300);
            Console.Beep(659, 300);
            Console.Beep(261, 300);
            Console.Beep(293, 300);
            Console.Beep(329, 300);
            Console.Beep(698, 300);
            Console.Beep(698, 300);
            Console.Beep(698, 300);
            Thread.Sleep(300);
            Console.Beep(698, 300);
            Console.Beep(659, 300);
            Console.Beep(659, 300);
            Thread.Sleep(300);
            Console.Beep(659, 300);
            Console.Beep(587, 300);
            Console.Beep(587, 300);
            Console.Beep(659, 300);
            Console.Beep(587, 300);
            Thread.Sleep(300);
            Console.Beep(783, 300);
            Thread.Sleep(300);
            Console.Beep(659, 300);
            Console.Beep(659, 300);
            Console.Beep(659, 300);
            Thread.Sleep(300);
            Console.Beep(659, 300);
            Console.Beep(659, 300);
            Console.Beep(659, 300);
            Thread.Sleep(300);
            Console.Beep(659, 300);
            Console.Beep(783, 300);
            Console.Beep(523, 300);
            Console.Beep(587, 300);
            Console.Beep(659, 300);
            Console.Beep(261, 300);
            Console.Beep(293, 300);
            Console.Beep(329, 300);
            Console.Beep(698, 300);
            Console.Beep(698, 300);
            Console.Beep(698, 300);
            Thread.Sleep(300);
            Console.Beep(698, 300);
            Console.Beep(659, 300);
            Console.Beep(659, 300);
            Thread.Sleep(300);
            Console.Beep(783, 300);
            Console.Beep(783, 300);
            Console.Beep(698, 300);
            Console.Beep(587, 300);
            Console.Beep(523, 600);
            Thread.Sleep(600);
        }
        static void coupleSolo()
        {
            Console.Beep(392, 300);
            Console.Beep(659, 300);
            Console.Beep(587, 300);
            Console.Beep(523, 300);
            Console.Beep(392, 600);
            Thread.Sleep(300 * 2);
            Console.Beep(392, 300);
            Console.Beep(659, 300);
            Console.Beep(587, 300);
            Console.Beep(523, 300);
            Console.Beep(440, 600);
            Thread.Sleep(600);
            Console.Beep(440, 300);
            Console.Beep(698, 300);
            Console.Beep(659, 300);
            Console.Beep(587, 300);
            Console.Beep(783, 600);
            Thread.Sleep(600);
            Console.Beep(880, 300);
            Console.Beep(880, 300);
            Console.Beep(783, 300);
            Console.Beep(622, 300);
            Console.Beep(659, 600);
            Thread.Sleep(600);
            Console.Beep(392, 300);
            Console.Beep(659, 300);
            Console.Beep(587, 300);
            Console.Beep(523, 300);
            Console.Beep(392, 600);
            Thread.Sleep(600);
            Console.Beep(392, 300);
            Console.Beep(659, 300);
            Console.Beep(587, 300);
            Console.Beep(523, 300);
            Console.Beep(440, 600);
            Thread.Sleep(600);
            Console.Beep(440, 300);
            Console.Beep(698, 300);
            Console.Beep(659, 300);
            Console.Beep(587, 300);
            Console.Beep(783, 600);
            Thread.Sleep(600);
            Console.Beep(880, 300);
            Console.Beep(783, 300);
            Console.Beep(698, 300);
            Console.Beep(587, 300);
            Console.Beep(523, 600);
            Thread.Sleep(600);
        }

        //Миссия не выполнима
        private static void MissionImpossible()
        {
            Console.Beep(784, 150);
            Thread.Sleep(300);
            Console.Beep(784, 150);
            Thread.Sleep(300);
            Console.Beep(932, 150);
            Thread.Sleep(150);
            Console.Beep(1047, 150);
            Thread.Sleep(150);
            Console.Beep(784, 150);
            Thread.Sleep(300);
            Console.Beep(784, 150);
            Thread.Sleep(300);
            Console.Beep(699, 150);
            Thread.Sleep(150);
            Console.Beep(740, 150);
            Thread.Sleep(150);
            Console.Beep(784, 150);
            Thread.Sleep(300);
            Console.Beep(784, 150);
            Thread.Sleep(300);
            Console.Beep(932, 150);
            Thread.Sleep(150);
            Console.Beep(1047, 150);
            Thread.Sleep(150);
            Console.Beep(784, 150);
            Thread.Sleep(300);
            Console.Beep(784, 150);
            Thread.Sleep(300);
            Console.Beep(699, 150);
            Thread.Sleep(150);
            Console.Beep(740, 150);
            //Thread.Sleep(150);
            //Console.Beep(932, 150);
            //Console.Beep(784, 150);
            //Console.Beep(587, 1200);
            //Thread.Sleep(75);
            //Console.Beep(932, 150);
            //Console.Beep(784, 150);
            //Console.Beep(554, 1200);
            //Thread.Sleep(75);
            //Console.Beep(932, 150);
            //Console.Beep(784, 150);
            //Console.Beep(523, 1200);
            //Thread.Sleep(150);
            //Console.Beep(466, 150);
            //Console.Beep(523, 150);
        }

        //Двойной клик по времени
        private void timeIndicator_DoubleClick(object sender, EventArgs e)
        {
            if (!timerIsWork)
            {
                Setting setting = new Setting();
                DialogResult result =  setting.ShowDialog();
           
                if(DialogResult.OK == result)
                {
                    InitializePomodor();

                    time = lifeSpanPomodor;
                    timeIndicator.Text = TimeToString(time);

                    counPomodor = countPomodorForLongRest;
                }
                
            }
                
        }

        
        
        //-------------------------------------------------------------------

        //время в центре экрана
        private void MainForm_SizeChanged(object sender, EventArgs e)                                                                                                                               
        {
            Point point = new Point();

            Size sizeForm = this.Size;  //Размеры формы
            Size sizeGroupBox = groupBox.Size;  //Размеры временного индикатора

            point.X = (sizeForm.Width / 2 - sizeGroupBox.Width/2) - 7;
            point.Y = sizeForm.Height / 2 - sizeGroupBox.Height/2 - 19;

            groupBox.Location = point;
        }


        //-------------------------------------------------------------------
        private void startPausePomodor_MouseMove(object sender, MouseEventArgs e)
        {
            if (timeIsTask)
            {
                startPausePomodor.BackColor = Color.Salmon;
            }
            else
            {
                startPausePomodor.BackColor = Color.YellowGreen;
            }            
        }

        private void startPausePomodor_MouseLeave(object sender, EventArgs e)
        {
            if (timeIsTask)
            {
                startPausePomodor.BackColor = Color.IndianRed;
            }
            else
            {
                startPausePomodor.BackColor = Color.OliveDrab;
            }
            
        }

        private void buttonStop_MouseMove(object sender, MouseEventArgs e)
        {
            if (timeIsTask)
            {
                buttonStop.BackColor = Color.Salmon;
            }
            else
            {
                buttonStop.BackColor = Color.YellowGreen;
            }
        }

        private void buttonStop_MouseLeave(object sender, EventArgs e)
        {            
            //IndianRed  OliveDrab
            if (timeIsTask)
            {
                buttonStop.BackColor = Color.IndianRed;
            }
            else
            {
                buttonStop.BackColor = Color.OliveDrab;
            }
        }

        //-------------------------------------------------------------------

        //Время для задачи. Функция инициализирует форму красным цветом
        private void ColorTimeTask()
        {
            //Инициализируем фон главного окна
            this.BackColor = Color.IndianRed;
            startPausePomodor.BackColor = Color.Salmon;
            buttonStop.BackColor = Color.Salmon;

        }

        //время для отдыха. Функция инициализирует форму зеленым цветом
        private void ColorTimeRelax()
        {
            //Инициализируем фон главного окна
            this.BackColor = Color.OliveDrab;

            startPausePomodor.BackColor = Color.OliveDrab;
            buttonStop.BackColor = Color.OliveDrab;
        }

        //Двойной клик по форме в свободном месте
        private void MainForm_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!timerIsWork)
            {
                string str = "  Программу разработал Рябов А.А.\n\n" +
                                         "  Техника \"Помидора\" представляет простой инструмент для улучшения производительности (для Вас и вашей команды) " +
                                         "и может быть использован для:\n" +
                                         "  - облегчения начала работы;\n" +
                                         "  - улучшения концентрации, избавления от отвлекающих факторов;\n" +
                                         "  - повышение осведомленности о ваших решениях;\n" +
                                         "  - улучшения и сохранения мотивации;\n" +
                                         "  - определенности с пониманием достижения Ваших целей;\n" +
                                         "  - уточнение Вашего рабочего или учебного процесса;\n" +
                                         "  - укрепление Вашей решительности в сложных ситуациях;\n";

                MessageBox.Show(str, "О программе");
            }
                
        }
    }
}
