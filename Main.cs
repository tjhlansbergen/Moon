using System;

namespace Moon;

public class Main
{
    private State _state;
    private Drawer _drawer;
    private Interpreter _interpreter;

    public Main(State state, Drawer drawer, Interpreter interpreter)
    {
        _state = state;
        _drawer = drawer;
        _interpreter = interpreter;
    }

    public void Run()
    {
        // test
        _state.AddTile(new Tile { DisplayChar = 'e', DisplayColor = ConsoleColor.Green }, new Point(10, 10));


        do
        {
            _drawer.Draw();

            WriteStatus();

            _interpreter.Read(Console.ReadLine());

        } while (!_state.Quit);

    }

    private void WriteStatus()
    {
        Console.Write($"({_state.Cursor.X}:{_state.Cursor.Y}) ");

        var color = Console.ForegroundColor;
        if (_state.Status.Item2) Console.ForegroundColor = ConsoleColor.Green;
        else Console.ForegroundColor = ConsoleColor.Red;
        
        Console.WriteLine(_state.Status.Item1);
        Console.ForegroundColor = color;
        
        Console.Write("> ");
    }
}