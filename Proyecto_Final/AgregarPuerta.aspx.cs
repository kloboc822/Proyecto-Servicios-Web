using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class AgregarPuerta: System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void agregar_Click(object sender, EventArgs e)
    {
        
        Boolean estado = false;
        //valida que todos los datos se hayan ingresado antes de ingresar a la BD
        if (Cod_puerta.SelectedValue.Equals("") || detalleTxt.SelectedValue.Equals("Estado de puerta"))
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Por favor ingrese un código y estado de puerta válidos')", true);
        }

        else
        {
            //valida si el código que se desea asignar ya fue asignado
            string resultado = DatosPUERTAS.verificarPuerta(Cod_puerta.SelectedValue);
            
            if (resultado.Equals("El código seleccionado ya fue asignado a una puerta, por favor compruebe con soporte el código correspondiente"))
            {
                detalleTxt.SelectedIndex=0;
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + resultado + "')", true);
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
                resultado = DatosPUERTAS.agregarPUERTA(Cod_puerta.SelectedValue,estado);
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + resultado + "')", true);
                if (resultado.Equals("Puerta agregada con éxito."))
                {
                    DatosPUERTAS.sumarConsecutivoPuerta();
                    Response.Redirect("http://localhost:53551/IndexPuertas.aspx");
                }
            }
        }
    }

    protected void cancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("http://localhost:53551/IndexPuertas.aspx");
    }
}