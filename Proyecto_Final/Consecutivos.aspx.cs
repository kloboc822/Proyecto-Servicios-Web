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
        if (Page.IsPostBack != true)
        {
            txtPre.Enabled = false;
            txtRanFin.Enabled = false;
            txtRanIni.Enabled = false;
        }

    }

    public void addConsecutivo(string descripcion, string prefijo, int rangoIni,int rangoFin,int consecutivo) {
        //Agregar nuevo consecutivo, su rango y prefijo
        con.Close();
        SqlCommand com = new SqlCommand("INSERT INTO CONSECUTIVO(descripcion,prefijo, rango_inic, rango_fin,next_conse,codigo) VALUES(@descripcion, @prefijo, @rainicial, @rafinal,@next,@codigo)", con);
        com.Parameters.AddWithValue("@descripcion", descripcion);
        com.Parameters.AddWithValue("@prefijo", prefijo);
        com.Parameters.AddWithValue("@rainicial", rangoIni);
        com.Parameters.AddWithValue("@rafinal", rangoFin);
        com.Parameters.AddWithValue("@next",consecutivo);
        com.Parameters.AddWithValue("@codigo",prefijo+consecutivo);
        con.Open();
        com.ExecuteNonQuery();
        con.Close();

    
      
    }

    public void cleanText()
    {
        txtCon.Text = "";
        txtPre.Text = "";
        txtRanFin.Text = "";
        txtRanIni.Text = "";

    }

    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        //Verificar si ya existe un consecutivo para esa descripcion
        con.Open();
        SqlCommand com1 = new SqlCommand("SELECT descripcion FROM CONSECUTIVO WHERE descripcion = '" + dplDesc.Text + "'", con);
        SqlDataReader leer = com1.ExecuteReader();
        if (leer.Read())
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Ya existe consecutivo para esta descripcion')", true);
            con.Close();
        }

        else
        {
            try
            {  //**********Programa entra aqui si la persona crea un consecutivo con prefijo y rango
                if (chkPrefijo.Checked == true && chkRango.Checked == true)
                {
                    con.Close();
                    //verificar que no existan espacios vacios
                    if (txtCon.Text.Equals("") || txtPre.Text.Equals("") || txtRanFin.Text.Equals("") || txtRanIni.Text.Equals(""))
                    { ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('No blank spaces are allowed.')", true); }
                    //verificar que el rango inicial sea menor al rango final
                    else if (Convert.ToInt32(txtRanFin.Text) < Convert.ToInt32(txtRanIni.Text))
                    { ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Invalid Ranks')", true); }
                    //verificar que el numero de consecutivo este dentro del rango
                    else if (Convert.ToInt32(txtCon.Text) > Convert.ToInt32(txtRanFin.Text) || Convert.ToInt32(txtCon.Text) < Convert.ToInt32(txtRanIni.Text))
                    { ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Do not meet ranks')", true); }

                    else
                    {
                        //Agregar nuevo consecutivo, su rango y prefijo               
                        addConsecutivo(dplDesc.Text, txtPre.Text, Int32.Parse(txtRanIni.Text), Int32.Parse(txtRanFin.Text), Int32.Parse(txtCon.Text));
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Consecutivo Agregado')", true);
                        cleanText();
                    }

                }
                //**********Programa entra aqui si alguno de los checks no esta marcado

                //se agrega consecutivo cuando quiere prefijo pero no rango
                else if (chkPrefijo.Checked == true && chkRango.Checked == false)
                {
                    if (txtCon.Text.Equals("") || txtPre.Text.Equals(""))
                    { ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('No blank spaces are allowed.')", true); }
                    else
                    {
                        addConsecutivo(dplDesc.Text, txtPre.Text, 0, 0, Int32.Parse(txtCon.Text));
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Consecutivo Agregado')", true);
                        cleanText();
                    }
                }

                //se agrega consecutivo cuando quiere rango pero no prefijo
                else if (chkPrefijo.Checked == false && chkRango.Checked == true)
                {
                    if (txtCon.Text.Equals("") || txtRanFin.Text.Equals("") || txtRanIni.Text.Equals(""))
                    { ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('No blank spaces are allowed.')", true); }
                    //verificar que el rango inicial sea menor al rango final
                    else if (Convert.ToInt32(txtRanFin.Text) < Convert.ToInt32(txtRanIni.Text))
                    { ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Invalid Ranks')", true); }
                    //verificar que el numero de consecutivo este dentro del rango
                    else if (Convert.ToInt32(txtCon.Text) > Convert.ToInt32(txtRanFin.Text) || Convert.ToInt32(txtCon.Text) < Convert.ToInt32(txtRanIni.Text))
                    { ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Do not meet ranks')", true); }

                    else
                    {
                        addConsecutivo(dplDesc.Text, "", Int32.Parse(txtRanIni.Text), Int32.Parse(txtRanFin.Text), Int32.Parse(txtCon.Text));
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Consecutivo Agregado')", true);
                        cleanText();
                    }
                }

                //Se agrega consecutivo cuando no quiere rango ni prefijo
                else if (chkPrefijo.Checked == false && chkRango.Checked == false)
                {
                    if (txtCon.Text.Equals(""))
                    { ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('No blank spaces are allowed.')", true); }
                    else
                    {
                        addConsecutivo(dplDesc.Text, "", 0,0, Int32.Parse(txtCon.Text));
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Consecutivo Agregado')", true);
                        cleanText();
                    }
                }

            }  catch (Exception)
        {  ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Invalid Data')", true); }
    }
    }
    
    //metodo que muestra los datos de un prefijo ya existente en caso de que sea necesario
    //protected void btnVerDa_Click(object sender, EventArgs e)
    //{
    //    con.Open();
    //    SqlCommand comando = new SqlCommand(String.Format("Select prefijo,rango_inic,rango_fin from CONSECUTIVO where prefijo = '{0}'", dplPre.Text), con);
    //    SqlDataReader red = comando.ExecuteReader();
    //    while (red.Read())
    //    {
    //        txtPre.Text = red.GetString(0);
    //        txtRanIni.Text = red.GetInt32(1).ToString();
    //        txtRanFin.Text = red.GetInt32(2).ToString();
    //    }
    //    con.Close();
    //}

    protected void btnVer_Click(object sender, EventArgs e)
    {
        Response.Redirect("showCon.aspx");
    }


    protected void chkPrefijo_CheckedChanged(object sender, EventArgs e)
    {
        if (((CheckBox)sender).Checked)
        {
            txtPre.Enabled = true;
        }
        else
        {
            txtPre.Enabled = false;
        }

    }

    protected void chkRango_CheckedChanged(object sender, EventArgs e)
    {
          if (((CheckBox)sender).Checked)
        {
            txtRanIni.Enabled = true;
            txtRanFin.Enabled = true;
        }
        else
        {
            txtRanIni.Enabled = false;
            txtRanFin.Enabled = false;
        }

    }

   
}
