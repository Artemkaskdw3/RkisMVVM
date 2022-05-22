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
    public class TaskForCompliteViewModel : BaseViewModel
    {
        private RelayCommand _backBtn;
        private ObservableCollection<Tasks> _taskForComplite;

        public TaskForCompliteViewModel()
        {
            TaskForComplite = new ObservableCollection<Tasks>(Helper.db.Tasks.Where(x=>x.IdUserTake == Helper.userSession.IdUser));
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
        public ObservableCollection<Tasks> TaskForComplite
        {
            get { return _taskForComplite; }
            set
            {
                _taskForComplite = value;
                OnPropertyChanged();
            }
        }
    }
}
