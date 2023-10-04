using System;

namespace Moon;

public class Drawer : IDisposable
{
    private readonly State _state;

    private readonly ConsoleColor _userForeground;
    private readonly ConsoleColor _userBackground;
    //private readonly bool _userCursorVisible;

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
        for (int y = ViewPort.Y; y < ViewPort.Bottom; y++)
        {
            // for each column
            for (int x = ViewPort.X; x < ViewPort.Right; x++)
            {
                if (x == _state.Cursor.X && y == _state.Cursor.Y) Console.BackgroundColor = Constants.CursorColor;

                var tile = _state.TileOrDefault(new Point(x, y));
                Console.ForegroundColor = tile?.DisplayColor ?? _userForeground;
                Console.Write(tile?.DisplayChar ?? ' ');

                Console.BackgroundColor = _userBackground;
            }
        }

        WriteStatus();
    }

    private void WriteStatus()
    {
        Console.Write($"d{_state.Date} ({_state.Cursor.X}:{_state.Cursor.Y})  ");

        var color = Console.ForegroundColor;
        if (_state.Status.Item2) Console.ForegroundColor = ConsoleColor.Green;
        else Console.ForegroundColor = ConsoleColor.Red;
        
        Console.WriteLine(_state.Status.Item1);
        Console.ForegroundColor = color;
        
        Console.Write("> ");
    }

    private void SyncViewPort()
    {
        // sync with console
        ViewPort = ViewPort.Resize(Console.WindowWidth, Console.WindowHeight - 2);

        // follow cursor
        if (_state.Cursor.X < ViewPort.X) ViewPort = ViewPort.MoveHorizontal(_state.Cursor.X - ViewPort.X);
        if (_state.Cursor.X >= ViewPort.Right) ViewPort = ViewPort.MoveHorizontal(1 + _state.Cursor.X - ViewPort.Right);
        if (_state.Cursor.Y < ViewPort.Y) ViewPort = ViewPort.MoveVertical(_state.Cursor.Y - ViewPort.Y);
        if (_state.Cursor.Y >= ViewPort.Bottom) ViewPort = ViewPort.MoveVertical(1 + _state.Cursor.Y - ViewPort.Bottom);
    }
}