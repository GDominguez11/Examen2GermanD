using SoporteTecnico_Exa2GD.Vistas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoporteTecnico_Exa2GD.Controladores
{
    public class TicketsController
    {
        TicketsView vista;

        public TicketsController(TicketsView view)
        {
            vista = view;
            vista.Nuevobutton.Click += new EventHandler(Nuevo);
        }

        private void Nuevo(object sender, EventArgs e)
        {
            HabilitarControles();
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
    }
}
