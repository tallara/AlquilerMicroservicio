using AlquilerMicroservicio.Domain.Entities;

namespace AlquilerMicroservicio.Domain.Interfaces
{
    /// <summary>
    /// Contrato para el repositorio de alquileres. Define las operaciones básicas sobre la entidad Rental.
    /// </summary>
    public interface IRentalRepository
    {
        /// <summary>
        /// Agrega un nuevo alquiler al sistema de forma asíncrona.
        /// </summary>
        Task AddAsync(Rental rental);

        /// <summary>
        /// Obtiene el alquiler activo de un cliente, si es que tiene uno en curso.
        /// </summary>
        Task<Rental?> GetActiveRentalByCustomerAsync(string customerId);

        /// <summary>
        /// Busca un alquiler por su identificador.
        /// </summary>
        Task<Rental?> GetByIdAsync(Guid id);

        /// <summary>
        /// Actualiza la informacion de un alquiler existennte.
        /// </summary>
        Task UpdateAsync(Rental rental);
    }
}
