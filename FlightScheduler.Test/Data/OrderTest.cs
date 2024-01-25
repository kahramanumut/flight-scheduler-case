using FlightScheduler.Data;
using Xunit;

namespace FlightScheduler.Test.Data;

public class OrderTest
{
    [Fact]
    public void FromJson_ShouldValidDeserialization()
    {
        // Arrange
        var path = "orders.json";
        
        // Act
        var orders = Order.FromJson(path);
        
        // Assert
        Assert.Equal(96, orders.Count);
        Assert.Equal("order-001", orders[0].No);
        Assert.Equal("YYZ", orders[0].DestinationCode);
    }
    
}