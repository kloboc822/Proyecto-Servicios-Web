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

        sum2 = sum + 1;


        //actualizar el nuevo consecutivo disponible
        conVue.Open();
        SqlCommand com = new SqlCommand("UPDATE CONSECUTIVO SET next_conse=@a1, codigo=@a2 where descripcion = 'Vuelos'", conVue);
        com.Parameters.AddWithValue("a1", sum2);
        com.Parameters.AddWithValue("a2", pre + sum2);
        com.ExecuteNonQuery();
        conVue.Close();
    }


}