namespace libraryManagementSystem
{
    partial class BookIssued
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BookIssued));
            this.dgv_BookIssued = new System.Windows.Forms.DataGridView();
            this.btn_Approve = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_BookIssued)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_BookIssued
            // 
            this.dgv_BookIssued.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_BookIssued.Location = new System.Drawing.Point(51, 84);
            this.dgv_BookIssued.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgv_BookIssued.Name = "dgv_BookIssued";
            this.dgv_BookIssued.RowTemplate.Height = 24;
            this.dgv_BookIssued.Size = new System.Drawing.Size(967, 242);
            this.dgv_BookIssued.TabIndex = 0;
            this.dgv_BookIssued.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_BookIssued_RowHeaderMouseClick);
            // 
            // btn_Approve
            // 
            this.btn_Approve.Location = new System.Drawing.Point(190, 386);
            this.btn_Approve.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_Approve.Name = "btn_Approve";
            this.btn_Approve.Size = new System.Drawing.Size(120, 29);
            this.btn_Approve.TabIndex = 1;
            this.btn_Approve.Text = "Approve";
            this.btn_Approve.UseVisualStyleBackColor = true;
            this.btn_Approve.Click += new System.EventHandler(this.btn_Approve_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(543, 386);
            this.btn_Cancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(141, 29);
            this.btn_Cancel.TabIndex = 2;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click_1);
            // 
            // BookIssued
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1055, 531);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Approve);
            this.Controls.Add(this.dgv_BookIssued);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "BookIssued";
            this.Text = "BookIssued";
            this.Load += new System.EventHandler(this.BookIssued_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_BookIssued)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_BookIssued;
        private System.Windows.Forms.Button btn_Approve;
        private System.Windows.Forms.Button btn_Cancel;
    }
}