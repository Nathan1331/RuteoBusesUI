using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuteoBusesDAL
{
    public class Ruta
    {
        public int rutaId { get; set; }
        public string nombreRuta { get; set; }
        public double montoEstimado { get; set; }
        public double montoRecibido { get; set; }
        public int cantidadDeParadas { get; set; }

        public virtual ICollection<Bus>? buses { get; set; }
        public virtual ICollection<ParadaRuta>? paradas { get; set; }
    }
}
