using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PetShopManagemnetSystem
{
    public partial class LoginForm : Form
    {
        DBConnect dBCon = new DBConnect();
        public static string SellerName;
        public LoginForm()
        {
            InitializeComponent();
        }

        private void label4_MouseEnter(object sender, EventArgs e)
        {
            label4.ForeColor = Color.Red;
        }

        private void label4_MouseLeave(object sender, EventArgs e)
        {
            label4.ForeColor = Color.Black;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CLEAR_Click(object sender, EventArgs e)
        {
            Textbox_Username.Clear();
            Textbox_Password.Clear();
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            if (Textbox_Username.Text == "" || Textbox_Password.Text == "")
            {
                MessageBox.Show("Please Enter Username and Password", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (comboBox_Role.SelectedIndex > -1)
                {
                    if (comboBox_Role.SelectedItem.ToString() == "ADMIN")
                    {
                        if (Textbox_Username.Text == "Admin" && Textbox_Password.Text == "123")
                        {
                            ProductForm product = new ProductForm();
                            product.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("If you are Admin, Please Enter the corret Id and Password", "Miss Id", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        string selectQuery = "SELECT * FROM Seller WHERE SellerName='" + Textbox_Username.Text + "' AND SellerPass='" + Textbox_Password.Text + "'";

                        SqlDataAdapter adapter = new SqlDataAdapter(selectQuery, dBCon.GetCon());
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        if (table.Rows.Count > 0)
                        {
                            SellerName = Textbox_Username.Text;
                            SellingForm selling = new SellingForm();
                            selling.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Wrong Username or Password", "Wrong Information", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }

                    }
                }
                else
                {
                    MessageBox.Show("Please Select Role", "Wrong Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void Textbox_Username_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox_Role_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
