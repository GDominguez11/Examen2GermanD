using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SoporteTecnico_Exa2GD.Vistas
{
    public partial class MenuView : Syncfusion.Windows.Forms.Office2010Form
    {
        public MenuView()
        {
            InitializeComponent();
        }

        private void ClientesyTipostoolStripButton_Click(object sender, EventArgs e)
        {
            Clientes_ySolicitudView vista = new Clientes_ySolicitudView();
            vista.MdiParent = this;
            vista.Show();


        }

        private void SolicitudestoolStripButton_Click(object sender, EventArgs e)
        {
            EstadoSolicitud vista = new EstadoSolicitud();
            vista.MdiParent = this;
            vista.Show();
        }

        private void RibbonPanel_Click(object sender, EventArgs e)
        {

        }

        private void TicketstoolStripButton_Click(object sender, EventArgs e)
        {
            TicketsView vista = new TicketsView();
            vista.MdiParent = this;
            vista.Show();
        }
    }
}
