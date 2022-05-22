using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public class AvailableTasksViewModel : BaseViewModel
    {

        private ObservableCollection<Tasks> _listTasks;
        private Tasks _selectedTasks;
        private RelayCommand _backBtn;
        private RelayCommand _takeTask;
        private RelayCommand _search;
        private string _login;
        private RelayCommand _update;

        public AvailableTasksViewModel()
        {
            ListTasks = new ObservableCollection<Tasks>(Helper.db.Tasks.Where(x => x.Status == 2 && x.IdUserCreation != Helper.userSession.IdUser).ToList());
        }
        public string LoginTextBlock
        {
            get => _login;
            set
            {
                _login = value;
            }
        }
        public RelayCommand Update
        {
            get
            {
                return _update ?? (_update = new RelayCommand((x) => 
                {
                    ListTasks = new ObservableCollection<Tasks>(Helper.db.Tasks.Where(x => x.Status == 2 && x.IdUserCreation != Helper.userSession.IdUser).ToList());
                    OnPropertyChanged();

                }));
            }
        }
        public RelayCommand Search
        {
            get 
            {
                return _search ?? (_search = new RelayCommand((x) =>
                {
                    if (!string.IsNullOrWhiteSpace(LoginTextBlock) && Helper.db.Users.Any(x => x.Login == LoginTextBlock))
                    {
                        if (Helper.db.Users.Where(q => q.Login == LoginTextBlock).FirstOrDefault().IdUser != Helper.userSession.IdUser)
                        {
                            ListTasks = new ObservableCollection<Tasks>(Helper.db.Tasks.Where(x => x.IdUserCreation == Helper.db.Users.Where(q => q.Login == LoginTextBlock && x.Status == 2).FirstOrDefault().IdUser));
                            OnPropertyChanged();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Поле пустое или такого пользователя не существует", "Поиск", MessageBoxButton.OK,MessageBoxImage.Error);
                    }
                }
                ));
            }
        }
        public RelayCommand TakeTask
        {
            get 
            {
                return _takeTask ?? (_takeTask = new RelayCommand((x) =>
                {
                    SelectedTask.IdUserTake = Helper.userSession.IdUser;
                    SelectedTask.Status = 3;
                    Helper.db.SaveChanges();
                    MessageBox.Show("Вы взяли задачу");
                    ListTasks = new ObservableCollection<Tasks>(Helper.db.Tasks.Where(x => x.Status == 2 && x.IdUserCreation != Helper.userSession.IdUser).ToList());
                    OnPropertyChanged();
                })); 
            }
        }

        public RelayCommand BackBtnn
        {
            get
            {
                return _backBtn ??
                    (_backBtn = new RelayCommand((x) =>
                    {
                        new View.MenuWindow().Show();
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
        public ObservableCollection<Tasks> ListTasks
        {
         
            get { return _listTasks; }
            set
            {
                _listTasks = value;
                OnPropertyChanged();
            }
        }
        public Tasks SelectedTask
        {
            get => _selectedTasks;
            set
            {
                _selectedTasks = value;
                OnPropertyChanged();
            }
        }

    }
}
