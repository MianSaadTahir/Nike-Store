using System;
using System.Windows.Forms;

namespace NikeWinForm.UI
{
    public partial class AdminMainMenu : Form
    {
        public AdminMainMenu()
        {
            InitializeComponent();
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
            AdminAddSuit addSuit = new AdminAddSuit();
            addSuit.Show();
        }



        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            ViewStock viewSuit = new ViewStock();
            viewSuit.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            UpdateStock updateSuit = new UpdateStock();
            updateSuit.Show();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            RemoveStock deleteSuit = new RemoveStock();
            deleteSuit.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            ChangePassword changePassword = new ChangePassword();
            changePassword.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            ViewFeedbacks viewFeedbacks = new ViewFeedbacks();
            viewFeedbacks.Show();
        }
    }
}
