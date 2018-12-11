using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web;

/// <summary>
/// Descripción breve de DatosPAISES
/// </summary>
public class DatosPAISES
{
    static SqlConnection conexion = new SqlConnection("data source= " + Global.servidor + ";initial catalog = Vuelos;" +
    "user id=" + Global.database_user + ";password=" + Global.database_password + ";");
    static SqlCommand com;

    public static string verificarPais(string codigo, string nombre)
    {

        string sql;
        SqlDataReader rs;
        string resultado = "";

        try
        {
            conexion.Close();
            conexion.Open();
            sql = "SELECT * FROM PAIS WHERE cod_pais = '" + codigo +
            "' or nombre = '" + nombre + "'";
            com = conexion.CreateCommand();
            com.CommandText = sql;
            rs = com.ExecuteReader();
            if (rs.Read())
            {
                resultado = "El código/nombre seleccionado ya fue asignado a un país, por favor compruebe con soporte el código correspondiente";
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
    public static string agregarPais(byte[] imagen, string nombre, string codigo)
    {
        try
        {
            conexion.Close();
            com = new SqlCommand();
            com.CommandText =
                "INSERT INTO PAIS (cod_pais, nombre, imagen) VALUES(@cod_pais, @nombre, @imagen )";
            com.Parameters.Add("@cod_pais", System.Data.SqlDbType.Text).Value = codigo;
            com.Parameters.Add("@nombre", System.Data.SqlDbType.Text).Value = nombre;
            com.Parameters.Add("@imagen", System.Data.SqlDbType.Image).Value = imagen;
            com.CommandType = System.Data.CommandType.Text;
            com.Connection = conexion;
            conexion.Open();
            com.ExecuteNonQuery();
            conexion.Close();
            string resultado = "País agregado con éxito.";
            DatosBITACORA.agregarDato(resultado + " al agregar país " + nombre);           
            return resultado;

        }
        catch (Exception e)
        {
            string excepcion = e.ToString();
            string resultado = "Los datos seleccionados no pueden ingresarse, por favor verifique e intente de nuevo";
            DatosBITACORA.agregarDato(resultado + " al agregar país " + nombre);
            return resultado;
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
            sql = "SELECT * FROM PAIS WHERE cod_pais = '" + codigo + "'";
            com = conexion.CreateCommand();
            com.CommandText = sql;
            rs = com.ExecuteReader();
            if (rs.Read())
            {
                Global.cod_pais = rs[0].ToString();
                Global.nombre_pais = rs[1].ToString();
            }
            conexion.Close();
            conexion.Open();
            sql = "SELECT imagen FROM PAIS WHERE cod_pais = '" + codigo + "'";
            com = conexion.CreateCommand();
            com.CommandText = sql;
            byte[] bytes = (byte[])com.ExecuteScalar();
            Global.imagen_pais = Convert.ToBase64String(bytes);
            conexion.Close();
            resultado = "Datos comprobados de forma correcta";
            return resultado;


        }
        catch (Exception e)
        {
            string excepcion = e.ToString();
            resultado = "Hubo un problema con la conexión, informe a soporte técnico";
            return resultado;
        }
    }

    public static string actualizarPais(byte[] imagen, string nombre, string codigo)
    {
        string resultado = "";

        try
        {
            conexion.Close();

            conexion.Open();
            using (SqlCommand cmd =
                new SqlCommand("UPDATE PAIS SET nombre=@nombre, imagen=@imagen" +
                    " WHERE cod_pais=@cod_pais", conexion))
            {
                cmd.Parameters.AddWithValue("@cod_pais", codigo);
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@imagen", imagen);
                cmd.ExecuteNonQuery();
            }

            conexion.Close();
            resultado = "País actualizado exitosamente";
            DatosBITACORA.agregarDato(resultado + " al agregar país " + nombre);
            return resultado;
        }
        catch (Exception e)
        {
            string excepcion = e.ToString();
            resultado = "Hubo un problema con la conexión, informe a soporte técnico";
            DatosBITACORA.agregarDato(resultado + " al agregar país " + nombre);
            return resultado;
        }
    }

    //este metodo incrementa el consecutivo cuando se agrega un nuevo pais
    public static void sumarConsecutivoPais()
    {

        int sum = 0;
        int sum2 = 0;
        string pre = "";

        conexion.Open();
        SqlCommand comando = new SqlCommand(String.Format("Select prefijo,next_conse from CONSECUTIVO where descripcion = '{0}'", "Paises"), conexion);
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
        com2.Parameters.AddWithValue("@descripcion", "Paises");
        com2.ExecuteNonQuery();
        conexion.Close();
        DatosBITACORA.agregarDato("Consecutivo agregado " + pre + sum);
        sum2 = sum + 1;


        //actualizar el nuevo consecutivo disponible
        conexion.Open();
        SqlCommand com = new SqlCommand("UPDATE CONSECUTIVO SET next_conse=@a1, codigo=@a2 where descripcion = 'Paises'", conexion);
        com.Parameters.AddWithValue("a1", sum2);
        com.Parameters.AddWithValue("a2", pre + sum2);
        com.ExecuteNonQuery();
        conexion.Close();
        DatosBITACORA.agregarDato("Consecutivo actualizado " + pre + sum);
    }

    public static string obtenerCod_Pais(string nombre)
    {
        string sql;
        SqlDataReader rs;
        string resultado = "";

        try
        {
            conexion.Close();
            conexion.Open();
            sql = "SELECT cod_pais FROM PAIS WHERE nombre = '" + nombre + "'";
            com = conexion.CreateCommand();
            com.CommandText = sql;
            rs = com.ExecuteReader();
            if (rs.Read())
            {
                resultado = rs[0].ToString();
            }
            else
            {
                resultado = "ERROR OBTENIENDO COD_PAIS, CONTACTE A SU DESARROLLADOR";
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

}