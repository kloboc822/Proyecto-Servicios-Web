using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Drawing;

public partial class AgregarPais : System.Web.UI.Page
{
    static byte[] ImagenOriginal;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void SubirBtn_Click(object sender, EventArgs e)
    {
        //Valida que se haya elegido una imagen
        string resultado = DatosPAISES.verificarPais(Cod_pais.SelectedValue, Nombretxt.Text);
        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + resultado + "')", true);
        if (resultado.Equals("El código/nombre seleccionado ya fue asignado a un país, por favor compruebe con soporte el código correspondiente"))
        {
            Nombretxt.Text = "";
            SelectImag.Attributes.Clear();
            ImagenPais.ImageUrl = "~/images/search-engine-optimisation-settings-17.png";
        }
        else
        {
            if (SelectImag.HasFile == false)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Por favor suba una imagen en representación al país que desea agregar')", true);
            }
            else
            {
                //Obtener datos de imagen
                int Tamanio = SelectImag.PostedFile.ContentLength;
                ImagenOriginal = new byte[Tamanio];
                SelectImag.PostedFile.InputStream.Read(ImagenOriginal, 0, Tamanio);


                string ImagenDataURL64 = "data:image/jpg;base64, " + Convert.ToBase64String(ImagenOriginal);
                ImagenPais.ImageUrl = ImagenDataURL64;
                AgregarBtn.Visible = true;
            }
        }



    }

    protected void AgregarBtn_Click(object sender, EventArgs e)
    {
        //valida que todos los datos se hayan ingresado antes de ingresar a la BD
        if (Cod_pais.SelectedValue.Equals("") || Nombretxt.Text.Equals(""))
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Por favor ingrese un código y nombre de país válidos')", true);
        }
        else
        {
            // Llama al procedimiento de DatosPAISES que inserta los datos en la BD
            string resultado = DatosPAISES.agregarPais(ImagenOriginal, Nombretxt.Text, Cod_pais.SelectedValue);
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + resultado + "')", true);
            if (resultado.Equals("País agregado con éxito."))
            {
                DatosPAISES.sumarConsecutivoPais();
                Response.Redirect("http://localhost:53551/IndexPaises.aspx");
            }
        }
    }

    protected void cancelarBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("http://localhost:53551/IndexPaises.aspx");
    }
}