using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoporteTecnico_Exa2GD.Modelos.Entidades
{
    public class Estado
    {
        public int Id { get; set; }

        public bool  Abierto { get; set; }

        public bool EnEspera { get; set; }

        public bool SinResolver { get; set; }

        public bool Cerrado { get; set; }

    }
}
