namespace FlightScheduler.Data;

public class Schedule
{
    public Schedule(int flightNo, string arrivalCode, int day)
    {
        FlightNo = flightNo;
        ArrivalCode = arrivalCode;
        Day = day;
    }
    
    public int FlightNo { get; }
    public string DepartureCode => "YUL";
    public string ArrivalCode { get;}
    public int Day { get; }
    
    public int RemainingCapacity() => Capacity - OrderCount;
    public void AddOrder() => OrderCount++;
    
    private int Capacity => 20;
    private int OrderCount { get; set; }
    
}