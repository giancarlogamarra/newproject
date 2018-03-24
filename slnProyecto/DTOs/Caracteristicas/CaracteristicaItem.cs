using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Caracteristicas
{
    public class CaracteristicaItem
    {
        public Guid ID { get; set; }
        public string CARACTERISTICA { get; set; }
        public string VALOR { get; set; }

        public bool ESTADO { get; set; }
    }
}
