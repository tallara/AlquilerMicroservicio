using MediatR;
using System;

namespace AlquilerMicroservicio.Domain.Events
{
    /// <summary>
    /// Evento de dominio que se lanza cuando un veh�culo ha sido alquilado.
    /// </summary>
    public class VehicleRentedDomainEvent : INotification
    {
        /// <summary>
        /// Identificador del alquiler realizado.
        /// </summary>
        public Guid RentalId { get; }

        /// <summary>
        /// Identificador del veh�culo alquilado.
        /// </summary>
        public Guid VehicleId { get; }

        /// <summary>
        /// Identificador del cliente que alquil� el veh�culo.
        /// </summary>
        public string CustomerId { get; }

        /// <summary>
        /// Constructor del evento que asigna los datos del alquiler realizado.
        /// </summary>
        public VehicleRentedDomainEvent(Guid rentalId, Guid vehicleId, string customerId)
        {
            RentalId = rentalId;
            VehicleId = vehicleId;
            CustomerId = customerId;
        }
    }
}
