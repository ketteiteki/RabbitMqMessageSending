using MassTransit;
using RabbitMqAspNetCore.Models;

namespace RabbitMqAspNetCore.Sender;

public class Startup
{
    public void ConfigureServices(IServiceCollection serviceCollection)
    {
        serviceCollection.AddControllers();
        serviceCollection.AddEndpointsApiExplorer();
        serviceCollection.AddSwaggerGen();

        serviceCollection.AddMassTransit(config =>
        {
            config.UsingRabbitMq((ctx, cfg) =>
            {
                cfg.Host("localhost", h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });
            });
            
            config.AddRequestClient<Message>();
        });
        
        serviceCollection.AddMassTransitHostedService();
    }

    public void Configure(IApplicationBuilder applicationBuilder, IHostEnvironment hostEnvironment)
    {
        if (hostEnvironment.IsDevelopment())
{
    applicationBuilder.UseSwagger();
    applicationBuilder.UseSwaggerUI();
}

        applicationBuilder.UseHttpsRedirection();

        applicationBuilder.UseRouting();

        applicationBuilder.UseEndpoints(builder =>
        {
            builder.MapControllers();
        });
    }
}