using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ModificarPais : System.Web.UI.Page
{
    static byte[] ImagenOriginal;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string resultado = DatosPAISES.obtenerDatosModificar(Global.cod_pais);
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + resultado + "')", true);
            ImagenPais.ImageUrl = "data:Image/jpg;base64," + Global.imagen_pais;
            Cod_pais.Text = Global.cod_pais;
            Nombretxt.Text = Global.nombre_pais;
        }
    }


    protected void ModificarBtn_Click(object sender, EventArgs e)
    {
        if (Nombretxt.Text.Equals(""))
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Por favor ingrese un nombre de país válido')", true);
        }
        else
        {
            // Llama al procedimiento de DatosPAISES que inserta los datos en la BD
            string resultado = DatosPAISES.actualizarPais(ImagenOriginal, Nombretxt.Text, Cod_pais.Text);
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + resultado + "')", true);
            if (resultado.Equals("País actualizado exitosamente"))
            {
                Response.Redirect("http://localhost:53551/IndexPaises.aspx");
            }
        }
    }

    protected void SubirBtn_Click(object sender, EventArgs e)
    {
        if (SelectImag.HasFile == false)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Por favor suba una nueva imagen para el país que desea modificar')", true);
        }
        else
        {
            //Obtener datos de imagen
            int Tamanio = SelectImag.PostedFile.ContentLength;
            ImagenOriginal = new byte[Tamanio];
            SelectImag.PostedFile.InputStream.Read(ImagenOriginal, 0, Tamanio);


            string ImagenDataURL64 = "data:image/jpg;base64, " + Convert.ToBase64String(ImagenOriginal);
            ImagenPais.ImageUrl = ImagenDataURL64;
            ModificarBtn.Visible = true;
        }
    }

    protected void cancelarBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("http://localhost:53551/IndexPaises.aspx");
    }
}