using System.Diagnostics;
using System.Reflection;
using Akka.Actor;
using Akka.Routing;

namespace Core.Actors;

class Program
{
    static async Task Main(string[] args)
    {

        using var timer = new PeriodicTimer(TimeSpan.FromSeconds(1));
        using var actorSystem = ActorSystem.Create("MyActorSystem");
        using var cancellationTokenSource = new CancellationTokenSource();

        var defaultStrategy = new OneForOneStrategy(3,TimeSpan.FromSeconds(3), exception => exception is ActorInitializationException ? Directive.Stop : Directive.Resume);

        var mainActorProps = Props.Create<MainActor>().WithSupervisorStrategy(defaultStrategy).WithRouter(new RandomPool(10));

        var mainActor = actorSystem.ActorOf(mainActorProps, nameof(MainActor));
        
         var messageSentCount = 0;

         var stopWatch = Stopwatch.StartNew();
         try
         {
             while (messageSentCount < 100 && await timer.WaitForNextTickAsync(cancellationTokenSource.Token))
             {

                 
                 Console.WriteLine("[{0}] - Address:{1} - Path:{2} - Name:{3}",nameof(MainActor),mainActor.Path.Address,mainActor.Path,mainActor.Path.Name);
                 Console.WriteLine($"Job still running... Elapsed time:{stopWatch.Elapsed}");

                 if (stopWatch.Elapsed >= TimeSpan.FromSeconds(5))
                 {
                     Console.WriteLine("Timeout...Time:{0} second(s)",stopWatch.Elapsed.Seconds);
                     break;
                 }
                 
                 mainActor.Tell(new MainActorMessage(message: $"testing this main actor:{messageSentCount}"));

                 messageSentCount++;


             }
         }
         catch (Exception e)
         {
             Console.WriteLine(e);
             throw;
         }
         finally
         {
             stopWatch.Stop();
         }
      
        
    }
    
    
}