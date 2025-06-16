using MediatR;
using System;

namespace AlquilerMicroservicio.Application.Commands
{
    /// <summary>
    /// Comando para crear un vehículo. Se lanza y que el handler se encargue del marrón.
    /// </summary>
    public class CreateVehicleCommand : IRequest<Unit>
    {
        /// <summary>
        /// Identificador único del cacharro, que no se repita o la liamos.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Marca del coche, moto o lo que sea que estemos registrando.
        /// </summary>
        public string Brand { get; set; } = default!;

        /// <summary>
        /// Modelo del vehículo, pa saber si es un trasto o algo decente.
        /// </summary>
        public string Model { get; set; } = default!;

        /// <summary>
        /// Fecha en la que salió de fábrica. Si es muy viejo, igual ni arranca.
        /// </summary>
        public DateTime ManufactureDate { get; set; }
    }
}
