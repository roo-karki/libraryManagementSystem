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
    public partial class BookIssued : Form
    {
        public BookIssued()
        {
            InitializeComponent();
        }
        int id;
        void load()
        {
            SqlConnection con = new SqlConnection("Data Source=kathmandu;Initial Catalog=LibrarySystem;Integrated Security=True");
            try
            {
                con.Open();
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("SELECT dbo.History.Id, dbo.Book_Details.Book_Code, dbo.Book_Details.Title, " +
                    "dbo.Book_Details.Description," +
                    " dbo.History.Issue_Date, dbo.History.Return_Date,  dbo.Users.Username,dbo.History.Status FROM" +
                    " dbo.Book_Details INNER JOIN dbo.History ON dbo.Book_Details.Id = dbo.History.Book_Id" +
                    " INNER JOIN dbo.Users ON dbo.History.Student_Id = dbo.Users.ID", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                dgv_BookIssued.DataSource = dt;

                con.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { con.Close(); }
        }

            private void BookIssued_Load(object sender, EventArgs e)
        {
                load();
        }

        private void btn_Approve_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=kathmandu;Initial Catalog=LibrarySystem;Integrated Security=True");
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("update History set Status=1 where Id=@a", con);
                cmd.Parameters.AddWithValue("@a", id);
                

                int i = cmd.ExecuteNonQuery();


                con.Close();
                if (i > 0)
                {
                    MessageBox.Show("Approved Sucesfully!");
                    load();


                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { con.Close(); }
        }

        private void dgv_BookIssued_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            id = int.Parse(dgv_BookIssued.Rows[e.RowIndex].Cells["Id"].Value.ToString());
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            
        }

        private void btn_Cancel_Click_1(object sender, EventArgs e)
        {
            Admin a = new Admin();
            this.Hide();
        }
    }
    }

