using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Usuarios
/// </summary>
public class Usuarios
{
    static SqlConnection conexion = new SqlConnection("data source= " + Global.servidor + ";initial catalog = Vuelos;" +
    "user id=" + Global.database_user + ";password=" + Global.database_password + ";");
    static SqlCommand com;

    public Usuarios()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static string inicioSesion(int id, string password)
    {
        string sql;
        SqlDataReader rs;
        string resultado = "";

        try
        {
            conexion.Close();
            conexion.Open();

            sql = "SELECT * FROM USUARIO WHERE id_usuario = '" + id +
            "' and contrasena = '" + password + "'";
            com = conexion.CreateCommand();
            com.CommandText = sql;
            rs = com.ExecuteReader();
            if (rs.Read())
            {
                Global.id = Int32.Parse(rs["id_usuario"].ToString());
                Global.userType = Int32.Parse(rs["Rol"].ToString());

                return Global.userType.ToString();

            }
            else
            {
                resultado = "Los datos ingresados no son correctos, usuario no existe.";
            }
            conexion.Close();
            return resultado;


        }
        catch (Exception e)
        {
            string excepcion = e.ToString();
            resultado = "Hubo un problema con la conexión, informe a soporte técnico";
            conexion.Close();
            return resultado;
        }
        
    }

    public static string verificaUsuario(int id)
    {
        string sql;
        SqlDataReader rs;
        string resultado = "";

        try
        {
            conexion.Close();
            conexion.Open();

            sql = "SELECT * FROM USUARIO WHERE id_usuario = '" + id +"'";
            com = conexion.CreateCommand();
            com.CommandText = sql;
            rs = com.ExecuteReader();
            if (rs.Read())
            {
                Global.id = Int32.Parse(rs["id_usuario"].ToString());
                resultado = "exitoso";
            }
            else
            {
                resultado = "Los datos ingresados no son correctos, usuario no existe.";
            }
            conexion.Close();
            return resultado;


        }
        catch (Exception e)
        {
            string excepcion = e.ToString();
            resultado = "Hubo un problema con la conexión, informe a soporte técnico";
            conexion.Close();
            return resultado;
        }

    }

    public static string obtienePregunta()
    {
        string sql;
        SqlDataReader rs;
        string resultado = "";

        try
        {
            conexion.Close();
            conexion.Open();

            sql = "SELECT * FROM USUARIO WHERE id_usuario = '" + Global.id + "'";
            com = conexion.CreateCommand();
            com.CommandText = sql;
            rs = com.ExecuteReader();
            if (rs.Read())
            {
                resultado = rs[8].ToString();
            }
            else
            {
                resultado = "ERROR AL CARGAR PREGUNTA DE SEGURIDAD";
            }
            conexion.Close();
            return resultado;


        }
        catch (Exception e)
        {
            string excepcion = e.ToString();
            resultado = "Hubo un problema con la conexión, informe a soporte técnico";
            conexion.Close();
            return resultado;
        }

    }

    public static string comparaRespuesta(string respuesta)
    {
        string sql;
        SqlDataReader rs;
        string resultado = "";

        try
        {
            conexion.Close();
            conexion.Open();

            sql = "SELECT * FROM USUARIO WHERE id_usuario = '" + Global.id + "'";
            com = conexion.CreateCommand();
            com.CommandText = sql;
            rs = com.ExecuteReader();
            if (rs.Read())
            {
                if (rs[9].ToString().Equals(respuesta))
                {
                    resultado = "correcto";
                }
                else
                {
                    resultado = "no";
                }
            }
            else
            {
                resultado = "ERROR AL CARGAR RESPUESTA DE SEGURIDAD";
            }
            conexion.Close();
            return resultado;


        }
        catch (Exception e)
        {
            string excepcion = e.ToString();
            resultado = "Hubo un problema con la conexión, informe a soporte técnico";
            conexion.Close();
            return resultado;
        }

    }

    public static string reseteaContrasena(string password)
    {
        string resultado = "";

        try
        {
            conexion.Close();

            conexion.Open();
            SqlCommand com = new SqlCommand("UPDATE USUARIO SET contrasena = @password where id_usuario = '"+ Global.id +"'", conexion);
            com.Parameters.AddWithValue("password", password);
            com.ExecuteNonQuery();
            resultado = "Actualizacion de contrasena realizada con exito";
            conexion.Close();
            return resultado;


        }
        catch (Exception e)
        {
            string excepcion = e.ToString();
            resultado = "Hubo un problema con la conexión, informe a soporte técnico";
            conexion.Close();
            return resultado;
        }

    }

    public static string addUser(string firstname, string surname1, string surname2, int id, string email, int tipouser, string password, string nacionalidad)
    {
        string resultado = "";
        try
        {
            SqlCommand com2;
            com2 = new SqlCommand("INSERT INTO USUARIO(id_usuario, nombre, apellido1, apellido2, correo, contrasena, nacionalidad, rol) VALUES(@id_usuario, @nombre, @apellido1, @apellido2, @correo, @contrasena, @nacionalidad, @rol)", conexion);
            com2.Parameters.AddWithValue("@id_usuario", id);
            com2.Parameters.AddWithValue("@nombre", firstname);
            com2.Parameters.AddWithValue("@apellido1", surname1);
            com2.Parameters.AddWithValue("@apellido2", surname2);
            com2.Parameters.AddWithValue("@correo", email);
            com2.Parameters.AddWithValue("@contrasena", password);
            com2.Parameters.AddWithValue("@nacionalidad", nacionalidad);
            com2.Parameters.AddWithValue("@rol", tipouser);

            conexion.Open();
            com2.ExecuteNonQuery();
            conexion.Close();
            resultado = "Usuario añadido con éxito";
            DatosBITACORA.agregarDato(resultado + " al agregar usuario " + id.ToString());
            return resultado;
        }
        catch (Exception e)
        {
            string excepcion = e.ToString();
            resultado = "Error de conexión. [addUserError]";
            DatosBITACORA.agregarDato(resultado + " al agregar usuario " + id.ToString());
            return resultado;
        }
        
    }


}