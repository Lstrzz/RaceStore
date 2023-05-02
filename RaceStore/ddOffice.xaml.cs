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
    /// Логика взаимодействия для ddOffice.xaml
    /// </summary>
    public partial class ddOffice : Window
    {
        public ddOffice()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(OfficeTitleTb.Text!=""&&StorageTitleTb.Text!=""&&CityTb.Text!=""&&StreetTb.Text!=""&& NunhomeTb.Text != "" && NumkvTb.Text != "" && PindexTb.Text != "")
            {
                Addres addres = new Addres(Convert.ToInt32(PindexTb.Text),CityTb.Text,StreetTb.Text, NunhomeTb.Text, Convert.ToInt32(NumkvTb.Text));
                Helper.GetContext().Addres.Add(addres);
                Helper.GetContext().SaveChanges();
                int num = Convert.ToInt32(NumkvTb.Text);
                int ind = Convert.ToInt32(PindexTb.Text);
                addres = Helper.GetContext().Addres.FirstOrDefault(a => a.City == CityTb.Text && a.Street == StreetTb.Text && a.Nunhome == NunhomeTb.Text && a.Numkv == num && a.Pindex ==ind );
                Storages storages = new Storages(StorageTitleTb.Text);
                Helper.GetContext().Storages.Add(storages);
                Helper.GetContext().SaveChanges();
                storages = Helper.GetContext().Storages.FirstOrDefault(s => s.StorageTitle == StorageTitleTb.Text);
                Offices offices = new Offices(OfficeTitleTb.Text, addres.AddresID,storages.StorageID);
                Helper.GetContext().Offices.Add(offices);
                Helper.GetContext().SaveChanges();
                this.DialogResult = true;
            }
            else MessageBox.Show("Не все поля заполнены", "Ошибка");
        }
    }
}
