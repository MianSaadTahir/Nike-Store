using NikeDLL.DL.DB;
using NikeDLL.Utils;
using System;
using System.Windows.Forms;

namespace NikeWinForm.UI
{
    public partial class SignUp : Form
    {
        private UserDB userDB;
        public SignUp()
        {
            InitializeComponent();
            string connectionString = ConnectionManager.GetConnectionString();
            userDB = new UserDB(connectionString);
        }

        private void SignUp_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

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
            string role = textBox3.Text;
            try
            {
                userDB.SignUp(username, password, role);
                MessageBox.Show("User signed up successfully!");
                ClearInputFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sign-up failed: " + ex.Message);

            }
        }
        private void ClearInputFields()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
