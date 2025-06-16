using MediatR;
using System;

namespace AlquilerMicroservicio.Application.Commands
{
    /// <summary>
    /// Comando para crear un veh�culo. Se lanza y que el handler se encargue del marr�n.
    /// </summary>
    public class CreateVehicleCommand : IRequest<Unit>
    {
        /// <summary>
        /// Identificador �nico del cacharro, que no se repita o la liamos.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Marca del coche, moto o lo que sea que estemos registrando.
        /// </summary>
        public string Brand { get; set; } = default!;

        /// <summary>
        /// Modelo del veh�culo, pa saber si es un trasto o algo decente.
        /// </summary>
        public string Model { get; set; } = default!;

        /// <summary>
        /// Fecha en la que sali� de f�brica. Si es muy viejo, igual ni arranca.
        /// </summary>
        public DateTime ManufactureDate { get; set; }
    }
}
