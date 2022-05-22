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
    public class MainWinViewModel : BaseViewModel
    {
        private RelayCommand _authorization;
        private RelayCommand _registrationBtn;
        private string _login;


        public RelayCommand RegistrationBtn
        {
            get { return _registrationBtn ?? (_registrationBtn = new RelayCommand((x) => 
                    {
                        new View.Registration().Show();
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
        public RelayCommand Authorization
        {
            get 
            {
                return _authorization ??
                    (_authorization = new RelayCommand((x) =>
                    {
                        PasswordBox password = (PasswordBox)x;
                        Users user = Helper.db.Users.FirstOrDefault(x => x.Login == LoginUser && x.Password == password.Password);
                        if (user != null)
                        {
                            Helper.userSession = user;
                            new View.MenuWindow().Show();
                            foreach (Window item in Application.Current.Windows)
                            {
                                if (item.DataContext == this) 
                                {
                                    item.Close();
                                }
                            }

                        }
                        else
                        {
                            MessageBox.Show("Неверный  логин или пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }
                    }));
            }
            set 
            { 
                _authorization = value;
                OnPropertyChanged();
            }
        }

        public string LoginUser
        {
            get => _login; 
            set { _login = value; OnPropertyChanged(); }
        }


    }
}
