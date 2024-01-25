using FlightScheduler.Application.Scheduler.Query;
using FlightScheduler.Data;
using Xunit;

namespace FlightScheduler.Test.Application;

public class GetScheduleListQueryHandlerTest
{
    [Fact]
    public async Task Handle_ShouldReturnScheduleList()
    {
        // Arrange
        var flightScheduleList = new List<Schedule>
        {
            new(1, "YYZ", 1),
            new(2, "YVR", 2),
            new(3, "YYC", 3)
        };
        
        var query = new GetScheduleListQuery(flightScheduleList);
        var handler = new GetScheduleListQueryHandler();
        
        // Act
        var orderSchedule = await handler.Handle(query, CancellationToken.None);
        
        // Assert
        Assert.True(orderSchedule.Count() > 50);
        Assert.Equal("order-001", orderSchedule[0].OrderNo);
        Assert.Equal(1, orderSchedule[0].FlightNumber);
        Assert.Equal("YYZ", orderSchedule[0].ArrivalCode);
        Assert.Equal("YUL", orderSchedule[0].DepartureCode);
        Assert.DoesNotContain("not scheduled", orderSchedule[0].ToString());
        Assert.Contains("not scheduled", orderSchedule[50].ToString());
    }
}