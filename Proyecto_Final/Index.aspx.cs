using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

 


    protected void btnConsecutivos_Click(object sender, EventArgs e)
    {
        Response.Redirect("showCon.aspx");
    }

    protected void btnAerolineas_Click(object sender, EventArgs e)
    {
        Response.Redirect("verAerolineas.aspx");
    }

    protected void btnVuelos_Click(object sender, EventArgs e)
    {
        Response.Redirect("Vuelos.aspx");
    }

    protected void BtnPaises_Click(object sender, EventArgs e)
    {
        Response.Redirect("IndexPaises.aspx");
    }

    protected void BtnPuertas_Click(object sender, EventArgs e)
    {
        Response.Redirect("IndexPuertas.aspx");
    }
}