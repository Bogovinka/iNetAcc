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
    /// Логика взаимодействия для AddTypeName.xaml
    /// </summary>
    public partial class AddTypeName : Window
    {
        public AddTypeName()
        {
            InitializeComponent();
        }
        public AddTypeName(string t)
        {
            InitializeComponent();
            text.Text = t;
        }

        private void select_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
