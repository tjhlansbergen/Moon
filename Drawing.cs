using System;

namespace Moon;

internal class Drawing
{
    internal static void Draw(Mapper map, Point center)
    {
        var bounds = new Point(Console.WindowWidth, Console.WindowHeight);
        Console.Clear();

        for (int y = 0; y < bounds.Y - 1; y++)
        {
            for (int x = 0; x < bounds.X; x++)
            {
                var tile = map.TileOrDefault(new Point(x, y));
                Console.ForegroundColor = tile?.DisplayColor ?? ConsoleColor.White;
                Console.Write(tile?.DisplayChar ?? '.');
            }
        }
        
    }
}