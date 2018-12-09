﻿using System;
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


        txtFecha.Enabled = false;

   
        
      

    }

 

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Vuelos.aspx");
    }

    protected void btnInsertar_Click(object sender, EventArgs e)
    {

        string horas = dplHoras.Text + ":" +dplMin.Text;
        string fecha = Calendar1.SelectedDate.ToString("m");

        try
        {
            if (txtFecha.Text.Equals("") || txtLugar.Text.Equals("") || txtPrecio.Text.Equals(""))
            { ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('No blank spaces are allowed.')", true); }

            else if (Calendar1.SelectedDate < DateTime.Today)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Fecha Invalida')", true);
            }
            else
            {

                VueloDa.insertarVuelo(dplCod.Text, dplAero.Text, fecha, horas, txtLugar.Text, Int32.Parse(txtPrecio.Text), dpdPuerta.Text, Session["Tipo"].ToString(), dpdEstado.Text);
                VueloDa.sumarConsecutivoVuelo();

            }
        }
        catch (Exception)
        { ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Invalid Data')", true); }

    }

    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        txtFecha.Text = Calendar1.SelectedDate.ToString("m");
    }

   
}