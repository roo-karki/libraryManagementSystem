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
    public partial class AddUser : Form
    {
        public AddUser()
        {
            InitializeComponent();
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            Admin a = new Admin();
           
            this.Hide();
        }
        int admin = 0;
        int id = 0;
        private void btn_CreateUser_Click(object sender, EventArgs e)
        {
            if (cmb_Usertype.Text == "User")
            {
                admin = 2;
            }
            else
            {
                admin = 1;
            }
            SqlConnection con = new SqlConnection("Data Source=kathmandu;Initial Catalog=LibrarySystem;Integrated Security=True");
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into Users (Username,Password,Usertype) values (@a,@b,@c)", con);
                cmd.Parameters.AddWithValue("@a", txt_UserName.Text);
                cmd.Parameters.AddWithValue("@b", txt_Password.Text);
                cmd.Parameters.AddWithValue("@c", admin);
                
                int i = cmd.ExecuteNonQuery();


                con.Close();
                if (i > 0)
                {
                    MessageBox.Show("Saved Sucesfully!");
                    load();
                 }
            }
            catch (Exception ex)
            {
              throw ex;
            }
            finally { con.Close(); }
        }
        public void load()
        {
            SqlConnection con = new SqlConnection("Data Source=kathmandu;Initial Catalog=LibrarySystem;Integrated Security=True");
            try
            {
                con.Open();
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("select ID, Username, " +
                    "case " +
                    "when Usertype=1 then 'Admin'" +
                    "when Usertype=2 then 'Student'" +
                    "else 'not defined'" +
                    "end as Usertype from Users ", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                dgv_User.DataSource = dt;

                con.Close();
            }
            catch (Exception ex)
            {
             throw ex;
            }
            finally { con.Close(); }
        }
        private void AddUser_Load(object sender, EventArgs e)
        {
            load();
        }

        private void dgv_User_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgv_User_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
           id= int.Parse(dgv_User.Rows[e.RowIndex].Cells["ID"].Value.ToString());
            

        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=kathmandu;Initial Catalog=LibrarySystem;Integrated Security=True");
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("update Users set Status=0 where ID=@i", con);
                cmd.Parameters.AddWithValue("@i", id);
                int i = cmd.ExecuteNonQuery();
                con.Close();
                if (i > 0)
                {
                    MessageBox.Show("Deleted Sucesfully!");
                    load();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { con.Close(); }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
    }

