using api_ferreteriapieda.Models.FormasDePago;
using api_ferreteriapieda.Models.Producto;
using api_ferreteriapieda.Config;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using static api_ferreteriapieda.Models.Producto.csProducto;

namespace api_ferreteriapieda.Controllers
{
    
    public class ProductoController : ControllerBase
    {
        private readonly ConexionDB _conexionDB;

        public ProductoController(ConexionDB conexionDB)
        {
            _conexionDB = conexionDB;
        }
        [HttpPost]
        [Route("rest/api/insertarProducto")]
        public IActionResult InsertarProducto([FromBody] csRequestProductoInsertar model)
        {
            csProductoInsertar obj = new csProductoInsertar(_conexionDB);

           ResponseProducto respuesta = obj.insertarProducto(
                model.IdProducto,
                model.Nombre,
                model.Descripcion,
                model.Precio,
                model.Inventario,
                model.Oferta
            );

            return Ok(respuesta);
        }

        [HttpPut]
        [Route("rest/api/actualizarProducto")]
        public IActionResult ActualizarProducto([FromBody] csRequestProductoActualizar model)
        {
            csProductoActualizar obj = new csProductoActualizar(_conexionDB);

            ResponseProducto respuesta = obj.actualizarProducto(
                model.IdProducto,
                model.Nombre,
                model.Descripcion,
                model.Precio,
                model.Inventario,
                model.Oferta
            );

            return Ok(respuesta);
        }

        [HttpDelete]
        [Route("rest/api/eliminarProducto")]
        public IActionResult EliminarProducto([FromBody] csRequestProductoEliminar model)
        {
            csProductoEliminar obj = new csProductoEliminar(_conexionDB);

            ResponseProducto respuesta = obj.eliminarProducto(
                model.IdProducto
            );

            return Ok(respuesta);
        }


        [HttpGet]
        [Route("rest/api/listarProducto")]
        public IActionResult ListarProductos()
        {
            csProductoListar obj = new csProductoListar(_conexionDB);
            var ds = obj.listarProducto();

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
