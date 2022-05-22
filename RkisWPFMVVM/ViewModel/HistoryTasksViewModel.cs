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

    public class HistoryTasksViewModel : BaseViewModel
    {
        private RelayCommand _backBtn;
        private ObservableCollection<Tasks> _historyTasks;
        private Tasks _selectedTasks;
        private RelayCommand _switchStatus;
        private string _selectedItemFromCB;
        private RelayCommand _acceptBtn;
        private string _showTask;

        public HistoryTasksViewModel()
        {
            HistoryTasks = new ObservableCollection<Tasks>(Helper.db.Tasks.Where(x=>x.IdUserCreation == Helper.userSession.IdUser).ToList());

            ShowTask = "Ничего не выбрано";

        }
        public string SelectedItemFromCB
        {
            get => _selectedItemFromCB;
            set
            {
                _selectedItemFromCB = value;
                OnPropertyChanged();

            }
        }
        public ObservableCollection<Tasks> HistoryTasks
        {
            get { return _historyTasks; }
            set 
            {
                _historyTasks = value;
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
        public RelayCommand SwitchStatus
        {
            get
            {
                return _switchStatus ?? (_switchStatus = new RelayCommand((x) =>
                {
                    if (!string.IsNullOrWhiteSpace(SelectedTask.NameTask.ToString()) && Helper.db.Tasks.Any(x => x.NameTask == SelectedTask.NameTask.ToString()))
                    {
                        ShowTask = SelectedTask.NameTask;

                    }
                    else
                    {
                        ShowTask = "Ничего не выбрано";
                    }
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
        public RelayCommand AcceptBTN
        {
            get
            {
                
            
                return _acceptBtn ?? (_acceptBtn = new RelayCommand((x) =>
                {
                   
                    switch (SelectedItemFromCB)
                    {

                        case "System.Windows.Controls.ComboBoxItem: Готов":
                            if (SelectedTask.Status != 2)
                            {

                                SelectedTask.Status = 1;
                                Helper.db.SaveChanges();
                                HistoryTasks = new ObservableCollection<Tasks>(Helper.db.Tasks.Where(x => x.IdUserCreation == Helper.userSession.IdUser).ToList());
                                OnPropertyChanged();
                            }
                            else
                            {
                                MessageBox.Show("Чтобы изменить задачу с статусом Не готов\nНужно чтобы её кто принял", "Изменение статуса", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                            
                            break;
                        case "System.Windows.Controls.ComboBoxItem: Не готов":
                                
                            SelectedTask.Status = 2;
                            SelectedTask.IdUserTake = null;
                            Helper.db.SaveChanges();
                            HistoryTasks = new ObservableCollection<Tasks>(Helper.db.Tasks.Where(x => x.IdUserCreation == Helper.userSession.IdUser).ToList());
                            OnPropertyChanged();  
                            break;
                        case "System.Windows.Controls.ComboBoxItem: Выполняется":
                            if (SelectedTask.Status != 2)
                            {

                                SelectedTask.Status = 3;
                                Helper.db.SaveChanges();
                                HistoryTasks = new ObservableCollection<Tasks>(Helper.db.Tasks.Where(x => x.IdUserCreation == Helper.userSession.IdUser).ToList());
                                OnPropertyChanged();
                            }
                            else
                            {
                                MessageBox.Show("Чтобы изменить задачу с статусом Не готов\nНужно чтобы её кто принял", "Изменение статуса", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                            break;
                        default:
                            MessageBox.Show("Ничего не выбрано", "Изменение статуса", MessageBoxButton.OK, MessageBoxImage.Error);

                            break;
                    }
                    

                }));
            }
        }
        public string ShowTask
        {
            get => _showTask;
            set
            {
                _showTask = value;
                OnPropertyChanged();

            }
        }

    }
}
