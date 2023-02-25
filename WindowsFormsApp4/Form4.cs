using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp4
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        bool formtasi = false;
        Point baslangic = new Point(0, 0);
        MySqlConnection conn = new MySqlConnection("SERVER=;PORT=3306;DATABASE=;UID=;PASSWORD=;");
        MySqlCommand cmd;
        MySqlDataAdapter adapter;
        DataTable dt;
        void VeriGetir()
        {
            dt = new DataTable();
            conn.Open();
            adapter = new MySqlDataAdapter("SELECT *FROM stoklar", conn);
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].HeaderText = "Marka";
            dataGridView1.Columns[1].Width = 90;
            dataGridView1.Columns[2].HeaderText = "Model";
            dataGridView1.Columns[2].Width = 90;
            dataGridView1.Columns[3].HeaderText = "Seri No";
            dataGridView1.Columns[3].Width = 70;
            dataGridView1.Columns[4].HeaderText = "Kayıt Yapan";
            dataGridView1.Columns[4].Width = 70;
            dataGridView1.Columns[5].HeaderText = "Alis Fiyat";
            dataGridView1.Columns[5].Width = 70;
            dataGridView1.Columns[6].HeaderText = "Satis Fiyat";
            dataGridView1.Columns[6].Width = 70;
            dataGridView1.Columns[7].HeaderText = "Stok Adeti";
            dataGridView1.Columns[7].Width = 70;
            dataGridView1.Columns[8].HeaderText = "Kayit Tarihi";
            dataGridView1.Columns[8].Width = 100;
            conn.Close();
            double toplam = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                toplam++;
            }
            toplam = toplam - 1;
            label13.Text = toplam.ToString();
        }
        private void Form4_Load(object sender, EventArgs e)
        {
            VeriGetir();

        }

        private void ıconButton4_Click(object sender, EventArgs e)
        {
            VeriGetir();
        }

        private void pictureBox5_MouseDown(object sender, MouseEventArgs e)
        {
            Application.Exit();
        }

        private void Form4_MouseDown(object sender, MouseEventArgs e)
        {
            formtasi = true;
            baslangic = new Point(e.X, e.Y);
        }

        private void Form4_MouseUp(object sender, MouseEventArgs e)
        {
            formtasi = false;
        }

        private void Form4_MouseMove(object sender, MouseEventArgs e)
        {
            if (formtasi)
            {
                Point a = PointToScreen(e.Location);
                Location = new Point(a.X - this.baslangic.X, a.Y - this.baslangic.Y);
            }
        }

        private void pictureBox6_MouseDown(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void ıconButton1_Click(object sender, EventArgs e)
        {
            ıconButton1.ImageAlign = ContentAlignment.MiddleRight;
            ıconButton1.TextImageRelation = TextImageRelation.Overlay;
            ıconButton2.ImageAlign = ContentAlignment.MiddleLeft;
            ıconButton2.TextImageRelation = TextImageRelation.ImageBeforeText;
            Form3 stokekle = new Form3();
            stokekle.Show();
            this.Hide();
        }

        private void ıconButton3_Click(object sender, EventArgs e)
        {
            ıconButton3.ImageAlign = ContentAlignment.MiddleRight;
            ıconButton3.TextImageRelation = TextImageRelation.Overlay;
            ıconButton2.ImageAlign = ContentAlignment.MiddleLeft;
            ıconButton2.TextImageRelation = TextImageRelation.ImageBeforeText;
            Form2 anasayfa = new Form2();
            anasayfa.Show();
            this.Hide();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            Form2 anasayfa = new Form2();
            anasayfa.Show();
            this.Hide();
        }

        private void ıconButton5_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow drow in dataGridView1.SelectedRows) 
            {
                int numara = Convert.ToInt32(drow.Cells[0].Value);
                string sql = "DELETE FROM stoklar WHERE id=@id";
                cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", numara);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            VeriGetir();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataView dv = dt.DefaultView;
            dv.RowFilter = "marka LIKE '" + textBox1.Text + "%'";
            dataGridView1.DataSource = dv;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                textBox4.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                comboBox1.SelectedItem = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                textBox6.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                textBox5.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                textBox7.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                bunifuDatepicker1.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ıconButton7_Click(object sender, EventArgs e)
        {
            string sorgu = "UPDATE stoklar SET marka=@marka,model=@model,seriNo=@seriNo,kayitYapan=@kayitYapan,alisFiyat=@alisFiyat,satisFiyat=@satisFiyat,stokAdeti=@stokAdeti,kayitTarih=@kayitTarih WHERE id=@id";
            cmd = new MySqlCommand(sorgu, conn);
            cmd.Parameters.AddWithValue("@id", dataGridView1.CurrentRow.Cells[0].Value.ToString());
            cmd.Parameters.AddWithValue("@marka", textBox4.Text);
            cmd.Parameters.AddWithValue("@model", textBox2.Text);
            cmd.Parameters.AddWithValue("@seriNo", textBox3.Text);
            cmd.Parameters.AddWithValue("@kayitYapan", comboBox1.SelectedItem);
            cmd.Parameters.AddWithValue("@alisFiyat", int.Parse(textBox6.Text));
            cmd.Parameters.AddWithValue("@satisFiyat", int.Parse(textBox5.Text));
            cmd.Parameters.AddWithValue("@stokAdeti", int.Parse(textBox7.Text));
            cmd.Parameters.AddWithValue("@kayitTarih", bunifuDatepicker1.Value);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Başarıyla Güncellendi");
            VeriGetir();
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            DataView dv = dt.DefaultView;
            dv.RowFilter = "model LIKE '" + textBox8.Text + "%'";
            dataGridView1.DataSource = dv;
        }

        private void ıconButton6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ID: " + dataGridView1.CurrentRow.Cells[0].Value.ToString()+ "\nMarka: " + dataGridView1.CurrentRow.Cells[1].Value.ToString()+ "\nModel: " + dataGridView1.CurrentRow.Cells[2].Value.ToString()+ "\nSeri No: " + dataGridView1.CurrentRow.Cells[3].Value.ToString()+ "\nKayıt Yapan: " + dataGridView1.CurrentRow.Cells[4].Value.ToString()+ "\nÜrün Alış Fiyatı: " + dataGridView1.CurrentRow.Cells[5].Value.ToString() + "\nÜrün Satış Fiyatı: " + dataGridView1.CurrentRow.Cells[6].Value.ToString()+ "\nStok Adeti: " + dataGridView1.CurrentRow.Cells[7].Value.ToString() + "\nKayıt Tarihi: " + dataGridView1.CurrentRow.Cells[8].Value.ToString(),"Arda Depo | "+ dataGridView1.CurrentRow.Cells[1].Value.ToString()+" "+ dataGridView1.CurrentRow.Cells[2].Value.ToString(),MessageBoxButtons.OK);

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
