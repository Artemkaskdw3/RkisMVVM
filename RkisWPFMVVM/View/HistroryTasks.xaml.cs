using Microsoft.EntityFrameworkCore;
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
using System.Windows.Shapes;

namespace RkisWPFMVVM.View
{
    /// <summary>
    /// Логика взаимодействия для HistroryTasks.xaml
    /// </summary>
    public partial class HistroryTasks : Window
    {
      
        public HistroryTasks()
        {
            InitializeComponent();
            Helper.db.Users.Load();
            Helper.db.StatusTabl.Load();
            DataContext = new ViewModel.HistoryTasksViewModel();

        }
    
    }
}
