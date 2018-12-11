using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.UI;

/// <summary>
/// Summary description for VueloDa
/// </summary>
public class VueloDa
{
    static SqlConnection conVue = new SqlConnection("Data Source = localhost\\SQLEXPRESS; Initial Catalog = Vuelos; Integrated Security = True");
    static SqlCommand com;
    public VueloDa()
    {


    }
    public static void insertarVuelo(string codigo, string aerolinea, string fecha, string hora, string lugar , int precio , string puerta, string tipo,string estado) {

      
            conVue.Close();
            SqlCommand com = new SqlCommand("INSERT INTO Vuelo(cod_vuelo,aerolinea, fecha, hora,lugar,precio,puerta,tipo,estado) VALUES(@codigo,@aerolinea, @fecha, @hora,@lugar,@precio,@puerta,@tipo,@estado)", conVue);
            com.Parameters.AddWithValue("@codigo", codigo);
            com.Parameters.AddWithValue("@aerolinea", aerolinea);
            com.Parameters.AddWithValue("@fecha", fecha);
            com.Parameters.AddWithValue("@hora", hora);
            com.Parameters.AddWithValue("@lugar", lugar);
            com.Parameters.AddWithValue("@precio", precio);
            com.Parameters.AddWithValue("@puerta", puerta);
            com.Parameters.AddWithValue("@tipo", tipo);
            com.Parameters.AddWithValue("@estado", estado);
            conVue.Open();
            com.ExecuteNonQuery();
            conVue.Close();
        }


    public static string consultarVuelo(string lugar, string fecha)
    {
        conVue.Close();

        string sql;
        SqlDataReader rs;
        string resultado;

        try
        {
            conVue.Close();
            conVue.Open();

            sql = "SELECT cod_vuelo,aerolinea,hora, precio FROM Vuelo WHERE fecha = '" + fecha +
            "' and lugar = '" + lugar + "'";
            com = conVue.CreateCommand();
            com.CommandText = sql;
            rs = com.ExecuteReader();
            if (rs.Read())
            {
                return "Cargando Vuelos con los parametros deseados, presione OK.";
            }
            else
            {
                resultado = "No existen vuelos en las fecha seleccionada al destino seleccionado, intente una nueva busqueda";
            }
            conVue.Close();
            return resultado;
        }
        catch (Exception e)
        {
            string excepcion = e.ToString();
            resultado = "Hubo un problema con la conexión, informe a soporte técnico";
            conVue.Close();
            return resultado;
        }
    }

    public static string obtenerCod_compra()
    {
        conVue.Close();

        string sql;
        SqlDataReader rs;
        string resultado;

        try
        {
            conVue.Close();
            conVue.Open();

            sql = "select codigo from consecutivo where descripcion = 'Compra de Boletos'";
            com = conVue.CreateCommand();
            com.CommandText = sql;
            rs = com.ExecuteReader();
            if (rs.Read())
            {
                resultado = rs[0].ToString();
            }
            else
            {
                resultado = "ERROR OBTENIENDO CODIGO DE COMPRA";
            }
            conVue.Close();
            return resultado;
        }
        catch (Exception e)
        {
            string excepcion = e.ToString();
            resultado = "Hubo un problema con la conexión, informe a soporte técnico";
            conVue.Close();
            return resultado;
        }
    }

    public static string obtenerCod_reserva()
    {
        conVue.Close();

        string sql;
        SqlDataReader rs;
        string resultado;

        try
        {
            conVue.Close();
            conVue.Open();

            sql = "select codigo from consecutivo where descripcion = 'Reservacion de Boletos'";
            com = conVue.CreateCommand();
            com.CommandText = sql;
            rs = com.ExecuteReader();
            if (rs.Read())
            {
                resultado = rs[0].ToString();
            }
            else
            {
                resultado = "ERROR OBTENIENDO CODIGO DE Reserva";
            }
            conVue.Close();
            return resultado;
        }
        catch (Exception e)
        {
            string excepcion = e.ToString();
            resultado = "Hubo un problema con la conexión, informe a soporte técnico";
            conVue.Close();
            return resultado;
        }
    }

    public static void registrarCompra()
    {

        conVue.Close();
        SqlCommand com = new SqlCommand("INSERT INTO Compra(cod_compra,id_usuario,cod_pais,cod_vuelo,total,tipo) VALUES(@cod_compra,@id_usuario,@cod_pais,@cod_vuelo,@total,@tipo)", conVue);
        com.Parameters.AddWithValue("@cod_compra", obtenerCod_compra());
        com.Parameters.AddWithValue("@id_usuario", Global.id);
        com.Parameters.AddWithValue("@cod_pais", DatosPAISES.obtenerCod_Pais(Global.lugar));
        com.Parameters.AddWithValue("@cod_vuelo", Global.cod_vuelo);
        com.Parameters.AddWithValue("@total", Global.precio);
        com.Parameters.AddWithValue("@tipo", Global.tipo);
        conVue.Open();
        com.ExecuteNonQuery();
        conVue.Close();
        sumarConsecutivoCompra();
    }

    public static void registrarReserva()
    {

        conVue.Close();
        SqlCommand com = new SqlCommand("INSERT INTO Reserva(cod_reserva,id_usuario,cod_pais,cod_vuelo,cantidad) VALUES(@cod_compra,@id_usuario,@cod_pais,@cod_vuelo,@cantidad)", conVue);
        com.Parameters.AddWithValue("@cod_compra", obtenerCod_reserva());
        com.Parameters.AddWithValue("@id_usuario", Global.id);
        com.Parameters.AddWithValue("@cod_pais", DatosPAISES.obtenerCod_Pais(Global.lugar));
        com.Parameters.AddWithValue("@cod_vuelo", Global.cod_vuelo);
        com.Parameters.AddWithValue("@cantidad", Global.cantidad);
        conVue.Open();
        com.ExecuteNonQuery();
        conVue.Close();
        sumarConsecutivoReserva();
    }


    public static void sumarConsecutivoVuelo()
    {

        int sum = 0;
        int sum2 = 0;
        string pre = "";

        conVue.Open();
        SqlCommand comando = new SqlCommand(String.Format("Select prefijo,next_conse from CONSECUTIVO where descripcion = '{0}'", "Vuelos"), conVue);
        SqlDataReader red = comando.ExecuteReader();
        while (red.Read())
        {
            pre = red.GetString(0);
            sum = red.GetInt32(1);
        }
        conVue.Close();

        //Agregar a tabla de codigos usados
        conVue.Open();
        SqlCommand com2 = new SqlCommand("INSERT INTO CODIGOS(codigo,descripcion) VALUES(@codigo, @descripcion)", conVue);
        com2.Parameters.AddWithValue("@codigo", pre + sum);
        com2.Parameters.AddWithValue("@descripcion", "Vuelos");
        com2.ExecuteNonQuery();
        conVue.Close();
        DatosBITACORA.agregarDato("Consecutivo agregado " + pre + sum);
        sum2 = sum + 1;


        //actualizar el nuevo consecutivo disponible
        conVue.Open();
        SqlCommand com = new SqlCommand("UPDATE CONSECUTIVO SET next_conse=@a1, codigo=@a2 where descripcion = 'Vuelos'", conVue);
        com.Parameters.AddWithValue("a1", sum2);
        com.Parameters.AddWithValue("a2", pre + sum2);
        com.ExecuteNonQuery();
        conVue.Close();
        DatosBITACORA.agregarDato("Consecutivo actualizado " + pre + sum);
    }

    public static void sumarConsecutivoCompra()
    {

        int sum = 0;
        int sum2 = 0;
        string pre = "";

        conVue.Open();
        SqlCommand comando = new SqlCommand(String.Format("Select prefijo,next_conse from CONSECUTIVO where descripcion = '{0}'", "Compra de Boletos"), conVue);
        SqlDataReader red = comando.ExecuteReader();
        while (red.Read())
        {
            pre = red.GetString(0);
            sum = red.GetInt32(1);
        }
        conVue.Close();

        //Agregar a tabla de codigos usados
        conVue.Open();
        SqlCommand com2 = new SqlCommand("INSERT INTO CODIGOS(codigo,descripcion) VALUES(@codigo, @descripcion)", conVue);
        com2.Parameters.AddWithValue("@codigo", pre + sum);
        com2.Parameters.AddWithValue("@descripcion", "Compra de Boletos");
        com2.ExecuteNonQuery();
        conVue.Close();
        DatosBITACORA.agregarDato("Consecutivo agregado " + pre + sum);
        sum2 = sum + 1;


        //actualizar el nuevo consecutivo disponible
        conVue.Open();
        SqlCommand com = new SqlCommand("UPDATE CONSECUTIVO SET next_conse=@a1, codigo=@a2 where descripcion = 'Compra de Boletos'", conVue);
        com.Parameters.AddWithValue("a1", sum2);
        com.Parameters.AddWithValue("a2", pre + sum2);
        com.ExecuteNonQuery();
        conVue.Close();
        DatosBITACORA.agregarDato("Consecutivo actualizado " + pre + sum);
    }

    public static void sumarConsecutivoReserva()
    {

        int sum = 0;
        int sum2 = 0;
        string pre = "";

        conVue.Open();
        SqlCommand comando = new SqlCommand(String.Format("Select prefijo,next_conse from CONSECUTIVO where descripcion = '{0}'", "Reservacion de Boletos"), conVue);
        SqlDataReader red = comando.ExecuteReader();
        while (red.Read())
        {
            pre = red.GetString(0);
            sum = red.GetInt32(1);
        }
        conVue.Close();

        //Agregar a tabla de codigos usados
        conVue.Open();
        SqlCommand com2 = new SqlCommand("INSERT INTO CODIGOS(codigo,descripcion) VALUES(@codigo, @descripcion)", conVue);
        com2.Parameters.AddWithValue("@codigo", pre + sum);
        com2.Parameters.AddWithValue("@descripcion", "Reservacion de Boletos");
        com2.ExecuteNonQuery();
        conVue.Close();
        DatosBITACORA.agregarDato("Consecutivo agregado " + pre + sum);
        sum2 = sum + 1;


        //actualizar el nuevo consecutivo disponible
        conVue.Open();
        SqlCommand com = new SqlCommand("UPDATE CONSECUTIVO SET next_conse=@a1, codigo=@a2 where descripcion = 'Reservacion de Boletos'", conVue);
        com.Parameters.AddWithValue("a1", sum2);
        com.Parameters.AddWithValue("a2", pre + sum2);
        com.ExecuteNonQuery();
        conVue.Close();
        DatosBITACORA.agregarDato("Consecutivo actualizado " + pre + sum);
    }


}