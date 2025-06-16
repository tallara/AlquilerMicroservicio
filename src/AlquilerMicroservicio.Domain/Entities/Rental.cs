using System;

namespace AlquilerMicroservicio.Domain.Entities
{
    /// <summary>
    /// Entidad que representa un alquiler. Guarda quién pilló qué coche, cuándo lo hizo y si ya lo devolvió o sigue alquilado.
    /// </summary>
    public class Rental
    {
        /// <summary>
        /// Identificador único del alquiler.
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// Id del vehículo que fue alquilado. Aquí queda registrado.
        /// </summary>
        public Guid VehicleId { get; private set; }

        /// <summary>
        /// Id del cliente que hizo el alquiler.
        /// </summary>
        public string CustomerId { get; private set; }

        /// <summary>
        /// Fecha y hora en la que se registró el alquiler. UTC para no liar husos.
        /// </summary>
        public DateTime RentalDate { get; private set; }

        /// <summary>
        /// Fecha de devolución, si ya lo trajo de vuelta. Si está a null, el coche sigue fuera.
        /// </summary>
        public DateTime? ReturnDate { get; private set; }

        /// <summary>
        /// Indica si el alquiler sigue activo.
        /// </summary>
        public bool IsActive => ReturnDate == null;

        /// <summary>
        /// Crea una nueva instancia de alquiler con la info mínima. La fecha se mete sola al momento.
        /// </summary>
        public Rental(Guid id, Guid vehicleId, string customerId)
        {
            Id = id;
            VehicleId = vehicleId;
            CustomerId = customerId;
            RentalDate = DateTime.UtcNow;
            ReturnDate = null;
        }

        /// <summary>
        /// Marca el alquiler como devuelto. Si ya estaba cerrado, lanza excepción.
        /// </summary>
        public void Return()
        {
            if (!IsActive)
                throw new InvalidOperationException("Rental is already closed.");

            ReturnDate = DateTime.UtcNow;
        }
    }
}
