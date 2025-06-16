using Microsoft.Extensions.DependencyInjection;
using MediatR;
using System.Reflection;

namespace AlquilerMicroservicio.Application
{
    /// <summary>
    /// Clase de extensión que mete todo lo necesario de la capa de aplicación en el contenedor de dependencias.
    /// </summary>
    public static class ApplicationServiceCollectionExtensions
    {
        /// <summary>
        /// Registra MediatR con todos los handlers que hay en esta capa. Lo deja listo para lanzar comandos y consultas.
        /// </summary>
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });

            return services;
        }
    }
}
