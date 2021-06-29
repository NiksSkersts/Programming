
namespace Midi
{
    partial class owner_house
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
            this.owner_grid = new System.Windows.Forms.DataGridView();
            this.fk_grid = new System.Windows.Forms.DataGridView();
            this.proj_grid = new System.Windows.Forms.DataGridView();
            this.houseTableAdapter1 = new Midi.housingTableAdapters.houseTableAdapter();
            this.ownerTableAdapter1 = new Midi.housingTableAdapters.ownerTableAdapter();
            this.projectTableAdapter1 = new Midi.housingTableAdapters.projectTableAdapter();
            this.proj_name = new System.Windows.Forms.DataGridViewComboBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.owner_grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fk_grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.proj_grid)).BeginInit();
            this.SuspendLayout();
            // 
            // owner_grid
            // 
            this.owner_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.owner_grid.Location = new System.Drawing.Point(12, 12);
            this.owner_grid.Name = "owner_grid";
            this.owner_grid.Size = new System.Drawing.Size(243, 416);
            this.owner_grid.TabIndex = 0;
            // 
            // fk_grid
            // 
            this.fk_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.fk_grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.proj_name});
            this.fk_grid.Location = new System.Drawing.Point(261, 12);
            this.fk_grid.Name = "fk_grid";
            this.fk_grid.Size = new System.Drawing.Size(345, 416);
            this.fk_grid.TabIndex = 1;
            // 
            // proj_grid
            // 
            this.proj_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.proj_grid.Location = new System.Drawing.Point(12, 434);
            this.proj_grid.Name = "proj_grid";
            this.proj_grid.Size = new System.Drawing.Size(594, 451);
            this.proj_grid.TabIndex = 2;
            // 
            // houseTableAdapter1
            // 
            this.houseTableAdapter1.ClearBeforeFill = true;
            // 
            // ownerTableAdapter1
            // 
            this.ownerTableAdapter1.ClearBeforeFill = true;
            // 
            // projectTableAdapter1
            // 
            this.projectTableAdapter1.ClearBeforeFill = true;
            // 
            // proj_name
            // 
            this.proj_name.HeaderText = "Project";
            this.proj_name.Name = "proj_name";
            // 
            // owner_house
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 897);
            this.Controls.Add(this.proj_grid);
            this.Controls.Add(this.fk_grid);
            this.Controls.Add(this.owner_grid);
            this.Name = "owner_house";
            this.Text = "owner_house";
            ((System.ComponentModel.ISupportInitialize)(this.owner_grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fk_grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.proj_grid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView owner_grid;
        private System.Windows.Forms.DataGridView fk_grid;
        private System.Windows.Forms.DataGridView proj_grid;
        public housingTableAdapters.houseTableAdapter houseTableAdapter1;
        public housingTableAdapters.ownerTableAdapter ownerTableAdapter1;
        public housingTableAdapters.projectTableAdapter projectTableAdapter1;
        private System.Windows.Forms.DataGridViewComboBoxColumn proj_name;
    }
}