using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class Vuelos : System.Web.UI.Page
{
    SqlConnection cone = new SqlConnection("Data Source = localhost\\SQLEXPRESS; Initial Catalog = Vuelos; Integrated Security = True");
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {

            LoadLlegada();
            LoadSalida();

        }

    }

    protected void btnCreate_Click(object sender, EventArgs e)
    {
        if (dplTipo.Text == "Salida")
        {

            Session["Tipo"] = "Salida";
            Response.Redirect("CrearVuelo.aspx");

        }

        else if(dplTipo.Text == "Llegada")
        {
            Session["Tipo"] = "Llegada";
            Response.Redirect("CrearVuelo.aspx");
        }

    }

    private void LoadLlegada()
    {

        cone.Open();

        SqlCommand cmd = new SqlCommand("Select * from Vuelo where tipo ='Llegada'", cone);
        SqlDataReader rdr = cmd.ExecuteReader();
        GridView1.DataSource = rdr;
        GridView1.DataBind();

        cone.Close();

    }

    private void LoadSalida()
    {

        cone.Open();

        SqlCommand cmd = new SqlCommand("Select * from Vuelo where tipo ='Salida'", cone);
        SqlDataReader rdr = cmd.ExecuteReader();
        GridView2.DataSource = rdr;
        GridView2.DataBind();

        cone.Close();

    }
}