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
    public partial class Hesap : Form
    {
        public Hesap()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-OLJ3I84;Initial Catalog=Library;Integrated Security=True");


        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("UPDATE giris SET Password=@Password WHERE Mail=@Mail", baglanti);
            baglanti.Open();
            komut.Parameters.AddWithValue("@Mail", textBox1.Text);
            komut.Parameters.AddWithValue("@Password", maskedTextBox2.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Güncelleme işlemi gerçekleştirildi.");
            foreach (Control item in Controls)
            {
                if (item is TextBox)
                {
                    item.Text = " ";
                }
                else if (item is MaskedTextBox)
                {
                    item.Text = " ";
                }
            }

        }
    }
}
