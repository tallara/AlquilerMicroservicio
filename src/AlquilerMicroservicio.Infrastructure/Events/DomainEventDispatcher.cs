using MediatR;
using System.Threading.Tasks;
using System.Threading;

namespace AlquilerMicroservicio.Infrastructure.Events
{
    /// <summary>
    /// Interfaz para despachar eventos de dominio usando un mecanismo externo.
    /// </summary>
    public interface IDomainEventDispatcher
    {
        /// <summary>
        /// Lanza un evento de dominio mediante el sistema de publicación.
        /// </summary>
        Task DispatchAsync<TEvent>(TEvent domainEvent, CancellationToken cancellationToken = default)
            where TEvent : notnull;
    }

    /// <summary>
    /// Implementación del despachador de eventos de dominio que utiliza MediatR para publicar los eventos.
    /// </summary>
    public class DomainEventDispatcher : IDomainEventDispatcher
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// Se inyecta el mediador para poder publicar los eventos de forma centralizada.
        /// </summary>
        public DomainEventDispatcher(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Publica el evento usando MediatR, si el evento no es nulo.
        /// </summary>
        public async Task DispatchAsync<TEvent>(TEvent domainEvent, CancellationToken cancellationToken = default) where TEvent : notnull
        {
            if (domainEvent is not null)
            {
                await _mediator.Publish(domainEvent, cancellationToken);
            }
        }
    }
}
