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
using System.Security.Cryptography.X509Certificates;

namespace Bonusproje
{
    public partial class ogrencinotlar : Form
    {
        public ogrencinotlar()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-LK988TL\SQLEXPRESS;Initial Catalog=BonusOkul;Integrated Security=True");
        public string number;
        private void ogrencinotlar_Load(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT Dersad, Sınav1, Sınav2, Proje, Ortalama, Durum FROM tblnotlar INNER JOIN tbldersler ON tblnotlar.dersid=tbldersler.dersid WHERE Ogrenciid=@p1", con);
            /* SqlCommand kmt = new SqlCommand("SELECT ogrenciad, ogrencisoyad FROM tblogrenci WHERE ogrenciid=@p2", con);

             kmt.Parameters.AddWithValue("@p2", number);
             SqlDataReader dr = kmt.ExecuteReader();

             string ogrenciAd = "";
             string ogrenciSoyad = "";

             // öğrenci adı ve soyadını oku
             while (dr.Read())
             {
                 ogrenciAd = dr["ogrenciad"].ToString();
                 ogrenciSoyad = dr["ogrencisoyad"].ToString();
             }

             dr.Close();

             // öğrenci adı ve soyadını form başlığına yazdır
             this.Text = ogrenciAd + " " + ogrenciSoyad;*/
            SqlCommand kmt = new SqlCommand("SELECT ogrenciad + ' ' + ogrencisoyad FROM tblogrenci WHERE ogrenciid = @p1", con);
            kmt.Parameters.AddWithValue("@p1", number);
            string adSoyad = kmt.ExecuteScalar().ToString();
            this.Text = adSoyad;


            cmd.Parameters.AddWithValue("@p1", number);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            con.Close();


        }
    }
}
