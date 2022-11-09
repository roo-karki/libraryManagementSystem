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
    public partial class History : Form
    {
       

        public History()
        {
            InitializeComponent();
        }

        private void dv_load_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        public int id;
        public void Load1()
        {
            
            SqlConnection con = new SqlConnection("Data Source=kathmandu;Initial Catalog=LibrarySystem;Integrated Security=True");
            try
            {
                
                con.Open();
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("select h.Id, " +
                "b.Title, b.Author , h.Issue_Date, h.Return_Date,  case when h.Status = 0 " +
                "then 'Pending....'when h.Status = 1 then 'Approved'end as Status  from Book_Details as b , " +
                "History as h where b.Id = h.Book_Id and  h.Student_Id = 2", con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                gv_load.DataSource = dt;

                con.Close();
            }
            catch (Exception ex)
            {
             throw ex;
            }
            finally { con.Close(); }
        }


        private void btn_exit_Click(object sender, EventArgs e)
        {
            Dashboard d = new Dashboard();
            d.Show();
            this.Hide();
        }

        private void History_Load(object sender, EventArgs e)
        {
            Load1();
            
        }
        
        private void History_Load_1(object sender, EventArgs e)
        {
            
            Load1();
            
        }

        private void btn_display_Click(object sender, EventArgs e)
        {
            
        }
    }
}
