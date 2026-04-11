using api_ferreteriapieda.Models.DetalleFactura;
using api_ferreteriapieda.Models.Factura;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using static api_ferreteriapieda.Models.DetalleFactura.csDetalleFactura;

namespace api_ferreteriapieda.Controllers
{
    
    public class DetalleFacturaController : ControllerBase
    {

        [HttpPost]
        [Route("rest/api/insertarDetalleFactura")]
        public IActionResult InsertarDetalleFactura([FromBody] csRequestDetalleFacturaInsertar model)
        {
            csDetalleFacturaInsertar obj = new csDetalleFacturaInsertar();

            ResponseDetalleFactura respuesta = obj.insertarDetalleFactura(
                model.IdFactura,
                model.IdProducto,
                model.Cantidad,
                model.Precio_Unitario
            );

            return Ok(respuesta);
        }

        [HttpPut]
        [Route("rest/api/actualizarDetalleFactura")]
        public IActionResult ActualizarDetalleFactura([FromBody] csRequestDetalleFacturaActualizar model)
        {
            csDetalleFacturaActualizar obj = new csDetalleFacturaActualizar();

            ResponseDetalleFactura respuesta = obj.actualizarDetalleFactura(
                model.IdDetalleFacturacion,
                model.IdFactura,
                model.IdProducto,
                model.Cantidad,
                model.Precio_Unitario
            );

            return Ok(respuesta);
        }

        [HttpDelete]
        [Route("rest/api/eliminarDetalleFactura")]
        public IActionResult EliminarDetalleFactura([FromBody] csRequestDetalleFacturaEliminar model)
        {
            csDetalleFacturaEliminar obj = new csDetalleFacturaEliminar();

            ResponseDetalleFactura respuesta = obj.eliminarDetalleFactura(
                model.IdDetalleFacturacion
            );

            return Ok(respuesta);
        }


        [HttpGet]
        [Route("rest/api/listarDetalleFacturas")]
        public IActionResult ListarDetalleFacturas()
        {
            csDetalleFacturaListar obj = new csDetalleFacturaListar();
            var ds = obj.listarDetalleFacturas();

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
