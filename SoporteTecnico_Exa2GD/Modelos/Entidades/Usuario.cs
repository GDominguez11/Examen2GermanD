using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoporteTecnico_Exa2GD.Modelos.Entidades
{
    public class Usuario
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Identidad { get; set; }

        public string Direccion { get; set; }

        public string Email { get; set; }

        public string Clave { get; set; }

        public bool ReparacionPC { get; set; }

        public bool ReparacionMovil { get; set; }

        public bool CambioDePiezas { get; set; }

        public bool Desbloqueo { get; set; }






    }
}
