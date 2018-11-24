using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class DeleteUser : System.Web.UI.Page
{
    SqlConnection conexion = new SqlConnection("data source= LAPTOP-L53C31U3\\SQLEXPRESS;initial catalog = Proyecto_final;" +
    "user id=Kevin;password=klobo;");
    SqlCommand com;

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void deleteBtn_Click(object sender, EventArgs e)
    {
        string sql;
        SqlDataReader rs;
        try
        {
            if (idTxt.Text.Equals(""))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('ID field cannot be blank')", true);
            }
            else
            {
                conexion.Open();
                sql = "SELECT * FROM Usuario WHERE cedula = '" + Int32.Parse(idTxt.Text) + "'";
                com = conexion.CreateCommand();
                com.CommandText = sql;
                rs = com.ExecuteReader();
                if (rs.Read())
                {
                    Session["cedula"] = rs[0];
                    conexion.Close();
                    com = new SqlCommand("DELETE FROM Usuario WHERE (cedula=@cedula)", conexion);
                    com.Parameters.AddWithValue("@cedula", idTxt.Text);
                    conexion.Open();
                    com.ExecuteNonQuery();
                    conexion.Close();
                    if (IsPostBack)
                    {
                        idTxt.Text = "";
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('User Deleted')", true);
                    }
                }
                else
                {
                    conexion.Close();
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('ID provided has no user linked.')", true);
                }
                
            }
        }
        catch (Exception)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Invalid values')", true);
        }
    }

    protected void cancelBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("IndexAdmin.aspx");
    }
}