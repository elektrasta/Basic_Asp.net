using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace KÜTÜPHANE_PROJESİ
{
    public partial class ödünçkitapal : System.Web.UI.Page
    {
        string conStr = ConfigurationManager.ConnectionStrings["OmerFaruk"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GW_Doldur();
                Barkod_Doldur();
            }
        }
        private void GW_Doldur()
        {
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand("Select * from kitap", con);

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            GridView1.DataSource = dr;
            GridView1.DataBind();
            dr.Close();
            con.Close();
        }
        private void Barkod_Doldur()
        {
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand("select kitapID, barkod from kitap", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            ddl_barkod.DataSource = dr;
            ddl_barkod.DataValueField = "kitapID";
            ddl_barkod.DataTextField = "barkod";
            ddl_barkod.DataBind();
            dr.Close();
            con.Close();
        }
        //SqlConnection con = new SqlConnection(conStr);
        //SqlCommand cmd = new SqlCommand("update üye set adres=@adres,telefon=@telefon", con);
        //con.Open();
        //cmd.Parameters.AddWithValue("@adres",txt_üyeadres.Text);
        //cmd.Parameters.AddWithValue("@telefon",txt_üyetelefon.Text);
        //cmd.ExecuteNonQuery();
        //con.Close();

        //public static SqlConnection connection = new SqlConnection("Data Source=DESKTOP-KMRLDBJ\\SQLEXPRESS;Initial Catalog=KÜTÜPHANE_PROJESİ;Integrated Security=True");

        //  protected void ödünçal_Click(object sender, EventArgs e)
        //  { 
        // Response.Redirect("ödünçkitapver.aspx");}
        //{

        //    int hata = 0;
        //    if (txtalkikuis.Text == string.Empty)
        //        hata = 1;
        //    if (txtalkibanu.Text == string.Empty)
        //        hata = 1;
        //    if (hata == 0)
        //    {
        //        connection.Open();
        //        SqlCommand kitap = new SqlCommand();
        //        kitap.CommandText = "insert into kitap values ( @barkodnumarasıki, @kullanıcıismiki)";
        //        kitap.Connection = connection;
        //        kitap.Parameters.AddWithValue("@barkodnumarasıki", txtalkibanu.Text);
        //        kitap.Parameters.AddWithValue("@kullanıcıismiki", txtalkikuis.Text);
        //        kitap.ExecuteNonQuery();
        //        connection.Close();
        //        Response.Redirect("iştamamdır.aspx");
        //        //connection.Open();
        //        //SqlCommand kitap = new SqlCommand();
        //        //kitap.CommandText = "insert into ktpişlemleri values ( @barkodnumarasıki, @kullanıcıismiki)";
        //        //kitap.Connection = connection;
        //        //kitap.Parameters.AddWithValue("@barkodnumarasıki", txtalkibanu.Text);
        //        //kitap.Parameters.AddWithValue("@kullanıcıismiki", txtalkikuis.Text);
        //        //kitap.ExecuteNonQuery();
        //        //connection.Close();
        //        //Response.Redirect("iştamamdır.aspx");
        //    }


        //    else
        //    {

        //    }
        //}

        protected void ddl_barkod_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand("select*from kitap where barkod=@barkod", con);
            cmd.Parameters.AddWithValue("@barkod", ddl_barkod.SelectedItem.Text);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            GridView1.DataSource = dr;
            GridView1.DataBind();
            dr.Close();
            con.Close();
        }
    }
}