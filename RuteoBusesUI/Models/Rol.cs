using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuteoBusesDAL
{
    public class Rol
    {
        public int rolId { get; set; }
        public string Tipo { get; set; }
    }
}
