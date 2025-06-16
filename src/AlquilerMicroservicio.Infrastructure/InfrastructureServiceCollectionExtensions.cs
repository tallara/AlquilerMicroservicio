using AlquilerMicroservicio.Domain.Interfaces;
using AlquilerMicroservicio.Domain.Services;
using AlquilerMicroservicio.Infrastructure.Repositories;
using AlquilerMicroservicio.Infrastructure.Events;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace AlquilerMicroservicio.Infrastructure
{
    /// <summary>
    /// Clase de extensión que registra los servicios de infraestructura en el contenedor de dependencias.
    /// </summary>
    public static class InfrastructureServiceCollectionExtensions
    {
        /// <summary>
        /// Registra la configuración de MongoDB, los repositorios, servicios de dominio y el despachador de eventos.
        /// </summary>
        /// <param name="services">Contenedor de servicios.</param>
        /// <param name="configuration">Configuración de la aplicación.</param>
        /// <returns>El contenedor con los servicios registrados.</returns>
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IMongoClient>(sp =>
            {
                var connectionString = configuration.GetConnectionString("MongoDb");
                return new MongoClient(connectionString);
            });

            services.AddScoped(serviceProvider =>
            {
                var client = serviceProvider.GetRequiredService<IMongoClient>();
                var databaseName = configuration.GetSection("MongoDb:Database").Value;
                return client.GetDatabase(databaseName);
            });

            services.AddScoped<IVehicleRepository, MongoVehicleRepository>();
            services.AddScoped<IRentalRepository, MongoRentalRepository>();

            services.AddScoped<IDomainEventDispatcher, DomainEventDispatcher>();
            services.AddScoped<RentalDomainService>();

            return services;
        }
    }
}
