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
    public class TicketsDAO : Conexion
    {
        SqlCommand comando = new SqlCommand();

        public bool InsertarTicket(Tickets ticket)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" INSERT INTO TICKET ");
                sql.Append(" VALUES (@Dispositivo, @Descripcion, @Importe, @Fecha); ");

                comando.Connection = MiConexion;
                MiConexion.Open();
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = sql.ToString();
                comando.Parameters.Add("@Dispositivo", SqlDbType.NVarChar, 50).Value = ticket.Dispositivo;
                comando.Parameters.Add("@Descripcion", SqlDbType.NVarChar, 80).Value = ticket.Descripcion;
                comando.Parameters.Add("@Importe", SqlDbType.NVarChar, 50).Value = ticket.Importe;
                comando.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = ticket.Fecha;         
                comando.ExecuteNonQuery();
                MiConexion.Close();
                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }

        public DataTable GetTickets()
        {
            DataTable dt = new DataTable();
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" SELECT * FROM TICKET ");

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

        public bool ActualizarTicket(Tickets ticket)
        {
            bool modifico = false;
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" UPDATE TICKET ");
                sql.Append(" SET DISPOSITIVO = @Dispositivo, DESCRIPCION = @Descripcion, IMPORTE = @Importe, FECHA = @Fecha ");
                sql.Append(" WHERE ID = @Id ");

                comando.Connection = MiConexion;
                MiConexion.Open();
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = sql.ToString();
                comando.Parameters.Add("@Id", SqlDbType.Int).Value = ticket.Id;
                comando.Parameters.Add("@Dispositivo", SqlDbType.NVarChar, 50).Value = ticket.Dispositivo;
                comando.Parameters.Add("@Descripcion", SqlDbType.NVarChar, 80).Value = ticket.Descripcion;
                comando.Parameters.Add("@Importe", SqlDbType.NVarChar, 50).Value = ticket.Importe;
                comando.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = ticket.Fecha;
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

        public bool EliminarTicket(int Id)
        {
            bool modifico = false;
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" DELETE FROM TICKET ");              
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

