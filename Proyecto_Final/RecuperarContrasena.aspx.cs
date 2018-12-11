using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RecuperarContrasena : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void continuarBtn_Click(object sender, EventArgs e)
    {
        try
        {
            string resultado = Usuarios.verificaUsuario(Int32.Parse(userTxt.Text));
            if (resultado.Equals("exitoso"))
            {
                Response.Redirect("http://localhost:53551/RecuperarContrasena2.aspx");
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + resultado + "')", true);
            }
            
        }
        catch (Exception)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Error en la conexion')", true);
            throw;
        }
        
    }

    protected void cancelarBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("http://localhost:53551/LogIn.aspx");
    }
}