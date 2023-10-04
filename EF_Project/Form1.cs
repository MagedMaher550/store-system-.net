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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void AddStore_Click(object sender, EventArgs e)
        {
            StoreForm form = new StoreForm();
            form.Show();
        }

        private void sqlConnection1_InfoMessage(object sender, System.Data.SqlClient.SqlInfoMessageEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ItemForm form = new ItemForm();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CustomerForm form = new CustomerForm();
            form.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SupplierForm form = new SupplierForm();
            form.Show();
        }
    }
}
