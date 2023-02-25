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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        MySqlConnection conn = new MySqlConnection("SERVER=;PORT=3306;DATABASE=;UID=;PASSWORD=;");
        MySqlCommand cmd;
        MySqlDataAdapter adapter;
        DataTable dt;
        bool formtasi = false;
        Point baslangic = new Point(0, 0);
        private void Form3_MouseDown(object sender, MouseEventArgs e)
        {
            formtasi = true;
            baslangic = new Point(e.X, e.Y);
        }

        private void Form3_MouseMove(object sender, MouseEventArgs e)
        {
            if (formtasi)
            {
                Point a = PointToScreen(e.Location);
                Location = new Point(a.X - this.baslangic.X, a.Y - this.baslangic.Y);
            }
        }

        private void Form3_MouseUp(object sender, MouseEventArgs e)
        {
            formtasi = false;
        }

        private void pictureBox5_MouseDown(object sender, MouseEventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox6_MouseDown(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
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

        private void ıconButton1_Click(object sender, EventArgs e)
        {
            Form4 stoklistele = new Form4();
            stoklistele.Show();
            this.Hide();
        }

        private void ıconButton2_Click(object sender, EventArgs e)
        {
            ıconButton2.ImageAlign = ContentAlignment.MiddleRight;
            ıconButton2.TextImageRelation = TextImageRelation.Overlay;
            ıconButton3.ImageAlign = ContentAlignment.MiddleLeft;
            ıconButton3.TextImageRelation = TextImageRelation.ImageBeforeText;
            Form4 stoklistele = new Form4();
            stoklistele.Show();
            this.Hide();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            Form2 anasayfa = new Form2();
            anasayfa.Show();
            this.Hide();
        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }
        private void ıconButton4_Click(object sender, EventArgs e)
        {
            try
            {
                string sorgu = "INSERT INTO stoklar(marka,model,seriNo,kayitYapan,alisFiyat,satisFiyat,stokAdeti,kayitTarih) values(@marka,@model,@seriNo,@kayitYapan,@alisFiyat,@satisFiyat,@stokAdeti,@kayitTarih)";
                cmd = new MySqlCommand(sorgu, conn);
                cmd.Parameters.AddWithValue("@marka", textBox1.Text);
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
                MessageBox.Show("Başarıyla eklendi");
            }
            catch(Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message);
            }
            
        }

        private void Form3_Load(object sender, EventArgs e)
        {
        }
    }
}
