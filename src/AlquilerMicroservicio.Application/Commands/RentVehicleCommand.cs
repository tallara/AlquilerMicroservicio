using MediatR;
using System;

namespace AlquilerMicroservicio.Application.Commands
{
    /// <summary>
    /// Comando que se lanza cuando alguien quiere pillar un vehículo. Básicamente, reserva el trasto.
    /// </summary>
    public class RentVehicleCommand : IRequest<Unit>
    {
        /// <summary>
        /// Id del alquiler, pa tenerlo controlado y que no se mezcle con otro.
        /// </summary>
        public Guid RentalId { get; set; }

        /// <summary>
        /// Id del vehículo que quieren llevarse.
        /// </summary>
        public Guid VehicleId { get; set; }

        /// <summary>
        /// Id del cliente que hace la reserva. El que va a dar guerra.
        /// </summary>
        public string CustomerId { get; set; } = default!;
    }
}
