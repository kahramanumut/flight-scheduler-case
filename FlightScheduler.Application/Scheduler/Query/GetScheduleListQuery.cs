using FlightScheduler.Application.Scheduler.Dto;
using FlightScheduler.Data;
using MediatR;

namespace FlightScheduler.Application.Scheduler.Query;

public class GetScheduleListQuery : IRequest<List<OrderSchedule>>
{
    public GetScheduleListQuery(List<Schedule> schedules)
    {
        Schedules = schedules;
    }

    public List<Schedule> Schedules { get; }
}

public class GetScheduleListQueryHandler : IRequestHandler<GetScheduleListQuery, List<OrderSchedule>>
{
    public Task<List<OrderSchedule>> Handle(GetScheduleListQuery request, CancellationToken cancellationToken)
    {
        var orders = Order.FromJson("orders.json");
        var orderSchedules = new List<OrderSchedule>();
        foreach (var order in orders)
        {
            var schedule = request.Schedules
                .Where(schedule => schedule.ArrivalCode == order.DestinationCode && schedule.RemainingCapacity() > 0)
                .MinBy(schedule => schedule.Day);

            if (schedule != null)
            {
                schedule.AddOrder();
                orderSchedules.Add(new OrderSchedule(order.No, schedule.FlightNo, schedule.DepartureCode,
                    schedule.ArrivalCode, schedule.Day));
            }
            else
                orderSchedules.Add(new OrderSchedule(order.No, null, null, null, null));
        }

        return Task.FromResult(orderSchedules);
    }
}