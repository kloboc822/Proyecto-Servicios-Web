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
        if (!Page.IsPostBack) {

            LoadImages();

        }
    }

    private void LoadImages() {

        con.Open();

        SqlCommand cmd = new SqlCommand("Select * from AEROLINEA", con);
        SqlDataReader rdr = cmd.ExecuteReader();
        GridView1.DataSource = rdr;
        GridView1.DataBind();

        con.Close();

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

                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Image uploaded')", true);
                    LoadImages();
                }

                else
                {

                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Invalid Image')", true);

                }
            }

        }
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        Label l1 = GridView1.Rows[e.RowIndex].FindControl("stlbl") as Label;
        con.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "Delete from [Aerolinea] where cod_aerol = @cod_aerol";
        cmd.Parameters.AddWithValue("@cod_aerol", l1.Text);
        cmd.Connection = con;
        cmd.ExecuteNonQuery();
        con.Close();
        LoadImages();

    }
}