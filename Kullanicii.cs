using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace library
{

    class Kullanicii
    {
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-OLJ3I84;Initial Catalog=Library;Integrated Security=True");
        SqlCommand komut;
        SqlDataReader read;
        Kullanici kullan = new Kullanici();
        public SqlDataReader kullanıcı (TextBox grs_ad,MaskedTextBox grs_parola) {
            baglanti.Open();
            komut = new SqlCommand();
            komut.Connection = baglanti;
            komut.CommandText = "select *from giris where Mail='" + grs_ad.Text+"'";
            read = komut.ExecuteReader();
            if (read.Read() == true)
            {
                if (grs_parola.Text == read["Password"].ToString())
                {
                    kullan.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Şifrenizi kontrol ediniz!");
                }

            }
            else if (grs_ad.Text == "admin" && grs_parola.Text == "138138")
            {
                Yonetici yoneticisyf = new Yonetici();
                yoneticisyf.ShowDialog();
            }
            else { 
            MessageBox.Show("Bilgilerinizi kontrol ediniz");
            }

            baglanti.Close();
            return read;
        }
    }
}
