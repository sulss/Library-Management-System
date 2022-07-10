using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace library
{
    public partial class uyelik : Form
    {
       
        public uyelik()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-OLJ3I84;Initial Catalog=Library;Integrated Security=True");
      

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into giris(KullaniciAdi,Password,Mail,Telefon)values(@KullaniciAdi,@Password,@Mail,@Telefon)", baglanti);
            komut.Parameters.AddWithValue("@KullaniciAdi",TxtKA.Text);
            komut.Parameters.AddWithValue("@Password", mTxtP.Text);
            komut.Parameters.AddWithValue("@Mail", TxtMail.Text);
            komut.Parameters.AddWithValue("@Telefon", mTxtTel.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            SqlCommand komt = new SqlCommand();
            MessageBox.Show("Kayıt işleminiz gerçekleştirildi.Hoşgeldiniz.");
            foreach(Control item in Controls)
            {
                if (item is TextBox)
                {
                    item.Text = " ";
                }
                else if(item is MaskedTextBox)
                {
                    item.Text = " ";
                }
            }
        }

        private void uyelik_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
//Data Source=DESKTOP-OLJ3I84;Initial Catalog=Library;Integrated Security=True