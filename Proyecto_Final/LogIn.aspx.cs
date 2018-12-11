using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;



public partial class LogIn : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack)
        {
            
        }
    }

    protected void loginBtn_Click(object sender, EventArgs e)
    {
        if (usernameTxt.Text.Equals("") || passwordTxt.Text.Equals(""))
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Favor ingresar un usuario y contraseña')", true);
        }
        else
        {
            string resultado = Usuarios.inicioSesion(Int32.Parse(usernameTxt.Text),passwordTxt.Text);

            switch (resultado)
            {
                case "1":
                    Response.Redirect("http://localhost:53551/IndexAdmin.aspx");//Administrador
                    break;
                case "2":
                    Response.Redirect("http://localhost:53551/IndexAdmin.aspx");//Seguridad
                    break;
                case "3":
                    Response.Redirect("http://localhost:53551/IndexAdmin.aspx");//Consecutivo
                    break;
                case "4":
                    Response.Redirect("http://localhost:53551/IndexAdmin.aspx");//Mantenimiento
                    break;
                case "5":
                    Response.Redirect("http://localhost:53551/IndexAdmin.aspx");//Consulta
                    break;
                case "6":
                    Response.Redirect("http://localhost:53551/IndexUser.aspx");//Usuario Regular
                    break;
                default:
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + resultado + "')", true);
                break;
            }
        }

    }
}