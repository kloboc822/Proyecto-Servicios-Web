﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web;

/// <summary>
/// Summary description for Global
/// </summary>
public class Global
{
    public static string servidor = "localhost\\SQLEXPRESS";
    public static string database_user = "vuelos";
    public static string database_password = "vuelos";

    public static string firstname= "";
    public static string surname1 = "";
    public static string surname2 = "";
    public static string email = "";
    public static int id = 0;
    public static int userType = 0;
    public static int cantpregExam = 1;
    public static int cantRespPreg = 1;
    public static int cont = 1;
    public static int codExam = 0;
    public static string examName = "";
    public static int puntos = 0;
    public static string cod_pais = "";
    public static string nombre_pais = "";
    public static string imagen_pais = "";
    public static string cod_puerta = "";
    public static string detalle_puerta = "";


    public Global()
    {
        //
        // TODO: Add constructor logic here
        //
    }
}