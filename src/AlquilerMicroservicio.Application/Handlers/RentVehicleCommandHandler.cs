using AlquilerMicroservicio.Application.Commands;
using AlquilerMicroservicio.Domain.Interfaces;
using AlquilerMicroservicio.Domain.Services;
using AlquilerMicroservicio.Infrastructure.Events;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AlquilerMicroservicio.Application.Handlers
{
    /// <summary>
    /// Handler que se encarga de alquilar un vehículo: usa el dominio, guarda lo que haya que guardar y lanza eventos.
    /// </summary>
    public class RentVehicleCommandHandler : IRequestHandler<RentVehicleCommand, Unit>
    {
        private readonly RentalDomainService _rentalDomainService;
        private readonly IRentalRepository _rentalRepository;
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IDomainEventDispatcher _eventDispatcher;

        /// <summary>
        /// Aquí se mete todo lo necesario para poder alquilar: dominio, repos, eventos....
        /// </summary>
        public RentVehicleCommandHandler(
            RentalDomainService rentalDomainService,
            IRentalRepository rentalRepository,
            IVehicleRepository vehicleRepository,
            IDomainEventDispatcher eventDispatcher)
        {
            _rentalDomainService = rentalDomainService;
            _rentalRepository = rentalRepository;
            _vehicleRepository = vehicleRepository;
            _eventDispatcher = eventDispatcher;
        }

        /// <summary>
        /// Procesa el alquiler del vehículo: se hace la lógica, se actualiza todo y se lanza el evento.
        /// </summary>
        public async Task<Unit> Handle(RentVehicleCommand request, CancellationToken cancellationToken)
        {
            var (rental, domainEvent) = await _rentalDomainService.RentVehicleAsync(
                request.RentalId,
                request.VehicleId,
                request.CustomerId
            );

            var vehicle = await _vehicleRepository.GetByIdAsync(request.VehicleId);
            await _vehicleRepository.UpdateAsync(vehicle!);
            await _rentalRepository.AddAsync(rental);

            await _eventDispatcher.DispatchAsync(domainEvent, cancellationToken);

            return Unit.Value;
        }
    }
}
