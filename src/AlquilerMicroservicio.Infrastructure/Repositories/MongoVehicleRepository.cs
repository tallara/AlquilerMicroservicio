using AlquilerMicroservicio.Domain.Entities;
using AlquilerMicroservicio.Domain.Interfaces;
using MongoDB.Driver;

namespace AlquilerMicroservicio.Infrastructure.Repositories
{
    /// <summary>
    /// Implementaci�n del repositorio de veh�culos usando MongoDB como base de datos.
    /// </summary>
    public class MongoVehicleRepository : IVehicleRepository
    {
        private readonly IMongoCollection<Vehicle> _collection;

        /// <summary>
        /// Constructor que accede a la colecci�n de veh�culos en MongoDB.
        /// </summary>
        public MongoVehicleRepository(IMongoDatabase database)
        {
            _collection = database.GetCollection<Vehicle>("Vehicles");
        }

        /// <summary>
        /// Inserta un veh�culo nuevo en la colecci�n.
        /// </summary>
        public async Task AddAsync(Vehicle vehicle)
        {
            await _collection.InsertOneAsync(vehicle);
        }

        /// <summary>
        /// Devuelve una lista con los veh�culos que no est�n alquilados.
        /// </summary>
        public async Task<List<Vehicle>> GetAvailableAsync()
        {
            return await _collection.Find(v => !v.IsRented).ToListAsync();
        }

        /// <summary>
        /// Busca un veh�culo por su identificador.
        /// </summary>
        public async Task<Vehicle?> GetByIdAsync(Guid id)
        {
            return await _collection.Find(v => v.Id == id).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Reemplaza los datos del veh�culo con la informaci�n nueva.
        /// </summary>
        public async Task UpdateAsync(Vehicle vehicle)
        {
            await _collection.ReplaceOneAsync(v => v.Id == vehicle.Id, vehicle);
        }
    }
}
