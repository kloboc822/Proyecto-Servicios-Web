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
        int temp = 0;
        if (CodTxt.Text.Equals("") || CuentaTxt.Text.Equals(""))
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Por favor llene todos los campos que se le solicitan')", true);
        }
        else if (!int.TryParse(CodTxt.Text, out temp) || !int.TryParse(CuentaTxt.Text, out temp))
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Sólo se admiten números en los campos número de cuenta y código de seguridad')", true);
        }
        else
        {
            WebServicePago.Service1Client servicio = new WebServicePago.Service1Client();
            resultado = servicio.GetCuenta(Int32.Parse(CodTxt.Text), Int32.Parse(CuentaTxt.Text), ContrasenaTxt.Text, 500);
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + resultado + "')", true);
        }
    }
}