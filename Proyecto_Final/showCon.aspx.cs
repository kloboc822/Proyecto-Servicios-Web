using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class showCon : System.Web.UI.Page
{

    SqlConnection con = new SqlConnection("Data Source = localhost\\SQLEXPRESS; Initial Catalog = Vuelos; Integrated Security = True");
    protected void Page_Load(object sender, EventArgs e)
    {


        if (!Page.IsPostBack)
        {

            LoadData();

        }
        LoadDataCod();
    }

    //Carga datos de consecutivos en el gridview
    private void LoadData()
    {
        con.Open();

        SqlCommand cmd = new SqlCommand("Select * from CONSECUTIVO", con);
        SqlDataReader rdr = cmd.ExecuteReader();
        GridView1.DataSource = rdr;
        GridView1.DataBind();

        con.Close();
    }

    private void LoadDataCod(){

        con.Open();

        SqlCommand cmd = new SqlCommand("Select * from CODIGOS", con);
        SqlDataReader rdr = cmd.ExecuteReader();
        GridView2.DataSource = rdr;
        GridView2.DataBind();

        con.Close();

    }

    //Hace que el boton delete borre la fila y tambien actualice la base de datos
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        Label l1 = GridView1.Rows[e.RowIndex].FindControl("stlbl") as Label;
        con.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "Delete from [CONSECUTIVO] where prefijo = @prefijo";
        cmd.Parameters.AddWithValue("@prefijo", l1.Text);
        cmd.Connection = con;
        cmd.ExecuteNonQuery();
        con.Close();
        LoadData();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("Consecutivos.aspx");
    }
}