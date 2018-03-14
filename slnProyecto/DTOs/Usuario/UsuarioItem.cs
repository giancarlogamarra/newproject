using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Usuario
{
    public class UsuarioItem
    {
        public Guid ID { get; set; }
        public string USUARIO { get; set; }
        public string PASSWORD { get; set; }
        public string NOMBRE_COMPLETO { get; set; }
        public string ROL { get; set; }
        public bool ESTADO { get; set; }
    }
}
