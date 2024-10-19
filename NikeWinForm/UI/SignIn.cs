using NikeDLL.DL.DB;
using NikeDLL.Utils;
using System;
using System.Windows.Forms;

namespace NikeWinForm.UI
{
    public partial class SignIn : Form
    {
        private UserDB userDB;

        public SignIn()
        {
            InitializeComponent();
            string connectionString = ConnectionManager.GetConnectionString();
            userDB = new UserDB(connectionString);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoadingScreen main_Menu = new LoadingScreen();
            main_Menu.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;
            try
            {
                string role = userDB.SignIn(username, password);

                if (role != null)
                {

                    if ((role == "Admin") || (role == "admin"))
                    {
                        this.Hide();
                        AdminMainMenu adminMainMenu = new AdminMainMenu();
                        adminMainMenu.Show();
                    }
                    else if ((role == "Customer") || (role == "customer"))
                    {
                        this.Hide();
                        CustomerMainMenu customerMainMenu = new CustomerMainMenu();
                        customerMainMenu.Show();
                    }

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Invalid username or password. Please try again.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sign-in failed: " + ex.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
