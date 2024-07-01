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

namespace Yolcu_Bilet_Rezervasyon_Mini_App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-3JI920O\SQLEXPRESS;Initial Catalog=DbBiletRezervasyon;Integrated Security=True");

        void seferListele()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from TBLSEFERBILGI", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        void yolcuListele()
        {
            SqlDataAdapter da = new SqlDataAdapter("select AD,SOYAD,TC from TBLYOLCUBILGI", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView2.DataSource = dt;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("insert into TBLYOLCUBILGI (AD, SOYAD, TELEFON, TC, CINSIYET, MAIL) values (@p1, @p2, @p3, @p4, @p5, @p6)", conn);
            cmd.Parameters.AddWithValue("@p1", txtAd.Text);
            cmd.Parameters.AddWithValue("@p2", txtSoyad.Text);
            cmd.Parameters.AddWithValue("@p3", mskTelefon.Text);
            cmd.Parameters.AddWithValue("@p4", mskTC.Text);
            cmd.Parameters.AddWithValue("@p5", cmbCinsiyet.Text);
            cmd.Parameters.AddWithValue("@p6", txtMail.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Yolcu Bilgileri Kaydedildi.","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void btnKaptanKaydet_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("insert into TBLKAPTAN (KAPTANNO, ADSOYAD , TELEFON) values (@p1, @p2, @p3)", conn);
            cmd.Parameters.AddWithValue("@p1", txtKaptanNo.Text);
            cmd.Parameters.AddWithValue("@p2", txtKaptanAS.Text);
            cmd.Parameters.AddWithValue("@p3", mskKaptanTel.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Kaptan Bilgileri Kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnSefOl_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("insert into TBLSEFERBILGI ( KALKIS, VARIS, TARIH, SAAT, KAPTAN, FIYAT) values (@p1, @p2, @p3, @p4, @p5, @p6)", conn);
            cmd.Parameters.AddWithValue("@p1", txtKalkis.Text);
            cmd.Parameters.AddWithValue("@p2", txtVaris.Text);
            cmd.Parameters.AddWithValue("@p3", mskTarih.Text);
            cmd.Parameters.AddWithValue("@p4", mskSaat.Text);
            cmd.Parameters.AddWithValue("@p5", mskKaptan.Text);
            cmd.Parameters.AddWithValue("@p6", txtFiyat.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Sefer Bilgileri Kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            seferListele();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            seferListele();
            yolcuListele();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;

            txtRezSeferNo.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();

        }

        private void btn1_Click(object sender, EventArgs e)
        {
            txtKoltukNo.Text = "1";
        }

        private void btn13_Click(object sender, EventArgs e)
        {
            txtKoltukNo.Text = "13";
        }

        private void btn12_Click(object sender, EventArgs e)
        {
            txtKoltukNo.Text = "12";
        }

        private void btn11_Click(object sender, EventArgs e)
        {
            txtKoltukNo.Text = "11";
        }

        private void btn10_Click(object sender, EventArgs e)
        {
            txtKoltukNo.Text = "10";
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            txtKoltukNo.Text = "9";
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            txtKoltukNo.Text = "8";
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            txtKoltukNo.Text = "7";
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            txtKoltukNo.Text = "6";
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            txtKoltukNo.Text = "5";
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            txtKoltukNo.Text = "4";
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            txtKoltukNo.Text = "3";
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            txtKoltukNo.Text = "2";
        }

        private void btnRezervasyon_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("insert into TBLREZERVASYON (SEFERNO, YOLCUTC, KOLTUK) values (@p1, @p2, @p3)", conn);
            cmd.Parameters.AddWithValue("@p1", txtRezSeferNo.Text);
            cmd.Parameters.AddWithValue("@p2", mskRezYolcuTc.Text);
            cmd.Parameters.AddWithValue("@p3", txtKoltukNo.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Rezervasyon Yapıldı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView2.SelectedCells[0].RowIndex;

            mskRezYolcuTc.Text = dataGridView2.Rows[secilen].Cells[2].Value.ToString();
        }
    }
}
