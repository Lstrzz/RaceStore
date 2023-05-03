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
    /// Логика взаимодействия для OrderWindow.xaml
    /// </summary>
    public partial class OrderWindow : Window
    {
        int st;
        public OrderWindow(int id,int stid)
        {
            InitializeComponent();
            st = stid;
            Products products = Helper.GetContext().Products.FirstOrDefault(p => p.ProductID == id);
            ProductTb.Text = products.ProductTitle;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Products products = Helper.GetContext().Products.FirstOrDefault(p => p.ProductTitle == ProductTb.Text && p.StorageID !=st);
            if (products.Kolvo - Convert.ToInt32(ProdKolvoS.Value) >= 0)
            {
                products.Kolvo -= Convert.ToInt32(ProdKolvoS.Value);
                Helper.GetContext().SaveChanges();
                Products products1 = Helper.GetContext().Products.FirstOrDefault(p=>p.ProductTitle == products.ProductTitle &&p.Info == products.Info&&p.Price==products.Price && p.TypeProductID == products.TypeProductID&&p.ProviderID == products.ProviderID&& p.StorageID ==st);
                if(products1!=null) products1.Kolvo += Convert.ToInt32(ProdKolvoS.Value);
                else
                {
                    Products products2 = new Products(products.ProductTitle, products.Info, products.Price, Convert.ToInt32(ProdKolvoS.Value), products.TypeProductID, products.ProviderID, st);
                    Helper.GetContext().Products.Add(products2);
                    Helper.GetContext().SaveChanges();
                }
                ChaProducts chaProducts = new ChaProducts(products.ProductID, Convert.ToInt32(ProdKolvoS.Value), 5, DateTime.Now.ToString(), st, 1);
                Helper.GetContext().ChaProducts.Add(chaProducts);
                Helper.GetContext().SaveChanges();
                this.DialogResult = true;
            }
            else MessageBox.Show("Товара Не хватает", "Ошибка");
        }
    }
}
