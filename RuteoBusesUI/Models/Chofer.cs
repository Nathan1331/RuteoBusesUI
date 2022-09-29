using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuteoBusesDAL
{
    public class Chofer
    {
        public int choferId { get; set; }
        public string nombre { get; set; }
        public string cedula { get; set; }
        //-----------------------------------------------
        public virtual ICollection<Bus> buses { get; set; }
    }
}
