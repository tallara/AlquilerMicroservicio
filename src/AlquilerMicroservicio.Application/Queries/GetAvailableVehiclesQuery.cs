using AlquilerMicroservicio.Domain.Entities;
using MediatR;
using System.Collections.Generic;

namespace AlquilerMicroservicio.Application.Queries
{
    /// <summary>
    /// Query que pide la lista de vehÝculos disponibles.
    /// </summary>
    public class GetAvailableVehiclesQuery : IRequest<List<Vehicle>>
    {
    }
}
