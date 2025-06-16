using AlquilerMicroservicio.Domain.Entities;
using AlquilerMicroservicio.Domain.Interfaces;
using MongoDB.Driver;

namespace AlquilerMicroservicio.Infrastructure.Repositories
{
    /// <summary>
    /// Implementaci�n del repositorio de alquileres usando MongoDB como almacenamiento.
    /// </summary>
    public class MongoRentalRepository : IRentalRepository
    {
        private readonly IMongoCollection<Rental> _collection;

        /// <summary>
        /// Constructor que obtiene la colecci�n de alquileres desde la base de datos MongoDB.
        /// </summary>
        public MongoRentalRepository(IMongoDatabase database)
        {
            _collection = database.GetCollection<Rental>("Rentals");
        }

        /// <summary>
        /// Inserta un nuevo alquiler en la base de datos.
        /// </summary>
        public async Task AddAsync(Rental rental)
        {
            await _collection.InsertOneAsync(rental);
        }

        /// <summary>
        /// Obtiene el alquiler activo de un cliente, si tiene alguno en curso.
        /// </summary>
        public async Task<Rental?> GetActiveRentalByCustomerAsync(string customerId)
        {
            return await _collection.Find(r => r.CustomerId == customerId && r.ReturnDate == null).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Busca un alquiler por su identificador.
        /// </summary>
        public async Task<Rental?> GetByIdAsync(Guid id)
        {
            return await _collection.Find(r => r.Id == id).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Reemplaza la informaci�n de un alquiler existente por una versi�n actualizada.
        /// </summary>
        public async Task UpdateAsync(Rental rental)
        {
            await _collection.ReplaceOneAsync(r => r.Id == rental.Id, rental);
        }
    }
}
