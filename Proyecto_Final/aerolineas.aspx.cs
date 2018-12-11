using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.IO;
using System.Data;


public partial class aerolineas : System.Web.UI.Page
{
  
   
   
   SqlConnection con = new SqlConnection("Data Source = localhost\\SQLEXPRESS; Initial Catalog = Vuelos; Integrated Security = True");
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }

   
    private void sumarConsecutivo() {

        int sum = 0;
        int sum2 = 0;
        string pre = "";

        con.Open();
        SqlCommand comando = new SqlCommand(String.Format("Select prefijo,next_conse from CONSECUTIVO where descripcion = '{0}'", "Aerolinea"), con);
        SqlDataReader red = comando.ExecuteReader();
        while (red.Read())
        {
            pre = red.GetString(0);
            sum = red.GetInt32(1);
        }
        con.Close();

        //Agregar a tabla de codigos usados
        con.Open();
        SqlCommand com2 = new SqlCommand("INSERT INTO CODIGOS(codigo,descripcion) VALUES(@codigo, @descripcion)", con);
        com2.Parameters.AddWithValue("@codigo", pre + sum);
        com2.Parameters.AddWithValue("@descripcion", "Aerolinea");
        com2.ExecuteNonQuery();
        con.Close();
        DatosBITACORA.agregarDato("Consecutivo agregado " + pre + sum);
        sum2 = sum + 1;


        //actualizar el nuevo consecutivo disponible
        con.Open();
        SqlCommand com = new SqlCommand("UPDATE CONSECUTIVO SET next_conse=@a1, codigo=@a2 where descripcion = 'Aerolinea'", con);
        com.Parameters.AddWithValue("a1", sum2);
        com.Parameters.AddWithValue("a2", pre+sum2);
        com.ExecuteNonQuery();
        con.Close();
        DatosBITACORA.agregarDato("Consecutivo actualizado " + pre + sum);
    }

    protected void btnUpload_Click(object sender, EventArgs e)
    {
        if (txtName.Text.Equals("") || dplCodi.Text.Equals(""))
        { ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('No blank spaces are allowed.')", true); }

        else
        {
            con.Open();
            SqlCommand com1 = new SqlCommand("SELECT cod_aerol FROM AEROLINEA WHERE cod_aerol = '" + dplCodi.Text + "'", con);
            SqlDataReader leer = com1.ExecuteReader();
            if (leer.Read())
            {

                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Code already used')", true);
                con.Close();
            }

            else
            {
                con.Close();
                HttpPostedFile postedFile = FileUpload1.PostedFile;
                string fileName = Path.GetFileName(postedFile.FileName);
                string fileExtension = Path.GetExtension(fileName);
                int fileSize = postedFile.ContentLength;

                if (fileExtension.ToLower() == ".jpg" || fileExtension.ToLower() == ".gif" || fileExtension.ToLower() == ".png")
                {
                    Stream stream = postedFile.InputStream;
                    BinaryReader binaryReader = new BinaryReader(stream);
                    byte[] bytes = binaryReader.ReadBytes((int)stream.Length);



                    SqlCommand cmd = new SqlCommand("spUploadImage", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter paraCode = new SqlParameter()
                    {
                        ParameterName = "@cod_aerol",
                        Value = dplCodi.Text
                    };
                    cmd.Parameters.Add(paraCode);

                    SqlParameter paraName = new SqlParameter()
                    {
                        ParameterName = "@nombre",
                        Value = txtName.Text
                    };
                    cmd.Parameters.Add(paraName);

                    SqlParameter paraImage = new SqlParameter()
                    {
                        ParameterName = "@image",
                        Value = bytes
                    };
                    cmd.Parameters.Add(paraImage);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    sumarConsecutivo();
                    dplCodi.DataBind();
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Image uploaded')", true);
                    DatosBITACORA.agregarDato("Aerolínea creada " + txtName.Text);


                }

                else
                {

                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Invalid Image')", true);
                    DatosBITACORA.agregarDato("Problema al crear la aerolínea " + txtName.Text);

                }
            }

        }
    }







    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("verAerolineas.aspx");
    }
}