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

namespace RkisWPFMVVM.ViewModel
{
    public class MenuViewModel : BaseViewModel
    {
        private string _name;
        private string _sername;
        private string _lastName;
        private string _login;
        private string _phoneNumber;
        private RelayCommand _backBtn;
        private RelayCommand _listOfUsers;
        private RelayCommand _availableTask;
        private RelayCommand _historyTasks;
        private RelayCommand _ownTaskForComplite;
        public MenuViewModel()
        {
            Name = "Имя: " + Helper.userSession.Name;
            Sername = "Фамилия: " + Helper.userSession.Sername;
            LastName = "Отчество: " + Helper.userSession.LastName;
            Login = "Логин: " + Helper.userSession.Login;
            PhoneNumber = "Номер телефона: " + Helper.userSession.PhoneNumber;
        }
        public RelayCommand OwnTaskForComplite
        {
            get
            {
                return _ownTaskForComplite ?? (_ownTaskForComplite = new RelayCommand((x) =>
                {
                    new View.TaskForComplite().Show();
                    foreach (Window item in Application.Current.Windows)
                    {
                        if (item.DataContext == this)
                        {
                            item.Close();
                        }
                    }
                }));
            }
        }
        public RelayCommand HistoryTasks
        {
            get
            {
                return _historyTasks ?? (_historyTasks = new RelayCommand((x) =>
                {
                    new View.HistroryTasks().Show();
                    foreach (Window item in Application.Current.Windows)
                    {
                        if (item.DataContext == this)
                        {
                            item.Close();
                        }
                    }
                }));
            }
        }
        public RelayCommand AvailableTask
        {
            get 
            {
                return _availableTask ?? (_availableTask = new RelayCommand((x) =>
                {
                    new View.AvailableTasks().Show();
                    foreach (Window item in Application.Current.Windows)
                    {
                        if (item.DataContext == this)
                        {
                            item.Close();
                        }
                    }

                })); 
            }
        }
        public RelayCommand BackBtn
        {
            get 
            {
                return _backBtn ??
                    (_backBtn = new RelayCommand((x) =>
                    {
                        new View.MainWin().Show();
                        foreach (Window item in Application.Current.Windows)
                        {
                            if (item.DataContext == this)
                            {
                                item.Close();
                            }
                        }
                    }));

            }
        }
        public RelayCommand ListOfUsers
        {
            get
            {
                return _listOfUsers ??
                    (_listOfUsers = new RelayCommand((x) =>
                    {
                        new View.ListUsers().Show();
                        foreach (Window item in Application.Current.Windows)
                        {
                            if (item.DataContext == this)
                            {
                                item.Close();
                            }
                        }
                    }));
            }
            
        }
        public string Name
        {
            get => _name;
            set 
            {
                _name = value;         
                OnPropertyChanged(); 
            }       
        }
        public string Sername
        {
            get => _sername;
            set
            {
                _sername = value;
                OnPropertyChanged();
            }
        }
        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                OnPropertyChanged();
            }
        }
        public string Login
        {
            get => _login;
            set
            {
                _login = value;
                OnPropertyChanged();
            }
        }
        public string PhoneNumber
        {
            get => _phoneNumber;
            set
            {
                _phoneNumber = value;
                OnPropertyChanged();
            }
        }


    }
}
