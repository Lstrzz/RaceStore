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
    /// Логика взаимодействия для ProvidersWindow.xaml
    /// </summary>
    public partial class ProvidersWindow : Window
    {
        public ProvidersWindow()
        {
            InitializeComponent();
            ProvidersDg.ItemsSource = Helper.GetContext().Provides.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(ProviderTitleTb.Text!="")
            {
                Provides provides = Helper.GetContext().Provides.FirstOrDefault(p=>p.ProviderTitle == ProviderTitleTb.Text);
                if(provides==null)
                {
                    Provides provides1 = new Provides(ProviderTitleTb.Text);
                    Helper.GetContext().Provides.Add(provides1);
                    Helper.GetContext().SaveChanges();
                    ProvidersDg.ItemsSource = Helper.GetContext().Provides.ToList();
                    ProviderTitleTb.Text = "";
                }
                else MessageBox.Show("Такой поставщик уже есть", "Ошибка");
            }
            else MessageBox.Show("Не все поля заполнены", "Ошибка");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Provides provides = (Provides)ProvidersDg.SelectedItem;
            if (provides != null)
            {
                if (MessageBox.Show("Вы действительно хотите удалить поставщика?\nВсе товары этого постащика также будут удалены.", "Удалить поставщика", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    Helper.GetContext().Provides.Remove(provides);
                    Helper.GetContext().SaveChanges();
                    ProvidersDg.ItemsSource = Helper.GetContext().Provides.ToList();
                }
            }
        }
    }
}
