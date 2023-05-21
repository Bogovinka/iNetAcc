using Equipment_Accounting.Resource.Model;
using System;
using System.Collections.Generic;
using System.Configuration.Provider;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Equipment_Accounting
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Classes.ConnectBD con = new Classes.ConnectBD();
        Resource.Model.DatabaseEntities db;
        string pathAuto = @"auto.txt";
        public MainWindow()
        {
            InitializeComponent();
            db = con.getDB();
            try
            {

                loginText.Text = File.ReadLines("auto.txt").First();
                passwordText.Password = File.ReadLines("auto.txt").Skip(1).First();
            }
            catch { }
        }

        private void loginB_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (db.Logins.Where(x => x.Login == loginText.Text && x.Password == passwordText.Password).Count() > 0)
                {
                    Logins log = db.Logins.Where(x => x.Login == loginText.Text && x.Password == passwordText.Password).FirstOrDefault();
                    using (FileStream fs = File.Create(pathAuto))
                    {
                        byte[] info = new UTF8Encoding(true).GetBytes($"{loginText.Text}\n{passwordText.Password}");
                        // Add some information to the file.
                        fs.Write(info, 0, info.Length);
                    }
                    View.Menu m = new View.Menu(log);
                    m.Show();
                    this.Close();

                }
                else
                {
                    MessageBox.Show("Такого пользователя не существует или такого пароля");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void passV_MouseDown(object sender, MouseButtonEventArgs e)
        {
            passwordText2.Text = passwordText.Password.ToString();
            passwordText.Visibility = Visibility.Hidden;
            passwordText2.Visibility = Visibility.Visible;
        }

        private void passV_MouseUp(object sender, MouseButtonEventArgs e)
        {
            passwordText.Visibility = Visibility.Visible;
            passwordText2.Visibility = Visibility.Hidden;
        }

        private void passV_MouseLeave(object sender, MouseEventArgs e)
        {
            passwordText.Visibility = Visibility.Visible;
            passwordText2.Visibility = Visibility.Hidden;
        }

        private void setBD_Click(object sender, RoutedEventArgs e)
        {
            EditConection eC = new EditConection();
            eC.ShowDialog();
            if (eC.DialogResult == true)
            {
                using (FileStream fs = File.Create("connect.txt"))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes($"Data Source={eC.serverT.Text};Initial Catalog={eC.dbT.Text};Integrated Security=True".ToString());
                    // Add some information to the file.
                    fs.Write(info, 0, info.Length);
                }
            }
            db = con.getDB();
        }
    }
}
