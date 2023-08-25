using System;

namespace Moon;

public struct Point
{
    public int X { get; set; } = 0;
    public int Y { get; set; } = 0;

    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }

    public readonly Point MoveHorizontal(int by) => new(X + by, Y);
    public readonly Point MoveVertical(int by) => new (X, Y + by);
}

public struct Rect
{
    public int X { get; set; } = 0;
    public int Y { get; set; } = 0;
    public int Width { get; set; } = 0;
    public int Height { get; set; } = 0;

    public readonly int Right => X + Width;
    public readonly int Bottom => Y + Height;

    public Rect(int x, int y, int width, int height)
    {
        X = x;
        Y = y;
        Width = width;
        Height = height;
    }

    public readonly Rect Resize(int width, int height) => new(X, Y, width, height);
    public readonly Rect MoveHorizontal(int by) => new(X + by, Y, Width, Height);
    public readonly Rect MoveVertical(int by) => new (X, Y + by, Width, Height);
    
}