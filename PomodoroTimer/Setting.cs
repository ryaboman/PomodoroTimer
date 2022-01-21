using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace PomodoroTimer
{
    public partial class Setting : Form
    {
        public Setting()
        {
            InitializeComponent();
            //инициализируем форму данными из файла

            checkBoxAutoRest.Checked = true;

            string settingFile = Directory.GetCurrentDirectory() + "\\setting"; //файл с настройками

            Txt txt = new Txt();

            if (txt.SetPathToFile(settingFile))
            {
                //если файл настроек существует, то считываем данные
                try
                {
                    upDownLifePomodor.Value = Int32.Parse(txt.Select("<lifePomodor>", "</lifePomodor>"));    //получаем время жизни помодора

                    UpDownLifeSpanRest.Value = Int32.Parse(txt.Select("<lifeSpanRest>", "</lifeSpanRest>")); //получаем 

                    UpDownSpanLongRest.Value = Int32.Parse(txt.Select("<lifeSpanLongRest>", "</lifeSpanLongRest>"));        //получаем 

                    UpDownCountPomodor.Value = Int32.Parse(txt.Select("<countPomodorForLongRest>", "</countPomodorForLongRest>")); //получаем 

                    checkBoxAutoRest.Checked = Boolean.Parse(txt.Select("<autoStartRest>", "</autoStartRest>")); //получаем 

                    checkBoxAutoPomodor.Checked = Boolean.Parse(txt.Select("<autoStartPomodor>", "</autoStartPomodor>")); //получаем 

                }
                catch
                {
                    
                }
            }                                                                        

        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.Cancel;
        }

        private void save_Click(object sender, EventArgs e)
        {
            string settingFile = Directory.GetCurrentDirectory() + "\\setting"; //файл с настройками

            Txt txt = new Txt();

            if (txt.SetPathToFile(settingFile))
            {
                txt.text = string.Empty; //"обнулим" текс

                txt.text += "<lifePomodor>" + upDownLifePomodor.Value.ToString() + "</lifePomodor>";
                txt.text += "\n\n";
                txt.text += "<lifeSpanRest>" + UpDownLifeSpanRest.Value.ToString() + "</lifeSpanRest>";
                txt.text += "\n\n";
                txt.text += "<lifeSpanLongRest>" + UpDownSpanLongRest.Value.ToString() + "</lifeSpanLongRest>";
                txt.text += "\n\n";
                txt.text += "<countPomodorForLongRest>" + UpDownCountPomodor.Value.ToString() + "</countPomodorForLongRest>";
                txt.text += "\n\n";
                txt.text += "<autoStartRest>" + checkBoxAutoRest.Checked.ToString() + "</autoStartRest>";
                txt.text += "\n\n";
                txt.text += "<autoStartPomodor>" + checkBoxAutoPomodor.Checked.ToString() + "</autoStartPomodor>";
                txt.text += "\n\n";

                txt.RewriteFile();
            }

            this.DialogResult = DialogResult.OK;
            this.Close();                       

        }
    }
}
