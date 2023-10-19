using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuzzleGame
{
    public partial class Form2 : Form
    {
        public Image AppImage { get; private set; }

        public Form2()
        {
            InitializeComponent();

       
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.AppImage = pictureBox1.Image;
            this.DialogResult = DialogResult.OK;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.AppImage = pictureBox2.Image;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.AppImage = pictureBox3.Image;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.AppImage = pictureBox4.Image;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.AppImage = pictureBox5.Image;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.AppImage = pictureBox6.Image;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
