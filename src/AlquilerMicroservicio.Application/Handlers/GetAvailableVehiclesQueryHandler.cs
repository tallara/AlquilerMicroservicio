using AlquilerMicroservicio.Application.Queries;
using AlquilerMicroservicio.Domain.Entities;
using AlquilerMicroservicio.Domain.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AlquilerMicroservicio.Application.Handlers
{
    /// <summary>
    /// Handler que se encarga de buscar los veh�culos que est�n libres.
    /// </summary>
    public class GetAvailableVehiclesQueryHandler : IRequestHandler<GetAvailableVehiclesQuery, List<Vehicle>>
    {
        private readonly IVehicleRepository _vehicleRepository;

        /// <summary>
        /// Se inyecta el repo pa poder ir a mirar qu� veh�culos siguen en el parking.
        /// </summary>
        public GetAvailableVehiclesQueryHandler(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        /// <summary>
        /// Maneja la consulta para traer los veh�culos disponibles. Si no hay, pues se devuelve la lista vac�a y ya.
        /// </summary>
        public async Task<List<Vehicle>> Handle(GetAvailableVehiclesQuery request, CancellationToken cancellationToken)
        {
            return await _vehicleRepository.GetAvailableAsync();
        }
    }
}
