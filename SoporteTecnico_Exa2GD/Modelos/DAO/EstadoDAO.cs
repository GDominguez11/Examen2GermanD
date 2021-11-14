using SoporteTecnico_Exa2GD.Modelos.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoporteTecnico_Exa2GD.Modelos.DAO
{
    public class EstadoDAO : Conexion
    {

        SqlCommand comando = new SqlCommand();

        public bool InsertarEstado(Estado estado)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" INSERT INTO ESTADO ");
                sql.Append(" VALUES (@Abierto, @En_espera, @Sin_resolver, @Cerrado); ");

                comando.Connection = MiConexion;
                MiConexion.Open();
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = sql.ToString();
                comando.Parameters.Add("@Abierto", SqlDbType.Bit).Value = estado.Abierto;
                comando.Parameters.Add("@En_espera", SqlDbType.Bit).Value = estado.EnEspera;
                comando.Parameters.Add("@Sin_resolver", SqlDbType.Bit).Value = estado.SinResolver;
                comando.Parameters.Add("@Cerrado", SqlDbType.Bit).Value = estado.Cerrado;
                comando.ExecuteNonQuery();
                MiConexion.Close();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public DataTable GetEstado()
        {
            DataTable dt = new DataTable();
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" SELECT * FROM ESTADO ");

                comando.Connection = MiConexion;
                MiConexion.Open();
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = sql.ToString();
                SqlDataReader dr = comando.ExecuteReader();
                dt.Load(dr);
                MiConexion.Close();



            }
            catch (Exception)
            {

                
            }
            return dt;
        }

        public bool ActualizarEstado(Estado estado)
        {
            bool modifico = false;
            try
            {              
                StringBuilder sql = new StringBuilder();
                sql.Append(" UPDATE ESTADO ");
                sql.Append(" SET ABIERTO = @Abierto, EN_ESPERA = @En_espera, SIN_RESOLVER = @Sin_resolver, CERRADO = @Cerrado ");
                sql.Append(" WHERE ID = @Id ");

                comando.Connection = MiConexion;
                MiConexion.Open();
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = sql.ToString();
                comando.Parameters.Add("@Id", SqlDbType.Int).Value = estado.Id;
                comando.Parameters.Add("@Abierto", SqlDbType.Bit).Value = estado.Abierto;
                comando.Parameters.Add("@En_espera", SqlDbType.Bit).Value = estado.EnEspera;
                comando.Parameters.Add("@Sin_resolver", SqlDbType.Bit).Value = estado.SinResolver;
                comando.Parameters.Add("@Cerrado", SqlDbType.Bit).Value = estado.Cerrado;
                comando.ExecuteNonQuery();
                modifico = true;
                MiConexion.Close();
                
            }
            catch (Exception)
            {
                return modifico;
                
            }
            return modifico;

        }

        public bool EliminarEstado(int Id)
        {
            bool modifico = false;
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" DELETE FROM ESTADO ");             
                sql.Append(" WHERE ID = @Id ");

                comando.Connection = MiConexion;
                MiConexion.Open();
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = sql.ToString();
                comando.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
                comando.ExecuteNonQuery();
                modifico = true;
                MiConexion.Close();

            }
            catch (Exception)
            {
                return modifico;

            }
            return modifico;
        }
    }
}
