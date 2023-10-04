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
    public partial class CustomerForm : Form
    {
        Model1 Ent = new Model1();

        private void ShowCustomers()
        {
            var str = Ent.Customers
                .Select(c => new { c.ID, c.Name, c.Phone, c.Fax, c.Email, c.Telephone, c.Website })
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

        public CustomerForm()
        {
            InitializeComponent();
        }

        private void CustomerForm_Load(object sender, EventArgs e)
        {
            ShowCustomers();
            HandleCustomersIDs();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox9.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox6.Text != "" && textBox7.Text != "" && textBox8.Text != "")
            {
                int id = int.Parse(textBox1.Text);
                string name = textBox9.Text;
                string phone = textBox2.Text;
                string fax = textBox3.Text;
                string telephone = textBox6.Text;
                string email = textBox7.Text;
                string website = textBox8.Text;
                var existingCustomer = Ent.Customers.Find(id);
                if (existingCustomer != null)
                {
                    MessageBox.Show("Customer already exists!");
                    return;
                }
                var customer = new Customer()
                {
                    ID = id,
                    Name = name,
                    Phone = phone,
                    Fax = fax,
                    Telephone = telephone,
                    Email = email,
                    Website = website
                };
                Ent.Customers.Add(customer);
                Ent.SaveChanges();
                ShowCustomers();
                MessageBox.Show("DONE");
            }
            else
            {
                MessageBox.Show("Something went wrong!");
                return;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = int.Parse(comboBox1.Text);
            var customer = Ent.Customers.Find(id);
            textBox4.Text = customer.Name;
            textBox13.Text = customer.Phone;
            textBox12.Text = customer.Fax;
            textBox11.Text = customer.Telephone;
            textBox10.Text = customer.Email;
            textBox5.Text = customer.Website;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(comboBox1.Text);

            string name = textBox4.Text;
            string phone = textBox13.Text;
            string fax = textBox12.Text;
            string telephone = textBox11.Text;
            string email = textBox10.Text;
            string website = textBox5.Text;

            var newCustomer = Ent.Customers.Find(ID);
            if (newCustomer != null)
            {
                newCustomer.Name = name;
                newCustomer.Phone = phone;
                newCustomer.Fax = fax;
                newCustomer.Telephone = telephone;
                newCustomer.Email = email;
                newCustomer.Website = website;
                Ent.SaveChanges();
                ShowCustomers();
                textBox4.Text = textBox13.Text = textBox12.Text = textBox11.Text = textBox10.Text = textBox5.Text = "";
            }
            else
            {
                MessageBox.Show("Something went wrong");
            }
        }
    }
}

