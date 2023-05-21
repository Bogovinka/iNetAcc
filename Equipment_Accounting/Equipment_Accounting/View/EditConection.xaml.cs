using System;
using System.Collections.Generic;
using System.IO;
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

namespace Equipment_Accounting
{
    /// <summary>
    /// Логика взаимодействия для EditConection.xaml
    /// </summary>
    public partial class EditConection : Window
    {
        public EditConection()
        {
            InitializeComponent();
        }
        private void createB_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            this.Close();
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }

        private void localB_Click(object sender, RoutedEventArgs e)
        {
            using (FileStream fs = File.Create("connect.txt"))
            {
                byte[] info = new UTF8Encoding(true).GetBytes(@"data source=(LocalDB)\MSSQLLocalDB;attachdbfilename=|DataDirectory|\Resource\Database.mdf;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework".ToString());
                // Add some information to the file.
                fs.Write(info, 0, info.Length);
            }
            Close();
        }
    }
}
