using Microsoft.AspNetCore.Mvc;
using AlquilerMicroservicio.Application.Commands;
using MediatR;
using AlquilerMicroservicio.Application.Queries;

namespace AlquilerMicroservicio.API.Controllers
{
    /// <summary>
    /// Controlador que gestiona los vehículos. Aquí se crean y se listan los que están libres.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class VehiclesController : ControllerBase
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// Inyectamos el mediador para que esta cosa pueda enviar comandos y consultas.
        /// </summary>
        public VehiclesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Crea un vehículo nuevo. Lo manda al mediador y que él se apañe con lo que tenga que hacer.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> CreateVehicle(CreateVehicleCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        /// <summary>
        /// Devuelve la lista de vehículos que no están pillados. Solo los disponibles.
        /// </summary>
        [HttpGet("available")]
        public async Task<IActionResult> GetAvailableVehicles()
        {
            var vehicles = await _mediator.Send(new GetAvailableVehiclesQuery());
            return Ok(vehicles);
        }
    }
}
