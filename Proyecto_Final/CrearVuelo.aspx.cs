using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class CrearVuelo : System.Web.UI.Page
{
    //SqlConnection con = new SqlConnection("Data Source = localhost\\SQLEXPRESS; Initial Catalog = Vuelos; Integrated Security = True");
    protected void Page_Load(object sender, EventArgs e)
    {
        dpdEstado.Items.Clear();
        ListItem arribo = new ListItem("Arribó", "Arribó");
        ListItem salio = new ListItem("Salió", "Salió");
        ListItem confirmado = new ListItem("Confirmado", "Confirmado");
        ListItem demorado = new ListItem("Demorado", "Demorado");
        ListItem atiempo = new ListItem("A tiempo", "A tiempo");

        if (Session["Tipo"].Equals("Salida"))
        {
            lblTitulo.Text = "Crear Vuelo de Salida";
            lblTipo.Text = "Destino";

            dpdEstado.Items.Add(salio);
            dpdEstado.Items.Add(confirmado);
            dpdEstado.Items.Add(demorado);
            dpdEstado.Items.Add(atiempo);

        }

        else
        {
            lblTitulo.Text = "Crear Vuelo de Llegada";
            lblTipo.Text = "Procedencia";

            dpdEstado.Items.Add(arribo);
            dpdEstado.Items.Add(confirmado);
            dpdEstado.Items.Add(demorado);
            dpdEstado.Items.Add(atiempo);
        }


        

   
        
    }

    private void clearFields() {

        txtFecha.Text = "";
        txtPrecio.Text = "";
        dplCod.DataBind();
    }
 

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Vuelos.aspx");
    }

    protected void btnInsertar_Click(object sender, EventArgs e)
    {

        string horas = dplHoras.Text + ":" +dplMin.Text;
        string fecha = txtFecha.Text;

        try
        {
            if (txtFecha.Text.Equals("") || txtPrecio.Text.Equals(""))
            { ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('No blank spaces are allowed.')", true); }

          
            else
            {

                VueloDa.insertarVuelo(dplCod.Text, dplAero.Text, fecha, horas, dplluga.Text, Int32.Parse(txtPrecio.Text), dpdPuerta.Text, Session["Tipo"].ToString(), dpdEstado.Text);
                DatosBITACORA.agregarDato("Vuelo agregado " + dplCod.Text);
                VueloDa.sumarConsecutivoVuelo();
                clearFields();

            }
        }
        catch (Exception)
        { ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Invalid Data')", true);
            DatosBITACORA.agregarDato("Problema al agregar vuelo Invalid Data " + dplCod.Text);
        }

    }

  

   
}