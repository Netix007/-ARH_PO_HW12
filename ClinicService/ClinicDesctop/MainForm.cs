using ClinicServiceClientNamespace;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ClinicDesctop
{
    /// <summary>
    /// НЕОБХОДИМО ПОДКЛЮЧИТЬ СБОРКУ: System.Runtime.Serialization
    /// 
    /// 
    /// 
    /// ДОМАШНЕЕ ЗАДАНИЕ:
    /// 
    /// Разработать приложение ClinicDesctop, подключить ClinicService к вашему клиентскому приложению.
    /// </summary>
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            TestMethod1();
        }

        public void TestMethod1()
        {

        }

        private void buttonLOadClients_Click(object sender, EventArgs e)
        {
            ClinicServiceClient clinicServiceClient = new ClinicServiceClient("http://localhost:5154/",
                new System.Net.Http.HttpClient());

            ICollection<Client> clients = clinicServiceClient.ClientGetAllAsync().Result;

            listViewClients.Items.Clear();
            foreach (Client client in clients)
            {
                ListViewItem item = new ListViewItem();
                item.Text = client.ClientId.ToString();

                ListViewItem.ListViewSubItem subItemSurname = new ListViewItem.ListViewSubItem();
                subItemSurname.Text = client.SurName;
                item.SubItems.Add(subItemSurname);

                ListViewItem.ListViewSubItem subItemFirstName = new ListViewItem.ListViewSubItem();
                subItemFirstName.Text = client.FirstName;
                item.SubItems.Add(subItemFirstName);

                ListViewItem.ListViewSubItem subItemPatronymic = new ListViewItem.ListViewSubItem();
                subItemPatronymic.Text = client.Patronymic;
                item.SubItems.Add(subItemPatronymic);

                listViewClients.Items.Add(item);

            }

        }
    }
}
