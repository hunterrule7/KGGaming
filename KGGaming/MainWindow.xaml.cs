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
        string pulledInfo;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnSignUp_Click(object sender, RoutedEventArgs e)
        {
            DataContext db = new DataContext(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\Hunter Gulley\Source\Repos\KGGaming\KGGaming\LoginData.mdf; Integrated Security = True; Connect Timeout = 30");
            Table<Info> Information = db.GetTable<Info>();
            try
            {
                IQueryable<Info> detailQuery = from Info in Information select Info;
                foreach (Info item in detailQuery)
                {
                    pulledInfo += String.Format("ID={0}, Username={1}, Password={2}\n", item.Id, item.Username, item.Password);
                    MessageBox.Show(pulledInfo);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
