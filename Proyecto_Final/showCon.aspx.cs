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

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("Consecutivos.aspx");
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "seditar")
        {
            int crow;
            crow = Convert.ToInt32(e.CommandArgument.ToString());
            Session["vDes"] = GridView1.Rows[crow].Cells[1].Text;
            Session["vCon"] = GridView1.Rows[crow].Cells[2].Text;

            Response.Redirect("editConsecutivo.aspx");

        }
    }
}