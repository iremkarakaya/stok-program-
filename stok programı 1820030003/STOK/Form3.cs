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
    public partial class Form3 : Form
    {

        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source = stok.mdb");
        OleDbCommand komut = new OleDbCommand();
        
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        public Form3()
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
        private void Form3_Load(object sender, EventArgs e)
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
