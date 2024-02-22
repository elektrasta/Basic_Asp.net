using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace KÜTÜPHANE_PROJESİ
{
    public partial class ödünçkitapver : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public static SqlConnection connection = new SqlConnection("Data Source=DESKTOP-KMRLDBJ\\SQLEXPRESS;Initial Catalog=KÜTÜPHANE_PROJESİ;Integrated Security=True");

        protected void kitabıödünçverr_Click(object sender, EventArgs e)
        {

            int hata = 0;
            if (txtalkikuis.Text == string.Empty)
                hata = 1;
            if (txtalkibanu.Text == string.Empty)
                hata = 1;
            if (hata == 0)
            {
                connection.Open();
                SqlCommand kitap = new SqlCommand();
                kitap.CommandText = "insert into ktpişlemleri values ( @barkodnumarasıki, @kullanıcıismiki)";
                kitap.Connection = connection;
                kitap.Parameters.AddWithValue("@barkodnumarasıki", txtalkibanu.Text);
                kitap.Parameters.AddWithValue("@kullanıcıismiki", txtalkikuis.Text);
                kitap.ExecuteNonQuery();
                connection.Close();
                Response.Redirect("iştamamdır.aspx");
            }
        }
    }
}