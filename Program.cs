using Microsoft.Extensions.DependencyInjection;

namespace Moon;

class Program
{
    public static void Main(string[] args)
    {
        new ServiceCollection()
            .AddSingleton<State>()
            .AddSingleton<Drawer>()
            .AddSingleton<Main>()
            .BuildServiceProvider()
            .GetRequiredService<Main>()
            .Run();
    }
}


