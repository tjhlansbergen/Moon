using Microsoft.Extensions.DependencyInjection;

namespace Moon;

class Program
{
    public static void Main(string[] args)
    {
        new ServiceCollection()
            .AddSingleton(s => State.LoadOrNew())
            .AddSingleton<Drawer>()
            .AddSingleton<Interpreter>()
            .AddSingleton<Main>()
            .BuildServiceProvider()
            .GetRequiredService<Main>()
            .Run();
    }
}


