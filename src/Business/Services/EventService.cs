using Business.Interfaces;
using Domain;
using MassTransit;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace Business.WorkerServices
{
    public class EventService : IEventService
    {
        IPublishEndpoint publishEndpoint;
        IConfiguration configuration;
        public EventService(IPublishEndpoint _publishEndpoint,IConfiguration _configuration)
        {
            publishEndpoint = _publishEndpoint;
            configuration = _configuration;
        }
        public async Task PublishEvent()
        {
            try
            {
            
                var eventDto = new EventDto(configuration.GetSection("Paramaters:LocationId").Value, "title " + DateTime.Now.ToString("HH mm ss"), false);
               await publishEndpoint.Publish(eventDto);

                Console.WriteLine(eventDto);
          
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
