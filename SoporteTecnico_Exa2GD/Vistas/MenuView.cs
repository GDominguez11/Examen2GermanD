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
            vista.Show();


        }
    }
}
