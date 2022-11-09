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
    public partial class Admin : Form
    {
        private int childFormNumber = 0;

        public Admin()
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

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //statusStrip.Visible = statusBarToolStripMenuItem.Checked;
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
        public void load()
        {
            SqlConnection con = new SqlConnection("Data Source=kathmandu;Initial Catalog=LibrarySystem;Integrated Security=True");
            try
            {
                con.Open();
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("select * from Book_Details ", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dgv_BookDetails.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
             throw ex;
            }
            finally { con.Close(); }
        }


        private void Admin_Load(object sender, EventArgs e)
        {
            load();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=kathmandu;Initial Catalog=LibrarySystem;Integrated Security=True");
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into Book_Details (Book_Code,Title,Description,Author,Published_Date) " +
                    "values (@a,@b,@c,@d,@e)", con);
                cmd.Parameters.AddWithValue("@a", txt_BookCode.Text);
                cmd.Parameters.AddWithValue("@b", txt_BookTitle.Text);
                cmd.Parameters.AddWithValue("@c", txt_Description.Text);
                cmd.Parameters.AddWithValue("@d", txt_Author.Text);
                cmd.Parameters.AddWithValue("@e", dtp_Entry.Value.ToShortDateString());
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

        private void newUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddUser au = new AddUser();
            au.Show();
           

   
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void txt_Search_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=kathmandu;Initial Catalog=LibrarySystem;Integrated Security=True");
            try
            {
                con.Open();
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("select Book_Code,Title,Description, Author from Book_Details" +
                    " where Book_Code like '" + txt_Search.Text + "%' or Title like '" + txt_Search.Text + "%' " +
                    "or Description like '" + txt_Search.Text + "%' or Author like '" + txt_Search.Text + "%'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                dgv_BookDetails.DataSource = dt;

                con.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { con.Close(); }
        }

        private void bookIssusedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BookIssued b = new BookIssued();
                b.Show();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePassword cp = new ChangePassword();
            cp.Show();
            
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void BookDetails_Enter(object sender, EventArgs e)
        {

        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            l.Show();
            this.Hide();
        }
    }
}
