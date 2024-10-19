using NikeDLL.BL;
using NikeDLL.DL.DB;
using NikeDLL.Utils;
using System;
using System.Windows.Forms;

namespace NikeWinForm.UI
{
    public partial class RemoveStock : Form
    {
        private ProductDB productDB;
        private readonly ProductBL productBL;
        public RemoveStock()
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
            AdminMainMenu adminMainMenu = new AdminMainMenu();
            adminMainMenu.Show();
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

            try
            {
                productDB.DeleteSuit(suitID);

                MessageBox.Show("suit deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Text = "";
                BindDataGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Suit ID not found: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Text = "";
            }

        }
    }
}
