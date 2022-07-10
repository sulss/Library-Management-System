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
    public partial class Emanetİslemleri : Form
    {
        public Emanetİslemleri()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-OLJ3I84;Initial Catalog=Library;Integrated Security=True");
        DataSet daset = new DataSet();
      
        private void emanetlistele()
        {
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select *from emanet", baglanti);
            adtr.Fill(daset, "emanet");
            dataGridView1.DataSource = daset.Tables["emanet"];
            baglanti.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text!="" && textBox4.Text!="" && maskedTextBox1.Text!="") {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("insert into emanet (kullanıcıAd,mail,telefon,kitapadı,tur,yazar,yayınevi,teslimtarih,iadetarih)values(@kullanıcıAd,@mail,@telefon,@kitapadı,@tur,@yazar,@yayınevi,@teslimtarih,@iadetarih)", baglanti);
                komut.Parameters.AddWithValue("@kullanıcıAd", textBox2.Text);
                komut.Parameters.AddWithValue("@mail", textBox4.Text);
                komut.Parameters.AddWithValue("@telefon", maskedTextBox1.Text);
                komut.Parameters.AddWithValue("@kitapadı", textBox5.Text);
                komut.Parameters.AddWithValue("@tur", textBox6.Text);
                komut.Parameters.AddWithValue("@yazar", textBox7.Text);
                komut.Parameters.AddWithValue("@yayınevi", textBox8.Text);
                komut.Parameters.AddWithValue("@teslimtarih", dateTimePicker1.Text);
                komut.Parameters.AddWithValue("@iadetarih", dateTimePicker2.Text);
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Emanete ekleme işlemi gerçekleştirildi");
                daset.Tables["emanet"].Clear();
                emanetlistele();
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
            else
            {
                MessageBox.Show("Üye Bilgilerini eksiksiz girmelisiniz!", "UYARI!");
            }

        }


        private void Emanetİslemleri_Load(object sender, EventArgs e)
        {
            emanetlistele();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select *from giris where Mail like'" + textBox4.Text + "'", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                textBox2.Text = read["KullaniciAdi"].ToString();
             
                maskedTextBox1.Text = read["Telefon"].ToString();
                textBox4.Text = read["Mail"].ToString();
            }

            baglanti.Close();



            }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select *from Kitap where kitapAdi like '" + textBox5.Text + "' ", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                textBox6.Text = read["kitapTuru"].ToString();
                textBox7.Text = read["kitapYazari"].ToString();
                textBox8.Text = read["yayinEvi"].ToString();
              

            }
            baglanti.Close();
       
        }


        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("delete from emanet where kitapadı=@kitapadı ", baglanti);
            komut.Parameters.AddWithValue("@kitapadı", dataGridView1.CurrentRow.Cells["kitapadı"].Value.ToString());
            komut.ExecuteNonQuery();
            baglanti.Close();
            daset.Tables["emanet"].Clear();
            emanetlistele();

            MessageBox.Show("Teslim Alındı.");
        }


    }
}
