using ApiCuentaAhorros.Dtos.Simulaciones;
using ApiCuentaAhorros.Servicios.Simulaciones;
using Microsoft.AspNetCore.Mvc;

namespace ApiCuentaAhorros.Controladores
{
    [Route("api/simulaciones")]
    [ApiController]
    public class SimulacionesController : ControllerBase
    {
        private readonly IServicioSimulaciones _servicioSimulaciones;

        //* Inyeccion de dependencias
        public SimulacionesController(
            IServicioSimulaciones servicioSimulaciones
        )
        {
            _servicioSimulaciones = servicioSimulaciones;
        }

        [HttpGet]
        public async Task<ActionResult> ObtenerTodas()
        {
            //* Solicito al servicio todas las simulaciones guardadas.
            var result = await _servicioSimulaciones.ObtenerTodasAsync();

            return StatusCode(
                StatusCodes.Status200OK,
                result
            );
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> ObtenerPorId(int id)
        {
            //* Solicito al servicio la simulación que corresponde al ID.
            var result =
                await _servicioSimulaciones.ObtenerPorIdAsync(id);

            //* Si el servicio devuelve null, significa que el ID no existe.
            if (result is null)
            {
                return StatusCode(
                    StatusCodes.Status404NotFound,
                    new
                    {
                        mensaje = "No se encontró la simulación."
                    }
                );
            }

            return StatusCode(
                StatusCodes.Status200OK,
                result
            );
        }

        [HttpPost]
        public async Task<ActionResult> Crear(CrearSimulacionDto dto)
        {
            //* Verifico que el modelo recibido no tenga errores.
            if (!ModelState.IsValid)
            {
                return StatusCode(
                    StatusCodes.Status400BadRequest,
                    ModelState
                );
            }

            try
            {
                //* El servicio valida, calcula y guarda la simulación.
                var result = await _servicioSimulaciones.CrearAsync(dto);

                //* Devuelvo 201 y la ruta para consultar el registro creado.
                return CreatedAtAction(
                    nameof(ObtenerPorId),
                    new { id = result.Id },
                    result
                );
            }
            catch (ArgumentException ex)
            {
                //* Los valores menores o iguales a cero son datos inválidos.
                return StatusCode(
                    StatusCodes.Status400BadRequest,
                    new
                    {
                        mensaje = ex.Message
                    }
                );
            }
        }

        [HttpGet("{id}/proyeccion-mensual")] 
        public async Task<ActionResult> ObtenerProyeccionMensual(int id)
        {
            //* Solicito la proyección mensual usando el ID recibido.
            var result = await _servicioSimulaciones.ObtenerProyeccionMensualAsync(id);

            if (result is null)
            {
                return StatusCode(
                    StatusCodes.Status404NotFound,
                    new
                    {
                        mensaje = "No se encontró la simulación."
                    }
                );
            }

            return StatusCode(
                StatusCodes.Status200OK,
                result
            );
        }

        [HttpGet("{id}/proyeccion-anual")]
        public async Task<ActionResult> ObtenerProyeccionAnual(int id)
        {
            //* Solicito la proyección anual usando el ID recibido.
            var result = await _servicioSimulaciones.ObtenerProyeccionAnualAsync(id);

            if (result is null)
            {
                return StatusCode(
                    StatusCodes.Status404NotFound,
                    new
                    {
                        mensaje = "No se encontró la simulación."
                    }
                );
            }

            return StatusCode(
                StatusCodes.Status200OK,
                result
            );
        }
    }
}

