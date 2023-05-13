using Equipment_Accounting.Resource.Model;
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
    /// Логика взаимодействия для ContractsToClient.xaml
    /// </summary>
    public partial class ContractsToClient : Window
    {
        Client client;
        Resource.Model.DatabaseEntities db;
        public ContractsToClient(Client client_, Resource.Model.DatabaseEntities db_)
        {
            InitializeComponent();
            db = db_;
            client = client_;
            contractLv.ItemsSource = db.ClientContracts.Where(x => x.ClientID == client.ID).ToList();
        }

        private void addC_Click(object sender, RoutedEventArgs e)
        {
            AddContractToClient add = new AddContractToClient();
            if(add.ShowDialog() == true)
            {
                ClientContracts contractsToClient = new ClientContracts()
                {
                    ClientID = client.ID,
                    Client = db.Client.Where(x => x.ID == client.ID).FirstOrDefault(),
                    Contract = add.text.Text
                };
                db.ClientContracts.Add(contractsToClient);
                db.SaveChanges();
                contractLv.ItemsSource = db.ClientContracts.Where(x => x.ClientID == client.ID).ToList();
            }
        }

        private void editC_Click(object sender, RoutedEventArgs e)
        {
            if (contractLv.SelectedItem != null)
            {
                ClientContracts clientContracts = (ClientContracts)contractLv.SelectedItem;
                AddContractToClient add = new AddContractToClient(clientContracts.Contract);
                if (add.ShowDialog() == true)
                {
                    clientContracts.Contract = add.text.Text;
                    db.SaveChanges();
                    contractLv.ItemsSource = db.ClientContracts.Where(x => x.ClientID == client.ID).ToList();
                }
            }
        }

        private void DelC_Click(object sender, RoutedEventArgs e)
        {
            if (contractLv.SelectedItem != null)
            {
                ClientContracts clientContracts = (ClientContracts)contractLv.SelectedItem;
                if (db.Task.Where(x => x.Contract == clientContracts.ID).Count() == 0)
                {
                    db.ClientContracts.Remove(clientContracts);
                    db.SaveChanges();
                    contractLv.ItemsSource = db.ClientContracts.Where(x => x.ClientID == client.ID).ToList();
                }
                else MessageBox.Show("Этот договор используется в заявке");
            }
        
        }
    }
}
