using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source = stok.mdb");
        OleDbCommand komut = new OleDbCommand();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        public Form1()
        {
            InitializeComponent();
        }

        void listele()
        {
            baglanti.Open();
            OleDbDataAdapter adtr = new OleDbDataAdapter("Select * from stokbil", baglanti);
            adtr.Fill(ds, "stokbil");
            dataGridView1.DataSource = ds.Tables["stokbil"];
            adtr.Dispose();
            baglanti.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listele();
            /*dataGridView1.Columns[0].Width = 30;
            dataGridView1.Columns[1].Width = 100;
            dataGridView1.Columns[2].Width = 110;
            dataGridView1.Columns[3].Width = 110;
            dataGridView1.Columns[4].Width = 110;
            dataGridView1.Columns[5].Width = 110;

            dataGridView1.Columns[0].HeaderText = "İD";
            dataGridView1.Columns[1].HeaderText = "Ad ";
            dataGridView1.Columns[2].HeaderText = "Modeli";
            dataGridView1.Columns[3].HeaderText = "Adedi";
            dataGridView1.Columns[4].HeaderText = "Tarihi";
            dataGridView1.Columns[5].HeaderText = "Kayıt Yapan";*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
                    baglanti.Open();
             komut.Connection = baglanti;
             komut.CommandText = "INSERT INTO stokbil (stokAdi, stokModeli, stokAdedi, stokTarih, kayitYapan) VALUES ('" + adi.Text + "','" + modeli.Text + "','" + adedi.Text + "','" + tarihi.Text + "','" + kyapan.Text + "')";
            komut.ExecuteNonQuery();
            komut.Dispose();
            baglanti.Close();
            MessageBox.Show("Kişi eklemesi Başarılı Olmuştur...");
            ds.Clear();
            listele();
            temizle();
            
            



        }
        public void temizle()
        {
            adi.Text = "";
            adedi.Text = "";
            modeli.Text = "";
            tarihi.Text = "";
            kyapan.Text = "";
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 frm4 = new Form4();
            frm4.Show();
        }
    }
}
