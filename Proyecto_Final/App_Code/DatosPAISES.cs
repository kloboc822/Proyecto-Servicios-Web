﻿using System;
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

    public static string verificarPais(string codigo)
    {

        string sql;
        SqlDataReader rs;
        string resultado = "";

        try
        {
            conexion.Close();
            conexion.Open();
            sql = "SELECT cod_pais FROM PAIS WHERE cod_pais = '" + codigo + "'";
            com = conexion.CreateCommand();
            com.CommandText = sql;
            rs = com.ExecuteReader();
            if (rs.Read())
            {
                resultado = "El código seleccionado ya fue asignado a un país, por favor compruebe con soporte el código correspondiente";
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
            return "País agregado con éxito.";

        }
        catch (Exception e)
        {
            string excepcion = e.ToString();
            return "Los datos seleccionados no pueden ingresarse, por favor verifique e intente de nuevo";
        }
    }





}