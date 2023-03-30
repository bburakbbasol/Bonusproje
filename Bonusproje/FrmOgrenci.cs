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
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Bonusproje
{
    public partial class FrmOgrenci : Form
    {
        public FrmOgrenci()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Ogretmen frm = new Ogretmen();
            frm.Show(); 
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        



         DataSet1TableAdapters.DataTable1TableAdapter ds = new DataSet1TableAdapters.DataTable1TableAdapter();
        
        private void FrmOgrenci_Load(object sender, EventArgs e)

        {
            dataGridView1.DataSource= ds.Ogrenciliste();
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * From tblkulup", con);
            
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1.DisplayMember = "Kulupad";
            comboBox1.ValueMember = "Kulupid";
            comboBox1.DataSource = dt; 
            con.Close();

        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-LK988TL\SQLEXPRESS;Initial Catalog=BonusOkul;Integrated Security=True");
        private void buttonliste_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.Ogrenciliste();
        }
        
        public void cins()
        {

        }
        string c = "";
        private void button3_Click(object sender, EventArgs e)

        {

           
            if (radioButton1.Checked == true)
            {
                c = "Erkek";
            }
            if (radioButton2.Checked == true)
            {
                c = "Kız";
            }

            ds.Ogrenciekle(txtad.Text, txtsoyad.Text,byte.Parse(comboBox1.SelectedValue.ToString()),c);
            MessageBox.Show("Ekleme işlemi başarıyla yapılmıştır", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                comboBox1.Text = row.Cells["Kulupad"].Value.ToString();
                txtad.Text = row.Cells["Ogrenciad"].Value.ToString();
                txtsoyad.Text = row.Cells["OgrenciSoyad"].Value.ToString();
                txtid.Text = row.Cells["Ogrenciid"].Value.ToString();
                if ("Erkek" == row.Cells["Ogrencinsiyet"].Value.ToString())
                {
                    radioButton1.Checked = true;
                }

                if ("Kız" == row.Cells["Ogrencinsiyet"].Value.ToString())
                {
                    radioButton2.Checked = true;
                }
            }   

            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ds.DeleteQuery(int.Parse(txtid.Text));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ds.Ogrenciguncel(txtad.Text, txtsoyad.Text, byte.Parse(comboBox1.SelectedValue.ToString()), c,int.Parse(txtid.Text));
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                c = "Erkek";
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                c = "Kız";
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource= ds.Ogrencigetir(txtara.Text);   
        }
    }
}
