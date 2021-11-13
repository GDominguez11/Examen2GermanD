using SoporteTecnico_Exa2GD.Controladores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoporteTecnico_Exa2GD.Vistas
{
    public partial class Clientes_ySolicitudView : Form
    {
        public Clientes_ySolicitudView()
        {
            InitializeComponent();
            TipoSolicitudController controller = new TipoSolicitudController(this);
        }

        
    }
}
