using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoporteTecnico_Exa2GD.Modelos.Entidades
{
    public class Tickets
    {
        public int Id { get; set; }

        public string Dispositivo { get; set; }

        public string Descripcion { get; set; }

        public string Importe { get; set; }

        public DateTime Fecha { get; set; }

    }
}
