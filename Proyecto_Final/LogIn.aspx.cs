using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;


public partial class LogIn : System.Web.UI.Page
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

    protected void loginBtn_Click(object sender, EventArgs e)
    {
        string sql;
        SqlDataReader rs;

        conexion.Open();
        Global.firstname = usernameTxt.Text;
        try
        {
            sql = "SELECT * FROM Usuario WHERE cedula = '" + Int32.Parse(usernameTxt.Text) +
            "' and PWDCOMPARE('" + passwordTxt.Text + "', contraseña) = 1";
            com = conexion.CreateCommand();
            com.CommandText = sql;
            rs = com.ExecuteReader();
            if (rs.Read())
            {
                Session["cedula"] = rs[0];
                Global.id = Int32.Parse(rs[0].ToString());
                Session["tipo_usuario"] = rs[6];
                Global.userType = Convert.ToBoolean(rs[6].ToString());

                if (Global.userType)
                {
                    Response.Redirect("IndexAdmin.aspx");
                }
                else
                {
                    Response.Redirect("Index.aspx");
                }

            }
            conexion.Close();
        }
        catch (Exception)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Data is not valid')", true);
        }
        
    }
}