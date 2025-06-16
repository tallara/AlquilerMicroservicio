using AlquilerMicroservicio.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace AlquilerMicroservicio.Application.EventHandlers
{
    /// <summary>
    /// Manejador que se ejecuta cuando se alquila un vehículo. Básicamente, deja constancia del lío en los logs.
    /// </summary>
    public class VehicleRentedDomainEventHandler : INotificationHandler<VehicleRentedDomainEvent>
    {
        private readonly ILogger<VehicleRentedDomainEventHandler> _logger;

        /// <summary>
        /// Se mete el logger para soltar la info cuando alguien alquila un vehículo.
        /// </summary>
        public VehicleRentedDomainEventHandler(ILogger<VehicleRentedDomainEventHandler> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Maneja el evento de alquiler de vehículo y lo suelta en los logs pa que quede claro quién pilló qué.
        /// </summary>
        public Task Handle(VehicleRentedDomainEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Vehicle rented: RentalId={RentalId}, VehicleId={VehicleId}, CustomerId={CustomerId}",
                notification.RentalId, notification.VehicleId, notification.CustomerId);

            return Task.CompletedTask;
        }
    }
}
