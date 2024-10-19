using NikeDLL.BL;
using NikeDLL.DL.DB;
using NikeDLL.Utils;
using System;
using System.Windows.Forms;

namespace NikeWinForm.UI
{
    public partial class Feedback : Form
    {

        private ProductDB productDB;
        private readonly ProductBL productBL;
        public Feedback()
        {
            InitializeComponent();
            string connectionString = ConnectionManager.GetConnectionString();
            productDB = new ProductDB(connectionString);
            productBL = new ProductBL(productDB);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            CustomerMainMenu customerMainMenu = new CustomerMainMenu();
            customerMainMenu.Show();
        }
        private void ClearInputFields()
        {
            textBox1.Text = "";
            textBox5.Text = "";
            numericUpDown1.Value = 1;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox5.Text))
            {
                MessageBox.Show("Please fill in required fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string customerName = textBox1.Text;
            string feedbackText = textBox5.Text;
            int rating = (int)numericUpDown1.Value;

            bool feedbackAdded = productBL.AddFeedback(customerName, feedbackText, rating);

            if (feedbackAdded)
            {
                MessageBox.Show("Thank you for your feedback!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInputFields();
            }
            else
            {
                MessageBox.Show("Failed to submit feedback. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
