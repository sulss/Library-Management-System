﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace library
{
    public partial class kitapara2 : Form
    {
        public kitapara2()
        {
            InitializeComponent();
        }
        DataTable datab = new DataTable();
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-OLJ3I84;Initial Catalog=Library;Integrated Security=True");
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
                datab.Clear();
                baglanti.Open();
                SqlDataAdapter adtr = new SqlDataAdapter("select *from kitap where kitapAdi like'%" + textBox1.Text + "%'", baglanti);
                adtr.Fill(datab);
                dataGridView1.DataSource = datab;
                baglanti.Close();
            

        }
    }
}
