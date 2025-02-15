using System.Threading.Channel.Api.Actors;
using System.Threading.Channel.Api.Actors.Messages;
using System.Threading.Channel.Api.ServiceCollectionExtensions;
using System.Threading.Channel.Api.Services;
using Akka.Actor;
using Akka.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace System.Threading.Channel.Api;

public static class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var configuration = builder.Configuration;

        builder.Services.AddSingleton<QueueService<int>>();
        builder.Services.AddHostedService<ChannelBackgroundService>();
        builder.Services.AddHostedService<ChannelBackgroundService2>();
        builder.Services.AddActorSystem(configuration);
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.MapPost("/produce/channel", async ([FromServices] ActorRegistry registry ,int itemCount) =>
        {
            var mainActor = await registry.GetAsync<MainActor>();

            if (mainActor.Equals(ActorRefs.Nobody))
            {
                return Results.Problem("MainActor is not available :(");
            }
            
            
            mainActor.Tell(new SendChannelMessage(itemCount));

            return Results.Ok("Message sent to MainActor.....:)");
        });

        app.Run();
    }
}