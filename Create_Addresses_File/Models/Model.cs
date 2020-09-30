using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Create_Addresses_File
{
    /// <summary>
    /// Класс предоставляет меоды работы с полученными данными
    /// </summary>
    class Model
    {
        #region Свойства

        /// <summary>
        /// Свойство пути к файлу адресов
        /// </summary>
        public string OpenPath { get; set; }

        /// <summary>
        /// Свойство объекта адресов
        /// </summary>
        public Addresses allAddresses;

        #endregion

        #region Методы

        /// <summary>
        /// Метод создает стандартный файл адресов (свойства ServerAddress, ConnectionString будут пустыми. 
        /// Свойство UpdateAddress принимает имя папки
        /// и изменится при вводе сервера на "ServerAddress\UpdateWorkTracking\")
        /// </summary>
        /// <param name="path"></param>
        public void AddAddresses(string path)
        {
            // Создание объекта для сериализации
            Addresses addresses = new Addresses()
            {
                DBase = "PassYourWork",
                Generaltable = "Complited_Work",
                UsersTable = "Admins",
                OSP = "OSP",
                OsType = "OsType",
                Results = "Results",
                Why = "Why",
                ServerAddress = "",
                ConnectionString = "",
                UpdateAddress = "" + @"\UpdateWorkTracking\"
            };

            // Помещение значений в строку и сериализация
            string jsonWrite = JsonConvert.SerializeObject(addresses);

            // Запись в файл 
            File.WriteAllText($@"{path}", jsonWrite);
        }

        /// <summary>
        /// Метод получает данные из файла по заданному пути
        /// </summary>
        public void GetAddresses()
        {
            // Считывание файла и помещение данных в строку
            string addresses = File.ReadAllText($@"{OpenPath}");

            // Десериализация данных в объект
            allAddresses = JsonConvert.DeserializeObject<Addresses>(addresses);
        }

        /// <summary>
        /// Метод проверяет наличие файла в папке с программой и десериализует его
        /// </summary>
        /// <returns></returns>
        public bool OpenInRoot()
        {
            // Проверка наличия файла в папке с программой
            if (File.Exists(@"Addresses.json"))
            {
                OpenPath = Path.GetFullPath(@"Addresses.json");

                GetAddresses();

                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Метод применения изменений данных в файле
        /// </summary>
        public void Change()
        {
            // Сериализация новых данных
            string jsonWrite = JsonConvert.SerializeObject(allAddresses);

            if (!string.IsNullOrEmpty(OpenPath))
                // Запись данных в файл
                File.WriteAllText($@"{OpenPath}", jsonWrite);
            else
                MessageBox.Show("Нет пути к файлу. Создайте новый файл или выберите существующий.");
        }

        #endregion
    }
}
