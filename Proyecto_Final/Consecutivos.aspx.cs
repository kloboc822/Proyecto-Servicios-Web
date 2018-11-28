using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class Consecutivos : System.Web.UI.Page

{

    SqlConnection con = new SqlConnection("Data Source = localhost\\SQLEXPRESS; Initial Catalog = Vuelos; Integrated Security = True");
    protected void Page_Load(object sender, EventArgs e)
    {
       

    }

    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        //variable para concatenar prefijo con numero de consecutivo
        string ver = txtPre.Text + txtCon.Text;
        //**********Programa entra aqui si la persona va a crear un prefijo nuevo
        if (dplPre.Enabled == false)
        {
            try
            {
                //verificar que no existan espacios vacios
                if (txtCon.Text.Equals("") || txtPre.Text.Equals("") || txtRanFin.Text.Equals("") || txtRanIni.Text.Equals(""))
                { ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('No blank spaces are allowed.')", true); }
                //verificar que el rango inicial sea menor al rango final
                else if (Convert.ToInt32(txtRanFin.Text) < Convert.ToInt32(txtRanIni.Text))
                { ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Invalid Ranks')", true); }
                //verificar que el numero de consecutivo este dentro del rango
                else if (Convert.ToInt32(txtCon.Text) > Convert.ToInt32(txtRanFin.Text) || Convert.ToInt32(txtCon.Text) < Convert.ToInt32(txtRanIni.Text))
                { ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Do not meet ranks')", true);}


                else
                { //verificar si se crea un prefijo que ya existe
                    con.Open();
                    SqlCommand com1 = new SqlCommand("SELECT prefijo FROM CONSECUTIVO WHERE prefijo = '" + txtPre.Text + "'", con);
                    SqlDataReader leer = com1.ExecuteReader();
                    if (leer.Read())
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Prefijo ya Existe')", true);
                        con.Close();
                    }

                    else
                    {
                        //Agregar nuevo consecutivo, su rango y prefijo
                        con.Close();
                        SqlCommand com = new SqlCommand("INSERT INTO CONSECUTIVO(descripcion,prefijo, rango_inic, rango_fin) VALUES(@descripcion, @prefijo, @rainicial, @rafinal)", con);
                        com.Parameters.AddWithValue("@descripcion", dplDesc.Text);
                        com.Parameters.AddWithValue("@prefijo", txtPre.Text);
                        com.Parameters.AddWithValue("@rainicial", Int32.Parse(txtRanIni.Text));
                        com.Parameters.AddWithValue("@rafinal", Int32.Parse(txtRanFin.Text));

                        con.Open();
                        com.ExecuteNonQuery();
                        con.Close();

                        //Agregar nuevo Codigo de consecutivo a la tabla codigos (agregar consecutivo mas prefijo concatenado)
                        con.Open();
                        SqlCommand com2 = new SqlCommand("INSERT INTO CODIGOS(codigo,descripcion) VALUES(@codigo, @descripcion)", con);
                        com2.Parameters.AddWithValue("@codigo", ver);
                        com2.Parameters.AddWithValue("@descripcion", dplDesc.Text);
                        com2.ExecuteNonQuery();
                        con.Close();
                        //Limpia textboxes cuando se agrega un consecutivo
                        dplPre.DataBind();
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Consecutivo Agregado')", true);
                        txtCon.Text = "";
                        txtPre.Text = "";
                        txtRanFin.Text = "";
                        txtRanIni.Text = "";

                    }

                }

            }
            catch (Exception)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Invalid Data')", true);
            }
        }
        //**********Programa entra aqui si la persona va a crear un consecutivo nuevo a partir de un prefijo ya creado
       
        else
        {
            try
            {
                //verifica que no deje el espacio de consecutivo vacio
                if (txtCon.Text.Equals(""))
                { ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('No blank spaces are allowed.')", true); }

                else
                {
                    string ver2 = dplPre.Text + txtCon.Text; //varaible para concatenar prefijo con numero de consecutivo
                    con.Open();
                    //revisa en la tabla codigo que no exista una combinacion de codigo igual
                    SqlCommand com1 = new SqlCommand("SELECT codigo FROM CODIGOS WHERE codigo = '" + ver2 + "'", con);
                    SqlDataReader leer = com1.ExecuteReader();
                    if (leer.Read())
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Consecutivo ya existe')", true);
                        con.Close();
                    }

                    else
                    {
                        con.Close();
                        int rangini = 0;
                        int rangfina = 0;
                        //Obtener valor de rangos ya creados
                        con.Open();
                        SqlCommand comando = new SqlCommand(String.Format("Select rango_inic,rango_fin from CONSECUTIVO where prefijo = '{0}'", dplPre.Text), con);
                        SqlDataReader red = comando.ExecuteReader();
                        while (red.Read())
                        {
                            rangini = red.GetInt32(0);
                            rangfina = red.GetInt32(1);
                        }
                        con.Close();
                        //Revisar que el nuevo consecutivo cumpla los rangos
                        if (Convert.ToInt32(txtCon.Text) > rangfina || Convert.ToInt32(txtCon.Text) < rangini)
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Do not meet ranks')", true);
                        }
                        else
                        {
                            //Se agrega nuevo codigo a la tabla codigos
                            con.Close();
                            SqlCommand com3 = new SqlCommand("INSERT INTO CODIGOS(codigo,descripcion) VALUES(@codigo, @descripcion)", con);
                            com3.Parameters.AddWithValue("@codigo", ver2);
                            com3.Parameters.AddWithValue("@descripcion", dplDesc.Text);
                            con.Open();
                            com3.ExecuteNonQuery();
                            con.Close();
                            //cuando se agrega un nuevo consecutivo limpia los textboxes
                            dplPre.DataBind();
                            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Consecutivo Agregado')", true);
                            txtCon.Text = "";
                            txtPre.Text = "";
                            txtRanFin.Text = "";
                            txtRanIni.Text = "";
                        }
                    }
                }
            }
            catch (Exception)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Invalid Data')", true);
            }
        }
       
    }

    //metodo que controla boton cuando el usuario quiere crear un consecutivo con un prefijo nuevo o uno existente
    protected void btnEna_Click(object sender, EventArgs e)
    {
        if (dplPre.Enabled == true) { dplPre.Enabled = false; btnEna.Text = "Si";
            btnVerDa.Enabled = false;
            txtRanFin.Enabled = true;
            txtRanIni.Enabled = true;
            txtPre.Enabled = true;
        }

        else if (dplPre.Enabled == false) { dplPre.Enabled = true; btnEna.Text = "No";
            btnVerDa.Enabled = true;
            txtRanFin.Enabled = false;
            txtRanIni.Enabled = false;
            txtPre.Enabled = false;
        }
      
    
    }
    //metodo que muestra los datos de un prefijo ya existente en caso de que sea necesario
    protected void btnVerDa_Click(object sender, EventArgs e)
    {
        con.Open();
        SqlCommand comando = new SqlCommand(String.Format("Select prefijo,rango_inic,rango_fin from CONSECUTIVO where prefijo = '{0}'", dplPre.Text), con);
        SqlDataReader red = comando.ExecuteReader();
        while (red.Read())
        {
            txtPre.Text = red.GetString(0);
            txtRanIni.Text = red.GetInt32(1).ToString();
            txtRanFin.Text = red.GetInt32(2).ToString();
        }
        con.Close();
    }

    protected void btnVer_Click(object sender, EventArgs e)
    {
        Response.Redirect("showCon.aspx");
    }
}
