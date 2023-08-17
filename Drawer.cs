using System;

namespace Moon;

public class Drawer : IDisposable
{
    private readonly State _state;

    private readonly ConsoleColor _userForeground;
    private readonly ConsoleColor _userBackground;
    private readonly bool _userCursorVisible;

    public Rect ViewPort { get; private set; } = new(0,0,0,0);

    public Drawer(State state)
    {
        _state = state;
        _userForeground = Console.ForegroundColor;
        _userBackground = Console.BackgroundColor;
        //_userCursorVisible = Console.CursorVisible;

        //Console.CursorVisible = false;
    }

    public void Dispose()
    {
        Console.ForegroundColor = _userForeground;
        Console.BackgroundColor = _userBackground;
        //Console.CursorVisible = _userCursorVisible;
    }

    public void Draw()
    {
        SyncViewPort();
        Console.Clear();

        // for each row
        for (int y = ViewPort.Top; y < ViewPort.Bottom; y++)
        {
            // for each column
            for (int x = ViewPort.Left; x < ViewPort.Right; x++)
            {
                if (x == _state.Cursor.X && y == _state.Cursor.Y) Console.BackgroundColor = Constants.CursorColor;

                var tile = _state.TileOrDefault(new Point(x, y));
                Console.ForegroundColor = tile?.DisplayColor ?? _userForeground;
                Console.Write(tile?.DisplayChar ?? ' ');

                Console.BackgroundColor = _userBackground;
            }
        }
    }

    private void SyncViewPort()
    {
        // sync with console
        ViewPort.Width = Console.WindowWidth;
        ViewPort.Height = Console.WindowHeight - 2;

        // follow cursor
        if (_state.Cursor.X < ViewPort.Left) ViewPort.Left -= ViewPort.Left - _state.Cursor.X;
        if (_state.Cursor.X > ViewPort.Right) ViewPort.Left += _state.Cursor.X - ViewPort.Right;
        if (_state.Cursor.Y < ViewPort.Top) ViewPort.Top -= ViewPort.Top - _state.Cursor.Y;
        if (_state.Cursor.Y > ViewPort.Bottom) ViewPort.Top += _state.Cursor.Y - ViewPort.Bottom;
    }
}