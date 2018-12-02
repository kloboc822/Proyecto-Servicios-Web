using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Web;

/// <summary>
/// Descripción breve de DatosPUERTAS
/// </summary>
public class DatosPUERTAS
{
    static SqlConnection conexion = new SqlConnection("data source= " + Global.servidor + ";initial catalog = Vuelos;" +
   "user id=" + Global.database_user + ";password=" + Global.database_password + ";");
    static SqlCommand com;

    public static string verificarPuerta(string codigo)
    {

        string sql;
        SqlDataReader rs;
        string resultado = "";

        try
        {
            conexion.Close();
            conexion.Open();
            sql = "SELECT cod_puerta FROM PUERTA WHERE cod_puerta = '" + codigo + "'";
            com = conexion.CreateCommand();
            com.CommandText = sql;
            rs = com.ExecuteReader();
            if (rs.Read())
            {
                resultado = "El código seleccionado ya fue asignado a una puerta, por favor compruebe con soporte el código correspondiente";
            }
            else
            {
                resultado = "Datos comprobados de forma correcta";
            }
            conexion.Close();
            return resultado;


        }
        catch (Exception e)
        {
            string excepcion = e.ToString();
            resultado = "Hubo un problema con la conexión, informe a soporte técnico";
            return resultado;
        }
    }
    public static string agregarPUERTA(string codigo, Boolean detalle)
    {
        try
        {
            conexion.Close();
            com = new SqlCommand();
            com.CommandText =
                "INSERT INTO PUERTA (cod_puerta, detalle) VALUES(@cod_puerta, @detalle)";
            com.Parameters.Add("@cod_puerta", System.Data.SqlDbType.Text).Value = codigo;
            com.Parameters.Add("@detalle", System.Data.SqlDbType.Bit).Value = detalle;
            com.CommandType = System.Data.CommandType.Text;
            com.Connection = conexion;
            conexion.Open();
            com.ExecuteNonQuery();
            conexion.Close();
            return "Puerta agregada con éxito.";

        }
        catch (Exception e)
        {
            string excepcion = e.ToString();
            return "Los datos seleccionados no pueden ingresarse, por favor verifique e intente de nuevo";
        }
    }

    public static string obtenerDatosModificar(string codigo)
    {
        string sql;
        string resultado = "";
        SqlDataReader rs;

        try
        {
            conexion.Close();
            conexion.Open();
            sql = "SELECT * FROM PUERTA WHERE cod_puerta = '" + codigo + "'";
            com = conexion.CreateCommand();
            com.CommandText = sql;
            rs = com.ExecuteReader();
            if (rs.Read())
            {
                Global.cod_puerta = rs[0].ToString();
                Boolean estado = Boolean.Parse(rs[1].ToString());
                if (estado == false)
                {
                    Global.detalle_puerta = "Cerrada";
                }
                else
                {
                    Global.detalle_puerta = "Abierta";
                }
                resultado = "Datos comprobados de forma correcta";
            }
            conexion.Close();
            
            return resultado;


        }
        catch (Exception e)
        {
            string excepcion = e.ToString();
            resultado = "Hubo un problema con la conexión, informe a soporte técnico";
            return resultado;
        }
    }

    public static string actualizarPuerta(Boolean estado, string codigo)
    {
        string resultado = "";

        try
        {
            conexion.Close();

            conexion.Open();
            using (SqlCommand cmd =
                new SqlCommand("UPDATE PUERTA SET detalle=@detalle" +
                    " WHERE cod_puerta=@cod_puerta", conexion))
            {
                cmd.Parameters.AddWithValue("@cod_puerta", codigo);
                cmd.Parameters.AddWithValue("@detalle", estado);
                cmd.ExecuteNonQuery();
            }

            conexion.Close();
            return "Puerta actualizada exitosamente";
        }
        catch (Exception e)
        {
            string excepcion = e.ToString();
            resultado = "Hubo un problema con la conexión, informe a soporte técnico";
            return resultado;
        }
    }


}