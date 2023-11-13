using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BarcodeManagerment
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void setupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in this.MdiChildren)
            {
                childForm.Close();
            }
            Main p = new Main();
            p.MdiParent = this;
            p.WindowState = FormWindowState.Maximized;
            //menuStrip1.Enabled = false;
            p.Show();
           
        }

        private void setupToolStripMenuItem1_Click(object sender, EventArgs e)
        {
           
           
        }

        private void addPartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in this.MdiChildren)
            {
                childForm.Close();
            }
            AddPart p = new AddPart();
            p.MdiParent = this;
            p.WindowState = FormWindowState.Maximized;
           // menuStrip1.Enabled = false;
            p.Show();
        }

        private void createNewFunctionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in this.MdiChildren)
            {
                childForm.Close();
            }
            Createnewfunction p = new Createnewfunction();
            p.MdiParent = this;
            p.WindowState = FormWindowState.Maximized;
           // menuStrip1.Enabled = false;
            p.Show();
        }

        private void mcAddressToolStripMenuItem_Click(object sender, EventArgs e)
        {

            McAddress p = new McAddress();
            p.MdiParent = this;
            p.WindowState = FormWindowState.Maximized;
            // menuStrip1.Enabled = false;
            p.Show();
        }
    }
}
