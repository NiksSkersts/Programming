using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Midi
{
    public partial class owner_house : Form
    {
        public owner_house(housing proj)
        {
            InitializeComponent();
            //fill
            ownerTableAdapter1.Fill(proj.owner);
            projectTableAdapter1.Fill(proj.project);
            houseTableAdapter1.Fill(proj.house);
            //Binding
            BindingSource owner = new BindingSource(proj, "owner");
            BindingSource project = new BindingSource(proj, "project");
            proj_grid.DataSource = project;
            owner_grid.DataSource = owner;
            fk_grid.DataSource = new BindingSource(owner, "FK_owner_house");
            //dgv setup
            fk_grid.Columns["adress"].HeaderText = "Address";
            fk_grid.Columns["size"].HeaderText = "Size";
            proj_grid.Columns["id_proj"].Visible = false;
            proj_grid.Columns["name"].ReadOnly = true;
            proj_grid.Columns["name"].Width = 544;
            owner_grid.Columns["id_own"].Visible = false;
            fk_grid.Columns["id_own"].Visible = false;
            fk_grid.Columns["id_h"].Visible = false;
            fk_grid.Columns["id_proj"].Visible = false;
            //combo
            proj_name.DataSource = project;
            proj_name.DataPropertyName = "id_proj";
            proj_name.ValueMember = "id_proj";
            proj_name.DisplayMember = "name";
        }
    }
}