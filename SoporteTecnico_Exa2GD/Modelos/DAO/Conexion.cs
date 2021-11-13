using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;


namespace SoporteTecnico_Exa2GD.Modelos.DAO
{
    public class Conexion
    {

        protected SqlConnection MiConexion = new SqlConnection(ConfigurationManager.ConnectionStrings["LoginE2Conexion"].ConnectionString);

    }
}
