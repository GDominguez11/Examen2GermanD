using SoporteTecnico_Exa2GD.Modelos.DAO;
using SoporteTecnico_Exa2GD.Vistas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoporteTecnico_Exa2GD.Controladores
{
    public class DetalleController
    {
        DetallesView vista;
        DetalleDAO detalleDAO = new DetalleDAO();

        public DetalleController(DetallesView view)
        {
            vista = view;

            vista.Load += new EventHandler(Load);
        }

        private void Load(object serder, EventArgs e)
        {
            ListarDetalles();
        }

        private void ListarDetalles()
        {
            vista.DetalledataGridView.DataSource = detalleDAO.GetDetalles();
        }
    }
}
