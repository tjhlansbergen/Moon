using System;

namespace Moon;

public class Drawer : IDisposable
{
    private readonly State _state;

    private readonly ConsoleColor _userForeground;
    private readonly ConsoleColor _userBackground;
    private readonly bool _userCursorVisible;

    public Drawer(State state)
    {
        _state = state;
        _userForeground = Console.ForegroundColor;
        _userBackground = Console.BackgroundColor;
        _userCursorVisible = Console.CursorVisible;

        Console.CursorVisible = false;
    }

    public void Dispose()
    {
        Console.ForegroundColor = _userForeground;
        Console.BackgroundColor = _userBackground;
        Console.CursorVisible = _userCursorVisible;
    }

    public void Draw()
    {
        var bounds = new Point(Console.WindowWidth, Console.WindowHeight);
        Console.Clear();

        for (int y = 0; y < bounds.Y - 1; y++)
        {
            for (int x = 0; x < bounds.X; x++)
            {
                if (x == 20 && y == 20) Console.BackgroundColor = Constants.CursorColor;

                var tile = _state.TileOrDefault(new Point(x, y));
                Console.ForegroundColor = tile?.DisplayColor ?? _userForeground;
                Console.Write(tile?.DisplayChar ?? ' ');

                Console.BackgroundColor = _userBackground;
            }
        }
    }
}