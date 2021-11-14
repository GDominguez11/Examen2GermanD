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
    public class EstadoController
    {
        EstadoSolicitud vista;
        string operacion = string.Empty;
        EstadoDAO estadoDAO = new EstadoDAO();
        Estado estado = new Estado();

        public EstadoController(EstadoSolicitud view)
        {
            vista = view;
            vista.Nuevobutton.Click += new EventHandler(Nuevo);
            vista.Guardarbutton.Click += new EventHandler(Guardar);
            vista.Load += new EventHandler(Load);
            vista.Modificarbutton.Click += new EventHandler(Modificar);
            vista.Eliminarbutton.Click += new EventHandler(Eliminar);


        }

        private void Eliminar(object serder, EventArgs e)
        {
            if (vista.EstadodataGridView.SelectedRows.Count > 0)
            {
                bool elimino = estadoDAO.EliminarEstado(Convert.ToInt32(vista.EstadodataGridView.CurrentRow.Cells[0].Value.ToString()));
                if (elimino)
                {
                    DesabilitarControles();
                    LimpiarControles();
                    MessageBox.Show("Estado Eliminado Correctamente", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ListarEstados();
                }
            }
        }

        private void Nuevo(object serder, EventArgs e)
        {
            HabilitarControles();
            operacion = "Nuevo";
        }

        private void Modificar(object serder, EventArgs e)
        {
            operacion = "Modificar";
            if (vista.EstadodataGridView.SelectedRows.Count > 0)
            {
                vista.IdtextBox.Text = vista.EstadodataGridView.CurrentRow.Cells["ID"].Value.ToString();
                vista.AbiertocheckBox.Checked = Convert.ToBoolean(vista.EstadodataGridView.CurrentRow.Cells["ABIERTO"].Value);
                vista.EnEsperacheckBox.Checked = Convert.ToBoolean(vista.EstadodataGridView.CurrentRow.Cells["EN_ESPERA"].Value);
                vista.SinResolvercheckBox.Checked = Convert.ToBoolean(vista.EstadodataGridView.CurrentRow.Cells["SIN_RESOLVER"].Value);
                vista.CerradocheckBox.Checked = Convert.ToBoolean(vista.EstadodataGridView.CurrentRow.Cells["CERRADO"].Value);

                HabilitarControles();

            }
        }

        private void Load(object serder, EventArgs e)
        {
            ListarEstados();
        }



        private void Guardar(object serder, EventArgs e)
        {

            

            estado.Abierto = vista.AbiertocheckBox.Checked;
            estado.EnEspera = vista.EnEsperacheckBox.Checked;
            estado.SinResolver = vista.SinResolvercheckBox.Checked;
            estado.Cerrado = vista.CerradocheckBox.Checked;

            if (operacion == "Nuevo")
            {
                bool inserto = estadoDAO.InsertarEstado(estado);
                if (inserto)
                {
                    DesabilitarControles();
                    LimpiarControles();
                    MessageBox.Show("Estado Asignado Correctamente", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ListarEstados();
                }
                else
                {
                    MessageBox.Show("Error al Asignar el Estado", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else if(operacion == "Modificar")
            {
                estado.Id = Convert.ToInt32(vista.IdtextBox.Text);
                bool modifico = estadoDAO.ActualizarEstado(estado);
                if (modifico)
                {
                    DesabilitarControles();
                    LimpiarControles();
                    MessageBox.Show("Estado Modificado Correctamente", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ListarEstados();
                }
                else
                {
                    MessageBox.Show("Error al Modificar el Estado", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            

           


        }

        private void ListarEstados()
        {
            vista.EstadodataGridView.DataSource = estadoDAO.GetEstado();
        }

        private void LimpiarControles()
        {
            vista.EnEsperacheckBox.Checked = false;
            vista.AbiertocheckBox.Checked = false;
            vista.SinResolvercheckBox.Checked = false;
            vista.CerradocheckBox.Checked = false;
        }

        private void HabilitarControles()
        {
            vista.EnEsperacheckBox.Enabled = true;
            vista.AbiertocheckBox.Enabled = true;
            vista.SinResolvercheckBox.Enabled = true;
            vista.CerradocheckBox.Enabled = true;

            vista.Guardarbutton.Enabled = true;
            vista.Modificarbutton.Enabled = false;
            vista.Nuevobutton.Enabled = false;
        }

        private void DesabilitarControles()
        {
            vista.EnEsperacheckBox.Enabled = false;
            vista.AbiertocheckBox.Enabled = false;
            vista.SinResolvercheckBox.Enabled = false;
            vista.CerradocheckBox.Enabled = false;

            vista.Guardarbutton.Enabled = false;
            vista.Modificarbutton.Enabled = true;
            vista.Nuevobutton.Enabled = true;
        }
    }
}
