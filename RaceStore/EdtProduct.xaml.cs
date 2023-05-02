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
        int productId;
        public EdtProduct(int Id)
        {
            InitializeComponent();
            productId = Id;
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
            Products products = Helper.GetContext().Products.FirstOrDefault(p => p.ProductID == productId);
            if (ProductTitleTb.Text!=""&& ProductTitleTb.Text != products.ProductTitle) products.ProductTitle = ProductTitleTb.Text;
            if(InfoTb.Text!=""&&InfoTb.Text!=products.Info) products.Info = InfoTb.Text;
            if(PriceTb.Text!=""&& PriceTb.Text!=products.Price) products.Price = PriceTb.Text;
            if (KolvoTb.Text != "" && Convert.ToInt32(KolvoTb.Text) != products.Kolvo) products.Kolvo = Convert.ToInt32(KolvoTb.Text);
            TypeProducts typeProducts = Helper.GetContext().TypeProducts.FirstOrDefault(c => c.TypeProductID == products.TypeProductID);
            Provides provides = Helper.GetContext().Provides.FirstOrDefault(p => p.ProviderID == products.ProviderID);
            Storages storages = Helper.GetContext().Storages.FirstOrDefault(s => s.StorageID == products.StorageID);
            if (TypeProductsTb.Text!=""&& TypeProductsTb.Text != typeProducts.TypeTitle)
            {
                TypeProducts typeProducts1 = Helper.GetContext().TypeProducts.FirstOrDefault(t => t.TypeTitle == TypeProductsTb.Text);
                products.TypeProductID = typeProducts1.TypeProductID;
            }
            if(ProvidesTb.Text!=""&&ProvidesTb.Text!=provides.ProviderTitle)
            {
                Provides provides1 = Helper.GetContext().Provides.FirstOrDefault(p=>p.ProviderTitle== ProvidesTb.Text);
                products.ProviderID = provides1.ProviderID;
            }
            if (StoragesTb.Text != "" && StoragesTb.Text != storages.StorageTitle)
            {
                Storages storages1 = Helper.GetContext().Storages.FirstOrDefault(s=>s.StorageTitle == StoragesTb.Text);
                products.StorageID = storages1.StorageID;
            }
            Helper.GetContext().SaveChanges();
            this.DialogResult = true;
        }
    }
}
