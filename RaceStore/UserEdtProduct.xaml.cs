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
    /// Логика взаимодействия для UserEdtProduct.xaml
    /// </summary>
    public partial class UserEdtProduct : Window
    {
        int st;
        public UserEdtProduct( int id,int stid)
        {
            InitializeComponent();
            st = stid;
            Products products = Helper.GetContext().Products.FirstOrDefault(p=>p.ProductID == id);
            ProductTb.Text = products.ProductTitle;
            ChaTypesTb.ItemsSource = Helper.GetContext().ChaTypes.Where(c=>c.ChaTypeID!=5).ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (ProductTb.Text != "" && ChaTypesTb.Text != "")
            {
                Products products = Helper.GetContext().Products.FirstOrDefault(p => p.ProductTitle == ProductTb.Text&& p.StorageID == st);
                if (ChaTypesTb.Text == "Поставка") products.Kolvo += Convert.ToInt32(ProdKolvoS.Value);
                else if(ChaTypesTb.Text == "Возврат поставщику") products.Kolvo -= Convert.ToInt32(ProdKolvoS.Value);
                else if (ChaTypesTb.Text == "Списание") products.Kolvo -= Convert.ToInt32(ProdKolvoS.Value);
                else if (ChaTypesTb.Text == "Продажа") products.Kolvo -= Convert.ToInt32(ProdKolvoS.Value);
                ChaTypes chaTypes = Helper.GetContext().ChaTypes.FirstOrDefault(c => c.ChaTitle == ChaTypesTb.Text);
                ChaProducts chaProducts = new ChaProducts(products.ProductID,Convert.ToInt32(ProdKolvoS.Value),chaTypes.ChaTypeID);
                Helper.GetContext().ChaProducts.Add(chaProducts);
                Helper.GetContext().SaveChanges();
                this.DialogResult = true;
            }
        }
    }
}
