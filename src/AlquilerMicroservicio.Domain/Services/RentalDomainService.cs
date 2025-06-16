using AlquilerMicroservicio.Domain.Entities;
using AlquilerMicroservicio.Domain.Events;
using AlquilerMicroservicio.Domain.Interfaces;
using System;
using System.Threading.Tasks;

namespace AlquilerMicroservicio.Domain.Services
{
    /// <summary>
    /// Servicio de dominio que gestiona la lógica para alquilar un vehículo.
    /// Valida las reglas del negocio y genera el evento correspondiente.
    /// </summary>
    public class RentalDomainService
    {
        private readonly IRentalRepository _rentalRepository;
        private readonly IVehicleRepository _vehicleRepository;

        /// <summary>
        /// Se inyectan los repositorios necesarios para validar y procesar el alquiler.
        /// </summary>
        public RentalDomainService(IRentalRepository rentalRepository, IVehicleRepository vehicleRepository)
        {
            _rentalRepository = rentalRepository;
            _vehicleRepository = vehicleRepository;
        }

        /// <summary>
        /// Ejecuta el proceso de alquiler: valida que el cliente no tenga otro activo, 
        /// verifica que el vehículo exista y esté disponible, y construye el alquiler con su evento.
        /// </summary>
        public async Task<(Rental Rental, VehicleRentedDomainEvent DomainEvent)> RentVehicleAsync(Guid rentalId, Guid vehicleId, string customerId)
        {
            var activeRental = await _rentalRepository.GetActiveRentalByCustomerAsync(customerId);
            if (activeRental != null)
                throw new InvalidOperationException("Customer already has an active rental.");

            var vehicle = await _vehicleRepository.GetByIdAsync(vehicleId)
                          ?? throw new InvalidOperationException("Vehicle not found.");

            vehicle.Rent();

            var rental = new Rental(rentalId, vehicleId, customerId);

            return (rental, new VehicleRentedDomainEvent(rentalId, vehicleId, customerId));
        }
    }
}
