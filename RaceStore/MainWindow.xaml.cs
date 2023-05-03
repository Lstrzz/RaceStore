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

namespace RaceStore
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            UsersDG.ItemsSource = Helper.GetContext().Users.ToList();
            ProductsDG.ItemsSource = Helper.GetContext() .Products.ToList();
            OfficesDG.ItemsSource = Helper .GetContext().Offices.ToList();
            ChaProdDG.ItemsSource = Helper.GetContext().ChaProducts.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddUser addUser = new AddUser();
            if (addUser.ShowDialog() == true)
            {
                UsersDG.ItemsSource = Helper.GetContext().Users.ToList();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Users SelectedUser = (Users)UsersDG.SelectedItem;
            if(SelectedUser != null)
            {
                if (MessageBox.Show("Вы действительно хотите удалить сотрудника?", "Удалить сотрудника", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    Helper.GetContext().Users.Remove(SelectedUser);
                    Helper.GetContext().SaveChanges();
                }
                UsersDG.ItemsSource = Helper.GetContext().Users.ToList();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Users SelectedUser = (Users)UsersDG.SelectedItem;
            if (SelectedUser != null)
            {
                EdtUser edtUser = new EdtUser(SelectedUser.UserID);
                if (edtUser.ShowDialog() == true)
                {
                    UsersDG.ItemsSource = Helper.GetContext().Users.ToList();
                }
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

            if (MessageBox.Show("Вы действительно хотите выйти?", "Ввйти", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                AuthorizationWindow authorizationWindow = new AuthorizationWindow();
                authorizationWindow.Show();
                this.Close();
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            AddProduct addProduct = new AddProduct();
            if(addProduct.ShowDialog() == true)
            {
                ProductsDG.ItemsSource = Helper.GetContext().Products.ToList();
            }
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            Products products =(Products)ProductsDG.SelectedItem;
            if(products!=null)
            {
                if (MessageBox.Show("Вы действительно хотите удалить продукт?", "Удалить продукт", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    Helper.GetContext().Products.Remove(products);
                    Helper.GetContext().SaveChanges();
                }
                ProductsDG.ItemsSource = Helper.GetContext().Products.ToList();
            }
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            ProvidersWindow providersWindow = new ProvidersWindow();
            providersWindow.ShowDialog();
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            Products products = (Products)ProductsDG.SelectedItem;
            if (products != null)
            {
                EdtProduct edtProduct = new EdtProduct(products.ProductID);
                if(edtProduct.ShowDialog() == true)
                {
                    ProductsDG.ItemsSource = Helper.GetContext().Products.ToList();
                }
            }
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            ddOffice ddOffice = new ddOffice();
            if(ddOffice.ShowDialog() == true)
            {
                OfficesDG.ItemsSource = Helper.GetContext().Offices.ToList();
            }
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            Offices offices =(Offices)OfficesDG.SelectedItem; 
            if (offices != null) 
            {
                if (MessageBox.Show("Вы действительно хотите удалить филиал?", "Удалить филиал", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    Helper.GetContext().Offices.Remove(offices);
                    Helper.GetContext().SaveChanges();
                }
                OfficesDG.ItemsSource = Helper.GetContext().Offices.ToList();
            }
        }

        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            Offices offices = (Offices)OfficesDG.SelectedItem;
            if (offices != null)
            {
                EdtOffice edtOffice = new EdtOffice(offices.OfficeID);
                if (edtOffice.ShowDialog() == true)
                {
                    OfficesDG.ItemsSource = Helper.GetContext().Offices.ToList();
                }
            }
        }

        private void OfficeTitleTb_KeyUp(object sender, KeyEventArgs e)
        {
            List<Users> users = Helper.GetContext().Users.ToList();
            UsersDG.ItemsSource = users.Where(u => u.FIO.IndexOf(Search.Text) != -1);
        }
    }
}
