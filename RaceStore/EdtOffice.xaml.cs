using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
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
    /// Логика взаимодействия для EdtOffice.xaml
    /// </summary>
    public partial class EdtOffice : Window
    {
        int OfficeID;
        public EdtOffice(int id)
        {
            InitializeComponent();
            OfficeID = id;
            Offices offices = Helper.GetContext().Offices.FirstOrDefault(o => o.OfficeID == OfficeID);
            OfficeTitleTb.Text = offices.OfficeTitle;
            Storages storages = Helper.GetContext().Storages.FirstOrDefault(s => s.StorageID == offices.StorageID);
            Addres addres = Helper.GetContext().Addres.FirstOrDefault(a => a.AddresID == offices.AddresID);
            StorageTitleTb.Text = storages.StorageTitle;
            CityTb.Text = addres.City;
            StreetTb.Text = addres.Street;
            NunhomeTb.Text = addres.Nunhome;
            NumkvTb.Text = addres.Numkv.ToString();
            PindexTb.Text = addres.Pindex.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Offices offices = Helper.GetContext().Offices.FirstOrDefault(o => o.OfficeID == OfficeID);
            if (OfficeTitleTb.Text != "" && OfficeTitleTb.Text != offices.OfficeTitle) offices.OfficeTitle = OfficeTitleTb.Text;
            Storages storages = Helper.GetContext().Storages.FirstOrDefault(s => s.StorageID == offices.StorageID);
            if(StorageTitleTb.Text!=""&& StorageTitleTb.Text!=storages.StorageTitle) storages.StorageTitle = StorageTitleTb.Text;
            Addres addres = Helper.GetContext().Addres.FirstOrDefault(a => a.AddresID == offices.AddresID);
            if(CityTb.Text!=""&& CityTb.Text!= addres.City) addres.City = CityTb.Text;
            if(StreetTb.Text!=""&& StreetTb.Text!=addres.Street) addres.Street = StreetTb.Text;
            if(NunhomeTb.Text!=""&& NunhomeTb.Text!= addres.Nunhome) addres.Nunhome = NunhomeTb.Text;
            if (NumkvTb.Text != "" && Convert.ToInt32(NumkvTb.Text) != addres.Numkv) addres.Numkv = Convert.ToInt32(NumkvTb.Text);
            if (PindexTb.Text != "" && Convert.ToInt32(PindexTb.Text) != addres.Pindex) addres.Pindex = Convert.ToInt32(PindexTb.Text);
            Helper.GetContext().SaveChanges();
            this.DialogResult = true;
        }
    }
}
