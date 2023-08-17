using System;

namespace Moon;

class Program
{
    public static void Main(string[] args)
    {
        var mapper = new Mapper();
        mapper.Add(new Tile { DisplayChar = 'e', DisplayColor = ConsoleColor.Green}, new Point(10, 5));

        Drawing.Draw(mapper, new Point(1,1));
    }
}


