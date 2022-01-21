using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;


namespace PomodoroTimer
{
    class Txt
    {
        public string text { get; set; }

        private string pathToFile { get; set; }


        public Txt()
        {
            text = string.Empty;
            pathToFile = null;
        }

        //Получить ссылку на файл
        public string GetPathToFile()
        {
            return pathToFile;
        }

        //Установить ссылку на файл и прочитать его
        public bool SetPathToFile(string path)
        {
            try
            {
                if (File.Exists(path)) //Если файл существует, то
                {
                    //пытаемся читать файл                    
                    using (StreamReader sr = File.OpenText(path))
                    {
                        text = sr.ReadToEnd();
                        pathToFile = path;
                        return true;
                    }
                }
                else
                    return false;
            }
            catch
            {
                text = string.Empty;
                pathToFile = null;

                return false;
            }
        }

        public bool CreateFile(string path)
        {
            try
            {
                if (File.Exists(path)) //Если файл существует, то
                {
                    return false;
                }
                else //Иначе создаем
                {
                    using (StreamWriter fs = new StreamWriter(path, false))
                    {
                        //если удалось создать файл сохраним путь к нему
                        pathToFile = path;
                        //удалим текс
                        //text = string.Empty;

                        //если удалось создать вернем true
                        return true;
                    }
                }

            }
            catch
            {
                return false;
            }
        }

        //Функция для записи блоков в файл
        public void WriteBlock()
        {
            if(pathToFile != null)
            {
                //записываем в файл блок текста из text
                using (StreamWriter fs = new StreamWriter(pathToFile, true))
                {
                    fs.WriteLine();
                    fs.WriteLine(text);
                    fs.WriteLine();
                }
            }
        }

        public void RewriteFile()
        {
            if(pathToFile != null)
            {
                try
                {
                    //Перезаписываем файл
                    using (StreamWriter fs = new StreamWriter(pathToFile, false))
                    {
                        fs.WriteLine();
                        fs.WriteLine(text);
                        fs.WriteLine();
                    }

                }
                catch
                {

                }
            }
            
        }

        //Перезаписываем блок который находится между <..> и </..>
        public void RewriteBlock()
        {
            //Перезаписываем блок который находится между <..> и </..>
        }

        
        //Функция выделяет текст заключенный между <..> и </..>
        public string Select(string substr_begin, string substr_end)
        {

            try
            {
                int index_begin = text.IndexOf(substr_begin) + substr_begin.Length; //Индекс начала строки
                int index_end = text.IndexOf(substr_end); //Индекс конца строки

                int lenght = index_end - index_begin; //Длина выделяемой строки

                return text.Substring(index_begin, lenght); // выделить строку
            }
            catch
            {
                return null;
            }

        }
        

        //функция выделяет подстроки <Объект>...</Объект> из файла и возвращает их в виде объектов List<string>
        private List<string> SelectBlock(string STR, string substr_begin, string substr_end)
        {
            var list = new List<string>();
            int index_begin;
            int index_end;
            int lenght;

            int substr_end_length = substr_end.Length;

            while (STR.IndexOf(substr_begin) >= 0)
            {
                index_begin = STR.IndexOf(substr_begin);
                index_end = STR.IndexOf(substr_end) + substr_end_length;
                lenght = index_end - index_begin;

                list.Add(STR.Substring(index_begin, lenght));


                STR = STR.Remove(index_begin, lenght);

            }

            return list;
        }

        
    }
}
