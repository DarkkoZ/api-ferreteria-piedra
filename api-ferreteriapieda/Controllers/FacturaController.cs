using api_ferreteriapieda.Models.Cliente;
using api_ferreteriapieda.Models.Factura;
using api_ferreteriapieda.Config;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using static api_ferreteriapieda.Models.Factura.csFactura;

namespace api_ferreteriapieda.Controllers
{
    
    public class FacturaController : ControllerBase
    {
        private readonly ConexionDB _conexionDB;

        public FacturaController(ConexionDB conexionDB)
        {
            _conexionDB = conexionDB;
        }
        [HttpPost]
        [Route("rest/api/insertarFactura")]
        public IActionResult InsertarFactura([FromBody] csRequestFacturaInsertar model)
        {
            csFacturaInsertar obj = new csFacturaInsertar(_conexionDB);

            ResponseFactura respuesta = obj.insertarFactura(
                model.IdEmpleado,
                model.IdNit,
                model.IdPago,
                model.Monto_Total
            );

            return Ok(respuesta);
        }

        [HttpPut]
        [Route("rest/api/actualizarFactura")]
        public IActionResult ActualizarFactura([FromBody] csRequestActualizar model)
        {
            csFacturaActualizar obj = new csFacturaActualizar();

            ResponseFactura respuesta = obj.actualizarFactura(
                model.IdFactura,
                model.IdEmpleado,
                model.IdNit,
                model.IdPago,
                model.Monto_Total
            );

            return Ok(respuesta);
        }

        [HttpDelete]
        [Route("rest/api/eliminarFactura")]
        public IActionResult EliminarFactura([FromBody] csRequestFacturaEliminar model)
        {
            csFacturaEliminar obj = new csFacturaEliminar();

            ResponseFactura respuesta = obj.eliminarFactura(
                model.IdFactura
            );

            return Ok(respuesta);
        }


        [HttpGet]
        [Route("rest/api/listarFacturas")]
        public IActionResult ListarFacturas()
        {
            csFacturaListar obj = new csFacturaListar(_conexionDB);
            var ds = obj.listarFacturas();

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
