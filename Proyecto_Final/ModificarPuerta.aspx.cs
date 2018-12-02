using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ModificarPuerta : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string resultado = DatosPUERTAS.obtenerDatosModificar(Global.cod_puerta);
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + resultado + "')", true);
            Cod_puerta.Text = Global.cod_puerta;
            Estado_puerta.Text = Global.detalle_puerta;
        }
    }

    protected void modificar_Click(object sender, EventArgs e)
    {
        Boolean estado = false;
        if (detalleTxt.SelectedValue.Equals("Estado de puerta"))
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Por favor ingrese un nuevo estado de puerta válido')", true);
        }

        else
        {
                if (detalleTxt.SelectedValue.Equals("Abierta"))
                {
                    estado = true;
                }
                if (detalleTxt.SelectedValue.Equals("Cerrada"))
                {
                    estado = false;
                }
                // Llama al procedimiento de DatosPUERTAS que inserta los datos en la BD
                string resultado = DatosPUERTAS.actualizarPuerta(estado, Cod_puerta.Text);
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + resultado + "')", true);
                if (resultado.Equals("Puerta actualizada exitosamente"))
                {
                    Response.Redirect("http://localhost:53551/IndexPuertas.aspx");
                }
        }
        
    }

    protected void cancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("http://localhost:53551/IndexPuertas.aspx");
    }
}