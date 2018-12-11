using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CompraBoleto : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void buscarBtn_Click(object sender, EventArgs e)
    {
        string resultado = VueloDa.consultarVuelo(destinoTxt.Text, fechaSalidaTxt.Text);
        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + resultado + "')", true);
        if (resultado.Equals("Cargando Vuelos con los parametros deseados, presione OK."))
        {
            Global.lugar = destinoTxt.Text;
            Global.fechaSalida = fechaSalidaTxt.Text;
            Response.Redirect("http://localhost:53551/CompraBoletos2.aspx");
        }
        else
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + resultado + "')", true);
        }
    }

    protected void volverBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("http://localhost:53551/IndexUser.aspx");
    }
}