using System.Reflection;
using FlightScheduler.Application.Scheduler.Query;
using FlightScheduler.Data;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace FlightScheduler.Presentation;

public class Program
{
    public static async Task Main(string[] args)
    {
        var serviceProvider = ConfigureServices();

        var mediator = serviceProvider.GetService<IMediator>();

        var schedules = GetSchedules();
        var orderSchedule = await mediator.Send(new GetScheduleListQuery(schedules));
        foreach (var schedule in orderSchedule)
        {
            Console.WriteLine(schedule.ToString());
        }
    }
    
    private static ServiceProvider ConfigureServices()
    {
        var serviceProvider = new ServiceCollection()
            .AddMediatR(Assembly.GetAssembly(typeof(GetScheduleListQuery)))
            .BuildServiceProvider();

        return serviceProvider;
    } 
    
    private static List<Schedule> GetSchedules()
    {
        List<Schedule> schedules = new List<Schedule>();
        for (int day = 1; day < 3; day++) //day
        {
            for (int plane = 1; plane < 4; plane++) //plane
            {
                Console.WriteLine($"Please write {plane}. plane of {day}. day Arrival Code (Note: Departure code is YUL by default):");
                string arrivalCode = Console.ReadLine();
                
                schedules.Add(new Schedule(day*plane, arrivalCode, day));
            }
        }

        return schedules;
    }

}