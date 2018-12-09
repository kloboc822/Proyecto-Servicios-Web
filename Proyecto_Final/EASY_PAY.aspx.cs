using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EASY_PAY : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void pagar_Click(object sender, EventArgs e)
    {
        string resultado = "";
        WebServicePago.Service1Client servicio = new WebServicePago.Service1Client();
        resultado = servicio.GetCuenta(Int32.Parse(CodTxt.Text), Int32.Parse(CuentaTxt.Text), ContrasenaTxt.Text, 500);
        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + resultado + "')", true);
    }
}