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
        bool exit;

        do
        {
            _drawer.Draw();

            Console.WriteLine($"({_state.Cursor.X}:{_state.Cursor.Y})");
            Console.Write("> ");

            exit = _interpreter.Read(Console.ReadLine());

        } while (!exit);

    }
}