using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuteoBusesDAL
{
    public class ParadaRuta
    {
        
        public int paradaRutaId { get; set; }
        public string nombreParadaRuta { get; set; }
        //-----------------------------------------------
        public int?  rutaId { get; set; }// se define a cual ruta pertenece
        
        public virtual Ruta? ruta { get; set; }

        public int? busId { get; set; }

        
        public virtual Bus? bus { get; set; }


    }
}
