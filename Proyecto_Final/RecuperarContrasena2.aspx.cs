using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RecuperarContrasena2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        preguntaTxt.Text = Usuarios.obtienePregunta();
    }

    protected void cancelBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("http://localhost:53551/LogIn.aspx");
    }

    protected void aceptarBtn_Click(object sender, EventArgs e)
    {
        int cont = 0;
        try
        {
            string resultado = Usuarios.comparaRespuesta(respuestaTxt.Text);
            if (resultado.Equals("correcto"))
            {
                Response.Redirect("http://localhost:53551/RecuperarContrasena3.aspx");
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Respuesta de Seguridad Incorrecta')", true);
                cont++;
                if (cont==2)
                {
                    Response.Redirect("http://localhost:53551/LogIn.aspx");
                }
            }
        }
        catch (Exception)
        {
            throw;
        }
        
    }
}