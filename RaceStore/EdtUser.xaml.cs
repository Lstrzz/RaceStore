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
    /// Логика взаимодействия для EdtUser.xaml
    /// </summary>
    public partial class EdtUser : Window
    {
        int UserID;
        public EdtUser(int id)
        {
            InitializeComponent();
            UserID = id;
            OfficeTb.ItemsSource = Helper.GetContext().Offices.ToList();
            RoleTb.ItemsSource = Helper.GetContext().Roles.ToList();
            Users users = Helper.GetContext().Users.FirstOrDefault(u=>u.UserID == id);
            Roles roles = Helper.GetContext().Roles.FirstOrDefault(r=>r.RoleID == users.RoleID);
            Offices offices = Helper.GetContext().Offices.FirstOrDefault(o => o.OfficeID == users.OfficeID);
            FTb.Text = users.Fname;
            ITb.Text = users.Iname;
            OTb.Text = users.Oname;
            LoggTb.Text = users.Logg;
            OfficeTb.Text = offices.OfficeTitle;
            RoleTb.Text = roles.RolTitle; 
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Users users = Helper.GetContext().Users.FirstOrDefault(u => u.UserID == UserID);
            if(FTb.Text!=""&& FTb.Text !=users.Fname) users.Fname = FTb.Text;
            if (ITb.Text != "" && ITb.Text != users.Iname) users.Iname = ITb.Text;
            if (OTb.Text != "" && OTb.Text != users.Oname) users.Oname = OTb.Text;
            if (PassTb.Password != "" && PassTb.Password != users.Pass&& Pass1Tb.Password != "" && Pass1Tb.Password != users.Pass && PassTb.Password == Pass1Tb.Password)  users.Pass = PassTb.Password;
            Roles roles = Helper.GetContext().Roles.FirstOrDefault(r => r.RoleID == users.RoleID);
            Roles roles1 = Helper.GetContext().Roles.FirstOrDefault(r => r.RolTitle == RoleTb.Text);
            if (RoleTb.Text != "" && OfficeTb.Text != roles.RolTitle) users.RoleID = roles1.RoleID;
            Offices offices = Helper.GetContext().Offices.FirstOrDefault(o => o.OfficeID == users.OfficeID);
            Offices offices1 = Helper.GetContext().Offices.FirstOrDefault(o => o.OfficeTitle == OfficeTb.Text);
            if (OfficeTb.Text != "" && OfficeTb.Text != offices.OfficeTitle) users.OfficeID = offices1.OfficeID;
            Helper.GetContext().SaveChanges();


            OfficeTb.ItemsSource = Helper.GetContext().Offices.ToList();
            RoleTb.ItemsSource = Helper.GetContext().Roles.ToList();
            Users users3 = Helper.GetContext().Users.FirstOrDefault(u => u.UserID == UserID);
            Roles roles3 = Helper.GetContext().Roles.FirstOrDefault(r => r.RoleID == users.RoleID);
            Offices offices3 = Helper.GetContext().Offices.FirstOrDefault(o => o.OfficeID == users.OfficeID);
            FTb.Text = users3.Fname;
            ITb.Text = users3.Iname;
            OTb.Text = users3.Oname;
            LoggTb.Text = users3.Logg;
            OfficeTb.Text = offices3.OfficeTitle;
            RoleTb.Text = roles3.RolTitle;
            PassTb.Password = "";
            Pass1Tb.Password = "";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
