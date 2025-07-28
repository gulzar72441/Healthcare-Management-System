using System;
using System.Threading;
using System.Threading.Tasks;
using HealthcareSystem.Application.Appointments.Commands;
using HealthcareSystem.WebAPI.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

public class AppointmentsControllerTests
{
    [Fact]
    public async Task MoveToDoctor_ReturnsNoContent_WhenSuccess()
    {
        // Arrange
        var mediator = new Mock<IMediator>();
        var appointmentId = Guid.NewGuid();
        var doctorId = Guid.NewGuid();
        mediator.Setup(m => m.Send(It.IsAny<MoveAppointmentToDoctorCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(true);
        var controller = new AppointmentsController(mediator.Object);
        // Act
        var result = await controller.MoveToDoctor(appointmentId, doctorId);
        // Assert
        Assert.IsType<NoContentResult>(result);
    }
}
