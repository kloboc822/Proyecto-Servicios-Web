using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class IndexAdmin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            if (Global.userType == 1)
            {
                btnSeguridad.Visible = true;
                btnConsultas.Visible = true;
                btnAdmin.Visible = true;
            }

            else if (Global.userType == 2)
            {

                btnSeguridad.Visible = true;
                btnConsultas.Visible = false;
                btnAdmin.Visible = false;
            }

            else if (Global.userType == 3 || Global.userType == 4)
            {
                btnSeguridad.Visible = false;
                btnConsultas.Visible = false;
                btnAdmin.Visible = true;

            }
            else if (Global.userType == 5)
            {
                btnSeguridad.Visible = false;
                btnConsultas.Visible = true;
                btnAdmin.Visible = false;
            }
        }
    }

    protected void btnSeguridad_Click(object sender, EventArgs e)
    {
        Response.Redirect("NewUser.aspx");
    }

    protected void btnAdmin_Click(object sender, EventArgs e)
    {
        Response.Redirect("Index.aspx");
    }

    protected void btnConsultas_Click(object sender, EventArgs e)
    {
        Response.Redirect("IndexConsultas.aspx");
    }
}