using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EASY_PAY : System.Web.UI.Page
{
    bool Valid = false;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void pagar_Click(object sender, EventArgs e)
    {
        string resultado = "";
        int temp = 0;
        CaptchaValidate();
        if (Valid == false)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Por favor valide el captcha')", true);
        }
        else if (CodTxt.Text.Equals("") || CuentaTxt.Text.Equals(""))
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Por favor llene todos los campos que se le solicitan')", true);
        }
        else if (!int.TryParse(CodTxt.Text, out temp) || !int.TryParse(CuentaTxt.Text, out temp))
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Sólo se admiten números en los campos número de cuenta y código de seguridad')", true);
        }
        else
        {
            NewService.Service1Client servicio = new NewService.Service1Client();
            resultado = servicio.GetCuenta(Int32.Parse(CodTxt.Text), Int32.Parse(CuentaTxt.Text), ContrasenaTxt.Text, 500);
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + resultado + "')", true);

            try
            {
                VueloDa.registrarCompra();
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Compra Registrada con Exito')", true);
            }
            catch (Exception s)
            {
                string error = s.ToString();
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('ERROR EN EL REGISTRO DE LA COMPRA, CONTACTE A SU DESARROLLADOR')", true);
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