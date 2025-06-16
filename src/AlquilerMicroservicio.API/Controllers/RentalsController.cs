using Microsoft.AspNetCore.Mvc;
using AlquilerMicroservicio.Application.Commands;
using MediatR;

namespace AlquilerMicroservicio.API.Controllers
{
    /// <summary>
    /// Controlador HTTP que gestiona el alquiler y la devoluc d vehiculos, manda los comandos al mediador pa q los procese.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class RentalsController : ControllerBase
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// Constructor que inyecta el mediador pa poder mandar comandos desde los endpoints.
        /// </summary>
        public RentalsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Recibe una peticion para alquilar un vehiculo y lo manda como comando via MediatR.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> RentVehicle(RentVehicleCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        /// <summary>
        /// Se encarga de gestionar la devolucion del vehiculo, mandando el comando correspondiente.
        /// </summary>
        [HttpPost("return")]
        public async Task<IActionResult> ReturnVehicle(ReturnVehicleCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
    }
}
