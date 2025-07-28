using System;
using System.Threading;
using System.Threading.Tasks;
using HealthcareSystem.Application.Patients.Commands;
using HealthcareSystem.WebAPI.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

public class PatientsControllerTests
{
    [Fact]
    public async Task MoveToDoctor_ReturnsNoContent_WhenSuccess()
    {
        // Arrange
        var mediator = new Mock<IMediator>();
        var patientId = Guid.NewGuid();
        var doctorId = Guid.NewGuid();
        mediator.Setup(m => m.Send(It.IsAny<MovePatientToDoctorCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(true);
        var controller = new PatientsController(mediator.Object);
        // Act
        var result = await controller.MoveToDoctor(patientId, doctorId);
        // Assert
        Assert.IsType<NoContentResult>(result);
    }
}
