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
            string resultado = "Puerta agregada con éxito.";
            DatosBITACORA.agregarDato(resultado + " al agregar puerta " + codigo);
            return resultado;

        }
        catch (Exception e)
        {
            string excepcion = e.ToString();
            excepcion = "Los datos seleccionados no pueden ingresarse, por favor verifique e intente de nuevo";
            DatosBITACORA.agregarDato(excepcion + " al agregar puerta " + codigo);
            return excepcion;
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
            resultado = "Puerta actualizada exitosamente";
            DatosBITACORA.agregarDato(resultado + " al agregar puerta " + codigo);
            return resultado;

        }
        catch (Exception e)
        {
            string excepcion = e.ToString();
            resultado = "Hubo un problema con la conexión, informe a soporte técnico";
            DatosBITACORA.agregarDato(resultado + " al agregar puerta " + codigo);
            return resultado;
        }
    }

    //este metodo incrementa el consecutivo cuando se agrega una nueva puerta
    public static void sumarConsecutivoPuerta()
    {

        int sum = 0;
        int sum2 = 0;
        string pre = "";

        conexion.Open();
        SqlCommand comando = new SqlCommand(String.Format("Select prefijo,next_conse from CONSECUTIVO where descripcion = '{0}'", "Puertas del Aeropuerto"), conexion);
        SqlDataReader red = comando.ExecuteReader();
        while (red.Read())
        {
            pre = red.GetString(0);
            sum = red.GetInt32(1);
        }
        conexion.Close();

        //Agregar a tabla de codigos usados
        conexion.Open();
        SqlCommand com2 = new SqlCommand("INSERT INTO CODIGOS(codigo,descripcion) VALUES(@codigo, @descripcion)", conexion);
        com2.Parameters.AddWithValue("@codigo", pre + sum);
        com2.Parameters.AddWithValue("@descripcion", "Puertas del Aeropuerto");
        com2.ExecuteNonQuery();
        conexion.Close();
        DatosBITACORA.agregarDato("Consecutivo agregado " + pre + sum);

        sum2 = sum + 1;


        //actualizar el nuevo consecutivo disponible
        conexion.Open();
        SqlCommand com = new SqlCommand("UPDATE CONSECUTIVO SET next_conse=@a1, codigo=@a2 where descripcion = 'Puertas del Aeropuerto'", conexion);
        com.Parameters.AddWithValue("a1", sum2);
        com.Parameters.AddWithValue("a2", pre + sum2);
        com.ExecuteNonQuery();
        conexion.Close();
        DatosBITACORA.agregarDato("Consecutivo actualizado " + pre + sum);
    }


}