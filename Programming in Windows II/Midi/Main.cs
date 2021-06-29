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
    public partial class Main : Form
    {
        public housing housing = new();
        private owner_house oh;
        private project_add novie;

        public Main()
        {
            InitializeComponent();
            IsMdiContainer = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            oh = new owner_house(housing)
            {
                MdiParent = this
            };
            oh.Show();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            projectTableAdapter1.Update(housing.project);
            ownerTableAdapter1.Update(housing.owner);
            houseTableAdapter1.Update(housing.house);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            novie = new project_add(housing)
            {
                MdiParent = this
            };
            novie.Show();
        }
    }
}