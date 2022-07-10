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
    public partial class UyeIslem : Form
    {
        public UyeIslem()
        {
            InitializeComponent();
        }
        DataSet daset = new DataSet();

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtmail.Text = dataGridView1.CurrentRow.Cells["Mail"].Value.ToString();
        }
     
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-OLJ3I84;Initial Catalog=Library;Integrated Security=True");


        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult dialog;
            dialog = MessageBox.Show("Silme işlemi gerçekleştirilsin mi?", "SİL", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dialog == DialogResult.Yes)
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("delete from giris where Mail=@Mail ", baglanti);
                komut.Parameters.AddWithValue("@Mail", dataGridView1.CurrentRow.Cells["Mail"].Value.ToString());
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Silme işlemi gerçekleştirildi.");
                daset.Tables["giris"].Clear();
                uyelistele();
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
        private void uyelistele()
        {
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select *from giris", baglanti);
            adtr.Fill(daset, "giris");
            dataGridView1.DataSource = daset.Tables["giris"];
            baglanti.Close();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            uyelistele();
            daset.Tables["giris"].Clear();
            uyelistele();
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
          
            SqlCommand komut = new SqlCommand("UPDATE giris SET KullaniciAdi=@KullaniciAdi,Telefon=@Telefon,Password=@Password WHERE Mail=@Mail",baglanti);
            baglanti.Open();
            komut.Parameters.AddWithValue("@KullaniciAdi", Txtisim.Text);
            komut.Parameters.AddWithValue("@Mail", txtmail.Text);
            komut.Parameters.AddWithValue("@Telefon", mtxttel.Text);
            komut.Parameters.AddWithValue("@Password",mtxtparola.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Güncelleme işlemi gerçekleştirildi");
            daset.Tables["giris"].Clear();
            uyelistele();
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
        private void txtmail_TextChanged_1(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select *from giris where Mail like'" + txtmail.Text + "'", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                Txtisim.Text = read["KullaniciAdi"].ToString();
                mtxtparola.Text = read["Password"].ToString();
                mtxttel.Text = read["Telefon"].ToString();
                txtmail.Text = read["Mail"].ToString();
            }
            baglanti.Close();
        }

      
    }
}
