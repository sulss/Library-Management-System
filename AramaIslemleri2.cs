using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace library
{
    public partial class AramaIslemleri2 : Form
    {
        public AramaIslemleri2()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            kitapara2 kitap = new kitapara2();
            kitap.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            emanetgörüntüle emanet = new emanetgörüntüle();
            emanet.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            türara2 tur = new türara2();
            tur.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            yazarara2 yazar = new yazarara2();
            yazar.ShowDialog();
        }
    }
}
