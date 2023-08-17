using System;

namespace Moon;

internal class Mapper
{
    public Dictionary<Point, Tile> Map { get; private set; } = new Dictionary<Point, Tile>();

    public void Add(Tile tile, Point point)
    {
        Map.Add(point, tile);
    }

    public Tile? TileOrDefault(Point point)
    {
        return Map.ContainsKey(point) ? Map[point] : null; 
    }
}