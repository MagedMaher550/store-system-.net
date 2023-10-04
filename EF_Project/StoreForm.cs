using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EF_Project
{
    public partial class StoreForm : Form
    {
        private void ShowStores()
        {
            var str = Ent.Stores
                .Select(c => new { c.ID, c.Name, c.Address, c.ManagerId })
                .ToList();
            dataGridView1.DataSource = str;
        }

        private void HandleCustomersIDs()
        {
            comboBox1.Items.Clear();
            foreach (Customer itm in Ent.Customers)
            {
                comboBox1.Items.Add(itm.ID);
            }
        }
        private void HandleStoresIDs()
        {
            comboBox1.Items.Clear();
            foreach (Store store in Ent.Stores)
            {
                comboBox3.Items.Add(store.ID);
            }
        }

        Model1 Ent = new Model1();
        public StoreForm()
        {
            InitializeComponent();
        }

        /* Store */
        private void AddStoreForm_Load(object sender, EventArgs e){
            ShowStores();
            HandleCustomersIDs();
            HandleStoresIDs();
        }

        private void tabPage2_Click(object sender, EventArgs e){}

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && comboBox1.Text != "")
            {
                int ID = int.Parse(textBox1.Text);
                string name = textBox2.Text;
                string address = textBox3.Text;
                int managerId = int.Parse(comboBox1.Text);
                var storeID = Ent.Stores.Find(ID);
                if(storeID != null)
                {
                    MessageBox.Show("Store already exists");
                    return;
                }
                var store = new Store()
                {
                    ID = ID,
                    Name = name,
                    Address = address,
                    ManagerId = managerId
                };
                Ent.Stores.Add(store);
                Ent.SaveChanges();
                ShowStores();
                
            }
            else
            {
                MessageBox.Show("Something went wrong");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && comboBox2.Text != "")
            {
                int ID = int.Parse(comboBox3.Text);
                string name = textBox5.Text;
                string address = textBox4.Text;
                int managerId = int.Parse(comboBox2.Text);
                Store newStore = Ent.Stores.Find(ID);
                if (newStore != null)
                {
                    newStore.ID = ID;
                    newStore.Name = name;
                    newStore.Address = address;
                    newStore.ManagerId = managerId;
                    Ent.SaveChanges();
                    ShowStores();
                    textBox4.Text = textBox5.Text =  comboBox2.Text
                     = comboBox3.Text  = "";
                } else
                {
                    MessageBox.Show("Something went wrong");
                }
            }
            else
            {
                MessageBox.Show("Something went wrong");
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = int.Parse(comboBox3.Text);
            var store = Ent.Stores.Find(id);
            textBox5.Text = store.Name;
            textBox4.Text = store.Address;
            comboBox2.Text = store.ManagerId.ToString();
        }
    }
}
