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
    public partial class KitapIslem : Form
    {
        public KitapIslem()
        {
            InitializeComponent();
        }
        DataSet daset = new DataSet();
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-OLJ3I84;Initial Catalog=Library;Integrated Security=True");

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into Kitap(kitapAdi,kitapTuru,kitapYazari,yayinEvi)values(@kitapAdi,@kitapTuru,@kitapYazari,@yayinEvi)", baglanti);
            komut.Parameters.AddWithValue("@kitapAdi", kitad.Text);
            komut.Parameters.AddWithValue("@kitapTuru", kitür.Text);
            komut.Parameters.AddWithValue("@kitapYazari", kiyaz.Text);
            komut.Parameters.AddWithValue("@yayinEvi", kiyev.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt işlemi yapıldı.");
            daset.Tables["kitap"].Clear();
            kitaplistele();
            foreach(Control item in Controls)
            {
                if(item is TextBox)
                {
                    item.Text = " ";
                }
            }
        }
        private void kitaplistele()
        {
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select *from kitap", baglanti);
            adtr.Fill(daset, "kitap");
            dataGridView1.DataSource = daset.Tables["kitap"];
            baglanti.Close();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            kitaplistele();
            daset.Tables["kitap"].Clear();
            kitaplistele();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult dialog;
            dialog = MessageBox.Show("Silme işlemi gerçekleştirilsin mi?", "SİL", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dialog == DialogResult.Yes)
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("delete from Kitap where kitapAdi =@kitapAdi ", baglanti);
                komut.Parameters.AddWithValue("@kitapAdi", dataGridView1.CurrentRow.Cells["kitapAdi"].Value.ToString());
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Silme işlemi gerçekleştirildi.");
                daset.Tables["kitap"].Clear();
                kitaplistele();
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

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("UPDATE kitap SET kitapTuru=@kitapTuru,kitapYazari=@kitapYazari,yayinEvi=@yayinEvi WHERE kitapAdi=@kitapAdi", baglanti);
            baglanti.Open();
            komut.Parameters.AddWithValue("@kitapAdi", kitad.Text);
            komut.Parameters.AddWithValue("@kitapTuru", kitür.Text);
            komut.Parameters.AddWithValue("@kitapYazari", kiyaz.Text);
            komut.Parameters.AddWithValue("@yayinEvi", kiyev.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Güncelleme işlemi gerçekleştirildi");
            daset.Tables["kitap"].Clear();
            kitaplistele();
            foreach (Control item in Controls)
            {
                if (item is TextBox)
                {
                    item.Text = " ";
                }
            }
        }

    

    
    }
}
