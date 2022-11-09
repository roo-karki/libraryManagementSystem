namespace libraryManagementSystem
{
    partial class History
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(History));
            this.gv_load = new System.Windows.Forms.DataGridView();
            this.btn_exit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gv_load)).BeginInit();
            this.SuspendLayout();
            // 
            // gv_load
            // 
            this.gv_load.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gv_load.Location = new System.Drawing.Point(114, 96);
            this.gv_load.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gv_load.Name = "gv_load";
            this.gv_load.RowTemplate.Height = 24;
            this.gv_load.Size = new System.Drawing.Size(964, 188);
            this.gv_load.TabIndex = 0;
            this.gv_load.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dv_load_CellContentClick);
            // 
            // btn_exit
            // 
            this.btn_exit.Location = new System.Drawing.Point(994, 13);
            this.btn_exit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(84, 29);
            this.btn_exit.TabIndex = 2;
            this.btn_exit.Text = "Exit";
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // History
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1143, 390);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.gv_load);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "History";
            this.Text = "History";
            this.Load += new System.EventHandler(this.History_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.gv_load)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gv_load;
        private System.Windows.Forms.Button btn_exit;
    }
}