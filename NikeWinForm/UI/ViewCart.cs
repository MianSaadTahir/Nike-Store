using NikeDLL.BL;
using NikeDLL.DL.DB;
using NikeDLL.Utils;
using System;
using System.Windows.Forms;

namespace NikeWinForm.UI
{
    public partial class ViewCart : Form
    {
        private ProductDB productDB;
        private readonly ProductBL productBL;
        public ViewCart()
        {
            InitializeComponent();
            string connectionString = ConnectionManager.GetConnectionString();
            productDB = new ProductDB(connectionString);
            productBL = new ProductBL(productDB);

            BindDataGrid();
        }
        private void BindDataGrid()
        {
            dataGridView1.DataSource = productDB.GetSuitCart();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            CustomerMainMenu customerMainMenu = new CustomerMainMenu();
            customerMainMenu.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Please fill in the field.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int suitID;

            if (!int.TryParse(textBox1.Text, out suitID))
            {
                MessageBox.Show("Invalid Suit ID. Please enter a valid integer value.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool deleted = productBL.DeleteFromSuitCart(suitID);

            if (deleted)
            {
                MessageBox.Show("suit deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BindDataGrid();
                textBox1.Text = "";
            }
            else
            {

                MessageBox.Show("Failed to delete suit from cart. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ViewCart_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
