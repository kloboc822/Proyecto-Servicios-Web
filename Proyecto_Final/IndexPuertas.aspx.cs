using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class IndexPuertas : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void agregar_Click(object sender, EventArgs e)
    {
        Response.Redirect("http://localhost:53551/AgregarPuerta.aspx");
    }

    protected void cancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("http://localhost:53551/Index.aspx");
    }

    protected void modificar_Click(object sender, EventArgs e)
    {
        Response.Redirect("http://localhost:53551/ModificarPuerta.aspx");
    }

    protected void PuertasView_SelectedIndexChanged(object sender, EventArgs e)
    {
        Global.cod_puerta = PuertasView.SelectedRow.Cells[1].Text;
        modificar.Visible = true;
    }
}