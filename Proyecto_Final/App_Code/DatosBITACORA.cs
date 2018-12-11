using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

/// <summary>
/// Descripción breve de DatosBITACORA
/// </summary>
public class DatosBITACORA
{
    static SqlConnection conexion = new SqlConnection("data source= " + Global.servidor + ";initial catalog = Vuelos;" +
    "user id=" + Global.database_user + ";password=" + Global.database_password + ";");
    static SqlCommand com;
    public static void agregarDato(string descripcion)
    {
        try
        {
            conexion.Close();
            com = new SqlCommand();
            com.CommandText =
                "INSERT INTO BITACORA (fecha, descripcion, id_usuario) VALUES(GETDATE(), @descripcion, @id )";
            com.Parameters.Add("@descripcion", System.Data.SqlDbType.Text).Value = descripcion;
            com.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = Global.id;
            com.CommandType = System.Data.CommandType.Text;
            com.Connection = conexion;
            conexion.Open();
            com.ExecuteNonQuery();
            conexion.Close();

        }
        catch (Exception e)
        {
            string excepcion = e.ToString();
        }

    }
}