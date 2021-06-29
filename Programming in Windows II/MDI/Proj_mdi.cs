using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MDI
{
    public partial class Proj_mdi : Form
    {
        public Proj_mdi()
        {
            InitializeComponent();
        }

        private void Proj_mdi_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'housing.project' table. You can move, or remove it, as needed.
            DA_Proj.Fill(housing.project);
        }
    }
}