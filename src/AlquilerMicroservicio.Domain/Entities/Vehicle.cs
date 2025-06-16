using System;

namespace AlquilerMicroservicio.Domain.Entities
{
    /// <summary>
    /// Entidad que representa un veh�culo con su informaci�n b�sica y estado de alquiler.
    /// </summary>
    public class Vehicle
    {
        /// <summary>
        /// Identificador �nico del veh�culo.
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// Marca del veh�culo.
        /// </summary>
        public string Brand { get; private set; }

        /// <summary>
        /// Modelo del veh�culo.
        /// </summary>
        public string Model { get; private set; }

        /// <summary>
        /// Fecha de fabricaci�n del veh�culo.
        /// </summary>
        public DateTime ManufactureDate { get; private set; }

        /// <summary>
        /// Indica si el veh�culo est� alquilado o no.
        /// </summary>
        public bool IsRented { get; private set; }

        /// <summary>
        /// Constructor que inicializa el veh�culo. No permite registrar veh�culos con m�s de 5 a�os.
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
        /// Marca el veh�culo como alquilado. Lanza excepci�n si ya lo est�.
        /// </summary>
        public void Rent()
        {
            if (IsRented)
                throw new InvalidOperationException("Vehicle is already rented.");

            IsRented = true;
        }

        /// <summary>
        /// Marca el veh�culo como disponible. Lanza excepci�n si no estaba alquilado.
        /// </summary>
        public void Return()
        {
            if (!IsRented)
                throw new InvalidOperationException("Vehicle is not currently rented.");

            IsRented = false;
        }
    }
}
