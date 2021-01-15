using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Producer.StartupConfiguration
{

    public static class RabbitMqConfiguration
    {
        public static IServiceCollection RabbitMq(this IServiceCollection services, IConfiguration section)
        {
            // services.AddMassTransit(x =>
            //{
            //    x.UsingRabbitMq((context, config) =>
            //     {

            //         config.Host(new Uri(section.GetValue<string>("MessageBroker:RabbitMq:Url")),
            //                 h =>
            //                 {
            //                     h.Username(section.GetValue<string>("MessageBroker:RabbitMq:Username"));
            //                     h.Password(section.GetValue<string>("MessageBroker:RabbitMq:Password"));
            //                     h.Heartbeat(TimeSpan.FromSeconds(30));

            //                 });

            //         config.ExchangeType = ExchangeType.Direct;
            //     });
            //});


            services.AddMassTransit(x =>
            {
                x.UsingRabbitMq();
            });


            return services;
        }
    }

}
