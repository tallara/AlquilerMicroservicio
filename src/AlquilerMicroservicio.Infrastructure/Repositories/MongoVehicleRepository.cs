using AlquilerMicroservicio.Domain.Entities;
using AlquilerMicroservicio.Domain.Interfaces;
using MongoDB.Driver;

namespace AlquilerMicroservicio.Infrastructure.Repositories
{
    /// <summary>
    /// Implementación del repositorio de vehículos usando MongoDB como base de datos.
    /// </summary>
    public class MongoVehicleRepository : IVehicleRepository
    {
        private readonly IMongoCollection<Vehicle> _collection;

        /// <summary>
        /// Constructor que accede a la colección de vehículos en MongoDB.
        /// </summary>
        public MongoVehicleRepository(IMongoDatabase database)
        {
            _collection = database.GetCollection<Vehicle>("Vehicles");
        }

        /// <summary>
        /// Inserta un vehículo nuevo en la colección.
        /// </summary>
        public async Task AddAsync(Vehicle vehicle)
        {
            await _collection.InsertOneAsync(vehicle);
        }

        /// <summary>
        /// Devuelve una lista con los vehículos que no están alquilados.
        /// </summary>
        public async Task<List<Vehicle>> GetAvailableAsync()
        {
            return await _collection.Find(v => !v.IsRented).ToListAsync();
        }

        /// <summary>
        /// Busca un vehículo por su identificador.
        /// </summary>
        public async Task<Vehicle?> GetByIdAsync(Guid id)
        {
            return await _collection.Find(v => v.Id == id).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Reemplaza los datos del vehículo con la información nueva.
        /// </summary>
        public async Task UpdateAsync(Vehicle vehicle)
        {
            await _collection.ReplaceOneAsync(v => v.Id == vehicle.Id, vehicle);
        }
    }
}
