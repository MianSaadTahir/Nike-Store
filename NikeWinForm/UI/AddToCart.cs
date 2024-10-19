using NikeDLL.BL;
using NikeDLL.DL.DB;
using NikeDLL.Utils;
using System;
using System.Windows.Forms;

namespace NikeWinForm.UI
{
    public partial class AddToCart : Form
    {
        private ProductDB productDB;
        private readonly ProductBL productBL;
        public AddToCart()
        {
            InitializeComponent();
            string connectionString = ConnectionManager.GetConnectionString();
            productDB = new ProductDB(connectionString);
            productBL = new ProductBL(productDB);

            BindDataGrid();
        }
        private void BindDataGrid()
        {
            dataGridView1.DataSource = productDB.ShowAllSuits();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            CustomerMainMenu customerMainMenu = new CustomerMainMenu();
            customerMainMenu.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int suitID, quantity;

            if (!int.TryParse(textBox1.Text, out suitID))
            {
                MessageBox.Show("Invalid Suit ID. Please enter a valid integer value.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(textBox2.Text, out quantity))
            {
                MessageBox.Show("Invalid Quantity. Please enter a valid integer value.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            bool added = productBL.AddToSuitCart(suitID, quantity);

            if (added)
            {
                MessageBox.Show("suit added to cart successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInputFields();
            }
            else
            {
                MessageBox.Show("Failed to add suit to cart. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void ClearInputFields()
        {
            textBox1.Text = "";
            textBox2.Text = "";

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
