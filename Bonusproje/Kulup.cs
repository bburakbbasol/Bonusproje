using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Bonusproje
{
    public partial class Kulup : Form
    {
        public Kulup()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-LK988TL\SQLEXPRESS;Initial Catalog=BonusOkul;Integrated Security=True");
         void listele()
        {

            SqlDataAdapter da = new SqlDataAdapter("Select * from tblkulup", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;


        }
        private void Kulup_Load(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * from tblkulup", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void buttonliste_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into tblkulup(kulupad) values(@p1)", con);
                cmd.Parameters.AddWithValue("p1", textBox2.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Kulüp listeye eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listele();

            }
            catch (Exception)
            {
                MessageBox.Show("Hatalı işlem Yaptınız!!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {   con.Open();
            SqlCommand cmd = new SqlCommand("update tblkulup set kulupad=@p1 where kulupid=@p2", con);
            cmd.Parameters.AddWithValue("@p1",textBox2.Text);   
            cmd.Parameters.AddWithValue("@p2",textBox1.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            listele();
            MessageBox.Show("Güncelleme işlemi yapılmıştır ", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();


        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                // "tblkulup" tablosundan silinmek istenen kaydı referans alan kayıtları "tblogrenci" tablosundan sil
                SqlCommand cmd = new SqlCommand("DELETE FROM tblogrenci WHERE Ogrencikulup = @p1", con);
                cmd.Parameters.AddWithValue("@p1", textBox1.Text);
                cmd.ExecuteNonQuery();

                // "tblkulup" tablosundan ilgili kaydı sil
                SqlCommand cmd2 = new SqlCommand("DELETE FROM tblkulup WHERE kulupid = @p2", con);
                cmd2.Parameters.AddWithValue("@p2", textBox1.Text);
                cmd2.ExecuteNonQuery();

                con.Close();

                MessageBox.Show("Kayıt başarıyla silindi.");
                listele();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Ogretmen frm = new Ogretmen();
            frm.Show();
            this.Hide();
        }
    }
}
