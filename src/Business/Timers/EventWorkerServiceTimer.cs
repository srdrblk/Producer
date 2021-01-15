
using Business.Interfaces;
using Microsoft.Extensions.Hosting;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Timers
{
    public class EventWorkerServiceTimer : IHostedService, IDisposable
    {


        private Timer _timer;
        IEventService eventService;

        public EventWorkerServiceTimer(IEventService _eventService)
        {
            eventService = _eventService;
        }

        public Task StartAsync(CancellationToken stoppingToken)
        {

            _timer = new Timer(DoWork, null, TimeSpan.Zero,
                TimeSpan.FromSeconds(10));

            return Task.CompletedTask;
        }

        private async void DoWork(object state)
        {
            await eventService.PublishEvent();
        }

        public Task StopAsync(CancellationToken stoppingToken)
        {
            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}