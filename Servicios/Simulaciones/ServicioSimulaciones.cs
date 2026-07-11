using ApiCuentaAhorros.BaseDatos;
using ApiCuentaAhorros.Dtos.Simulaciones;
using ApiCuentaAhorros.Mapeadores;
using ApiCuentaAhorros.Servicios.Calculos;
using Microsoft.EntityFrameworkCore;

namespace ApiCuentaAhorros.Servicios.Simulaciones
{

    //* Recibo el contexto para trabajar con la base de datos
    public class ServicioSimulaciones : IServicioSimulaciones
    {
        private readonly ContextoBaseDatos _context;
        private readonly IServicioCalculos _servicioCalculos;

        public ServicioSimulaciones(
            ContextoBaseDatos context,
            IServicioCalculos servicioCalculos
        )
        {
            _context = context;
            _servicioCalculos = servicioCalculos;
        }


        public async Task<SimulacionRespuestaDto> CrearAsync(
            CrearSimulacionDto dto
        )
        {
            //* Primero valido que los datos ingresados sean mayores que cero.
            if (dto.DepositoInicial <= 0)
            {
                throw new ArgumentException(
                    "El deposito inicial debe ser mayor que cero."
                );
            }

            if (dto.TasaInteresAnual <= 0)
            {
                throw new ArgumentException(
                    "La tasa de interes anual debe ser mayor que cero."
                );
            }

            if (dto.PlazoAnios <= 0)
            {
                throw new ArgumentException(
                    "El plazo en años debe ser mayor que cero."
                );
            }


            //* Utilizo el servicio de cálculos para obtener el monto final
            var resultado = _servicioCalculos.CalcularResultado(dto.DepositoInicial,dto.TasaInteresAnual,dto.PlazoAnios);

            //* Convierto los datos recibidos y el resultado en una entidad
            var simulacionEntity = MapeadorSimulacion.CrearDtoAEntidad(dto,resultado);

            //* Agrego la simulación a la base de datos y guardo los cambios en SQLite.
            _context.Simulaciones.Add(simulacionEntity);
            await _context.SaveChangesAsync();

            //* Convierto la entidad guardada en un DTO para devolverla al cliente.
            var simulacionDto = MapeadorSimulacion.EntidadADto(simulacionEntity);

            return simulacionDto;
        }

        public async Task<List<SimulacionRespuestaDto>>ObtenerTodasAsync()
        {
             //* Consulto todas las simulaciones guardada y las ordeno por su id.
            var simulacionesEntity = await _context.Simulaciones.OrderBy(x => x.Id).ToListAsync();

            //* Convierto la lista de entidades en una lista de DTO.
            var simulacionesDto = MapeadorSimulacion.EntidadesADtos(simulacionesEntity);

            return simulacionesDto;
        }

        public async Task<SimulacionRespuestaDto?>ObtenerPorIdAsync(int id)
        {
            //* Busco la simulación que tenga el ID recibido.
            var simulacionEntity = await _context.Simulaciones.FirstOrDefaultAsync(x => x.Id == id);

            //* Si no encuentro la simulación, devuelvo null
            if (simulacionEntity is null)
            {
                return null;
            }

            //* Convierto la entidad encontrada en un DTO.
            var simulacionDto = MapeadorSimulacion.EntidadADto(simulacionEntity);

            return simulacionDto;
        }

        public async Task<List<ProyeccionMensualDto>?> ObtenerProyeccionMensualAsync(int id)
        {
            //* Busco la simulación porque necesito sus datos
            var simulacionEntity = await _context.Simulaciones.FirstOrDefaultAsync(x => x.Id == id);

            //* Si el ID no existe, devuelvo null.
            if (simulacionEntity is null)
            {
                return null;
            }

            //* La proyección se calcula nuevamente usando los datos guardados
            var proyeccionMensual = _servicioCalculos.CalcularProyeccionMensual(simulacionEntity.DepositoInicial,simulacionEntity.TasaInteresAnual,simulacionEntity.PlazoAnios);

            return proyeccionMensual;
        }

        public async Task<List<ProyeccionAnualDto>?>ObtenerProyeccionAnualAsync(int id)
        {
            //* Busco la simulación para obtener el depósito,
            var simulacionEntity = await _context.Simulaciones.FirstOrDefaultAsync(x => x.Id == id);

            //* Si no existe una simulación con ese ID, devuelvo null.
            if (simulacionEntity is null)
            {
                return null;
            }

            //* Utilizo el servicio de cálculos para generar la proyección correspondiente a cada año.
            var proyeccionAnual = _servicioCalculos.CalcularProyeccionAnual(simulacionEntity.DepositoInicial,simulacionEntity.TasaInteresAnual,simulacionEntity.PlazoAnios);

            return proyeccionAnual;
        }
    }
}