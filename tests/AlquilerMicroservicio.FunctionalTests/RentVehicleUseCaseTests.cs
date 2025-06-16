using AlquilerMicroservicio.Application.Commands;
using AlquilerMicroservicio.Application.Handlers;
using AlquilerMicroservicio.Domain.Entities;
using AlquilerMicroservicio.Domain.Interfaces;
using AlquilerMicroservicio.Domain.Services;
using AlquilerMicroservicio.Infrastructure.Events;
using Moq;

namespace AlquilerMicroservicio.FunctionalTests
{
    public class RentVehicleUseCaseTests
    {
        [Fact]
        public async Task ShouldRentVehicle_WhenCustomerHasNoActiveRental()
        {
            // Arrange
            var vehicleId = Guid.NewGuid();
            var rentalId = Guid.NewGuid();
            var customerId = "12345";

            var vehicle = new Vehicle(vehicleId, "Toyota", "Yaris", DateTime.UtcNow.AddYears(-1));

            var vehicleRepo = new Mock<IVehicleRepository>();
            var rentalRepo = new Mock<IRentalRepository>();
            var dispatcher = new Mock<IDomainEventDispatcher>();

            vehicleRepo.Setup(r => r.GetByIdAsync(vehicleId)).ReturnsAsync(vehicle);
            rentalRepo.Setup(r => r.GetActiveRentalByCustomerAsync(customerId)).ReturnsAsync((Rental?)null);

            var domainService = new RentalDomainService(rentalRepo.Object, vehicleRepo.Object);

            var handler = new RentVehicleCommandHandler(
                domainService,
                rentalRepo.Object,
                vehicleRepo.Object,
                dispatcher.Object
            );

            var command = new RentVehicleCommand
            {
                RentalId = rentalId,
                VehicleId = vehicleId,
                CustomerId = customerId
            };

            // Act
            await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.True(vehicle.IsRented);
            vehicleRepo.Verify(r => r.UpdateAsync(It.IsAny<Vehicle>()), Times.Once);
            rentalRepo.Verify(r => r.AddAsync(It.IsAny<Rental>()), Times.Once);
            dispatcher.Verify(d => d.DispatchAsync(It.IsAny<object>(), It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
