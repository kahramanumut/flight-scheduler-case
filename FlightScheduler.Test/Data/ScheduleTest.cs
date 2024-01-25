using FlightScheduler.Data;
using Xunit;

namespace FlightScheduler.Test.Data;

public class ScheduleTest
{
    [Fact]
    public void RemainingCapacity_ShouldReturnRemainingCapacity()
    {
        // Arrange
        var schedule = new Schedule(1, "YYZ", 1);
        schedule.AddOrder();
        schedule.AddOrder();
        
        // Act
        var remainingCapacity = schedule.RemainingCapacity();
        
        // Assert
        Assert.Equal(18, remainingCapacity);
    }
}