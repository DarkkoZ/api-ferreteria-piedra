using api_ferreteriapieda.Models.Cliente;
using api_ferreteriapieda.Models.Empleado;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using static api_ferreteriapieda.Models.Cliente.csCliente;

namespace api_ferreteriapieda.Controllers
{
    
    public class ClienteController : ControllerBase
    {
        [HttpPost]
        [Route("rest/api/insertarCliente")]
        public IActionResult InsertarCliente([FromBody] csRequestCliente model)
        {
            csClienteInsertar obj = new csClienteInsertar();

            ResponseCliente respuesta = obj.insertarCliente(
                model.IdNit,
                model.Nombre,
                model.Direccion,
                model.Telefono,
                model.Correo
            );

            return Ok(respuesta);
        }

        [HttpPut]
        [Route("rest/api/actualizarCliente")]
        public IActionResult ActualizarCliente([FromBody] csRequestClienteActualizar model)
        {
            csClienteActualizar obj = new csClienteActualizar();

            ResponseCliente respuesta = obj.actualizarCliente(
                model.IdNit,
                model.Nombre,
                model.Direccion,
                model.Telefono,
                model.Correo
            );

            return Ok(respuesta);
        }

        [HttpDelete]
        [Route("rest/api/eliminarCliente")]
        public IActionResult EliminarCliente([FromBody] csRequestEliminarCliente model)
        {
            csClienteEliminar obj = new csClienteEliminar();

            ResponseCliente respuesta = obj.eliminarCliente(
                model.IdNit
            );

            return Ok(respuesta);
        }


        [HttpGet]
        [Route("rest/api/listarClientes")]
        public IActionResult ListarClientes()
        {
            csClienteListar obj = new csClienteListar();
            var ds = obj.listarClientes();

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
