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
    public partial class Frm2Dersler : Form
    {
        public Frm2Dersler()
        {
            InitializeComponent();
        }
        DataSet1TableAdapters.tblderslerTableAdapter ds = new DataSet1TableAdapters.tblderslerTableAdapter();
        private void Frm2Dersler_Load(object sender, EventArgs e)
        {
           
            dataGridView1.DataSource = ds.DersListesi();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Ogretmen frm=new Ogretmen();
            frm.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            ds.DersEkle(textBox2.Text);
            MessageBox.Show("Ders ekleme işlemi başarıyla yapılmıştır ", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
          
        }

        private void buttonliste_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.DersListesi();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ds.DersGuncelle(textBox2.Text,byte.Parse(textBox1.Text));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ds.DersSil(byte.Parse(textBox1.Text));
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }
    }
}
