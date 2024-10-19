using System;
using System.Windows.Forms;

namespace NikeWinForm.UI
{
    public partial class CustomerMainMenu : Form
    {
        public CustomerMainMenu()
        {
            InitializeComponent();
        }

        private void CustomerMainMenu_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoadingScreen main_Menu = new LoadingScreen();
            main_Menu.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            ViewCustomerStock viewStock = new ViewCustomerStock();
            viewStock.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            ChangeCustomerPass changePass = new ChangeCustomerPass();
            changePass.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddToCart addCart = new AddToCart();
            addCart.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            ViewCart viewCart = new ViewCart();
            viewCart.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            GetBill bill = new GetBill();
            bill.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Feedback review = new Feedback();
            review.Show();
        }
    }
}
