using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Channel.Api.Actors;
using Akka.Actor;
using Akka.Actor.Dsl;
using Akka.Hosting;
using Microsoft.Win32;

namespace System.Threading.Channel.Api.ServiceCollectionExtensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddActorSystem(this IServiceCollection services, IConfiguration config)
    {
        var actorSystem = Regex.Replace(Assembly.GetExecutingAssembly().GetName().Name ?? "ActorSystem",
            @"[^a-zA-Z]+","",RegexOptions.None,TimeSpan.FromMilliseconds(100));


        services.AddAkka(actorSystem, builder =>
        {
            builder.WithActors((system, registry, resolver) =>
            {

                var defaultStrategy = new OneForOneStrategy(3,TimeSpan.FromSeconds(3), ex =>
                {

                    if (ex is not ActorInitializationException) return Directive.Resume;

                    _ = system.Terminate();
                    return Directive.Stop;
                });


                var mainActorProps = resolver.Props<MainActor>().WithSupervisorStrategy(defaultStrategy);

                var mainActor = system.ActorOf(mainActorProps, nameof(MainActor));
                
                registry.Register<MainActor>(mainActor);

            });
        });


        return services;
    }
    
}