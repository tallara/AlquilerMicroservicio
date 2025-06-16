using AlquilerMicroservicio.Domain.Entities;

namespace AlquilerMicroservicio.Domain.Interfaces
{
    /// <summary>
    /// Contrato para el repositorio de vehiculos. Define las operaciones permitidas sobre la entidad Vehicle.
    /// </summary>
    public interface IVehicleRepository
    {
        /// <summary>
        /// Guarda un nuevo vehículo en el sistema.
        /// </summary>
        Task AddAsync(Vehicle vehicle);

        /// <summary>
        /// Devuelve la lista de vehiculos que están disponibles para ser alquilados.
        /// </summary>
        Task<List<Vehicle>> GetAvailableAsync();

        /// <summary>
        /// Busca un vehiculo por su identificador.
        /// </summary>
        Task<Vehicle?> GetByIdAsync(Guid id);

        /// <summary>
        /// Actualiza la información de un vehiculo existente.
        /// </summary>
        Task UpdateAsync(Vehicle vehicle);
    }
}
