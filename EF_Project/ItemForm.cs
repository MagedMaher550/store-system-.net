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
    public partial class ItemForm : Form
    {
        Model1 Ent = new Model1();
     private void ShowProducts()
        {
            var str = Ent.Products
                .Select(p => new { p.ID, p.Name, p.Code, p.Mtool })
                .ToList();
            dataGridView1.DataSource = str;
}

        private void HandleCustomersIDs()
        {
            comboBox3.Items.Clear();
            foreach (Product prd in Ent.Products)
            {
                comboBox3.Items.Add(prd.ID);
            }
        }
        public ItemForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox6.Text != "")
            {
                int ID = int.Parse(textBox1.Text);
                int code = int.Parse(textBox2.Text);
                string name = textBox3.Text;
                string Mtool= textBox6.Text;
                var productID = Ent.Products.Find(ID);
                if (productID != null)
                {
                    MessageBox.Show("product already exists");
                    return;
                }
                var product= new Product()
                {
                    ID = ID,
                    Code = code,
                    Name = name,
                    Mtool = Mtool
                    
                };
                Ent.Products.Add(product);
                Ent.SaveChanges();
                ShowProducts();
            }
            else
            {
                MessageBox.Show("Something went wrong");
            }
        }

        private void ItemForm_Load(object sender, EventArgs e)
        {
            ShowProducts();
            HandleCustomersIDs();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox5.Text != "" && textBox4.Text != "" && textBox7.Text != "" && comboBox3.Text != "")
            {
                int ID = int.Parse(comboBox3.Text);
                string name = textBox4.Text;
                int code = int.Parse(textBox5.Text);
                string mtool = textBox7.Text;
                var productID = Ent.Products.Find(ID);
                if (productID != null)
                {
                    productID.ID = ID;
                    productID.Name = name;
                    productID.Code = code;
                    productID.Mtool= mtool;
                    Ent.SaveChanges();
                    ShowProducts();
                    textBox4.Text = textBox5.Text = textBox7.Text
                     = comboBox3.Text = "";
                }
                else
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
            var proudct = Ent.Products.Find(id);
            textBox4.Text = proudct.Name;
            textBox5.Text = proudct.Code.ToString();
            textBox7.Text = proudct.Mtool;
        }
    }
}
