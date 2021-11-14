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
    public class TicketsController
    {
        TicketsView vista;
        string operacion = string.Empty;
        TicketsDAO ticketDAO = new TicketsDAO();
        Tickets ticket = new Tickets();

        public TicketsController(TicketsView view)
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
            if (vista.TicketsdataGridView.SelectedRows.Count > 0)
            {
                bool elimino = ticketDAO.EliminarTicket(Convert.ToInt32(vista.TicketsdataGridView.CurrentRow.Cells[0].Value.ToString()));

                if (elimino)
                {
                    DesabilitarControles();
                    LimpiarControles();
                    MessageBox.Show("Ticket Eliminado Exitosamente", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ListarTickets();
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
            if (vista.TicketsdataGridView.SelectedRows.Count > 0)
            {
                vista.IdtextBox.Text = vista.TicketsdataGridView.CurrentRow.Cells["ID"].Value.ToString();
                vista.DispositivotextBox.Text = vista.TicketsdataGridView.CurrentRow.Cells["DISPOSITIVO"].Value.ToString();
                vista.DescripciontextBox.Text = vista.TicketsdataGridView.CurrentRow.Cells["DESCRIPCION"].Value.ToString();
                vista.ImportetextBox.Text = vista.TicketsdataGridView.CurrentRow.Cells["IMPORTE"].Value.ToString();

                HabilitarControles();
            }
        }

        private void Load(object sender, EventArgs e)
        {
            ListarTickets();
        }

        private void Guardar(object sender, EventArgs e)
        {
            if (vista.DispositivotextBox.Text == "")
            {
                vista.errorProvider1.SetError(vista.DispositivotextBox, "Ingrese Tipo de Dispositivo");
                vista.DispositivotextBox.Focus();
                return;
            }
            if (vista.DescripciontextBox.Text == "")
            {
                vista.errorProvider1.SetError(vista.DescripciontextBox, "Ingrese Descripcion del Dispositivo");
                vista.DescripciontextBox.Focus();
                return;
            }
            if (vista.ImportetextBox.Text == "")
            {
                vista.errorProvider1.SetError(vista.ImportetextBox, "Ingrese El Importe Total de la Solicitud");
                vista.ImportetextBox.Focus();
                return;
            }

            

            ticket.Dispositivo = vista.DispositivotextBox.Text;
            ticket.Descripcion = vista.DescripciontextBox.Text;
            ticket.Importe = vista.ImportetextBox.Text;
            ticket.Fecha = vista.FechadateTimePicker.Value;

            if (operacion == "Nuevo")
            {
                bool inserto = ticketDAO.InsertarTicket(ticket);
                if (inserto)
                {
                    DesabilitarControles();
                    LimpiarControles();
                    MessageBox.Show("Ticket Creado Exitosamente", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ListarTickets();
                }
                else
                {
                    MessageBox.Show("Fallo al Crear el Ticket", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            else if(operacion == "Modificar")
            {
                ticket.Id = Convert.ToInt32(vista.IdtextBox.Text);
                bool modifico = ticketDAO.ActualizarTicket(ticket);
                if (modifico)
                {
                    DesabilitarControles();
                    LimpiarControles();
                    MessageBox.Show("Ticket Modificado Exitosamente", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ListarTickets();
                }
                else
                {
                    MessageBox.Show("Fallo al Modificar el Ticket", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            

           
        }

        
        private void ListarTickets()
        {
            vista.TicketsdataGridView.DataSource = ticketDAO.GetTickets();
        }

        private void LimpiarControles()
        {
            vista.IdtextBox.Clear();
            vista.DispositivotextBox.Clear();
            vista.DescripciontextBox.Clear();
            vista.ImportetextBox.Clear();
            vista.FechadateTimePicker.Enabled = false;
            

        }

        private void HabilitarControles()
        {
            vista.IdtextBox.Enabled = true;
            vista.DispositivotextBox.Enabled = true;
            vista.DescripciontextBox.Enabled = true;
            vista.ImportetextBox.Enabled = true;
            vista.FechadateTimePicker.Enabled = true;

            vista.Guardarbutton.Enabled = true;
            vista.Modificarbutton.Enabled = false;
            vista.Nuevobutton.Enabled = false;
        }

        private void DesabilitarControles()
        {
            vista.IdtextBox.Enabled = false;
            vista.DispositivotextBox.Enabled = false;
            vista.DescripciontextBox.Enabled = false;
            vista.ImportetextBox.Enabled = false;
            vista.FechadateTimePicker.Enabled = false;

            vista.Guardarbutton.Enabled = false;
            vista.Modificarbutton.Enabled = true;
            vista.Nuevobutton.Enabled = true;
        }
    }
}
