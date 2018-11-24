using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class CreateExam : System.Web.UI.Page
{
    SqlConnection conexion = new SqlConnection("data source= LAPTOP-L53C31U3\\SQLEXPRESS;initial catalog = Proyecto_final;" +
    "user id=Kevin;password=klobo;");
    SqlCommand com;

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void submit_Click(object sender, EventArgs e)
    {
        string sql;
        SqlDataReader rs;
        try
        {
            Panel2.Visible = true;
            numPregTxt.Text = "Question #" + Global.cont;

            if (cod_pruebaTxt.Text.Equals("") || nombreTxt.Text.Equals("") || descripcionTxt.Text.Equals("") || cantpreguntasTxt.Text.Equals("") || puntajeTxt.Text.Equals("") || materiaTxt.Text.Equals("--Please select the Subject--"))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('No blank spaces are allowed.')", true);
            }
            else if (Int32.Parse(cantpreguntasTxt.Text) < 1 || Int32.Parse(cantpreguntasTxt.Text) > 10)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Number of questions cannot be 0, maximum is 10.')", true);
            }
            else if (Int32.Parse(puntajeTxt.Text) < 1 || Int32.Parse(puntajeTxt.Text) > 100)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Total points available should be between 1 and 100.')", true);
            }
            else
            {
                conexion.Open();
                sql = "SELECT cod_prueba FROM Prueba WHERE cod_prueba = '" + Int32.Parse(cod_pruebaTxt.Text) + "'";
                com = conexion.CreateCommand();
                com.CommandText = sql;
                rs = com.ExecuteReader();
                if (rs.Read())
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Exam code already exists')", true);
                    conexion.Close();
                }
                else
                {
                    conexion.Close();
                    com = new SqlCommand("INSERT INTO Prueba(cod_prueba, nombre, descripcion, topico, puntaje_total) VALUES(@cod_prueba, @nombre, @descripcion, @topico, @puntaje_total)", conexion);
                    com.Parameters.AddWithValue("@cod_prueba", Int32.Parse(cod_pruebaTxt.Text));
                    com.Parameters.AddWithValue("@nombre", nombreTxt.Text);
                    com.Parameters.AddWithValue("@descripcion", descripcionTxt.Text);
                    com.Parameters.AddWithValue("@topico", materiaTxt.Text);
                    com.Parameters.AddWithValue("@puntaje_total", Int32.Parse(puntajeTxt.Text));
                    Global.cantpregExam = Int32.Parse(cantpreguntasTxt.Text);

                    conexion.Open();
                    com.ExecuteNonQuery();
                    conexion.Close();

                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Data Submitted')", true);
                }
            }
        }
        catch (Exception)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('ERROR - DATA IS NOT VALID \n Exam code cannot be duplicated')", true);
        }
    }

    protected void addBtn_Click(object sender, EventArgs e)
    {
        try
        {
            if (descripcionPregTxt.Text.Equals("") || puntajePregTxt.Text.Equals("") || resp1Txt.Text.Equals("") || resp2Txt.Text.Equals("") || resp3Txt.Text.Equals("") || resp4Txt.Text.Equals(""))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('No blank spaces are allowed.')", true);
            }
            else if (Int32.Parse(puntajePregTxt.Text) < 1 || Int32.Parse(puntajePregTxt.Text) > 100)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Question value cannot exceed exam total value, or cannot be 0')", true);
            }
            else if (respCorrectaTxt.SelectedValue.Equals(""))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Please select a correct answer.')", true);
            }
            else
            {
                string codigoPreg = String.Concat(cod_pruebaTxt.Text,".", Global.cont);
                com = new SqlCommand("INSERT INTO Pregunta(cod_pregunta, cod_prueba, puntaje, descripcion) VALUES(@cod_pregunta, @cod_prueba, @puntaje, @descripcion)", conexion);
                com.Parameters.AddWithValue("@cod_pregunta", codigoPreg);
                com.Parameters.AddWithValue("@cod_prueba", Int32.Parse(cod_pruebaTxt.Text));
                com.Parameters.AddWithValue("@puntaje", Int32.Parse(puntajePregTxt.Text));
                com.Parameters.AddWithValue("@descripcion", descripcionPregTxt.Text);

                conexion.Open();
                com.ExecuteNonQuery();
                conexion.Close();

                string codigoPreg2 = String.Concat(cod_pruebaTxt.Text, ".", Global.cont, ".", Global.cantRespPreg);
                com = new SqlCommand("INSERT INTO Respuesta(cod_respuesta, descripcion, estado, cod_pregunta) VALUES(@cod_respuesta, @descripcion, @estado, @cod_pregunta)", conexion);
                com.Parameters.AddWithValue("@cod_respuesta", codigoPreg2);
                com.Parameters.AddWithValue("@descripcion", resp1Txt.Text);
                if (respCorrectaTxt.SelectedValue.Equals("Answer #1"))
                {
                    com.Parameters.AddWithValue("@estado", 1);
                }
                else
                {
                    com.Parameters.AddWithValue("@estado", 0);
                }
                com.Parameters.AddWithValue("@cod_pregunta", codigoPreg);
                Global.cantRespPreg += 1;
                conexion.Open();
                com.ExecuteNonQuery();
                conexion.Close();

                codigoPreg2 = String.Concat(cod_pruebaTxt.Text, ".", Global.cont, ".", Global.cantRespPreg);
                com = new SqlCommand("INSERT INTO Respuesta(cod_respuesta, descripcion, estado, cod_pregunta) VALUES(@cod_respuesta, @descripcion, @estado, @cod_pregunta)", conexion);
                com.Parameters.AddWithValue("@cod_respuesta", codigoPreg2);
                com.Parameters.AddWithValue("@descripcion", resp2Txt.Text);
                if (respCorrectaTxt.SelectedValue.Equals("Answer #2"))
                {
                    com.Parameters.AddWithValue("@estado", 1);
                }
                else
                {
                    com.Parameters.AddWithValue("@estado", 0);
                }
                com.Parameters.AddWithValue("@cod_pregunta", codigoPreg);
                Global.cantRespPreg += 1;
                conexion.Open();
                com.ExecuteNonQuery();
                conexion.Close();

                codigoPreg2 = String.Concat(cod_pruebaTxt.Text, ".", Global.cont, ".", Global.cantRespPreg);
                com = new SqlCommand("INSERT INTO Respuesta(cod_respuesta, descripcion, estado, cod_pregunta) VALUES(@cod_respuesta, @descripcion, @estado, @cod_pregunta)", conexion);
                com.Parameters.AddWithValue("@cod_respuesta", codigoPreg2);
                com.Parameters.AddWithValue("@descripcion", resp3Txt.Text);
                if (respCorrectaTxt.SelectedValue.Equals("Answer #3"))
                {
                    com.Parameters.AddWithValue("@estado", 1);
                }
                else
                {
                    com.Parameters.AddWithValue("@estado", 0);
                }
                com.Parameters.AddWithValue("@cod_pregunta", codigoPreg);
                Global.cantRespPreg += 1;
                conexion.Open();
                com.ExecuteNonQuery();
                conexion.Close();

                codigoPreg2 = String.Concat(cod_pruebaTxt.Text, ".", Global.cont,".", Global.cantRespPreg);
                com = new SqlCommand("INSERT INTO Respuesta(cod_respuesta, descripcion, estado, cod_pregunta) VALUES(@cod_respuesta, @descripcion, @estado, @cod_pregunta)", conexion);
                com.Parameters.AddWithValue("@cod_respuesta", codigoPreg2);
                com.Parameters.AddWithValue("@descripcion", resp4Txt.Text);
                if (respCorrectaTxt.SelectedValue.Equals("Answer #4"))
                {
                    com.Parameters.AddWithValue("@estado", 1);
                }
                else
                {
                    com.Parameters.AddWithValue("@estado", 0);
                }
                com.Parameters.AddWithValue("@cod_pregunta", codigoPreg);
                Global.cantRespPreg = 1;
                conexion.Open();
                com.ExecuteNonQuery();
                conexion.Close();

                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Data Submitted')", true);

                descripcionPregTxt.Text = "";
                puntajePregTxt.Text ="";
                resp1Txt.Text = "";
                resp2Txt.Text = "";
                resp3Txt.Text = "";
                resp4Txt.Text = "";
                respCorrectaTxt.ClearSelection();

                Global.cont += 1;
                numPregTxt.Text = "Question #" + Global.cont;
                

                if (Global.cont > Global.cantpregExam)
                {
                    addBtn.Enabled = false;
                    finishBtn.Visible = true;
                    Global.cont = 1;
                    Global.cantpregExam = 1;
                }
            }
        }
        catch (Exception)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Invalid Data')", true);
        }
    }

    protected void finishBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("IndexAdmin.aspx");
    }
}