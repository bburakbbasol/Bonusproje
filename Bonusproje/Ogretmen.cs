using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bonusproje
{
    public partial class Ogretmen : Form
    {
        public Ogretmen()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Kulup fr=new Kulup();
            fr.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Frm2Dersler frm = new Frm2Dersler();
            frm.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmOgrenci frm = new FrmOgrenci();  
            frm.Show();
            this.Hide();    
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmSınav frm = new FrmSınav();
            frm.Show();
            this.Hide();
        }
    }
}
