using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            if (Global.userType == 2)
            {

                btnConsecutivos.Visible = false;
                BtnPaises.Visible = false;
                btnAerolineas.Visible = false;
                btnVuelos.Visible = false;
                BtnPuertas.Visible = false;
            }

            else if (Global.userType == 3)
            {
                BtnPaises.Visible = false;
                btnAerolineas.Visible = false;
                btnVuelos.Visible = false;
                BtnPuertas.Visible = false;
                BtnUsuario.Visible = false;

            }
            else if (Global.userType == 4)
            {
                BtnUsuario.Visible = false;
            }
            else if (Global.userType == 5)
            {
                BtnUsuario.Visible = false;
                btnVuelos.Visible = false;
                btnConsecutivos.Visible = false;
                BtnPaises.Visible = false;
            }
        }
    }



    protected void btnConsecutivos_Click(object sender, EventArgs e)
    {
        Response.Redirect("showCon.aspx");
    }

    protected void btnAerolineas_Click(object sender, EventArgs e)
    {
        Response.Redirect("verAerolineas.aspx");
    }

    protected void btnVuelos_Click(object sender, EventArgs e)
    {
        Response.Redirect("Vuelos.aspx");
    }

    protected void BtnPaises_Click(object sender, EventArgs e)
    {
        Response.Redirect("IndexPaises.aspx");
    }

    protected void BtnPuertas_Click(object sender, EventArgs e)
    {
        Response.Redirect("IndexPuertas.aspx");
    }
    protected void BtnUsuario_Click(object sender, EventArgs e)
    {
        Response.Redirect("NewUser.aspx");
    }
}
