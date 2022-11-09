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

namespace libraryManagementSystem
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }



        private void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=kathmandu;Initial Catalog=LibrarySystem;Integrated Security=True");
            try
            {


                if (txtUsername.Text == "" && txtPassword.Text == "" && cboUsertype.Text == "")
                {
                    MessageBox.Show("please fill all the boxes ");
                }
                else
                {
                    con.Open();
                    DataTable dt = new DataTable();
                    SqlCommand cmd = new SqlCommand("select * from Users where Username=@Username and Password=@Password and Status=1 ", con);
                    cmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                    cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);

                    con.Close();

                     if (dt.Rows.Count == 1 && cboUsertype.Text == "Student")
                    {
                        Dashboard d = new Dashboard();
                        History h = new History();

                        //h.i = int.Parse(dt.Rows[0]["ID"].ToString());
                        d.i = int.Parse(dt.Rows[0]["ID"].ToString());



                        d.Show();


                        this.Hide();

                    }
                    else if (dt.Rows.Count == 1 && cboUsertype.Text == "Admin")
                    {
                        Admin a = new Admin();
                        a.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Username or password doesn't match");
                    }
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { con.Close(); }




        }
    }
}
