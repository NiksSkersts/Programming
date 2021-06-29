
namespace MDI
{
    partial class Proj_mdi
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
            this.components = new System.ComponentModel.Container();
            this.proj_dgv = new System.Windows.Forms.DataGridView();
            this.BS_Proj = new System.Windows.Forms.BindingSource(this.components);
            this.housing = new MDI.housing();
            this.DA_Proj = new MDI.housingTableAdapters.projectTableAdapter();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.proj_dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BS_Proj)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.housing)).BeginInit();
            this.SuspendLayout();
            // 
            // proj_dgv
            // 
            this.proj_dgv.AutoGenerateColumns = false;
            this.proj_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.proj_dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn});
            this.proj_dgv.DataSource = this.BS_Proj;
            this.proj_dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.proj_dgv.Location = new System.Drawing.Point(0, 0);
            this.proj_dgv.Name = "proj_dgv";
            this.proj_dgv.Size = new System.Drawing.Size(244, 315);
            this.proj_dgv.TabIndex = 0;
            // 
            // BS_Proj
            // 
            this.BS_Proj.DataMember = "project";
            this.BS_Proj.DataSource = this.housing;
            // 
            // housing
            // 
            this.housing.DataSetName = "housing";
            this.housing.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // DA_Proj
            // 
            this.DA_Proj.ClearBeforeFill = true;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.nameDataGridViewTextBoxColumn.Width = 200;
            // 
            // Proj_mdi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(244, 315);
            this.Controls.Add(this.proj_dgv);
            this.Name = "Proj_mdi";
            this.Text = "Proj_mdi";
            this.Load += new System.EventHandler(this.Proj_mdi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.proj_dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BS_Proj)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.housing)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView proj_dgv;
        private housing housing;
        private housingTableAdapters.projectTableAdapter DA_Proj;
        public System.Windows.Forms.BindingSource BS_Proj;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
    }
}