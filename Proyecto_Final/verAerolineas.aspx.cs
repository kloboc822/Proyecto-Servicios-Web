using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class verAerolineas : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection("Data Source = localhost\\SQLEXPRESS; Initial Catalog = Vuelos; Integrated Security = True");
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            LoadImages();

        }

    }

    private void LoadImages()
    {

        con.Open();

        SqlCommand cmd = new SqlCommand("Select * from AEROLINEA", con);
        SqlDataReader rdr = cmd.ExecuteReader();
        GridView1.DataSource = rdr;
        GridView1.DataBind();

        con.Close();

    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            Label l1 = GridView1.Rows[e.RowIndex].FindControl("stlbl") as Label;
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Delete from [Aerolinea] where cod_aerol = @cod_aerol";
            cmd.Parameters.AddWithValue("@cod_aerol", l1.Text);
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            con.Close();
            LoadImages();
        }
        catch (Exception)
        { ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Aerolinea used on another service')", true); }

    }

    protected void btnCrear_Click(object sender, EventArgs e)
    {
        Response.Redirect("aerolineas.aspx");
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}