using System;

namespace Moon;

public record Point
{
    public int X { get; set; } = 0;
    public int Y { get; set; } = 0;

    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }
}

public record Rect
{
    public int Left { get; set; } = 0;
    public int Top { get; set; } = 0;
    public int Width { get; set; } = 0;
    public int Height { get; set; } = 0;

    public int Right => Left + Width;
    public int Bottom => Top + Height;

    public Rect(int left, int top, int width, int height)
    {
        Left = left;
        Top = top;
        Width = width;
        Height = height;
    }
}