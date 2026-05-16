using api_ferreteriapieda.Models.Cliente;
using api_ferreteriapieda.Models.Usuario;
using api_ferreteriapieda.Config;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using static api_ferreteriapieda.Models.Usuario.csUsuario;

namespace api_ferreteriapieda.Controllers
{
    
    public class UsuarioController : ControllerBase
    {
        private readonly ConexionDB _conexionDB;

        public UsuarioController(ConexionDB conexionDB)
        {
            _conexionDB = conexionDB;
        }
        [HttpPost]
        [Route("rest/api/insertarUsuario")]
        public IActionResult InsertarUsuario([FromBody] csRequestUsuario model)
        {
            csUsuarioInsertar obj = new csUsuarioInsertar(_conexionDB);

            ResponseUsuario respuesta = obj.insertarUsuario(
                model.IdUsuario,
                model.IdNit,
                model.IdEmpleado,
                model.Password,
                model.Direccion,
                model.Telefono,
                model.Correo
            );

            return Ok(respuesta);
        }

        [HttpPut]
        [Route("rest/api/actualizarUsuario")]
        public IActionResult ActualizarUsuario([FromBody] csRequestUsuarioActualizar model)
        {
            csUsuarioActualizar obj = new csUsuarioActualizar(_conexionDB);

            ResponseUsuario respuesta = obj.actualizarUsuario(
                model.IdUsuario,
                model.IdNit,
                model.IdEmpleado,
                model.Password,
                model.Direccion,
                model.Telefono,
                model.Correo
            );

            return Ok(respuesta);
        }

        [HttpDelete]
        [Route("rest/api/eliminarUsuario")]
        public IActionResult EliminarUsuario([FromBody] csRequestUsuarioEliminar model)
        {
            csUsuarioEliminar obj = new csUsuarioEliminar(_conexionDB);

            ResponseUsuario respuesta = obj.eliminarUsuario(
                model.IdUsuario
            );

            return Ok(respuesta);
        }


        [HttpGet]
        [Route("rest/api/listarUsuarios")]
        public IActionResult ListarClientes()
        {
            csUsuarioListar obj = new csUsuarioListar(_conexionDB);
            var ds = obj.listarUsuarios();

            if (ds != null && ds.Tables.Count > 0)
            {
                var tabla = ds.Tables[0];

                var lista = new List<Dictionary<string, object>>();

                foreach (DataRow row in tabla.Rows)
                {
                    var dict = new Dictionary<string, object>();

                    foreach (DataColumn col in tabla.Columns)
                    {
                        dict[col.ColumnName] = row[col];
                    }

                    lista.Add(dict);
                }

                return Ok(lista);
            }
            else
            {
                return BadRequest("No se pudo obtener la información");
            }
        }
    }
}
