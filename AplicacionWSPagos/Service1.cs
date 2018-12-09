using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.SqlClient;

namespace AplicacionWSPagos
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código y en el archivo de configuración a la vez.
    public class Service1 : IService1
    {
        static SqlConnection conexion = new SqlConnection("data source=  localhost\\SQLEXPRESS ;initial catalog = Vuelos;" +
        "user id=vuelos;password=vuelos;");
        static SqlCommand com;
        private string MakePago(int fondo, int monto, int numcuenta)
        {
            string resultado = "";
            int nuevo_fondo = fondo-monto;
            try
            {
                conexion.Close();

                conexion.Open();
                using (SqlCommand cmd =
                    new SqlCommand("UPDATE EASY_PAY SET fondo=@fondo" +
                        " WHERE num_cuenta=@num_cuenta", conexion))
                {
                    cmd.Parameters.AddWithValue("@num_cuenta", numcuenta);
                    cmd.Parameters.AddWithValue("@fondo", nuevo_fondo);
                    cmd.ExecuteNonQuery();
                }

                conexion.Close();
                return "Transacción exitosa";
            }
            catch (Exception e)
            {
                string excepcion = e.ToString();
                resultado = "Hubo un problema con la conexión, informe a soporte técnico";
                return resultado;
            }
        }
        public string GetCuenta(int cod, int num_cuenta, string contrasena, int monto)
        {
            string sql;
            SqlDataReader rs;
            string resultado = "";
            EASY_PAY pago = new EASY_PAY();
            pago.cod_seguridad = cod;
            pago.num_cuenta = num_cuenta;
            pago.monto = monto;
            pago.contrasena = contrasena;
            try
            {
                conexion.Close();
                conexion.Open();
                sql = "SELECT * FROM EASY_PAY WHERE cod_cuenta = '" + pago.cod_seguridad +
                "' and num_cuenta = '" + pago.num_cuenta + "' and contrasena = " + pago.contrasena + "";
                com = conexion.CreateCommand();
                com.CommandText = sql;
                rs = com.ExecuteReader();
                if (rs.Read())
                {
                    int fondo = Int32.Parse(rs[5].ToString());
                    resultado = MakePago(fondo, pago.monto,pago.num_cuenta);
                }
                else
                {
                    resultado = "Número de cuenta/contraseña o código de seguridad inválidos";
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
}
