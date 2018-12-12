using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RecuperarContrasena3 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void cancelBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("http://localhost:53551/LogIn.aspx");
    }

    protected void aceptarBtn_Click(object sender, EventArgs e)
    {
        string resultado;
        if (contrasenaTxt.Text.Equals(confirmarTxt.Text))
        {
            resultado = Usuarios.reseteaContrasena(contrasenaTxt.Text);
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + resultado + "')", true);
            Response.Redirect("http://localhost:53551/LogIn.aspx");
        }
        else
        {
            resultado = "Las contraseñas insertadas no son correctas";
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + resultado + "')", true);
        }
        
    }
}