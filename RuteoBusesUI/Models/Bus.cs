using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RuteoBusesDAL
{
    public class Bus
    {
        
        public int busId { get; set; }
        public int? estadoId { get; set; } // el usuario debera elegir de una lista de la tabla estados 
        public virtual Estado? estadoUnidad{ get; set; }
        public int? rutaId { get; set; }

        public virtual Ruta? ruta { get; set; } //Puede ser null se asigna a la hora de asignar ruta
        public int? choferId { get; set; }

        public virtual Chofer? chofer { get; set; }

        public virtual ICollection<ParadaRuta>? paradas { get; set; }

    }
}