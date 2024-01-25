using System.Text.Json;

namespace FlightScheduler.Data;

public class Order
{
    private Order(string no, string destinationCode)
    {
        No = no;
        DestinationCode = destinationCode;
    }

    public string No { get; }
    public string DestinationCode { get; }
    
    public static List<Order> FromJson(string path)
    {
        string json = File.ReadAllText("orders.json");
        var orders = new List<Order>();
        var jsonDocument = JsonDocument.Parse(json);
        var root = jsonDocument.RootElement;
        foreach (var property in root.EnumerateObject())
        {
            string orderNo = property.Name;
            string destinationCode = property.Value.GetProperty("destination").GetString()!;
            orders.Add(new Order(orderNo, destinationCode));
        }
        
        return orders;
    }
}