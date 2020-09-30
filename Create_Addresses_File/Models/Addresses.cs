using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Create_Addresses_File
{
    /// <summary>
    /// Класс предоставляет свойства для создания файла адресов подключения и названия таблиц
    /// </summary>
    class Addresses : IView
    {
        /// <summary>
        /// Свойство названия БД
        /// </summary>
        public string DBase { get; set; }
        /// <summary>
        /// Свойство названия таблицы работ
        /// </summary>
        public string Generaltable { get; set; }
        /// <summary>
        /// Свойство названия таблицы пользователей
        /// </summary>
        public string UsersTable { get; set; }
        /// <summary>
        /// Свойство названия таблицы подразделений
        /// </summary>
        public string OSP { get; set; }
        /// <summary>
        /// Свойство названия таблицы типов основных средств
        /// </summary>
        public string OsType { get; set; }
        /// <summary>
        /// Свойство названия таблицы результатов работ
        /// </summary>
        public string Results { get; set; }
        /// <summary>
        /// Свойство названия таблицы причин обращения
        /// </summary>
        public string Why { get; set; }
        /// <summary>
        /// Свойство адреса сервера
        /// </summary>
        public string ServerAddress { get; set; }
        /// <summary>
        /// Свойство строки подключения к базе данных
        /// </summary>
        public string ConnectionString { get; set; }
        /// <summary>
        /// Свойство пути обновления
        /// </summary>
        public string UpdateAddress { get; set; }
    }
}
