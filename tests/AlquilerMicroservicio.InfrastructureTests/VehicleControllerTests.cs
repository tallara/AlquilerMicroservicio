
using AlquilerMicroservicio.API.Controllers;
using AlquilerMicroservicio.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace AlquilerMicroservicio.InfrastructureTests
{
    public class VehicleControllerTests
    {
        [Fact]
        public async Task CreateVehicle_ShouldReturnOk()
        {
            // Arrange
            var mediator = new Mock<IMediator>();
            mediator.Setup(m => m.Send(It.IsAny<CreateVehicleCommand>(), It.IsAny<CancellationToken>()))
                    .ReturnsAsync(Unit.Value);

            var controller = new VehiclesController(mediator.Object);
            var command = new CreateVehicleCommand
            {
                Id = Guid.NewGuid(),
                Brand = "Toyota",
                Model = "RAV4",
                ManufactureDate = DateTime.UtcNow.AddYears(-1)
            };

            // Act
            var result = await controller.CreateVehicle(command);

            // Assert
            Assert.IsType<OkResult>(result);
        }
    }
}
