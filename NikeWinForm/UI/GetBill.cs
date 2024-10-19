using NikeDLL.BL;
using NikeDLL.DL.DB;
using NikeDLL.Utils;
using System;
using System.Windows.Forms;

namespace NikeWinForm.UI
{
    public partial class GetBill : Form
    {

        private ProductDB productDB;
        private readonly ProductBL productBL;
        public GetBill()
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
            decimal totalAmount = productDB.CalculateTotalPayableAmount();

            MessageBox.Show($"Total payable amount: {totalAmount:C}", "Total Amount", MessageBoxButtons.OK, MessageBoxIcon.Information);

            bool emptied = productDB.EmptyCartTables();
            if (emptied)
            {
                MessageBox.Show("THANKS FOR SHOPPING! Dont forget to give feedback", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            BindDataGrid();
        }
    }
}
