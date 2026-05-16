using api_ferreteriapieda.Models.Empleado;
using api_ferreteriapieda.Config;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Data;
using System.Linq;
using System.Web;
using static api_ferreteriapieda.Models.Empleado.csEmpleado;
using static api_ferreteriapieda.Models.Empleado.csEmpleadoActualizar;
using static api_ferreteriapieda.Models.Empleado.csEmpleadoEliminar;
using static api_ferreteriapieda.Models.Empleado.csEmpleadoInsertar;
using static api_ferreteriapieda.Models.Empleado.csEmpleadoListar;



namespace api_ferreteriapieda.Controllers
{
    
    public class EmpleadoController : ControllerBase
    {
        private readonly ConexionDB _conexionDB;

        public EmpleadoController(ConexionDB conexionDB)
        {
            _conexionDB = conexionDB;
        }
        [HttpPost]
        [Route("rest/api/insertarEmpleado")]
        public IActionResult InsertarEmpleado([FromBody] csRequestEmpleado model)
        {
            csEmpleadoInsertar obj = new csEmpleadoInsertar(_conexionDB);

            ResponseEmpleado respuesta = obj.insertarEmpleado(
                model.Nombre,
                model.Direccion,
                model.Telefono,
                model.Correo
            );

            return Ok(respuesta);
        }

        [HttpPut]
        [Route("rest/api/actualizarEmpleado")]
        public IActionResult ActualizarEmpleado([FromBody] csRequestEmpleadoActualizar model)
        {
            csEmpleadoActualizar obj = new csEmpleadoActualizar(_conexionDB);

            ResponseEmpleado respuesta = obj.actualizarEmpleado(
                model.IdEmpleado,
                model.Nombre,
                model.Direccion,
                model.Telefono,
                model.Correo
            );

            return Ok(respuesta);
        }

        [HttpDelete]
        [Route("rest/api/eliminarEmpleado")]
        public IActionResult EliminarEmpleado([FromBody] csRequestEmpleadoEliminar model)
        {
            csEmpleadoEliminar obj = new csEmpleadoEliminar(_conexionDB);

            ResponseEmpleado respuesta = obj.eliminarEmpleado(
                model.IdEmpleado
            );

            return Ok(respuesta);
        }


        [HttpGet]
        [Route("rest/api/listarEmpleados")]
        public IActionResult ListarEmpleados()
        {
            csEmpleadoListar obj = new csEmpleadoListar(_conexionDB);
            var ds = obj.listarEmpleados();

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
