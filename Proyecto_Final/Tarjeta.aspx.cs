using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Tarjeta : System.Web.UI.Page
{
    bool Valid = false;
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
                break;
        }
        CaptchaValidate();
        if (Valid == false)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Por favor valide el captcha')", true);
        }
        else if (mesTxt.Text.Equals("Mes de expiración") || annoTxt.Text.Equals("Año de expiración") || nombreTxt.Text.Equals("") || tarjetaTxt.Text.Equals("") || codTxt.Text.Equals("") || TipoTxt.Text.Equals("Tipo de tarjeta"))
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
            resultado = servicio.GetTarjeta(Int32.Parse(codTxt.Text), Int32.Parse(tarjetaTxt.Text), nombreTxt.Text, 500, Int32.Parse(annoTxt.SelectedValue), Int32.Parse(mesTxt.SelectedValue), tipotarjeta);
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
    public bool CaptchaValidate()
    {
        string ResponseByGoogle = Request["g-recaptcha-response"];

        string CaptchaSecretKey = "6LfnN4AUAAAAAJm-GDYwST1UBuMSJKLAypBRqLB5";
        

        HttpWebRequest req = (HttpWebRequest)WebRequest.Create("https://www.google.com/recaptcha/api/siteverify?secret=" + CaptchaSecretKey + "&response=" + ResponseByGoogle);

        try
        {
            using (WebResponse wResponse = req.GetResponse())
            {
                using (StreamReader readStream = new
                    StreamReader(wResponse.GetResponseStream()))
                {
                    string jsonResponse = readStream.ReadToEnd();

                    JavaScriptSerializer js = new JavaScriptSerializer();
                    CaptchaValidate data = js.Deserialize<CaptchaValidate>(jsonResponse);

                    Valid = Convert.ToBoolean(data.success);


                }
            }

            return Valid;
        }
        catch (WebException ex)
        {
            throw ex;
        }
    }
    protected void btntest_Click(object sender, EventArgs e)
    {
        if (CaptchaValidate() == true)
        {

            lbltest.Text = "Validación correcta";
        }

        else if (CaptchaValidate() == false)
        {

            lbltest.Text = "Validación incorrecta";

        }

    }
}