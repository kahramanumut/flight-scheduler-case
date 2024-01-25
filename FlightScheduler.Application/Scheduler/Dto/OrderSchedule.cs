namespace FlightScheduler.Application.Scheduler.Dto;

public class OrderSchedule
{
    public OrderSchedule(string orderNo, int? flightNumber, string departureCode, string arrivalCode, int? day)
    {
        OrderNo = orderNo;
        FlightNumber = flightNumber;
        DepartureCode = departureCode;
        ArrivalCode = arrivalCode;
        Day = day;
    }
    
    public string OrderNo { get; }
    public int? FlightNumber { get; }
    public string DepartureCode { get; }
    public string ArrivalCode { get; }
    public int? Day { get; }
    
    public override string ToString()
    {
        if(FlightNumber != null)
            return $"OrderNo: {OrderNo}, FlightNumber: {FlightNumber}, DepartureCode: {DepartureCode}, ArrivalCode: {ArrivalCode}, Day: {Day}";

        return $"OrderNo:{OrderNo}, FlightNumber: not scheduled";
    }
}