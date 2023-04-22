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
    /// Логика взаимодействия для AddUser.xaml
    /// </summary>
    public partial class AddUser : Window
    {
        public AddUser()
        {
            InitializeComponent();
            OfficeTb.ItemsSource = Helper.GetContext().Offices.ToList();
            RoleTb.ItemsSource= Helper.GetContext().Roles.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(FTb.Text!=""&&ITb.Text!=""&&OTb.Text!=""&&LoggTb.Text!=""&&PassTb.Password!=""&&Pass1Tb.Password!=""&&OfficeTb.Text!=""&&RoleTb.Text!="")
            {
                if(Pass1Tb.Password == PassTb.Password)
                {
                    Offices offices = Helper.GetContext().Offices.FirstOrDefault(o => o.OfficeTitle == OfficeTb.Text);
                    Roles roles = Helper.GetContext().Roles.FirstOrDefault(r => r.RolTitle == RoleTb.Text);
                    Users users = new Users(LoggTb.Text, PassTb.Password, FTb.Text, ITb.Text, OTb.Text,offices.OfficeID,roles.RoleID);
                    Helper.GetContext().Users.Add(users);
                    Helper.GetContext().SaveChanges();
                    this.DialogResult = true;
                }
                else MessageBox.Show("Пароли не совпадают", "Ошибка");
            }
            else MessageBox.Show("Не все поля заполнены", "Ошибка");
        }
    }
}
