using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Tarjeta : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void pagar_Click(object sender, EventArgs e)
    {
        string resultado = "";
        int temp = 0;
        string tipotarjeta = "";
        switch (TipoTxt.Text)
        {
            case "VISA":
                tipotarjeta = "V";
                break;
            case "Mastercard":
                tipotarjeta = "M";
                break;
            case "American Express":
                tipotarjeta = "A";
                break;
            default:
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert(' Por favor elija un tipo de reunión ')", true);
                break;
        }
        if (mesTxt.Text.Equals("Mes de expiración") || annoTxt.Text.Equals("Año de expiración") || nombreTxt.Text.Equals("") || tarjetaTxt.Text.Equals("") || codTxt.Text.Equals("") || TipoTxt.Text.Equals("Tipo de tarjeta"))
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Por favor llene todos los campos que se le solicitan')", true);
        }
        else if (!int.TryParse(codTxt.Text, out temp) || !int.TryParse(tarjetaTxt.Text, out temp))
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Sólo se admiten números en los campos número de tarjeta y código de seguridad')", true);
        }
        else
        {
            NewService.Service1Client servicio = new NewService.Service1Client();
            resultado = servicio.GetTarjeta(Int32.Parse(codTxt.Text), Int32.Parse(tarjetaTxt.Text),nombreTxt.Text,500, Int32.Parse(annoTxt.SelectedValue), Int32.Parse(mesTxt.SelectedValue), tipotarjeta);
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + resultado + "')", true);

            try
            {
                VueloDa.registrarCompra();
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Compra Registrada con Exito')", true);
            }
            catch (Exception s)
            {
                string error = s.ToString();
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('ERROR REGISTRANDO COMPRA, CONTACTE A SU DESARROLLADOR')", true);
                throw;
            }

        }
    }
}