
namespace dataset
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.study = new System.Windows.Forms.DataGridView();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_SP_F = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.faculty = new System.Windows.Forms.DataGridView();
            this.fname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fshort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.full = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.GetTS = new System.Windows.Forms.ToolStripButton();
            this.SetTS = new System.Windows.Forms.ToolStripButton();
            this.Col_Full_View = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Col_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_Surname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_sex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_Birthdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_SP = new System.Windows.Forms.DataGridViewComboBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.study)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.faculty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.full)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // study
            // 
            this.study.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.study.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.name,
            this.Col_SP_F});
            this.study.Location = new System.Drawing.Point(12, 283);
            this.study.Name = "study";
            this.study.Size = new System.Drawing.Size(300, 328);
            this.study.TabIndex = 1;
            // 
            // name
            // 
            this.name.DataPropertyName = "name";
            this.name.HeaderText = "Study Program";
            this.name.Name = "name";
            // 
            // Col_SP_F
            // 
            this.Col_SP_F.HeaderText = "Faculty";
            this.Col_SP_F.Name = "Col_SP_F";
            this.Col_SP_F.Width = 155;
            // 
            // faculty
            // 
            this.faculty.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.faculty.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fname,
            this.fshort});
            this.faculty.Location = new System.Drawing.Point(318, 283);
            this.faculty.Name = "faculty";
            this.faculty.Size = new System.Drawing.Size(343, 328);
            this.faculty.TabIndex = 2;
            // 
            // fname
            // 
            this.fname.DataPropertyName = "name";
            this.fname.HeaderText = "Faculty Name";
            this.fname.Name = "fname";
            this.fname.Width = 200;
            // 
            // fshort
            // 
            this.fshort.DataPropertyName = "short";
            this.fshort.HeaderText = "Abbreviation";
            this.fshort.Name = "fshort";
            // 
            // full
            // 
            this.full.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.full.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Col_Full_View,
            this.Col_Name,
            this.Col_Surname,
            this.Col_sex,
            this.Col_Birthdate,
            this.Col_SP});
            this.full.Location = new System.Drawing.Point(12, 28);
            this.full.Name = "full";
            this.full.Size = new System.Drawing.Size(649, 249);
            this.full.TabIndex = 3;
            this.full.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.full_CellContentClick);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GetTS,
            this.SetTS});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(674, 25);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // GetTS
            // 
            this.GetTS.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.GetTS.Image = ((System.Drawing.Image)(resources.GetObject("GetTS.Image")));
            this.GetTS.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.GetTS.Name = "GetTS";
            this.GetTS.Size = new System.Drawing.Size(56, 22);
            this.GetTS.Text = "Get Data";
            this.GetTS.ToolTipText = "Get Data";
            this.GetTS.Click += new System.EventHandler(this.GetTS_Click);
            // 
            // SetTS
            // 
            this.SetTS.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.SetTS.Image = ((System.Drawing.Image)(resources.GetObject("SetTS.Image")));
            this.SetTS.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SetTS.Name = "SetTS";
            this.SetTS.Size = new System.Drawing.Size(62, 22);
            this.SetTS.Text = "Save Data";
            this.SetTS.Click += new System.EventHandler(this.SetTS_Click);
            // 
            // Col_Full_View
            // 
            this.Col_Full_View.HeaderText = "View All";
            this.Col_Full_View.Name = "Col_Full_View";
            this.Col_Full_View.ReadOnly = true;
            this.Col_Full_View.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Col_Full_View.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Col_Full_View.Text = "View All";
            this.Col_Full_View.ToolTipText = "View All";
            // 
            // Col_Name
            // 
            this.Col_Name.DataPropertyName = "name";
            this.Col_Name.HeaderText = "Name";
            this.Col_Name.Name = "Col_Name";
            // 
            // Col_Surname
            // 
            this.Col_Surname.DataPropertyName = "surname";
            this.Col_Surname.HeaderText = "Surname";
            this.Col_Surname.Name = "Col_Surname";
            // 
            // Col_sex
            // 
            this.Col_sex.DataPropertyName = "sex";
            this.Col_sex.HeaderText = "Sex";
            this.Col_sex.Name = "Col_sex";
            // 
            // Col_Birthdate
            // 
            this.Col_Birthdate.DataPropertyName = "birthdate";
            this.Col_Birthdate.HeaderText = "Birthdate";
            this.Col_Birthdate.Name = "Col_Birthdate";
            // 
            // Col_SP
            // 
            this.Col_SP.DataPropertyName = "id_sp";
            this.Col_SP.HeaderText = "Study Program";
            this.Col_SP.Name = "Col_SP";
            this.Col_SP.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 623);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.full);
            this.Controls.Add(this.faculty);
            this.Controls.Add(this.study);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.study)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.faculty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.full)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView study;
        private System.Windows.Forms.DataGridView faculty;
        private System.Windows.Forms.DataGridView full;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton GetTS;
        private System.Windows.Forms.ToolStripButton SetTS;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewComboBoxColumn Col_SP_F;
        private System.Windows.Forms.DataGridViewTextBoxColumn fname;
        private System.Windows.Forms.DataGridViewTextBoxColumn fshort;
        private System.Windows.Forms.DataGridViewButtonColumn Col_Full_View;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_Surname;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_sex;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_Birthdate;
        private System.Windows.Forms.DataGridViewComboBoxColumn Col_SP;
    }
}

