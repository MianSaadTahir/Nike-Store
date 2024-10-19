using NikeDLL.BL;
using NikeDLL.DL.DB;
using NikeDLL.Utils;
using System;
using System.Windows.Forms;

namespace NikeWinForm.UI
{
    public partial class ViewStock : Form

    {
        private ProductDB productDB;
        private readonly ProductBL productBL;
        public ViewStock()
        {
            InitializeComponent();
            string connectionString = ConnectionManager.GetConnectionString();
            productDB = new ProductDB(connectionString);
            productBL = new ProductBL(productDB);

            BindDataGrid();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminMainMenu main_Menu = new AdminMainMenu();
            main_Menu.Show();
        }
        private void BindDataGrid()
        {
            dataGridView1.DataSource = productDB.ShowAllSuits();
        }

    }
}
