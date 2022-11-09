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
    public partial class Dashboard : Form
    {
        private int childFormNumber = 0;

        public Dashboard()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }



        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        public int i;
        int id;
        private void Dashboard_Load(object sender, EventArgs e)
        {
            label2.Text = i.ToString();
            SqlConnection con = new SqlConnection("Data Source=kathmandu;Initial Catalog=LibrarySystem;Integrated Security=True");
            try
            {
                con.Open();
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("select * from Book_Details ", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                gvLoad.DataSource = dt;

                con.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { con.Close(); }
            Login l = new Login(); }


        private void historyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            History h = new History();
            h.Show();
        }

        private void historyToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            History h = new History();
            h.Show();
            this.Hide();
        }

        private void txt_search_TextChanged(object sender, EventArgs e)
        {
         SqlConnection con = new SqlConnection("Data Source=kathmandu;Initial Catalog=LibrarySystem;Integrated Security=True");
            try
            {
                con.Open();
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("select Book_Code,Title,Description, Author from Book_Details where Book_Code " +
                "like '" + txt_search.Text + "%' or Title like '" + txt_search.Text + "%' or Description " +
                "like '" + txt_search.Text + "%' or Author like '" + txt_search.Text + "%'", con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                gvLoad.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
               throw ex;
            }finally { con.Close(); }
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            l.Show();
            this.Hide();
        }

        private void profileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Profile p = new Profile();
            p.Show();
            this.Hide();
        }

        private void btn_Borrow_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=kathmandu;Initial Catalog=LibrarySystem;Integrated Security=True");
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into History (Student_Id,Book_Id,Issue_Date,Return_Date,Status) values (@a,@b,@c,@d,'0')", con);
                cmd.Parameters.AddWithValue("@a", label2.Text);
                cmd.Parameters.AddWithValue("@b", txt_BookId.Text);
                cmd.Parameters.AddWithValue("@c", dtp_Issue.Value.ToShortDateString());
                cmd.Parameters.AddWithValue("@d", dtp_Return.Value.ToShortDateString());

                int i = cmd.ExecuteNonQuery();


                con.Close();
                if (i > 0)
                {
                    MessageBox.Show("Requested Sucesfully!");
                    


                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { con.Close(); }
        }

        private void gvLoad_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txt_BookId.Text = gvLoad.Rows[e.RowIndex].Cells["Id"].Value.ToString();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }

       
    }

    


        

        

      

