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
    public partial class Form1 : Form
    {
        //Abbreviation format : XX_Y -> where XX - DataAdapter/Binding Source and so on, and Y - Dataset table first letter.
        public Form1()
        {
            InitializeComponent();
            IsMdiContainer = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
        }
    }

    public partial class O_h : Form
    {
        public o_h()
        {
            InitializeComponent();
        }

        private void o_h_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'housing.house' table. You can move, or remove it, as needed.
            this.houseTableAdapter.Fill(this.housing.house);
            // TODO: This line of code loads data into the 'housing.owner' table. You can move, or remove it, as needed.
            this.ownerTableAdapter.Fill(this.housing.owner);
        }
    }
}