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

    string desc = "";
    int next = 0;
    string pref = "";
    int ranIn = 0;
    int ranFi = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
       
        //Guardo valores del consecutivo a editar en variables para usarlos mas adelante   
        con.Open();
        SqlCommand vip = new SqlCommand(String.Format("Select descripcion,next_conse,prefijo,rango_inic,rango_fin from CONSECUTIVO where descripcion = '{0}' and codigo = '{1}' ", Session["vDes"], Session["vCon"]), con);
        SqlDataReader leer = vip.ExecuteReader();
        while (leer.Read())
        {
            desc = leer.GetString(0);
            next = leer.GetInt32(1);
            pref = leer.GetString(2);
            ranIn = leer.GetInt32(3);
            ranFi = leer.GetInt32(4);

        }
        ///***************************************************
        txtCon.Enabled = false;
        lblDes.Text = desc;
        txtCon.Text = next.ToString();

        ///**************************************************
        if (Page.IsPostBack != true)
        {
            txtPre.Enabled = false;
            txtRanFin.Enabled = false;
            txtRanIni.Enabled = false;

            if (pref != "")
            {
                txtPre.Text = pref;
            }

            if (ranIn == 0 && ranFi == 0)
            {
                txtRanFin.Text = "";
                txtRanIni.Text = "";
            }
            else
            {
                txtRanFin.Text = ranFi.ToString();
                txtRanIni.Text = ranIn.ToString();
            }

            txtPre.Enabled = false;
            if (pref != "")
            {
                txtPre.Enabled = true;
                chkPrefijo.Checked = true;
            }

            txtRanFin.Enabled = false;
            txtRanIni.Enabled = false;

            if (ranIn != 0 || ranFi != 0)
            {
                txtRanFin.Enabled = true;
                txtRanIni.Enabled = true;
                chkRango.Checked = true;
            }
        }

    }



    public void cleanText()
    {
        txtCon.Text = "";
        txtPre.Text = "";
        txtRanFin.Text = "";
        txtRanIni.Text = "";

    }
    private void updateCon(string prefi, int rangi, int ranfi, string codigo)
    {
        con.Close();
        con.Open();
        SqlCommand com = new SqlCommand("UPDATE CONSECUTIVO SET descripcion=@a1,next_conse=@a2,prefijo=@a3,rango_inic=@a4,rango_fin=@a5,codigo=@a6 where descripcion = '" + Session["vDes"] + "' and codigo = '" + Session["vCon"] + "'", con);
        com.Parameters.AddWithValue("a1", desc);
        com.Parameters.AddWithValue("a2", next);
        com.Parameters.AddWithValue("a3", prefi);
        com.Parameters.AddWithValue("a4", rangi);
        com.Parameters.AddWithValue("a5", ranfi);
        com.Parameters.AddWithValue("a6", codigo);
        com.ExecuteNonQuery();
        con.Close();

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
            txtPre.Text = "";
        }

    }

    protected void chkRango_CheckedChanged(object sender, EventArgs e)
    {
          if (((CheckBox)sender).Checked)
        {
            txtRanIni.Enabled = false;
            txtRanIni.Text = next.ToString();
            txtRanFin.Enabled = true;
        }
        else
        {
            txtRanIni.Enabled = false;
            txtRanFin.Enabled = false;
            txtRanFin.Text = "";
            txtRanIni.Text = "";
        }

    }



    protected void btnAceptar_Click(object sender, EventArgs e)
    {
        try
        {
            if (chkPrefijo.Checked == true && chkRango.Checked == true)
            {

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
                    updateCon(txtPre.Text, next, Int32.Parse(txtRanFin.Text), txtPre.Text + next);
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Consecutivo Editado')", true);
                }
            }

            else if (chkPrefijo.Checked == true && chkRango.Checked == false)
            {
                if (txtCon.Text.Equals("") || txtPre.Text.Equals(""))
                { ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('No blank spaces are allowed.')", true); }

                else
                {
                    updateCon(txtPre.Text, 0, 0, txtPre.Text + next);
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Consecutivo Editado')", true);
                }
            }

            else if (chkPrefijo.Checked == false && chkRango.Checked == true)
            {
                if (txtRanFin.Text.Equals("") || txtRanIni.Text.Equals(""))
                { ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('No blank spaces are allowed.')", true); }
                //verificar que el rango inicial sea menor al rango final
                else if (Convert.ToInt32(txtRanFin.Text) < Convert.ToInt32(txtRanIni.Text))
                { ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Invalid Ranks')", true); }
                //verificar que el numero de consecutivo este dentro del rango
                else if (Convert.ToInt32(txtCon.Text) > Convert.ToInt32(txtRanFin.Text) || Convert.ToInt32(txtCon.Text) < Convert.ToInt32(txtRanIni.Text))
                { ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Do not meet ranks')", true); }

                else
                {
                    updateCon("", next, Int32.Parse(txtRanFin.Text), "" + next);
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Consecutivo Editado')", true);
                }
            }
            else if (chkPrefijo.Checked == false && chkRango.Checked == false)
            {
                updateCon("", 0, 0, "" + next);
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Consecutivo Editado')", true);
            }
        }
        catch (Exception)
        { ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Invalid Data')", true); }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("showCon.aspx");
    }
}

