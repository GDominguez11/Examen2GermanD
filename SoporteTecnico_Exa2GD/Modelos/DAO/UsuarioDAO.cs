using SoporteTecnico_Exa2GD.Modelos.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace SoporteTecnico_Exa2GD.Modelos.DAO
{
    public class UsuarioDAO : Conexion
    {
        SqlCommand comando = new SqlCommand();

        public bool ValidarUsuario(Usuario user)
        {
            bool valido = false;
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append("SELECT 1 FROM USUARIO WHERE EMAIL = @Email AND CLAVE = @Clave;");

                comando.Connection = MiConexion;
                MiConexion.Open();
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = sql.ToString();
                comando.Parameters.Add("@Email", SqlDbType.NVarChar, 50).Value = user.Email;
                comando.Parameters.Add("@Clave", SqlDbType.NVarChar, 100).Value = user.Clave;
                valido = Convert.ToBoolean(comando.ExecuteScalar());
                MiConexion.Close();

            }
            catch (Exception)
            {

                
            }
            return valido;
        }

        public bool InsertarNuevoUsuario(Usuario user)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" INSERT INTO USUARIO ");
                sql.Append(" VALUES (@Nombre, @Identidad, @Direccion, @Email, @Clave, @Reparacion_PC, @Reparacion_Movil, @Cambio_De_Piezas, @Desbloqueo); ");

                comando.Connection = MiConexion;
                MiConexion.Open();
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = sql.ToString();
                comando.Parameters.Add("@Nombre", SqlDbType.NVarChar, 80).Value = user.Nombre;
                comando.Parameters.Add("@Identidad", SqlDbType.NVarChar, 20).Value = user.Identidad;
                comando.Parameters.Add("@Direccion", SqlDbType.NVarChar, 80).Value = user.Direccion;
                comando.Parameters.Add("@Email", SqlDbType.NVarChar, 50).Value = user.Email;
                comando.Parameters.Add("@Clave", SqlDbType.NVarChar, 80).Value = EncriptarClave(user.Clave);
                comando.Parameters.Add("@Reparacion_PC", SqlDbType.Bit).Value = user.ReparacionPC;
                comando.Parameters.Add("@Reparacion_Movil", SqlDbType.Bit).Value = user.ReparacionMovil;
                comando.Parameters.Add("@Cambio_De_Piezas", SqlDbType.Bit).Value = user.CambioDePiezas;
                comando.Parameters.Add("@Desbloqueo", SqlDbType.Bit).Value = user.Desbloqueo;
                comando.ExecuteNonQuery();
                MiConexion.Close();
                return true;
                
            }
            catch (Exception)
            {

                return false;
            }
        }

        public static string EncriptarClave(string str) //Funcion para encriptar contraseña en la BD
        {
            string cadena = str + "MiClavePersonal";
            SHA256 sha256 = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha256.ComputeHash(encoding.GetBytes(cadena));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }

        public DataTable GetUsuarios()
        {
            DataTable dt = new DataTable();
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" SELECT * FROM USUARIO ");

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

        public bool ActualizarUsuario(Usuario user)

        {
            bool modifico = false;
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" UPDATE USUARIO ");
                sql.Append(" SET NOMBRE = @Nombre, IDENTIDAD = @Identidad, DIRECCION = @Direccion, EMAIL =  @Email, CLAVE = @Clave, REPARACION_PC = @Reparacion_PC, REPARACION_MOVIL = @Reparacion_Movil, CAMBIO_DE_PIEZAS =  @Cambio_De_Piezas, DESBLOQUEO =  @Desbloqueo ");
                sql.Append(" WHERE ID = @Id; ");

                comando.Connection = MiConexion;
                MiConexion.Open();
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = sql.ToString();
                comando.Parameters.Add("@Id", SqlDbType.Int).Value = user.Id;
                comando.Parameters.Add("@Nombre", SqlDbType.NVarChar, 80).Value = user.Nombre;
                comando.Parameters.Add("@Identidad", SqlDbType.NVarChar, 20).Value = user.Identidad;
                comando.Parameters.Add("@Direccion", SqlDbType.NVarChar, 80).Value = user.Direccion;
                comando.Parameters.Add("@Email", SqlDbType.NVarChar, 50).Value = user.Email;
                comando.Parameters.Add("@Clave", SqlDbType.NVarChar, 80).Value = EncriptarClave(user.Clave);
                comando.Parameters.Add("@Reparacion_PC", SqlDbType.Bit).Value = user.ReparacionPC;
                comando.Parameters.Add("@Reparacion_Movil", SqlDbType.Bit).Value = user.ReparacionMovil;
                comando.Parameters.Add("@Cambio_De_Piezas", SqlDbType.Bit).Value = user.CambioDePiezas;
                comando.Parameters.Add("@Desbloqueo", SqlDbType.Bit).Value = user.Desbloqueo;
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

        public bool EliminarUsuario(int id)
        {
            bool modifico = false;
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" DELETE FROM USUARIO ");         
                sql.Append(" WHERE ID = @Id; ");

                comando.Connection = MiConexion;
                MiConexion.Open();
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = sql.ToString();
                comando.Parameters.Add("@Id", SqlDbType.Int).Value = id;              
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
