using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ReservaBoletos2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SqlDataSource1.SelectParameters["fecha"].DefaultValue = Global.fechaSalida;
            SqlDataSource1.SelectParameters["lugar"].DefaultValue = Global.lugar;
        }
    }

    protected void comprarBtn_Click(object sender, EventArgs e)
    {
        try
        {
            VueloDa.registrarReserva();
            Response.Redirect("http://localhost:53551/IndexUser.aspx");
        }
        catch (Exception s)
        {
            string error = s.ToString();
            throw;
        }
        
    }

    protected void volverBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("http://localhost:53551/ReservaBoletos.aspx");
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Global.cod_vuelo = GridView1.SelectedRow.Cells[1].Text;
        Global.precio = Int32.Parse(GridView1.SelectedRow.Cells[4].Text);
    }
}