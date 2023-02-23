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
    public partial class Form1 : Form
    {
        MySqlConnection conn;
        MySqlCommand cmd;
        MySqlDataReader dr;
        string connString;
        public Form1()
        {
            InitializeComponent();
        }
        bool formtasi = false;
        Point baslangic = new Point(0, 0);


        private void button1_Click(object sender, EventArgs e)
        {

            
        }

        public void girisKontrol()
        {
            conn.Close();
            string user = textBox1.Text;
            string pass = textBox2.Text;
            cmd = new MySqlCommand();
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM adminuser where kullaniciAdi='" + user + "' AND sifre='" + pass + "'";
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                conn.Close();
                Form2 frm2 = new Form2();
                frm2.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Kullanıcı Adı veya Şifre Girdiniz.", "Arda Depo | Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox2_MouseDown(object sender, MouseEventArgs e)
        {
            if (textBox2.Text == "Şifre")
            {
                textBox2.Text = "";
                if (pictureBox4.Enabled == true)
                {
                    textBox2.UseSystemPasswordChar = false;
                }
                else if (pictureBox4.Enabled == false)
                {
                    textBox2.UseSystemPasswordChar = true;
                }
            }
            if (textBox1.Text== "")
            {
                textBox1.Text = "Kullanıcı Adı";
            }
        }

        private void textBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (textBox1.Text == "Kullanıcı Adı")
            {
                textBox1.Text = "";
            }
            
            if (textBox2.Text == "")
            {
                textBox2.UseSystemPasswordChar = false;
                textBox2.Text = "Şifre";
            }


        }

        private void pictureBox3_MouseDown(object sender, MouseEventArgs e)
        {
            if (textBox2.Text != "Şifre")
            {
                pictureBox3.Visible = false;
                pictureBox3.Enabled = false;
                pictureBox4.Visible = true;
                pictureBox4.Enabled = true;
                textBox2.UseSystemPasswordChar = false;
            }
           
        }

        private void pictureBox4_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox4.Visible = false;
            pictureBox4.Enabled = false;
            pictureBox3.Visible = true;
            pictureBox3.Enabled = true;
            textBox2.UseSystemPasswordChar = true;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (pictureBox4.Enabled == true)
            {
                textBox2.UseSystemPasswordChar = false;
            }
            else if (pictureBox4.Enabled == false)
            {
                textBox2.UseSystemPasswordChar = true;
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                girisKontrol();
            }

        }

        private void pictureBox5_MouseDown(object sender, MouseEventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox6_MouseDown(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        string hatames;
        private void Form1_Load(object sender, EventArgs e)
        {
            connString = "SERVER=87.248.157.101;PORT=3306;DATABASE=ismaildepo;UID=depoismailSQL;PASSWORD=depoismailSQL11";
            try
            {
                conn = new MySqlConnection(connString);
                conn.ConnectionString = connString;
                conn.Open();
                label2.Text = "Bağlandı";
                label2.ForeColor = Color.Green;
            }
            catch (MySqlException ex)
            {
                label2.Text = "Bağlantı Başarısız Hata:";
                label2.ForeColor = Color.FromArgb(192, 0, 0);
                label3.Visible = true;
                label3.Text = "TIKLA";              
                hatames = ex.Message;
            }
            this.ActiveControl = pictureBox1;
            
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            formtasi = true;
            baslangic = new Point(e.X, e.Y);
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            formtasi = false;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (formtasi)
            {
                Point a = PointToScreen(e.Location);
                Location = new Point(a.X - this.baslangic.X, a.Y - this.baslangic.Y);
            }
        }

        private void label3_MouseDown(object sender, MouseEventArgs e)
        {
            MessageBox.Show(hatames,"Arda Depo | MySQL Hata",MessageBoxButtons.OK);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            girisKontrol();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                girisKontrol();
            }
        }
    }
}
