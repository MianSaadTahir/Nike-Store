using NikeDLL.BL;
using NikeDLL.DL.DB;
using NikeDLL.Utils;
using System;
using System.Windows.Forms;

namespace NikeWinForm.UI
{
    public partial class ViewFeedbacks : Form
    {
        private ProductDB productDB;
        private readonly ProductBL productBL;
        public ViewFeedbacks()
        {
            InitializeComponent();
            string connectionString = ConnectionManager.GetConnectionString();
            productDB = new ProductDB(connectionString);
            productBL = new ProductBL(productDB);
            BindDataGrid();
        }
        private void BindDataGrid()
        {
            dataGridView1.DataSource = productDB.GetFeedback();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminMainMenu adminMainMenu = new AdminMainMenu();
            adminMainMenu.Show();
        }
    }
}
