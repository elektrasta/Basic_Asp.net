using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace KÜTÜPHANE_PROJESİ
{
    public partial class kitapekle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public static SqlConnection connection = new SqlConnection("Data Source=DESKTOP-KMRLDBJ\\SQLEXPRESS;Initial Catalog=KÜTÜPHANE_PROJESİ;Integrated Security=True");
        protected void ekle_Click(object sender, EventArgs e)
        {
            int hata = 0;
            if (barkod.Text == string.Empty)
                hata = 1;
            if (kitapadı.Text == string.Empty)
                hata = 1;
            if (yazarı.Text == string.Empty)
                hata = 1;
            if (yayınevi.Text == string.Empty)
                hata = 1;
            if (hata == 0)
            {
                connection.Open();
                SqlCommand kitap = new SqlCommand();
                kitap.CommandText = "insert into kitap values ( @barkod, @kitapadı, @yazarı, @yayınevi, @sayfasayısı)";
                kitap.Connection = connection;
                kitap.Parameters.AddWithValue("@barkod", txtbarkod.Text);
                kitap.Parameters.AddWithValue("@kitapadı", txtkitapadı.Text);
                kitap.Parameters.AddWithValue("@yazarı", txtyazarı.Text);
                kitap.Parameters.AddWithValue("@yayınevi", txtyayınevi.Text);
                kitap.Parameters.AddWithValue("@sayfasayısı", txtsayfasayısı.Text);
                kitap.ExecuteNonQuery();
                connection.Close();
                Response.Redirect("iştamamdır.aspx");
            }

            else
            {

            }
        }

        protected void ktbsil_Click(object sender, EventArgs e)
        {
            // DialogResult dialog;
            // dialog = MessageBox.Show("Bu kaydı silmek mi istiyorsunuz?", "Sil", MessageBoxButtons.YesNo, MessageBox
            ///if (dialog == DialogResult.Yes)
            // {
            //    baglanti.Open();
            //    SqlCommand kitap = new SqlCommand("delete from kitap where barkodno=@barkodno", baglanti);
            //    kitap.Parameters.AddWithValue("@barkod", dataGridView1.Current Row.Cells["barkodno"].Value.ToString
            //   kitap.ExecuteNonQuery();
            //  connection.Close();
            //  MessageBox.Show("Silme işlemi gerçekleşti");
            //  daset.Tables["kitap"].Clear();
            //  kitaplistele();
            //  foreach (Control item in Controls)
            //   {
            //    if (item is TextBox)
            //     {
            //         item.Text = "";
            //     }
            //   }
            // }

        }
    }
}