using AlquilerMicroservicio.Application.Commands;
using AlquilerMicroservicio.Domain.Entities;
using AlquilerMicroservicio.Domain.Interfaces;
using MediatR;

namespace AlquilerMicroservicio.Application.Handlers
{
    /// <summary>
    /// Handler que se encarga de registrar un vehículo nuevo. Lo mete en el repo y a otra cosa.
    /// </summary>
    public class CreateVehicleCommandHandler : IRequestHandler<CreateVehicleCommand, Unit>
    {
        private readonly IVehicleRepository _vehicleRepository;

        /// <summary>
        /// Se inyecta el repositorio de vehículos.
        /// </summary>
        public CreateVehicleCommandHandler(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        /// <summary>
        /// Procesa el comando para crear un vehículo. Lo construye y lo suelta en el repositorio.
        /// </summary>
        public async Task<Unit> Handle(CreateVehicleCommand request, CancellationToken cancellationToken)
        {
            var vehicle = new Vehicle(request.Id, request.Brand, request.Model, request.ManufactureDate);
            await _vehicleRepository.AddAsync(vehicle);
            return Unit.Value;
        }
    }
}
