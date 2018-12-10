using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace AplicacionWSPagos
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        string GetCuenta(int cod_seguridad, int num_cuenta, string contrasena, int monto);

        [OperationContract]
        string GetTarjeta(int cod, int num_tarjeta, string nombre, int monto, int anyo, int mes, string tipo);
    }
}
