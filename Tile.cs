using System;
using System.ComponentModel;

namespace Moon;

public class Tile
{
    public char DisplayChar { get; set; }
    public ConsoleColor DisplayColor { get; set; } = ConsoleColor.White;

    public static Tile New(New type)
    {
        switch (type)
        {
            case Moon.New.road:
                return new Tile { DisplayChar = '#', DisplayColor = ConsoleColor.DarkYellow };
            default:
                throw new InvalidEnumArgumentException();
        }
    }
}