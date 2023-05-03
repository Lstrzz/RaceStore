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
    /// Логика взаимодействия для EdtStatusOrderWindow.xaml
    /// </summary>
    public partial class EdtStatusOrderWindow : Window
    {
        int ch;
        public EdtStatusOrderWindow(int id)
        {
            InitializeComponent();
            ch = id;
            ChaProducts chaProducts = Helper.GetContext().ChaProducts.FirstOrDefault(c=>c.ChaProdID == id);
            StatuseTb.ItemsSource = Helper.GetContext().Statuses.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ChaProducts chaProducts = Helper.GetContext().ChaProducts.FirstOrDefault(c => c.ChaProdID == ch);
            Statuses statuses = Helper.GetContext().Statuses.FirstOrDefault(s => s.StatuseTitle == StatuseTb.Text);
            chaProducts.StatuseID = statuses.StatuseID;
            Helper.GetContext().SaveChanges();
            this.DialogResult = true;
        }
    }
}
