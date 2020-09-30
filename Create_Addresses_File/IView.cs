using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Create_Addresses_File
{
    interface IView
    {
        /// <summary>
        /// Название базы данных
        /// </summary>
        string DBase { get; set; }
        /// <summary>
        /// Таблица выполненных работ
        /// </summary>
        string Generaltable { get; set; }
        /// <summary>
        /// Таблица пользователей
        /// </summary>
        string UsersTable { get; set; }
        /// <summary>
        /// Таблица подразаделений
        /// </summary>
        string OSP { get; set; }
        /// <summary>
        /// Таблица типов основных средств
        /// </summary>
        string OsType { get; set; }
        /// <summary>
        /// Таблица результатов
        /// </summary>
        string Results { get; set; }
        /// <summary>
        /// Таблица причин обращения
        /// </summary>
        string Why { get; set; }
        /// <summary>
        /// Адрес сервера 
        /// </summary>
        string ServerAddress { get; set; }
        /// <summary>
        /// Поле строки подключения к БД
        /// </summary>
        string ConnectionString { get; set; }
        /// <summary>
        /// Адрес обновления
        /// </summary>
        string UpdateAddress { get; set; }
    }
}
