﻿using System;
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
    /// Логика взаимодействия для ManagerWindow.xaml
    /// </summary>
    public partial class ManagerWindow : Window
    {
        Users users;
        Offices offices;
        public ManagerWindow(int id)
        {
            InitializeComponent();
            users = Helper.GetContext().Users.FirstOrDefault(u => u.UserID == id);
            offices = Helper.GetContext().Offices.FirstOrDefault(o => o.OfficeID == users.OfficeID);
            ProductsDG.ItemsSource = Helper.GetContext().Products.Where(p=>p.StorageID ==offices.StorageID).ToList();
            ProductsOrderDG.ItemsSource = Helper.GetContext().Products.Where(p => p.StorageID != offices.StorageID).ToList();
            ChaProdDG.ItemsSource = Helper.GetContext().ChaProducts.Where(c => c.StorageID == offices.StorageID&&c.ChaTypeID==5).ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (MessageBox.Show("Вы действительно хотите выйти?", "Ввйти", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                AuthorizationWindow authorizationWindow = new AuthorizationWindow();
                authorizationWindow.Show();
                this.Close();
            }
        }

        private void OfficeTitleTb_KeyUp(object sender, KeyEventArgs e)
        {
            List<Products> products = Helper.GetContext().Products.ToList();
            ProductsDG.ItemsSource = products.Where(p => p.StorageID == offices.StorageID && p.ProductTitle.IndexOf(Search.Text) != -1);
        }

        private void OfficeTitleTb_KeyUp1(object sender, KeyEventArgs e)
        {
            List<Products> products = Helper.GetContext().Products.ToList();
            ProductsOrderDG.ItemsSource = products.Where(p => p.StorageID != offices.StorageID && p.ProductTitle.IndexOf(SearchOrder.Text) != -1);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Products products = (Products)ProductsDG.SelectedItem;
            if(products != null)
            {
                UserEdtProduct userEdtProduct = new UserEdtProduct(products.ProductID,offices.StorageID);
                if(userEdtProduct.ShowDialog()==true)
                {
                    List<Products> products1 = Helper.GetContext().Products.ToList();
                    ProductsDG.ItemsSource = products1.Where(p => p.StorageID == offices.StorageID && p.ProductTitle.IndexOf(Search.Text) != -1);
                }
            }
        }

        private void c1_Click(object sender, RoutedEventArgs e)
        {
            c2.IsChecked = false;
            ChaProdDG.ItemsSource = Helper.GetContext().ChaProducts.Where(c => c.StorageID == offices.StorageID&&c.ChaTypeID == 5).ToList();
        }

        private void c2_Click(object sender, RoutedEventArgs e)
        {
            c1.IsChecked = false;
            ChaProdDG.ItemsSource = Helper.GetContext().ChaProducts.Where(c => c.Products.StorageID == offices.StorageID&&c.ChaTypeID == 5).ToList();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Products products = (Products)ProductsOrderDG.SelectedItem;
            if(products != null)
            {
                OrderWindow orderWindow = new OrderWindow(products.ProductID,offices.StorageID);
                if(orderWindow.ShowDialog()==true)
                {
                    ProductsOrderDG.ItemsSource = Helper.GetContext().Products.Where(p => p.StorageID != offices.StorageID).ToList();
                    ChaProdDG.ItemsSource = Helper.GetContext().ChaProducts.Where(c => c.StorageID == offices.StorageID && c.ChaTypeID == 5).ToList();
                }
            }
        }

        private void mdk(object sender, MouseButtonEventArgs e)
        {
            if (c2.IsChecked == true)
            {
                ChaProducts chaProducts = (ChaProducts)ChaProdDG.SelectedItem;
                if (chaProducts != null)
                {
                    EdtStatusOrderWindow edtStatusOrderWindow = new EdtStatusOrderWindow(chaProducts.ChaProdID);
                    if (edtStatusOrderWindow.ShowDialog() == true)
                    {
                        ChaProdDG.ItemsSource = Helper.GetContext().ChaProducts.Where(c =>c.Products.StorageID == offices.StorageID && c.ChaTypeID == 5).ToList();
                    }
                }
            }
        }
    }
}
