using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace library
{
    public partial class AramaIslem : Form
    {
        public AramaIslem()
        {
            InitializeComponent();
        }
        DataSet daset = new DataSet();
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-OLJ3I84;Initial Catalog=Library;Integrated Security=True");

        private void button3_Click(object sender, EventArgs e)
        {
            kitapara kitapara = new kitapara();
            kitapara.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            turara turara = new turara();
            turara.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            yazarara yazarara = new yazarara();
            yazarara.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            uyeara uyeara = new uyeara();
            uyeara.ShowDialog();
        }
    }
}
