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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace KGGaming
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool foundMatch;
        private string myEmpID;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            DataContext db = new DataContext(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\Hunter Gulley\Source\Repos\KGGaming\KGGaming\LoginData.mdf; Integrated Security = True; Connect Timeout = 30");
            Table<LoginInfo> Information = db.GetTable<LoginInfo>();
            try
            {
                IQueryable<LoginInfo> detailQuery = from LoginInfo in Information select LoginInfo;
                foreach (LoginInfo item in detailQuery)
                {
                    if (txtLoginUser.Text == item.Username && passBoxPassword.Password == item.Password)
                    {
                        foundMatch = true;
                        break;
                    }
                    else
                    {
                        foundMatch = false;
                    }
                }
                if (foundMatch == true)
                {
                    MessageBox.Show("Logged In!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    MainMenu mainMenu = new MainMenu(txtLoginUser.Text);
                    mainMenu.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Invalid Login Credintials, Please check to see if the username and password are both correct.", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSignUp_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
