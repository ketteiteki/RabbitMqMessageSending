using MassTransit;

namespace RabbitMqAspNetCore.Receiver;

public class Startup
{
    public void ConfigureServices(IServiceCollection serviceCollection)
    {
        serviceCollection.AddControllers();
        serviceCollection.AddEndpointsApiExplorer();
        serviceCollection.AddSwaggerGen();

        serviceCollection.AddMassTransit(config =>
        {
            config.AddConsumer<MessageConsumer>();

            config.UsingRabbitMq((ctx, cfg) =>
            {
                cfg.Host("localhost", h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });
                
                cfg.ReceiveEndpoint("message-queue", c =>
                {
                    c.ConfigureConsumer<MessageConsumer>(ctx);
                });
            });
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