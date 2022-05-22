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
    public class RegistrationViewModel : BaseViewModel
    {
        private string _nameText;
        private string _sernameText;
        private string _lastNameText;
        private string _loginText;
        private string _passwordText;
        private string _phoneNumberText;
        private RelayCommand _registrationBtn;
        private RelayCommand _backBtn;


        public RelayCommand RegistrationBtn
        {
            get {
                return _registrationBtn ?? (_registrationBtn = new RelayCommand((x) =>
                {
                    if (!string.IsNullOrEmpty(NameText) &&
                        !string.IsNullOrEmpty(SernameText) &&
                        !string.IsNullOrEmpty(LastNameText) &&
                        !string.IsNullOrEmpty(LoginText) &&
                        !string.IsNullOrEmpty(PasswordText) &&
                        !string.IsNullOrEmpty(PhoneNumberText))
                    {
                        if (Helper.db.Users.All(x => x.Login != LoginText))
                        {

                            Users newUser = new Users
                            {
                                Name = NameText,
                                Sername = SernameText,
                                LastName = LastNameText,
                                Login = LoginText,
                                Password = PasswordText,
                                PhoneNumber = PhoneNumberText,
                            };
                            Helper.db.Users.Add(newUser);
                            Helper.db.SaveChanges();
                            MessageBox.Show("Упешно!","Регистрация",MessageBoxButton.OK,MessageBoxImage.Information);
                            new View.MainWin().Show();
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
                            MessageBox.Show("Такой логин уже занят!", "Регистрация", MessageBoxButton.OK,MessageBoxImage.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Одно или несколько полей пустые!", "Регистрация", MessageBoxButton.OK, MessageBoxImage.Error);
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
        public string NameText{ get => _nameText; set { _nameText = value; OnPropertyChanged(); }}
        public string SernameText { get => _sernameText; set { _sernameText = value; OnPropertyChanged(); }}
        public string LastNameText { get => _lastNameText; set { _lastNameText = value;OnPropertyChanged(); }}
        public string LoginText { get => _loginText; set { _loginText = value; OnPropertyChanged();} }
        public string PasswordText { get => _passwordText; set { _passwordText = value; OnPropertyChanged(); } }
        public string PhoneNumberText { get => _phoneNumberText; set { _phoneNumberText = value; OnPropertyChanged(); } }

    }
}
