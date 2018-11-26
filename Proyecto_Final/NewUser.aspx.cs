using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class NewUser : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack)
        {
            
        }
    }

    protected void cancelBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("IndexAdmin.aspx");
    }

    protected void createBtn_Click(object sender, EventArgs e)
    {
        try
        {
            if (idTxt.Text.Equals("") || passwordTxt.Text.Equals("") || firstnameTxt.Text.Equals("") || surname1Txt.Text.Equals("") || surname2Txt.Text.Equals("") || emailTxt.Text.Equals(""))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('All spaces must have info.')", true);
            }
            else
            {
                string resultado = Usuarios.addUser(firstnameTxt.Text, surname1Txt.Text, surname2Txt.Text, Int32.Parse(idTxt.Text), emailTxt.Text, Int32.Parse(tipouserTxt.Text), passwordTxt.Text, nacionalidadTxt.Text);
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + resultado + "')", true);
            }
        }
        catch (Exception)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Error en codigo de boton')", true);
            throw;
        }
    }
}