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

namespace RaceStore
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (LoggTb.Text != "" && PassTb.Password != "")
            {
                Users user = Helper.GetContext().Users.FirstOrDefault(u => u.Logg == LoggTb.Text && u.Pass == PassTb.Password);
                if (user != null && user.RoleID == 1)
                {
                    MainWindow main = new MainWindow();
                    main.Show();
                    this.Close();
                }
                else if (user != null && user.RoleID == 2)
                {
                    ManagerWindow managerWindow = new ManagerWindow(user.UserID);
                    managerWindow.Show();
                    this.Close();
                }
                else MessageBox.Show("Пользователь не найден", "Ошибка");
            }
        }
    }
}
