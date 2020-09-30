using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Create_Addresses_File
{
    class SaveOpen
    {
        /// <summary>
        /// Метод открывает диалоговое окно сохранения файла и возвращает полный путь сохранения
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string SaveFile(string name)
        {
            // Инициализация класса сохранения файла
            SaveFileDialog sfd = new SaveFileDialog();

            // Имя сохраняемого файла
            sfd.FileName = name;

            // условие нормальной отработки диалогового окна
            if (sfd.ShowDialog() == true)
            {
                return sfd.FileName;
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Метод открывает диалоговое окно выбора файла и возвращает полный путь к файлу
        /// </summary>
        /// <returns></returns>
        public string OpenFile()
        {
            // Инициализация класса выбора файла
            OpenFileDialog opn = new OpenFileDialog();

            // Фильтр расширений файлов
            opn.Filter = "Файл JSON (*.JSON)|*.JSON";

            // условие нормальной отработки диалогового окна
            if (opn.ShowDialog() == true)
            {
                return opn.FileName;
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
