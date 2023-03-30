using Bonusproje.DataSet1TableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Bonusproje
{
    public partial class FrmSınav : Form
    {
        public FrmSınav()
        {
            InitializeComponent();
        }
        DataSet1TableAdapters.tblnotlarTableAdapter ds = new tblnotlarTableAdapter();
        DataSet1TableAdapters.DataTable3TableAdapter dsthree=new DataTable3TableAdapter();
           
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Ogretmen fr = new Ogretmen();
            fr.Show();
            this.Hide();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-LK988TL\SQLEXPRESS;Initial Catalog=BonusOkul;Integrated Security=True");
        private void FrmSınav_Load(object sender, EventArgs e)
        {
            

            con.Open();
            SqlCommand cmd = new SqlCommand("Select * From tbldersler", con);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1.DisplayMember = "Dersad";
            comboBox1.ValueMember = "Dersid";
            comboBox1.DataSource = dt;
            
            con.Close();
           


        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.Notlistesi(int.Parse(txtidd.Text));
            dataGridView1.DataSource= dsthree.Notadd();
        }
        int notid;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            notid=int.Parse(txtidd.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtidd.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtsnv1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtsnv2.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtproje.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtortalama.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtdurum.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            
        }

        private void buttonliste_Click(object sender, EventArgs e)
        {
            int sınav1, sınav2, proje;
            double ortalama;
            string durum;
            sınav1 = Convert.ToInt16(txtsnv1.Text);
            sınav2= Convert.ToInt16(txtsnv2.Text);
            proje= Convert.ToInt16(txtproje.Text);
            ortalama = Convert.ToDouble((sınav1 + sınav2 + proje) / 3.00);
            txtortalama.Text=ortalama.ToString();
            if (ortalama > 50)
            {
                txtdurum.Text = "True";

            }
            else
            {
                txtdurum.Text = "False";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {  
            ds.UpdateQuery(byte.Parse(comboBox1.SelectedValue.ToString()),int.Parse(txtidd.Text), byte.Parse(txtsnv1.Text), byte.Parse(txtsnv2.Text), byte.Parse(txtproje.Text), decimal.Parse(txtortalama.Text), bool.Parse(txtdurum.Text), notid);
            dataGridView1.DataSource = ds.Notlistesi(int.Parse(txtidd.Text));
        }
    }
}
