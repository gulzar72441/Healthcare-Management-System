using System;
using System.Threading;
using System.Threading.Tasks;
using HealthcareSystem.Application.Appointments.Commands;
using HealthcareSystem.Domain.Entities;
using HealthcareSystem.Domain.Interfaces;
using Moq;
using Xunit;

public class MoveAppointmentToDoctorCommandHandlerTests
{
    [Fact]
    public async Task Handle_ShouldMoveAppointment_WhenBothExist()
    {
        // Arrange
        var appointmentId = Guid.NewGuid();
        var doctorId = Guid.NewGuid();
        var appointment = new Appointment { Id = appointmentId };
        var doctor = new Doctor { Id = doctorId };
        var appointmentRepo = new Mock<IAppointmentRepository>();
        var doctorRepo = new Mock<IDoctorRepository>();
        appointmentRepo.Setup(r => r.GetByIdAsync(appointmentId)).ReturnsAsync(appointment);
        doctorRepo.Setup(r => r.GetByIdAsync(doctorId)).ReturnsAsync(doctor);
        appointmentRepo.Setup(r => r.UpdateAsync(appointment)).Returns(Task.CompletedTask);
        var handler = new MoveAppointmentToDoctorCommandHandler(appointmentRepo.Object, doctorRepo.Object);
        var command = new MoveAppointmentToDoctorCommand(appointmentId, doctorId);
        // Act
        var result = await handler.Handle(command, CancellationToken.None);
        // Assert
        Assert.True(result);
        Assert.Equal(doctorId, appointment.DoctorId);
        appointmentRepo.Verify(r => r.UpdateAsync(appointment), Times.Once);
    }
}
