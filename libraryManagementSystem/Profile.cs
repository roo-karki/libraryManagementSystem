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
    public partial class Profile : Form
    {
        public Profile()
        {
            InitializeComponent();
        }

        int Id=0;
        private void Profile_Load(object sender, EventArgs e)
        {
            load();
        }
        void load()
        {
            SqlConnection con = new SqlConnection("Data Source=kathmandu;Initial Catalog=LibrarySystem;Integrated Security=True");
            try
            {
                con.Open();
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("select * from Users", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dgv_Profile.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
        throw ex;
            }
            finally { con.Close(); }
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=kathmandu;Initial Catalog=LibrarySystem;Integrated Security=True");
            try
            {
                con.Open();
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("update Users set Username=@a, Fullname=@c, Faculty=@d," +
                    "Address=@e, PhoneNo=@f where Id=@g ", con);
                cmd.Parameters.AddWithValue("@a", txt_UserName.Text);
                //cmd.Parameters.AddWithValue("@b", txt_CurrentP.Text);
                cmd.Parameters.AddWithValue("@c", txt_FullName.Text);
                cmd.Parameters.AddWithValue("@e", txt_Address.Text);
                cmd.Parameters.AddWithValue("@f", txt_PhoneNo.Text);
                cmd.Parameters.AddWithValue("@d", txt_Faculty.Text);
                cmd.Parameters.AddWithValue("@g", Id);
                int i=cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    MessageBox.Show("Updataed sucessfully");
                    load();
                }
                con.Close();
            }
            catch (Exception ex)
            {
               throw ex;
            }
            finally { con.Close(); } }
    

        private void dgv_Profile_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //Id = int.Parse(dgv_Profile.Rows[0].Cells["ID"].Value.ToString());

            //txt_UserName.Text = dgv_Profile.Rows[0].Cells["Username"].Value.ToString();
            //txt_CurrentP.Text = dgv_Profile.Rows[0].Cells["Password"].Value.ToString();
            //txt_Faculty.Text = dgv_Profile.Rows[0].Cells["Faculty"].Value.ToString();
            //txt_PhoneNo.Text = dgv_Profile.Rows[0].Cells["PhoneNo"].Value.ToString();
            //txt_Address.Text = dgv_Profile.Rows[0].Cells["Address"].Value.ToString();

            Id = int.Parse(dgv_Profile.Rows[e.RowIndex].Cells[0].Value.ToString());
            txt_UserName.Text = dgv_Profile.Rows[e.RowIndex].Cells[1].Value.ToString();
            txt_CurrentP.Text = dgv_Profile.Rows[e.RowIndex].Cells[2].Value.ToString();
            txt_Faculty.Text = dgv_Profile.Rows[e.RowIndex].Cells[4].Value.ToString();
            txt_PhoneNo.Text = dgv_Profile.Rows[e.RowIndex].Cells[5].Value.ToString();
            txt_Address.Text = dgv_Profile.Rows[e.RowIndex].Cells[6].Value.ToString();
            txt_FullName.Text = dgv_Profile.Rows[e.RowIndex].Cells[7].Value.ToString();



        }

      private void btn_exit_Click(object sender, EventArgs e)
        {
            Dashboard d = new Dashboard();
            d.Show();
            this.Hide();
        }
        private void dgv_Profile_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
