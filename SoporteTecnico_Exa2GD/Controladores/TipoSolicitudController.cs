using SoporteTecnico_Exa2GD.Modelos.DAO;
using SoporteTecnico_Exa2GD.Modelos.Entidades;
using SoporteTecnico_Exa2GD.Vistas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoporteTecnico_Exa2GD.Controladores
{
    public class TipoSolicitudController
    {

        Clientes_ySolicitudView vista;
        string operacion = string.Empty;
        UsuarioDAO userDAO = new UsuarioDAO();
        Usuario user = new Usuario();

        public TipoSolicitudController(Clientes_ySolicitudView view)
        {
            vista = view;
            vista.Nuevobutton.Click += new EventHandler(Nuevo);
            vista.Guardarbutton.Click += new EventHandler(Guardar);
            vista.Load += new EventHandler(Load);
            vista.Modificarbutton.Click += new EventHandler(Modificar);
            vista.Eliminarbutton.Click += new EventHandler(Eliminar);
        }

        private void Eliminar(object sender, EventArgs e)
        {
            if (vista.SolicituddataGridView.SelectedRows.Count > 0)
            {
                bool elimino = userDAO.EliminarUsuario(Convert.ToInt32(vista.SolicituddataGridView.CurrentRow.Cells[0].Value.ToString()));

                if (elimino)
                {
                    DesabilitarControles();
                    LimpiarControles();
                    MessageBox.Show("Solicitud Eliminada Exitosamente", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ListarUsuarios();
                }
                
            }
        }

        private void Nuevo(object sender, EventArgs e)
        {
            HabilitarControles();
            operacion = "Nuevo";
        }

        private void Modificar(object sender, EventArgs e)
        {
            operacion = "Modificar";
            if (vista.SolicituddataGridView.SelectedRows.Count > 0)
            {
                vista.IdtextBox.Text = vista.SolicituddataGridView.CurrentRow.Cells["ID"].Value.ToString();
                vista.NombretextBox.Text = vista.SolicituddataGridView.CurrentRow.Cells["NOMBRE"].Value.ToString();
                vista.IdentidadtextBox.Text = vista.SolicituddataGridView.CurrentRow.Cells["IDENTIDAD"].Value.ToString();
                vista.DirecciontextBox.Text = vista.SolicituddataGridView.CurrentRow.Cells["DIRECCION"].Value.ToString();
                vista.EmailtextBox.Text = vista.SolicituddataGridView.CurrentRow.Cells["EMAIL"].Value.ToString();
                vista.ReparacionPCcheckBox.Checked = Convert.ToBoolean(vista.SolicituddataGridView.CurrentRow.Cells["REPARACION_PC"].Value);
                vista.ReparacionMovilcheckBox.Checked = Convert.ToBoolean(vista.SolicituddataGridView.CurrentRow.Cells["REPARACION_MOVIL"].Value);
                vista.CambioPiezascheckBox.Checked = Convert.ToBoolean(vista.SolicituddataGridView.CurrentRow.Cells["CAMBIO_DE_PIEZAS"].Value);
                vista.DesbloqueocheckBox.Checked = Convert.ToBoolean(vista.SolicituddataGridView.CurrentRow.Cells["DESBLOQUEO"].Value);

                HabilitarControles();
            }
        }

        private void Load(object sender, EventArgs e)
        {
            ListarUsuarios();
        }



        private void Guardar(object sender, EventArgs e)
        {
            if (vista.NombretextBox.Text == "")
            {
                vista.errorProvider1.SetError(vista.NombretextBox, "Ingrese un nombre");
                vista.NombretextBox.Focus();
                return;
            }
            if (vista.IdentidadtextBox.Text == "")
            {
                vista.errorProvider1.SetError(vista.IdentidadtextBox, "Ingrese una Identidad");
                vista.IdentidadtextBox.Focus();
                return;
            }
            if (vista.DirecciontextBox.Text == "")
            {
                vista.errorProvider1.SetError(vista.DirecciontextBox, "Ingrese una Direccion");
                vista.DirecciontextBox.Focus();
                return;
            }
            if (vista.EmailtextBox.Text == "")
            {
                vista.errorProvider1.SetError(vista.EmailtextBox, "Ingrese un Email");
                vista.EmailtextBox.Focus();
                return;
            }
            if (vista.ClavetextBox.Text == "")
            {
                vista.errorProvider1.SetError(vista.ClavetextBox, "Ingrese su clave de Cliente");
                vista.ClavetextBox.Focus();
                return;
            }

         

            user.Nombre = vista.NombretextBox.Text;
            user.Identidad = vista.IdentidadtextBox.Text;
            user.Direccion = vista.DirecciontextBox.Text;
            user.Email = vista.EmailtextBox.Text;
            user.Clave = vista.ClavetextBox.Text;
            user.ReparacionPC = vista.ReparacionPCcheckBox.Checked;
            user.ReparacionMovil = vista.ReparacionMovilcheckBox.Checked;
            user.CambioDePiezas = vista.CambioPiezascheckBox.Checked;
            user.Desbloqueo = vista.DesbloqueocheckBox.Checked;

            if (operacion == "Nuevo")
            {
                bool inserto = userDAO.InsertarNuevoUsuario(user);

                if (inserto)
                {
                    DesabilitarControles();
                    LimpiarControles();
                    MessageBox.Show("Solicitud Creada Exitosamente", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ListarUsuarios();
                }
                else
                {
                    MessageBox.Show("Fallo al crear su Solicitud", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (operacion == "Modificar")
            {
                user.Id = Convert.ToInt32(vista.IdtextBox.Text);
                bool Modifico = userDAO.ActualizarUsuario(user);
               
                if (Modifico)
                {
                    DesabilitarControles();
                    LimpiarControles();
                    MessageBox.Show("Solicitud Modificada Exitosamente", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    ListarUsuarios();
                }
                else
                {
                    MessageBox.Show("Fallo al Modificar su Solicitud", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

           
          

        }

        private void ListarUsuarios()
        {
            vista.SolicituddataGridView.DataSource = userDAO.GetUsuarios(); 
        }


        private void LimpiarControles()
        {
            vista.IdtextBox.Clear();
            vista.NombretextBox.Clear();
            vista.IdentidadtextBox.Clear();
            vista.DirecciontextBox.Clear();
            vista.EmailtextBox.Clear();
            vista.ClavetextBox.Clear();
            vista.ReparacionPCcheckBox.Checked = false;
            vista.ReparacionMovilcheckBox.Checked = false;
            vista.CambioPiezascheckBox.Checked = false;
            vista.DesbloqueocheckBox.Checked = false;


        }

        private void HabilitarControles()
        {
            vista.IdtextBox.Enabled = true;
            vista.NombretextBox.Enabled = true;
            vista.IdentidadtextBox.Enabled = true;
            vista.DirecciontextBox.Enabled = true;
            vista.EmailtextBox.Enabled = true;
            vista.ClavetextBox.Enabled = true;
            vista.SolicitudgroupBox.Enabled = true;
            
            

            vista.Guardarbutton.Enabled = true;
            vista.Modificarbutton.Enabled = false;
            vista.Nuevobutton.Enabled = false;
        }

        private void DesabilitarControles()
        {
            vista.IdtextBox.Enabled = false;
            vista.NombretextBox.Enabled = false;
            vista.IdentidadtextBox.Enabled = false;
            vista.DirecciontextBox.Enabled = false;
            vista.EmailtextBox.Enabled = false;
            vista.ClavetextBox.Enabled = false;
            vista.SolicitudgroupBox.Enabled = false;



            vista.Guardarbutton.Enabled = false;           
            vista.Modificarbutton.Enabled = true;
            vista.Nuevobutton.Enabled = true;
        }

    }
}
