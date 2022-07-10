using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace library
{
    public partial class Kullanici : Form
    {
        public Kullanici()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AramaIslemleri2 aramaislem = new AramaIslemleri2();
            aramaislem.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hesap hes = new Hesap();
            hes.ShowDialog();
        }
    }
}
