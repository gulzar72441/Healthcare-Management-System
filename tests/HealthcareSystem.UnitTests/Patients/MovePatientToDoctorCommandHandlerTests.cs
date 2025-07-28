using System;
using System.Threading;
using System.Threading.Tasks;
using HealthcareSystem.Application.Patients.Commands;
using HealthcareSystem.Domain.Entities;
using HealthcareSystem.Domain.Interfaces;
using Moq;
using Xunit;

public class MovePatientToDoctorCommandHandlerTests
{
    [Fact]
    public async Task Handle_ShouldMovePatient_WhenBothExist()
    {
        // Arrange
        var patientId = Guid.NewGuid();
        var doctorId = Guid.NewGuid();
        var patient = new Patient { Id = patientId };
        var doctor = new Doctor { Id = doctorId };
        var patientRepo = new Mock<IPatientRepository>();
        var doctorRepo = new Mock<IDoctorRepository>();
        patientRepo.Setup(r => r.GetByIdAsync(patientId)).ReturnsAsync(patient);
        doctorRepo.Setup(r => r.GetByIdAsync(doctorId)).ReturnsAsync(doctor);
        patientRepo.Setup(r => r.UpdateAsync(patient)).Returns(Task.CompletedTask);
        var handler = new MovePatientToDoctorCommandHandler(patientRepo.Object, doctorRepo.Object);
        var command = new MovePatientToDoctorCommand(patientId, doctorId);
        // Act
        var result = await handler.Handle(command, CancellationToken.None);
        // Assert
        Assert.True(result);
        Assert.Equal(doctorId, patient.Id);
        patientRepo.Verify(r => r.UpdateAsync(patient), Times.Once);
    }
}
