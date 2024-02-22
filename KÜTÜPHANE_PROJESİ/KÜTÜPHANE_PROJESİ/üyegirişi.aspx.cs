using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace KÜTÜPHANE_PROJESİ
{
    public partial class üyegirişi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public static SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-KMRLDBJ\\SQLEXPRESS;Initial Catalog=KÜTÜPHANE_PROJESİ;Integrated Security=True");
        protected void girişyap_Click(object sender, EventArgs e)
        {
            string kullaniciAdi = kullanıcıadı.Text;
            string sifre = şifre.Text;

            baglanti.Open();
            SqlCommand komut = new SqlCommand();
            komut.Connection = baglanti;
            komut.CommandText = "SELECT * FROM üye WHERE kullanıcıadı ='" + kullaniciAdi + "' AND sifre='" + sifre + "'";
            //komut.ExecuteNonQuery();
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                Response.Redirect("anasayfa.aspx");
            }
            else
            {
                Response.Write("Yanlış Kulanıcı Adı Veya Parola");
            }
            baglanti.Close();
        }

        protected void üyeol_Click(object sender, EventArgs e)
        {
            Response.Redirect("üyeol.aspx");
        }
        //SqlConnection con = new SqlConnection(conStr);
        //SqlCommand cmd = new SqlCommand("update üye set adres=@adres,telefon=@telefon", con);
        //con.Open();
        //cmd.Parameters.AddWithValue("@adres",txt_üyeadres.Text);
        //cmd.Parameters.AddWithValue("@telefon",txt_üyetelefon.Text);
        //cmd.ExecuteNonQuery();
        //con.Close();
    }
}