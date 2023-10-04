using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EF_Project
{
    public partial class SupplierForm : Form
    {
        Model1 Ent = new Model1();
        private void ShowSuppliers()
        {
            var str = Ent.Suppliers
                .Select(c => new { c.ID, c.Name, c.Phone, c.Fax, c.Email, c.Telephone, c.Website })
                .ToList();
            dataGridView1.DataSource = str;
        }

        private void HandleSupplierssIDs()
        {
            comboBox1.Items.Clear();
            foreach (Supplier itm in Ent.Suppliers)
            {
                comboBox1.Items.Add(itm.ID);
            }
        }
        public SupplierForm()
        {
            InitializeComponent();
        }

        private void SupplierForm_Load(object sender, EventArgs e)
        {
            ShowSuppliers();
            HandleSupplierssIDs();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // add
            if (textBox1.Text != "" && textBox9.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox6.Text != "" && textBox7.Text != "" && textBox8.Text != "")
            {
                int id = int.Parse(textBox1.Text);
                string name = textBox9.Text;
                string phone = textBox2.Text;
                string fax = textBox3.Text;
                string telephone = textBox6.Text;
                string email = textBox7.Text;
                string website = textBox8.Text;
                var existingSupplier= Ent.Suppliers.Find(id);
                if (existingSupplier != null)
                {
                    MessageBox.Show("Supplier already exists!");
                    return;
                }
                var supplier = new Supplier()
                {
                    ID = id,
                    Name = name,
                    Phone = phone,
                    Fax = fax,
                    Telephone = telephone,
                    Email = email,
                    Website = website
                };
                Ent.Suppliers.Add(supplier);
                Ent.SaveChanges();
                ShowSuppliers();
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
            var suplier = Ent.Suppliers.Find(id);
            textBox4.Text = suplier.Name;
            textBox13.Text = suplier.Phone;
            textBox12.Text = suplier.Fax;
            textBox11.Text = suplier.Telephone;
            textBox10.Text = suplier.Email;
            textBox5.Text = suplier.Website;
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

            var newSupplier = Ent.Suppliers.Find(ID);
            if (newSupplier != null)
            {
                newSupplier.Name = name;
                newSupplier.Phone = phone;
                newSupplier.Fax = fax;
                newSupplier.Telephone = telephone;
                newSupplier.Email = email;
                newSupplier.Website = website;
                Ent.SaveChanges();
                ShowSuppliers();
                textBox4.Text = textBox13.Text = textBox12.Text = textBox11.Text = textBox10.Text = textBox5.Text = "";
            }
            else
            {
                MessageBox.Show("Something went wrong");
            }
        }
    }
}
