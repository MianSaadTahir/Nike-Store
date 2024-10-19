using NikeDLL.BL;
using NikeDLL.DL.DB;
using NikeDLL.Utils;
using System;
using System.Windows.Forms;


namespace NikeWinForm.UI
{
    public partial class AdminAddSuit : Form
    {
        private ProductDB productDB;
        private ProductBL productBL;
        public AdminAddSuit()
        {
            InitializeComponent();
            string connectionString = ConnectionManager.GetConnectionString();
            productDB = new ProductDB(connectionString);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string name = textBox1.Text;
                string size = textBox2.Text;
                string color = textBox3.Text;
                int quantity = int.Parse(textBox4.Text);
                decimal price = decimal.Parse(textBox5.Text);
                productDB.AddSuit(name, size, color, quantity, price);
                MessageBox.Show("Suit added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearInputFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding suit: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminMainMenu main_Menu = new AdminMainMenu();
            main_Menu.Show();
        }
        private void ClearInputFields()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
