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

namespace Equipment_Accounting.View
{
    /// <summary>
    /// Логика взаимодействия для NewContract.xaml
    /// </summary>
    public partial class NewContract : Window
    {
        public NewContract()
        {
            InitializeComponent();
        }

        private void select_Click(object sender, RoutedEventArgs e)
        {
            if (text.Text != "") DialogResult = true;
        }
    }
}
