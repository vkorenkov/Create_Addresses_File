using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Create_Addresses_File
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IView
    {
        /// <summary>
        /// Экземпляр класса передатчика данных
        /// </summary>
        Presenter Presenter;

        public MainWindow()
        {
            InitializeComponent();

            Presenter = new Presenter(this);

            // Отображение пути к фалу, при наличии его в папке с программой
            txbPathToFile.Text = Presenter.OpenConf();

            // Назначение действий на кнопки
            btnCreate.Click += (s, e) => txbPathToFile.Text = Presenter.CreateNewFile();
            btnChange.Click += (s, e) => Presenter.ChangeAddresses();
            btnOpen.Click += (s, e) => { Task.Run(() => Application.Current.Dispatcher.Invoke(() => txbPathToFile.Text = Presenter.OpenFile())); };
        }

        #region Свойства

        public string DBase
        {
            get => txbBD.Text;
            set => Application.Current.Dispatcher.Invoke(() => txbBD.Text = value);
        }
        public string Generaltable
        {
            get => txbGT.Text;
            set => Application.Current.Dispatcher.Invoke(() => txbGT.Text = value);
        }
        public string UsersTable
        {
            get => txbUT.Text;
            set => Application.Current.Dispatcher.Invoke(() => txbUT.Text = value);
        }
        public string OSP
        {
            get => txbOspT.Text;
            set => Application.Current.Dispatcher.Invoke(() =>  txbOspT.Text = value);
        }
        public string OsType
        {
            get => txbOsT.Text;
            set => Application.Current.Dispatcher.Invoke(() => txbOsT.Text = value);
        }
        public string Results
        {
            get => txbRT.Text;
            set => Application.Current.Dispatcher.Invoke(() => txbRT.Text = value);
        }
        public string Why
        {
            get => txbWT.Text;
            set => Application.Current.Dispatcher.Invoke(() => txbWT.Text = value);
        }
        public string ServerAddress
        {
            get => txbServer.Text;
            set => Application.Current.Dispatcher.Invoke(() => txbServer.Text = value);
        }
        public string ConnectionString
        {
            get => txbConString.Text;
            set => Application.Current.Dispatcher.Invoke(() => txbConString.Text = value);
        }
        public string UpdateAddress
        {
            get;
            set;
        }

        #endregion
    }
}
