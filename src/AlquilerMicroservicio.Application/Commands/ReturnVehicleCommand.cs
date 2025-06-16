using MediatR;
using System;

namespace AlquilerMicroservicio.Application.Commands
{
    /// <summary>
    /// Comando que se lanza cuando el cliente trae el coche de vuelta.
    /// </summary>
    public class ReturnVehicleCommand : IRequest<Unit>
    {
        /// <summary>
        /// Id del alquiler que se quiere cerrar.
        /// </summary>
        public Guid RentalId { get; set; }
    }
}
