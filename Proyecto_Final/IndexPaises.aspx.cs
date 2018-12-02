using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class IndexPaises : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void PaisesView_SelectedIndexChanged(object sender, EventArgs e)
    {
        Global.cod_pais = PaisesView.SelectedRow.Cells[1].Text;
        modificar.Visible = true;
    }

    protected void modificar_Click(object sender, EventArgs e)
    {
        Response.Redirect("http://localhost:53551/ModificarPais.aspx");
    }

    protected void cancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("http://localhost:53551/Index.aspx");
    }

    protected void agregar_Click(object sender, EventArgs e)
    {
        Response.Redirect("http://localhost:53551/AgregarPais.aspx");
    }
}