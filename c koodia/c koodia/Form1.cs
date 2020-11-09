using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace c_koodia
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Nappi_Click(object sender, EventArgs e)
        {
            string label1 = tekstilaatikko.Text;
            label2.Visible = true;
            label2.Text = "Hei " + label1 + " oikein hyvää viikkoa sinulle";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
