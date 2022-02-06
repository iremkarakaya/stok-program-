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
    public partial class Form2 : Form
    {
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source = stok.mdb");
        OleDbCommand komut = new OleDbCommand();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        public Form2()
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

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult c;
            c = MessageBox.Show("Silmek istediğinizden emin misiniz?", "Uyarı!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (c == DialogResult.Yes)
            {
                baglanti.Open();
                komut.Connection = baglanti;
                komut.CommandText = "DELETE from stokbil WHERE stokAdi='" + textBox1.Text + "'";
                komut.ExecuteNonQuery();
                komut.Dispose();
                baglanti.Close();
                ds.Clear();
                listele();
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void modeli_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            adi.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            modeli.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            adedi.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            tarihi.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            kyapan.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 frm4 = new Form4();
            frm4.Show();
        }
    }
}
