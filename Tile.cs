using System;
using System.ComponentModel;

namespace Moon;

public class Tile
{
    public char DisplayChar { get; set; }
    public ConsoleColor DisplayColor { get; set; } = ConsoleColor.White;

    public static Tile New(TileType type)
    {
        switch (type)
        {
            case TileType.ROAD:
                return new Tile { DisplayChar = '#', DisplayColor = ConsoleColor.DarkYellow };
            default:
                throw new InvalidEnumArgumentException();
        }
    }
}