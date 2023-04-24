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
    /// Логика взаимодействия для EdtProduct.xaml
    /// </summary>
    public partial class EdtProduct : Window
    {
        public EdtProduct(int Id)
        {
            InitializeComponent();
            TypeProductsTb.ItemsSource = Helper.GetContext().TypeProducts.ToList();
            ProvidesTb.ItemsSource = Helper.GetContext().Provides.ToList();
            StoragesTb.ItemsSource = Helper.GetContext().Storages.ToList();

            Products products = Helper.GetContext().Products.FirstOrDefault(p => p.ProductID == Id);
            ProductTitleTb.Text = products.ProductTitle;
            InfoTb.Text = products.Info;
            PriceTb.Text = products.Price;
            KolvoTb.Text = products.Kolvo.ToString();


            TypeProducts typeProducts = Helper.GetContext().TypeProducts.FirstOrDefault(c => c.TypeProductID == products.TypeProductID);
            Provides provides = Helper.GetContext().Provides.FirstOrDefault(p => p.ProviderID == products.ProviderID);
            Storages storages = Helper.GetContext().Storages.FirstOrDefault(s => s.StorageID == products.StorageID);
            TypeProductsTb.Text = typeProducts.TypeTitle;
            ProvidesTb.Text = provides.ProviderTitle;
            StoragesTb.Text = storages.StorageTitle;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
