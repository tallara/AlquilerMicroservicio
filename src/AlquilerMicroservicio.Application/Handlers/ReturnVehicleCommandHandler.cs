using AlquilerMicroservicio.Application.Commands;
using AlquilerMicroservicio.Domain.Interfaces;
using MediatR;

namespace AlquilerMicroservicio.Application.Handlers
{
    /// <summary>
    /// Handler que gestiona la devolución del vehículo. Revisa el alquiler y marca todo como devuelto.
    /// </summary>
    public class ReturnVehicleCommandHandler : IRequestHandler<ReturnVehicleCommand, Unit>
    {
        private readonly IRentalRepository _rentalRepository;
        private readonly IVehicleRepository _vehicleRepository;

        /// <summary>
        /// Inyectamos los repos necesarios pa buscar el alquiler y el coche, y actualizar el estado.
        /// </summary>
        public ReturnVehicleCommandHandler(
            IRentalRepository rentalRepository,
            IVehicleRepository vehicleRepository)
        {
            _rentalRepository = rentalRepository;
            _vehicleRepository = vehicleRepository;
        }

        /// <summary>
        /// Procesa la devolución: valida que el alquiler existe, que no está ya devuelto, y marca todo.
        /// </summary>
        public async Task<Unit> Handle(ReturnVehicleCommand request, CancellationToken cancellationToken)
        {
            var rental = await _rentalRepository.GetByIdAsync(request.RentalId)
                         ?? throw new InvalidOperationException("Rental not found.");

            if (!rental.IsActive)
                throw new InvalidOperationException("Rental is already returned.");

            rental.Return();

            var vehicle = await _vehicleRepository.GetByIdAsync(rental.VehicleId)
                          ?? throw new InvalidOperationException("Vehicle not found.");

            vehicle.Return();

            await _rentalRepository.UpdateAsync(rental);
            await _vehicleRepository.UpdateAsync(vehicle);

            return Unit.Value;
        }
    }
}
