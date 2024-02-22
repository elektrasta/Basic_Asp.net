using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace KÜTÜPHANE_PROJESİ
{
    public partial class üyeol : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public static SqlConnection connection = new SqlConnection("Data Source=DESKTOP-KMRLDBJ\\SQLEXPRESS;Initial Catalog=KÜTÜPHANE_PROJESİ;Integrated Security=True");
        protected void üyeoll_Click(object sender, EventArgs e)
        {
            int hata = 0;
            if (ad.Text == string.Empty)
                hata = 1;
            if (soyad.Text == string.Empty)
                hata = 1;
            if (kullanıcıadı.Text == string.Empty)
                hata = 1;
            if (şifre.Text == string.Empty)
                hata = 1;
            if (hata == 0)
            {
                connection.Open();
                SqlCommand uye = new SqlCommand();
                uye.CommandText = "insert into üye values ( @ad, @soyad, @kullanıcıadı, @sifre)";
                uye.Connection = connection;
                uye.Parameters.AddWithValue("@ad", ad.Text);
                uye.Parameters.AddWithValue("@soyad", soyad.Text);
                uye.Parameters.AddWithValue("@kullanıcıadı", kullanıcıadı.Text);
                uye.Parameters.AddWithValue("@sifre", şifre.Text);
                uye.ExecuteNonQuery();
                connection.Close();
                Response.Redirect("anasayfa.aspx");
            }

            else
            {

            }
            //label ı doldur hama mesajı
        }
    }
}