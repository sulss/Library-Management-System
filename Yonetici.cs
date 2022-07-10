using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace library
{
    public partial class Yonetici : Form
    {
        public Yonetici()
        {
            InitializeComponent();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            
            UyeIslem uyeislm = new UyeIslem();
            uyeislm.ShowDialog();
           
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            
            AramaIslem araislm = new AramaIslem();
            araislm.ShowDialog();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            KitapIslem kitapislemleri = new KitapIslem();
            kitapislemleri.ShowDialog();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Emanetİslemleri emanet = new Emanetİslemleri();
            emanet.ShowDialog();

        }
    }
}
