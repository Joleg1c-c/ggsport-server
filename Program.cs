using ggsport;
using ggsport.Infrastructure;

internal class Program
{
    private static void Main(string[] args)
    {
        WebApplication.CreateBuilder(args)
            .ConfigureService()
            .Build()
            .Configure()
            .Run();
    }
}