
using RuteoBusesDAL;
using System.Collections.Generic;
using System.Linq;

namespace FrontEnd_Hotel.Data
{
    public class DA_logica
    {

        //se puede utiliza ADO.NET 

        public List<Usuario> ListaUsuario()
        {

            return new List<Usuario>
            {
                new Usuario{nombre = "Empleado", Identificacion = "123", clave = "claveEmpleado", rolId = 2},
                new Usuario{nombre = "Admin",Identificacion = "1010", clave = "claveAdmin" , rolId=1}

            };


        }


        public Usuario ValidarUsuario(string _correo, string _clave)
        {
            return ListaUsuario().Where(item => item.Identificacion ==  _correo && item.clave == _clave).FirstOrDefault();
        }

    }
}
