using System;

namespace Moon;

public class Main
{
    private Drawer _drawer;
    private State _state;

    public Main(Drawer drawer, State state)
    {
        _drawer = drawer; 
        _state = state;
    }

    public void Run()
    {
        // test
        _state.AddTile(new Tile { DisplayChar = 'e', DisplayColor = ConsoleColor.Green }, new Point(10, 10));
        
        _drawer.Draw();

        Console.Write(">");
        Console.ReadLine();
    }
}