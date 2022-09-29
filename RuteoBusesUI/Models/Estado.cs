using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuteoBusesDAL
{
    public class Estado
    {
        public int EstadoId { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Bus> Buses { get; set; }
    }
}
