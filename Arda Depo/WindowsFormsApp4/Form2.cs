using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        bool formtasi = false;
        Point baslangic = new Point(0, 0);
        public void formOpen(Form frm)
        {
            frm.Show();
            this.Hide();
        }
        private void Form2_Load(object sender, EventArgs e)
        {

        }

        public void Form2_MouseDown(object sender, MouseEventArgs e)
        {
            formtasi = true;
            baslangic = new Point(e.X, e.Y);
        }

        public void Form2_MouseUp(object sender, MouseEventArgs e)
        {
            formtasi = false;
        }

        public void Form2_MouseMove(object sender, MouseEventArgs e)
        {
            if (formtasi)
            {
                Point a = PointToScreen(e.Location);
                Location = new Point(a.X - this.baslangic.X, a.Y - this.baslangic.Y);
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

        private void ıconButton3_Click(object sender, EventArgs e)
        {
            ıconButton3.ImageAlign = ContentAlignment.MiddleRight;
            ıconButton3.TextImageRelation = TextImageRelation.Overlay;
            ıconButton1.ImageAlign = ContentAlignment.MiddleLeft;
            ıconButton1.TextImageRelation = TextImageRelation.ImageBeforeText;
            ıconButton2.ImageAlign = ContentAlignment.MiddleLeft;
            ıconButton2.TextImageRelation = TextImageRelation.ImageBeforeText;

        }

        private void ıconButton1_Click(object sender, EventArgs e)
        {
            ıconButton1.ImageAlign = ContentAlignment.MiddleRight;
            ıconButton1.TextImageRelation = TextImageRelation.Overlay;
            ıconButton2.ImageAlign = ContentAlignment.MiddleLeft;
            ıconButton2.TextImageRelation = TextImageRelation.ImageBeforeText;
            Form3 stokekle = new Form3();
            formOpen(stokekle);
            
            
        }

        private void ıconButton2_Click(object sender, EventArgs e)
        {
            ıconButton1.ImageAlign = ContentAlignment.MiddleLeft;
            ıconButton1.TextImageRelation = TextImageRelation.ImageBeforeText;
            ıconButton2.ImageAlign = ContentAlignment.MiddleRight;
            ıconButton2.TextImageRelation = TextImageRelation.Overlay;
            Form4 stoklistele = new Form4();
            stoklistele.Show();
            this.Hide();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void pictureBox5_MouseDown_1(object sender, MouseEventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox6_MouseDown_1(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void ıconButton2_MouseDown(object sender, MouseEventArgs e)
        {
            Form4 stoklistele = new Form4();
            stoklistele.Show();
            this.Hide();
        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
