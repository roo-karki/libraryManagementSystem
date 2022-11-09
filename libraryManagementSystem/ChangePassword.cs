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
    public partial class ChangePassword : Form
    {
        public ChangePassword()
        {
            InitializeComponent();
        }

        private void ChangePassword_Load(object sender, EventArgs e)
        {

        }
        int id;
        private void btn_Update_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=kathmandu;Initial Catalog=LibrarySystem;Integrated Security=True");
            try
            {
                    con.Open();
                    DataTable dt = new DataTable();
                    SqlCommand cmd = new SqlCommand("select ID from Users where Username=@Username", con);
                    cmd.Parameters.AddWithValue("@Username", txt_Username.Text);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    con.Close();
                    if (dt.Rows.Count > 0)
                {
                    id = int.Parse(dt.Rows[0]["ID"].ToString());

                    SqlConnection con1 = new SqlConnection("Data Source=kathmandu;Initial Catalog=LibrarySystem;Integrated Security=True");
                    con1.Open();
                    DataTable dt1 = new DataTable();
                    SqlCommand cmd1= new SqlCommand("update Users set Password=@a where ID=@b ", con1);
                    cmd1.Parameters.AddWithValue("@a", txt_Password.Text);
                    cmd1.Parameters.AddWithValue("@b", id);


                    SqlDataAdapter da1 = new SqlDataAdapter(cmd);
                    da1.Fill(dt1);

                    int i1 = cmd1.ExecuteNonQuery();
                        con1.Close();
                        if (i1 > 0)
                        {
                            MessageBox.Show("Updated Sucessfully!");
                        }

                }
                else
                {
                    MessageBox.Show("can't find such Username!");
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
