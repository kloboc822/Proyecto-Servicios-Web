using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class NewUser : System.Web.UI.Page
{
    SqlConnection conexion = new SqlConnection("data source= LAPTOP-L53C31U3\\SQLEXPRESS;initial catalog = Proyecto_final;" +
    "user id=Kevin;password=klobo;");
    SqlCommand com;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack)
        {
            
        }
    }

    protected void cancelBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("IndexAdmin.aspx");
    }

    protected void createBtn_Click(object sender, EventArgs e)
    {
        try
        {
            if (idTxt.Text.Equals("") || passwordTxt.Text.Equals("") || firstnameTxt.Text.Equals("") || surname1Txt.Text.Equals("") || surname2Txt.Text.Equals("") || emailTxt.Text.Equals(""))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('All spaces must have info.')", true);
            }
            else
            {
                com = new SqlCommand("INSERT INTO Usuario(cedula, contraseña, nombre, apellido1, apellido2, email, tipo_usuario) VALUES(@cedula, PWDENCRYPT(@contraseña), @nombre, @apellido1, @apellido2, @email, @tipo_usuario)", conexion);
                com.Parameters.AddWithValue("@cedula", Int32.Parse(idTxt.Text));
                com.Parameters.AddWithValue("@contraseña", passwordTxt.Text);
                com.Parameters.AddWithValue("@nombre", firstnameTxt.Text);
                com.Parameters.AddWithValue("@apellido1", surname1Txt.Text);
                com.Parameters.AddWithValue("@apellido2", surname2Txt.Text);
                com.Parameters.AddWithValue("@email", emailTxt.Text);
                if (tipouserTxt.Text.Equals("Admin"))
                {
                    com.Parameters.AddWithValue("@tipo_usuario", true);
                }
                else
                {
                    com.Parameters.AddWithValue("@tipo_usuario", false);
                }

                conexion.Open();
                com.ExecuteNonQuery();
                conexion.Close();

                //if (IsPostBack)
                //{
                //    idTxt.Text = "";
                //    passwordTxt.Text = "";
                //    firstnameTxt.Text = "";
                //    surname1Txt.Text = "";
                //    surname2Txt.Text = "";
                //    emailTxt.Text = "";
                //}
                Response.Redirect("IndexAdmin.aspx");
            }
        }
        catch (Exception)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('ERROR - DATA IS NOT VALID \n Please remember that ID can be filled out with numbers only.')", true);
        }
    }
}