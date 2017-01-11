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

namespace KGGaming
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        // Variables
        List<storeProduct> inCartItems;
        MainWindow loginWindow;
        private double itemPrice;
        private string formattedPrice;

        public MainMenu(string EmpID)
        {
            InitializeComponent();
            loginWindow = new MainWindow();
            inCartItems = new List<storeProduct>();
            lblEmpID.Content = EmpID;
        }

        private void imgSettings_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Settings settingsObj = new Settings();
            settingsObj.Show();
        }

        private void btnItemTest_Click(object sender, RoutedEventArgs e)
        {
            itemPrice = 9.00;
            formattedPrice = "$" + String.Format("{0:0.00}", itemPrice);
            inCartItems.Add(new storeProduct() { Item = "M4 MidCap Magazine", Price = formattedPrice });
            cartList.ItemsSource = inCartItems;
            cartList.Items.Refresh();
            scrollToBottom();
        }

        public class storeProduct
        {
            public string Item { get; set; }
            public string Price { get; set; }
        }

        private void btnItemTest2_Click(object sender, RoutedEventArgs e)
        {
            itemPrice = 25.00;
            formattedPrice = "$" + String.Format("{0:0.00}", itemPrice);
            inCartItems.Add(new storeProduct() { Item = "LiPo 11.1v Battery", Price = formattedPrice });
            cartList.ItemsSource = inCartItems;
            cartList.Items.Refresh();
            scrollToBottom();
        }

        private void scrollToBottom()
        {
            cartList.SelectedIndex = cartList.Items.Count - 1;
            cartList.ScrollIntoView(cartList.SelectedItem);
        }
    }
}
