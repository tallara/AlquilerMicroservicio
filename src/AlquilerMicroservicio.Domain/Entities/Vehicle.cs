using System;

namespace AlquilerMicroservicio.Domain.Entities
{
    /// <summary>
    /// Entidad que representa un vehículo con su información básica y estado de alquiler.
    /// </summary>
    public class Vehicle
    {
        /// <summary>
        /// Identificador único del vehículo.
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// Marca del vehículo.
        /// </summary>
        public string Brand { get; private set; }

        /// <summary>
        /// Modelo del vehículo.
        /// </summary>
        public string Model { get; private set; }

        /// <summary>
        /// Fecha de fabricación del vehículo.
        /// </summary>
        public DateTime ManufactureDate { get; private set; }

        /// <summary>
        /// Indica si el vehículo está alquilado o no.
        /// </summary>
        public bool IsRented { get; private set; }

        /// <summary>
        /// Constructor que inicializa el vehículo. No permite registrar vehículos con más de 5 años.
        /// </summary>
        public Vehicle(Guid id, string brand, string model, DateTime manufactureDate)
        {
            if ((DateTime.UtcNow - manufactureDate).TotalDays > 365 * 5)
                throw new ArgumentException("Vehicle cannot be older than 5 years.");

            Id = id;
            Brand = brand;
            Model = model;
            ManufactureDate = manufactureDate;
            IsRented = false;
        }

        /// <summary>
        /// Marca el vehículo como alquilado. Lanza excepción si ya lo está.
        /// </summary>
        public void Rent()
        {
            if (IsRented)
                throw new InvalidOperationException("Vehicle is already rented.");

            IsRented = true;
        }

        /// <summary>
        /// Marca el vehículo como disponible. Lanza excepción si no estaba alquilado.
        /// </summary>
        public void Return()
        {
            if (!IsRented)
                throw new InvalidOperationException("Vehicle is not currently rented.");

            IsRented = false;
        }
    }
}
