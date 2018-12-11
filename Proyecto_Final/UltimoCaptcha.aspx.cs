using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UltimoCaptcha : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public bool CaptchaValidate()
    {
        string ResponseByGoogle = Request["g-recaptcha-response"];

        string CaptchaSecretKey = "6LfnN4AUAAAAAJm-GDYwST1UBuMSJKLAypBRqLB5";
        bool Valid = false;

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
        if (CaptchaValidate()== true) {

            lbltest.Text = "si autentico bien";
        }

        else if (CaptchaValidate() == false)
        {

            lbltest.Text = "por favor autentique robot de pich";

        }
       
    }
}