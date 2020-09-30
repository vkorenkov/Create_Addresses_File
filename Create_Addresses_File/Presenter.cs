using Microsoft.Win32;
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
    class Presenter
    {
        #region Свойства

        IView View;
        Model model;

        #endregion

        #region Конструкторы

        public Presenter(IView view)
        {
            View = view;

            model = new Model();
        }

        #endregion

        #region Методы

        /// <summary>
        /// Промежуточный метод создания файла
        /// </summary>
        /// <returns></returns>
        public string CreateNewFile()
        {
            var tempPath = model.OpenPath;

            // Инициализация экземпляра класса диалоговых окон
            SaveOpen save = new SaveOpen();

            // Получение пути сохранения файла
            model.OpenPath = save.SaveFile("Addresses.json");

            // Условие корректного получения пути сохранения
            if (!string.IsNullOrEmpty(model.OpenPath))
            {
                model.AddAddresses(model.OpenPath);

                model.GetAddresses();

                GetValues();
            }
            else
            {
                model.OpenPath = tempPath;
            }

            return model.OpenPath;
        }

        /// <summary>
        /// Промежуточный метод открытия файла
        /// </summary>
        /// <returns></returns>
        public string OpenFile()
        {
            // Инициализация экземпляра класса диалоговых окон
            SaveOpen open = new SaveOpen();

            // Веременная переменная для пути к файлу
            var temp = open.OpenFile();

            if (!string.IsNullOrEmpty(temp))
                // Получение пути к файлу
                model.OpenPath = temp;

            // Условие корректного получения пути к файлу
            if (!string.IsNullOrEmpty(model.OpenPath))
            {
                model.GetAddresses();

                GetValues();
            }

            return model.OpenPath;
        }

        /// <summary>
        /// Промежуточный метод открытия файла в папке с программой
        /// </summary>
        /// <returns></returns>
        public string OpenConf()
        {
            if (model.OpenInRoot())
            {
                GetValues();
            }

            return model.OpenPath;
        }

        /// <summary>
        /// Метод получения данных для отображения
        /// </summary>
        public void GetValues()
        {
            // Цикл получения свойств представления
            foreach (var t in View.GetType().GetProperties())
            {
                // Цикл получения свойств модели
                foreach (var x in model.allAddresses.GetType().GetProperties())
                {
                    // Назначение значения свойсв из модели в представление
                    if (t.Name == x.Name && t.PropertyType == x.PropertyType)
                    {
                        t.SetValue(View, x.GetValue(model.allAddresses));
                    }
                }
            }
        }

        /// <summary>
        /// Метод измения значения свойств модели
        /// </summary>
        public void ChangeAddresses()
        {
            // Цикл получения свойств модели
            foreach (var t in model.allAddresses.GetType().GetProperties())
            {
                // Цикл получения свойств представления
                foreach (var x in View.GetType().GetProperties())
                {
                    // Назначение значения свойсв из представления в модель
                    if (t.Name == x.Name && t.PropertyType == x.PropertyType)
                    {
                        if (t.Name == "UpdateAddress")
                        {
                            t.SetValue(model.allAddresses, View.ServerAddress + @"\UpdateWorkTracking\");
                        }
                        else
                        {
                            t.SetValue(model.allAddresses, x.GetValue(View));
                        }
                    }
                }
            }

            model.Change();
        }

        #endregion
    }
}
