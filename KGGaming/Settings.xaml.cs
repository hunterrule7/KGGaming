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
using System.Data.Linq;

namespace KGGaming
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void btnAddNewEmp_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataContext db = new DataContext(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\Hunter Gulley\Source\Repos\KGGaming\KGGaming\LoginData.mdf; Integrated Security = True; Connect Timeout = 30");
                LoginInfo loginInfo;
                if (txtNewEmpPass.Password == txtNewEmpPassConfirm.Password)
                {
                    loginInfo = new LoginInfo
                    {
                        Username = txtNewEmpID.Text,
                        Password = txtNewEmpPassConfirm.Password,
                        Id = 3
                    };
                    
                    db.SubmitChanges();
                }

                //This still needs code to be operational.

                MessageBox.Show("Success! You have added " + txtNewEmpID.Text + " to the database!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error has occured while trying to add the employee to the database.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                MessageBox.Show(ex.Message);
            }
        }
    }
}
