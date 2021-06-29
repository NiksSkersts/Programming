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
    public partial class project_add : Form
    {
        private BindingSource bs;

        public project_add(housing proj)
        {
            InitializeComponent();
            bs = new BindingSource(proj, "project");
            bs.AddNew();
            input_box.DataBindings.Add("text", bs, "name");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bs.AddNew();
        }
    }
}