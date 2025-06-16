using Microsoft.AspNetCore.Mvc;
using AlquilerMicroservicio.Application.Commands;
using MediatR;
using AlquilerMicroservicio.Application.Queries;

namespace AlquilerMicroservicio.API.Controllers
{
    /// <summary>
    /// Controlador que gestiona los veh�culos. Aqu� se crean y se listan los que est�n libres.
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
        /// Crea un veh�culo nuevo. Lo manda al mediador y que �l se apa�e con lo que tenga que hacer.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> CreateVehicle(CreateVehicleCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        /// <summary>
        /// Devuelve la lista de veh�culos que no est�n pillados. Solo los disponibles.
        /// </summary>
        [HttpGet("available")]
        public async Task<IActionResult> GetAvailableVehicles()
        {
            var vehicles = await _mediator.Send(new GetAvailableVehiclesQuery());
            return Ok(vehicles);
        }
    }
}
