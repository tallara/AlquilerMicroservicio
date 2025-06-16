
using AlquilerMicroservicio.Domain.Entities;
using Xunit;
using System;

namespace AlquilerMicroservicio.UnitTests
{
    public class VehicleTests
    {
        [Fact]
        public void CreateVehicle_ShouldSucceed_WhenUnderFiveYearsOld()
        {
            var vehicle = new Vehicle(Guid.NewGuid(), "Toyota", "Corolla", DateTime.UtcNow.AddYears(-2));
            Assert.False(vehicle.IsRented);
        }

        [Fact]
        public void CreateVehicle_ShouldThrow_WhenOlderThanFiveYears()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                new Vehicle(Guid.NewGuid(), "Ford", "Focus", DateTime.UtcNow.AddYears(-6));
            });
        }

        [Fact]
        public void RentVehicle_ShouldSetIsRented()
        {
            var vehicle = new Vehicle(Guid.NewGuid(), "Tesla", "Model 3", DateTime.UtcNow.AddYears(-1));
            vehicle.Rent();
            Assert.True(vehicle.IsRented);
        }

        [Fact]
        public void ReturnVehicle_ShouldUnsetIsRented()
        {
            var vehicle = new Vehicle(Guid.NewGuid(), "Tesla", "Model 3", DateTime.UtcNow.AddYears(-1));
            vehicle.Rent();
            vehicle.Return();
            Assert.False(vehicle.IsRented);
        }
    }
}
