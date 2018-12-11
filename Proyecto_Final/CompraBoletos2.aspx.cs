using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CompraBoletos2 : System.Web.UI.Page
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
        if (metodoPagoTxt.SelectedValue.Equals("Tarjeta"))
        {
            Response.Redirect("http://localhost:53551/Tarjeta.aspx");
        }
        else if (metodoPagoTxt.SelectedValue.Equals("EasyPay"))
        {
            Response.Redirect("http://localhost:53551/EASY_PAY.aspx");
        }
        else
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Seleccione un metodo de Pago')", true);
        }
    }

    protected void volverBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("http://localhost:53551/CompraBoleto.aspx");
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Global.cod_vuelo = GridView1.SelectedRow.Cells[1].Text;
        Global.precio = Int32.Parse(GridView1.SelectedRow.Cells[4].Text);
    }
}