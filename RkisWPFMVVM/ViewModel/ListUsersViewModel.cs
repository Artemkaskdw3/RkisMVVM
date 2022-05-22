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
    public class ListUsersViewModel : BaseViewModel
    {
        private List<Users> _listOfUsers;
        private RelayCommand _backBtn;

        public RelayCommand BackBtn
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
        public ListUsersViewModel()
        {
            ListUsers = Helper.db.Users.ToList();
        }

        public List<Users> ListUsers
        {
            get => _listOfUsers;

            set
            {
                _listOfUsers = value;
                OnPropertyChanged();

            }
        }


    }
}
