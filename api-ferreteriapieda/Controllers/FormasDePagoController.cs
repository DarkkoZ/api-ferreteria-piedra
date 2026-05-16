using api_ferreteriapieda.Models.Cliente;
using api_ferreteriapieda.Models.FormasDePago;
using api_ferreteriapieda.Config;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using static api_ferreteriapieda.Models.FormasDePago.csFormasDePago;

namespace api_ferreteriapieda.Controllers
{
    
    public class FormasDePagoController : ControllerBase
    {
        private readonly ConexionDB _conexionDB;

        public FormasDePagoController(ConexionDB conexionDB)
        {
            _conexionDB = conexionDB;
        }
        [HttpPost]
        [Route("rest/api/insertarFormasDePago")]
        public IActionResult InsertarFormasDePago([FromBody] csRequestFormasDePago model)
        {
            csFormasDePagoInsertar obj = new csFormasDePagoInsertar(_conexionDB);

            ResponseFormasDePago respuesta = obj.insertarFormaDePago(
                model.Tipo_Tarjeta,
                model.Visa_Cuotas,
                model.Tarjeta_Debito_Credito
            );

            return Ok(respuesta);
        }

        [HttpPut]
        [Route("rest/api/actualizarFormasDePago")]
        public IActionResult ActualizarFormasDePago([FromBody] csRequestFormasDePagoActualizar model)
        {
            csFormasDePagoActualizar obj = new csFormasDePagoActualizar(_conexionDB);

            ResponseFormasDePago respuesta = obj.actualizarFormasDePago(
                model.IdPago,
                model.Tipo_Tarjeta,
                model.Visa_Cuotas,
                model.Tarjeta_Debito_Credito
            );

            return Ok(respuesta);
        }

        [HttpDelete]
        [Route("rest/api/eliminarFormasDePago")]
        public IActionResult EliminarFormasDePago([FromBody] csRequestFormasDePagoEliminar model)
        {
            csFormasDePagoEliminar obj = new csFormasDePagoEliminar(_conexionDB);

            ResponseFormasDePago respuesta = obj.eliminarFormasDePago(
                model.IdPago
            );

            return Ok(respuesta);
        }


        [HttpGet]
        [Route("rest/api/listarFormasDePago")]
        public IActionResult ListarFormasDePago()
        {
            csFormasDePagoListar obj = new csFormasDePagoListar(_conexionDB);
            var ds = obj.listarFormasDePago();

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
