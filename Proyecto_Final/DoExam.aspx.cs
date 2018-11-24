using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class DoExam : System.Web.UI.Page
{
    SqlConnection conexion = new SqlConnection("data source= LAPTOP-L53C31U3\\SQLEXPRESS;initial catalog = Proyecto_final;" +
    "user id=Kevin;password=klobo;");
    SqlCommand com;
    int cantPreg = 0;
    int codigoExamen = 0;
    int cont = 1, cont2 = 1;
    string codPreg = "", codResp = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        //respuestasRB.Items.FindByValue("1").Text = "HOla";
        string sql;
        SqlDataReader rs,rs2;
        try
        {
            conexion.Open();
            sql = "SELECT cod_prueba FROM Prueba WHERE nombre = '" + Global.examName + "'";
            com = conexion.CreateCommand();
            com.CommandText = sql;
            rs = com.ExecuteReader();
            if (rs.Read())
            {
                codigoExamen = Int32.Parse(rs[0].ToString());
            }
            conexion.Close();

            conexion.Open();
            sql = "SELECT count(*) FROM Pregunta WHERE cod_prueba = '" + codigoExamen + "'";
            com = conexion.CreateCommand();
            com.CommandText = sql;
            cantPreg = (Int32)com.ExecuteScalar();
            conexion.Close();

            codPreg = codigoExamen + "." + cont;

            conexion.Open();
            sql = "SELECT * FROM Pregunta WHERE cod_pregunta = '" + codPreg + "'";
            com = conexion.CreateCommand();
            com.CommandText = sql;
            rs2 = com.ExecuteReader();
            if (rs2.Read())
            {
                Session["pregunta"] = rs2[3].ToString();
                Response.Write(preguntaTxt.Text = Session["pregunta"].ToString());
            }
            conexion.Close();

            while (cont2<5)
            {
                codResp = codPreg + "." + cont2;

                conexion.Open();
                sql = "SELECT * FROM Respuesta WHERE cod_respuesta = '" + codResp + "'";
                com = conexion.CreateCommand();
                com.CommandText = sql;
                rs = com.ExecuteReader();
            if (rs.Read())
            {
                respuestasRB.Items.FindByValue(cont2.ToString()).Text = rs[1].ToString();
            }
                cont2++;
                conexion.Close();
            }
            cont2 = 0;


        }
        catch (Exception)
        {
            throw;
        }

    }

    protected void submit_Click(object sender, EventArgs e)
    {

    }
}