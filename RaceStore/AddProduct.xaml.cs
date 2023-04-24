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
    /// Логика взаимодействия для AddProduct.xaml
    /// </summary>
    public partial class AddProduct : Window
    {
        public AddProduct()
        {
            InitializeComponent();
            TypeProductsTb.ItemsSource = Helper.GetContext().TypeProducts.ToList();
            ProvidesTb.ItemsSource = Helper.GetContext().Provides.ToList();
            StoragesTb.ItemsSource = Helper.GetContext().Storages.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(ProductTitleTb.Text!=""&&InfoTb.Text!=""&&PriceTb.Text!=""&&KolvoTb.Text!=""&& TypeProductsTb.Text!=""&&ProvidesTb.Text!=""&&StoragesTb.Text!="")
            {
                TypeProducts typeProducts = Helper.GetContext().TypeProducts.FirstOrDefault(c=>c.TypeTitle == TypeProductsTb.Text);
                Storages storages = Helper.GetContext().Storages.FirstOrDefault(s=>s.StorageTitle == StoragesTb.Text);
                Provides provides = Helper.GetContext().Provides.FirstOrDefault(p=>p.ProviderTitle == ProvidesTb.Text);
                if(provides == null)
                {
                    Provides provides1 = new Provides(ProvidesTb.Text);
                    Helper.GetContext().Provides.Add(provides1);
                    Helper.GetContext().SaveChanges();
                    ProvidesTb.ItemsSource = Helper.GetContext().Provides.ToList();
                    provides = Helper.GetContext().Provides.FirstOrDefault(p => p.ProviderTitle == ProvidesTb.Text);
                }
                Products products = new Products(ProductTitleTb.Text, InfoTb.Text, PriceTb.Text,Convert.ToInt32(KolvoTb.Text),typeProducts.TypeProductID,provides.ProviderID,storages.StorageID);
                Helper.GetContext().Products.Add(products);
                Helper.GetContext().SaveChanges();
                this.DialogResult = true;
            }
            else MessageBox.Show("Не все поля заполнены", "Ошибка");
        }
    }
}
