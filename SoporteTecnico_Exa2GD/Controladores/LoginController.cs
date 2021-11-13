using SoporteTecnico_Exa2GD.Modelos.DAO;
using SoporteTecnico_Exa2GD.Modelos.Entidades;
using SoporteTecnico_Exa2GD.Vistas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoporteTecnico_Exa2GD.Controladores
{

    public class LoginController
    {

        LoginView vista; //objeto de la vista login

        public LoginController(LoginView view) //se le pasa la vista al coonstructor
        {
            vista = view; //se le pasa la vista al parametro

            vista.Aceptarbutton.Click += new EventHandler(ValidarUsuario); //para ejecutar cuando el usuario de click en la vista



        }

        private void ValidarUsuario(object sender, EventArgs e) //metodo para poder usar Validarusuario de UsuarioDAO
        {
            bool esValido = false; //variable porque ValidarUsuario es bool
            UsuarioDAO userDao = new UsuarioDAO(); //onjeto para conectarse a la base de datos, Objeto de UsuarioDAO

            Usuario user = new Usuario(); //recibira la clave y email para poder conectarse

            user.Email = vista.EmailtextBox.Text;
            user.Clave = EncriptarClave(vista.ContraseñatextBox.Text);

            esValido = userDao.ValidarUsuario(user);

            if (esValido)
            {
                //MessageBox.Show("Usuario Correcto");
                MenuView menu = new MenuView(); //instanciar un objeto para poder llamar nuestro form
                vista.Hide();
                menu.Show();
            }
            else
            {
                MessageBox.Show("Usuario Incorrecto");
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


    }
}
