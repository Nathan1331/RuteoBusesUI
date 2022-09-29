using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using RuteoBusesDAL;

namespace RuteoBusesUI.Conexion
{
    public class GestorConexiones
    {
        #region Propiedad
        public HttpClient conexion { get; set; }
        #endregion

        #region Constructor 
        public GestorConexiones()
        {
            conexion = new HttpClient();
            conexion.BaseAddress = new Uri("https://localhost:7277/");
            conexion.DefaultRequestHeaders.Accept.Clear();
            conexion.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        #endregion

        #region Metodos Bus
        /// <summary>
        /// Método para listar articulos de la base de datos
        /// </summary>
        /// <returns></returns>
        /// 

        public List<SelectListItem> ListarBusesSelectItems()
        {
            IEnumerable<Bus> buses = ListarBuses().Result;
            List<SelectListItem> listaBuses = new List<SelectListItem>();
            foreach (Bus bus in buses)
            {
                listaBuses.Add(
                    new SelectListItem
                    {
                        Text = bus.busId.ToString(),
                        Value = bus.busId.ToString()
                    }
                    );
            }
            if (listaBuses.Count > 0)
            {
                return listaBuses;
            }
            return null;

        }
        public async Task<IEnumerable<Bus>>? ListarBuses()
        {
            IEnumerable<Bus>? listaBus = new List<Bus>();

            string url = "api/Buses";
            HttpResponseMessage resultado = await conexion.GetAsync(url);

            if (resultado.IsSuccessStatusCode)
            {
                var jsonString = await resultado.Content.ReadAsStringAsync();
                listaBus = JsonConvert.DeserializeObject<IEnumerable<Bus>>(jsonString);
            }

            return listaBus;
        }

        public async Task<IEnumerable<Bus>>? ListarBusesEstado(int id)
        {
            IEnumerable<Bus>? listaBus = new List<Bus>();

            string url = "api/Buses";
            HttpResponseMessage resultado = await conexion.GetAsync(url);

            if (resultado.IsSuccessStatusCode)
            {
                var jsonString = await resultado.Content.ReadAsStringAsync();
                listaBus = JsonConvert.DeserializeObject<IEnumerable<Bus>>(jsonString);
            }
            List<Bus>? listaBusEst = new List<Bus>();

            foreach (var bus in listaBus) 
            {
                if(bus.estadoId == id) 
                {
                    listaBusEst.Add(bus);
                }
            }

            return listaBusEst;
        }
        public async Task<IEnumerable<Bus>>? ListarBusesChofer(int id)
        {
            IEnumerable<Bus>? listaBus = new List<Bus>();

            string url = "api/Buses";
            HttpResponseMessage resultado = await conexion.GetAsync(url);

            if (resultado.IsSuccessStatusCode)
            {
                var jsonString = await resultado.Content.ReadAsStringAsync();
                listaBus = JsonConvert.DeserializeObject<IEnumerable<Bus>>(jsonString);
            }
            List<Bus>? listaBusEst = new List<Bus>();

            foreach (var bus in listaBus)
            {
                if (bus.choferId == id)
                {
                    listaBusEst.Add(bus);
                }
            }

            return listaBusEst;
        }


        /// <summary>
        /// Metodo para agregar un cliente en la base de datos
        /// </summary>
        /// <param name="P_Modelo">Modelo de tipo Cliente</param>
        /// <returns>TRUE = Correcto | FALSE = Incorrecto</returns>
        public async Task<bool> AgregarBus(Bus bus)
        {
            string url = "api/Buses";
            HttpResponseMessage resultado = await conexion.PostAsJsonAsync(url, bus);
            return resultado.IsSuccessStatusCode;
        }

        /// <summary>
        /// Metodo para eliminar un articulo en la base de datos
        /// </summary>
        /// <param name="P_Modelo">Modelo de tipo ArticuloModel</param>
        /// <returns>TRUE = Correcto | FALSE = Incorrecto</returns>
        public async Task<bool> EliminarBus(int? bus)
        {
            string url = "api/Buses/"+bus;
            HttpResponseMessage resultado = await conexion.DeleteAsync(url);
            return resultado.IsSuccessStatusCode;
        }

        /// <summary>
        /// Metodo para modificar un articulo en la base de datos
        /// </summary>
        /// <param name="P_Modelo">Modelo de tipo ArticuloModel</param>
        /// <returns>TRUE = Correcto | FALSE = Incorrecto</returns>
        public async Task<Bus>? BusPorId(int? id)
        {
            Bus? bus = new Bus();
            string url = "api/Buses/"+id;
            HttpResponseMessage resultado = await conexion.GetAsync(url);
            if (resultado.IsSuccessStatusCode)
            {
                var jsonString = await resultado.Content.ReadAsStringAsync();
                bus = JsonConvert.DeserializeObject<Bus>(jsonString);
            }

            return bus;
        }
        

        /// <summary>
        /// Metodo para modificar un articulo en la base de datos
        /// </summary>
        /// <param name="P_Modelo">Modelo de tipo ArticuloModel</param>
        /// <returns>TRUE = Correcto | FALSE = Incorrecto</returns>
        public async Task<bool> ModificarBus(int? Id, Bus? bus)
        {
            string url = "api/Buses/" + Id;
            HttpResponseMessage resultado = await conexion.PutAsJsonAsync(url, bus);
            return resultado.IsSuccessStatusCode;
              }
        #endregion


        #region Metodo Roles

        public List<SelectListItem> ListarRolesSelectItems()
        {
            IEnumerable<Rol> roles = ListarRoles().Result;
            List<SelectListItem> listaRoles = new List<SelectListItem>();
            foreach (Rol rol in roles)
            {
                listaRoles.Add(
                    new SelectListItem
                    {
                        Text = rol.Tipo,
                        Value = rol.rolId.ToString()
                    }
                    );
            }
            if (listaRoles.Count > 0)
            {
                return listaRoles;
            }
            return null;

        }

        public async Task<IEnumerable<Rol>>? ListarRoles()
        {
            IEnumerable<Rol>? listaRoles = new List<Rol>();

            string url = "api/Rols";
            HttpResponseMessage resultado = await conexion.GetAsync(url);

            if (resultado.IsSuccessStatusCode)
            {
                var jsonString = await resultado.Content.ReadAsStringAsync();
                listaRoles = JsonConvert.DeserializeObject<IEnumerable<Rol>>(jsonString);
            }

            return listaRoles;
        }
        #endregion



        #region Metodos Ruta

        /// <summary>
        /// Método para listar articulos de la base de datos
        /// </summary>
        /// <returns></returns>
        /// 


        public List<SelectListItem> ListarRutasSelectItems()
        {
            IEnumerable<Ruta> rutas = ListarRutas().Result;
            List<SelectListItem> listaRutas = new List<SelectListItem>();
            foreach (Ruta ruta in rutas)
            {
                listaRutas.Add(
                    new SelectListItem
                    {
                        Text = ruta.nombreRuta,
                        Value = ruta.rutaId.ToString()
                    }
                    );
            }
            if (listaRutas.Count > 0)
            {
                return listaRutas;
            }
            return null;

        }
        public async Task<IEnumerable<Ruta>>? ListarRutas()
        {
            IEnumerable<Ruta>? listaRuta = new List<Ruta>();

            string url = "api/Rutas";
            HttpResponseMessage resultado = await conexion.GetAsync(url);

            if (resultado.IsSuccessStatusCode)
            {
                var jsonString = await resultado.Content.ReadAsStringAsync();
                listaRuta = JsonConvert.DeserializeObject<IEnumerable<Ruta>>(jsonString);
            }

            return listaRuta;
        }


        /// <summary>
        /// Metodo para agregar un cliente en la base de datos
        /// </summary>
        /// <param name="P_Modelo">Modelo de tipo Cliente</param>
        /// <returns>TRUE = Correcto | FALSE = Incorrecto</returns>
        public async Task<bool> AgregarRuta(Ruta ruta)
        {
            string url = "api/Rutas";
            HttpResponseMessage resultado = await conexion.PostAsJsonAsync(url, ruta);
            return resultado.IsSuccessStatusCode;
        }

        /// <summary>
        /// Metodo para eliminar un articulo en la base de datos
        /// </summary>
        /// <param name="P_Modelo">Modelo de tipo ArticuloModel</param>
        /// <returns>TRUE = Correcto | FALSE = Incorrecto</returns>
        public async Task<bool> EliminarRuta(int? id)
        {
            string url = "api/Rutas/" + id;
            HttpResponseMessage resultado = await conexion.DeleteAsync(url);
            return resultado.IsSuccessStatusCode;
        }

        /// <summary>
        /// Metodo para modificar un articulo en la base de datos
        /// </summary>
        /// <param name="P_Modelo">Modelo de tipo ArticuloModel</param>
        /// <returns>TRUE = Correcto | FALSE = Incorrecto</returns>
        public async Task<Ruta>? RutaPorId(int? id)
        {
            Ruta? ruta = new Ruta();
            string url = "api/Rutas/" + id;
            HttpResponseMessage resultado = await conexion.GetAsync(url);
            if (resultado.IsSuccessStatusCode)
            {
                var jsonString = await resultado.Content.ReadAsStringAsync();
                ruta = JsonConvert.DeserializeObject<Ruta>(jsonString);
            }

            return ruta;
        }


        /// <summary>
        /// Metodo para modificar un articulo en la base de datos
        /// </summary>
        /// <param name="P_Modelo">Modelo de tipo ArticuloModel</param>
        /// <returns>TRUE = Correcto | FALSE = Incorrecto</returns>
        public async Task<bool> ModificarRuta(int? Id, Ruta? ruta)
        {
            string url = "api/Rutas/" + Id;
            HttpResponseMessage resultado = await conexion.PutAsJsonAsync(url, ruta);
            return resultado.IsSuccessStatusCode;
        }
        #endregion





        #region Metodos Parada Ruta

        /// <summary>
        /// Método para listar articulos de la base de datos
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ParadaRuta>>? ListarParadasRutas()
        {
            IEnumerable<ParadaRuta>? listaParadaRuta = new List<ParadaRuta>();

            string url = "api/ParadaRutas";
            HttpResponseMessage resultado = await conexion.GetAsync(url);

            if (resultado.IsSuccessStatusCode)
            {
                var jsonString = await resultado.Content.ReadAsStringAsync();
                listaParadaRuta = JsonConvert.DeserializeObject<IEnumerable<ParadaRuta>>(jsonString);
            }

            return listaParadaRuta;
        }


        /// <summary>
        /// Metodo para agregar un cliente en la base de datos
        /// </summary>
        /// <param name="P_Modelo">Modelo de tipo Cliente</param>
        /// <returns>TRUE = Correcto | FALSE = Incorrecto</returns>
        public async Task<bool> AgregarParadaRuta(ParadaRuta ruta)
        {
            string url = "api/ParadaRutas";
            HttpResponseMessage resultado = await conexion.PostAsJsonAsync(url, ruta);
            return resultado.IsSuccessStatusCode;
        }

        /// <summary>
        /// Metodo para eliminar un articulo en la base de datos
        /// </summary>
        /// <param name="P_Modelo">Modelo de tipo ArticuloModel</param>
        /// <returns>TRUE = Correcto | FALSE = Incorrecto</returns>
        public async Task<bool> EliminarParadaRuta(int? id)
        {
            string url = "api/ParadaRutas/" + id;
            HttpResponseMessage resultado = await conexion.DeleteAsync(url);
            return resultado.IsSuccessStatusCode;
        }

        /// <summary>
        /// Metodo para modificar un articulo en la base de datos
        /// </summary>
        /// <param name="P_Modelo">Modelo de tipo ArticuloModel</param>
        /// <returns>TRUE = Correcto | FALSE = Incorrecto</returns>
        public async Task<ParadaRuta>? ParadaRutaPorId(int? id)
        {
            ParadaRuta? paradaRuta = new ParadaRuta();
            string url = "api/ParadaRutas/" + id;
            HttpResponseMessage resultado = await conexion.GetAsync(url);
            if (resultado.IsSuccessStatusCode)
            {
                var jsonString = await resultado.Content.ReadAsStringAsync();
                paradaRuta = JsonConvert.DeserializeObject<ParadaRuta>(jsonString);
            }

            return paradaRuta;
        }


        /// <summary>
        /// Metodo para modificar un articulo en la base de datos
        /// </summary>
        /// <param name="P_Modelo">Modelo de tipo ArticuloModel</param>
        /// <returns>TRUE = Correcto | FALSE = Incorrecto</returns>
        public async Task<bool> ModificarParadaRuta(int? Id, ParadaRuta? paradaRuta)
        {
            string url = "api/ParadaRutas/" + Id;
            HttpResponseMessage resultado = await conexion.PutAsJsonAsync(url, paradaRuta);
            return resultado.IsSuccessStatusCode;
        }
        #endregion




        #region Metodos Usuario

        //public async Task<List<Usuario>>? nuevaListarUsuarios()
        //{
        //    IEnumerable<Usuario>? listaUsuarios = new List<Usuario>();

        //    string url = "api/Usuarios";
        //    HttpResponseMessage resultado = await conexion.GetAsync(url);

        //    if (resultado.IsSuccessStatusCode)
        //    {
        //        var jsonString = await resultado.Content.ReadAsStringAsync();
        //        listaUsuarios = JsonConvert.DeserializeObject<List<Usuario>>(jsonString);
        //    }

        //    return listaUsuarios;
        //}
        /// <summary>
        /// Método para listar articulos de la base de datos
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Usuario>>? ListarUsuarios()
        {
            IEnumerable<Usuario>? listaUsuarios = new List<Usuario>();

            string url = "api/Usuarios";
            HttpResponseMessage resultado = await conexion.GetAsync(url);

            if (resultado.IsSuccessStatusCode)
            {
                var jsonString = await resultado.Content.ReadAsStringAsync();
                listaUsuarios = JsonConvert.DeserializeObject<IEnumerable<Usuario>>(jsonString);
            }

            return listaUsuarios;
        }


        /// <summary>
        /// Metodo para agregar un cliente en la base de datos
        /// </summary>
        /// <param name="P_Modelo">Modelo de tipo Cliente</param>
        /// <returns>TRUE = Correcto | FALSE = Incorrecto</returns>
        public async Task<bool> AgregarUsuario(Usuario usuario)
        {
            string url = "api/Usuarios";
            HttpResponseMessage resultado = await conexion.PostAsJsonAsync(url, usuario);
            return resultado.IsSuccessStatusCode;
        }

        /// <summary>
        /// Metodo para eliminar un articulo en la base de datos
        /// </summary>
        /// <param name="P_Modelo">Modelo de tipo ArticuloModel</param>
        /// <returns>TRUE = Correcto | FALSE = Incorrecto</returns>
        public async Task<bool> EliminarUsuario(int? id)
        {
            string url = "api/Usuarios/" + id;
            HttpResponseMessage resultado = await conexion.DeleteAsync(url);
            return resultado.IsSuccessStatusCode;
        }

        /// <summary>
        /// Metodo para modificar un articulo en la base de datos
        /// </summary>
        /// <param name="P_Modelo">Modelo de tipo ArticuloModel</param>
        /// <returns>TRUE = Correcto | FALSE = Incorrecto</returns>
        public async Task<Usuario>? UsuarioPorId(int? id)
        {
            Usuario? usuario = new Usuario();
            string url = "api/Usuarios/" + id;
            HttpResponseMessage resultado = await conexion.GetAsync(url);
            if (resultado.IsSuccessStatusCode)
            {
                var jsonString = await resultado.Content.ReadAsStringAsync();
                usuario = JsonConvert.DeserializeObject<Usuario>(jsonString);
            }

            return usuario;
        }


        /// <summary>
        /// Metodo para modificar un articulo en la base de datos
        /// </summary>
        /// <param name="P_Modelo">Modelo de tipo ArticuloModel</param>
        /// <returns>TRUE = Correcto | FALSE = Incorrecto</returns>
        public async Task<bool> ModificarUsuario(int? Id, Usuario? usuario)
        {
            string url = "api/Usuarios/" + Id;
            HttpResponseMessage resultado = await conexion.PutAsJsonAsync(url, usuario);
            return resultado.IsSuccessStatusCode;
        }
        #endregion






        #region Metodos chofer

        /// <summary>
        /// Método para listar articulos de la base de datos
        /// </summary>
        /// <returns></returns>
        /// 

        public List<SelectListItem> ListarChoferesSelectItems()
        {
            IEnumerable<Chofer> choferes = ListarChoferes().Result;
            List<SelectListItem> listaChoferes = new List<SelectListItem>();
            foreach (Chofer chofer in choferes)
            {
                listaChoferes.Add(
                    new SelectListItem
                    {
                        Text = chofer.nombre + " - " + chofer.cedula,
                        Value = chofer.choferId.ToString()
                    }
                    );
            }
            if (listaChoferes.Count > 0)
            {
                return listaChoferes;
            }
            return null;

        }

        public async Task<IEnumerable<Chofer>>? ListarChoferes()
        {
            IEnumerable<Chofer>? listaBus = new List<Chofer>();

            string url = "api/Choferes";
            HttpResponseMessage resultado = await conexion.GetAsync(url);

            if (resultado.IsSuccessStatusCode)
            {
                var jsonString = await resultado.Content.ReadAsStringAsync();
                listaBus = JsonConvert.DeserializeObject<IEnumerable<Chofer>>(jsonString);
            }

            return listaBus;
        }

        /// <summary>
        /// Metodo para agregar un cliente en la base de datos
        /// </summary>
        /// <param name="P_Modelo">Modelo de tipo Cliente</param>
        /// <returns>TRUE = Correcto | FALSE = Incorrecto</returns>
        public async Task<bool> AgregarChofer(Chofer chofer)
        {
            string url = "api/Choferes";
            HttpResponseMessage resultado = await conexion.PostAsJsonAsync(url, chofer);
            return resultado.IsSuccessStatusCode;
        }

        /// <summary>
        /// Metodo para eliminar un articulo en la base de datos
        /// </summary>
        /// <param name="P_Modelo">Modelo de tipo ArticuloModel</param>
        /// <returns>TRUE = Correcto | FALSE = Incorrecto</returns>
        public async Task<bool> EliminarChofer(int? chofer)
        {
            string url = "api/Choferes/" + chofer;
            HttpResponseMessage resultado = await conexion.DeleteAsync(url);
            return resultado.IsSuccessStatusCode;
        }

        /// <summary>
        /// Metodo para modificar un articulo en la base de datos
        /// </summary>
        /// <param name="P_Modelo">Modelo de tipo ArticuloModel</param>
        /// <returns>TRUE = Correcto | FALSE = Incorrecto</returns>
        public async Task<Chofer>? ChoferPorId(int? id)
        {
            Chofer? chofer = new Chofer();
            string url = "api/Choferes/" + id;
            HttpResponseMessage resultado = await conexion.GetAsync(url);
            if (resultado.IsSuccessStatusCode)
            {
                var jsonString = await resultado.Content.ReadAsStringAsync();
                chofer = JsonConvert.DeserializeObject<Chofer>(jsonString);
            }

            return chofer;
        }


        /// <summary>
        /// Metodo para modificar un articulo en la base de datos
        /// </summary>
        /// <param name="P_Modelo">Modelo de tipo ArticuloModel</param>
        /// <returns>TRUE = Correcto | FALSE = Incorrecto</returns>
        public async Task<bool> ModificarChofer(int? Id, Chofer? chofer)
        {
            string url = "api/Choferes/" + Id;
            HttpResponseMessage resultado = await conexion.PutAsJsonAsync(url, chofer);
            return resultado.IsSuccessStatusCode;
        }
        #endregion

        #region Metodos Estado

        /// <summary>
        /// Método para listar articulos de la base de datos
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Estado>>? ListarEstados()
        {
            IEnumerable<Estado>? listaEstados = new List<Estado>();

            string url = "api/Estados";
            HttpResponseMessage resultado = await conexion.GetAsync(url);

            if (resultado.IsSuccessStatusCode)
            {
                var jsonString = await resultado.Content.ReadAsStringAsync();
                listaEstados = JsonConvert.DeserializeObject<IEnumerable<Estado>>(jsonString);
            }
            return listaEstados;
        }

        public List<SelectListItem> ListarEstadosSelectItems() 
        {
            IEnumerable<Estado> estados = ListarEstados().Result;
            List<SelectListItem> listaEstados = new List<SelectListItem>();
            foreach(Estado estado in estados) 
            {
                listaEstados.Add(
                    new SelectListItem
                    {
                        Text = estado.Description,
                        Value = estado.EstadoId.ToString()
                    }
                    ) ;
            }
            if(listaEstados.Count > 0) 
            {
                return listaEstados;
            }
            return null;

        }

        /// <summary>
        /// Metodo para agregar un cliente en la base de datos
        /// </summary>
        /// <param name="P_Modelo">Modelo de tipo Cliente</param>
        /// <returns>TRUE = Correcto | FALSE = Incorrecto</returns>
        public async Task<bool> AgregarEstado(Estado estado)
        {
            string url = "api/Estados";
            HttpResponseMessage resultado = await conexion.PostAsJsonAsync(url, estado);
            return resultado.IsSuccessStatusCode;
        }

        /// <summary>
        /// Metodo para eliminar un articulo en la base de datos
        /// </summary>
        /// <param name="P_Modelo">Modelo de tipo ArticuloModel</param>
        /// <returns>TRUE = Correcto | FALSE = Incorrecto</returns>
        public async Task<bool> EliminarEstado(int? estado)
        {
            string url = "api/Estados/" + estado;
            HttpResponseMessage resultado = await conexion.DeleteAsync(url);
            return resultado.IsSuccessStatusCode;
        }

        /// <summary>
        /// Metodo para modificar un articulo en la base de datos
        /// </summary>
        /// <param name="P_Modelo">Modelo de tipo ArticuloModel</param>
        /// <returns>TRUE = Correcto | FALSE = Incorrecto</returns>
        public async Task<Estado>? EstadoPorId(int? id)
        {
            Estado? estado = new Estado();
            string url = "api/Estados/" + id;
            HttpResponseMessage resultado = await conexion.GetAsync(url);
            if (resultado.IsSuccessStatusCode)
            {
                var jsonString = await resultado.Content.ReadAsStringAsync();
                estado = JsonConvert.DeserializeObject<Estado>(jsonString);
            }

            return estado;
        }


        /// <summary>
        /// Metodo para modificar un articulo en la base de datos
        /// </summary>
        /// <param name="P_Modelo">Modelo de tipo ArticuloModel</param>
        /// <returns>TRUE = Correcto | FALSE = Incorrecto</returns>
        public async Task<bool> ModificarEstado(int? Id, Estado? estado)
        {
            string url = "api/Estados/" + Id;
            HttpResponseMessage resultado = await conexion.PutAsJsonAsync(url, estado);
            return resultado.IsSuccessStatusCode;
        }
        #endregion


    }
}
