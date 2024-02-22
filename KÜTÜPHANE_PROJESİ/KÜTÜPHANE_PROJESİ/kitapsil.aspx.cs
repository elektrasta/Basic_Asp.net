using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Drawing;
using System.Configuration;

namespace KÜTÜPHANE_PROJESİ
{
    public partial class kitapsil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public static SqlConnection connection = new SqlConnection("Data Source=DESKTOP-KMRLDBJ\\SQLEXPRESS;Initial Catalog=KÜTÜPHANE_PROJESİ;Integrated Security=True");

        protected void ktbsil_Click(object sender, EventArgs e)
        {
            int hata = 0;
            if (txtbarkodno.Text == string.Empty)
                hata = 1;
            if (hata == 0)
            {
                connection.Open();
                SqlCommand kitap = new SqlCommand();
                kitap.CommandText = "delete from kitap where barkod=@barkod";
                kitap.Connection = connection;
                kitap.Parameters.AddWithValue("@barkod", txtbarkodno.Text);
                kitap.ExecuteNonQuery();
                connection.Close();
                Response.Redirect("iştamamdır.aspx");
            }
        }
    }
}