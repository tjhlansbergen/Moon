using System;

namespace Moon;

public class State
{
    public Dictionary<Point, Tile> Map { get; private set; } = new Dictionary<Point, Tile>();

    public void AddTile(Tile tile, Point point)
    {
        Map.Add(point, tile);
    }

    public Tile? TileOrDefault(Point point)
    {
        return Map.ContainsKey(point) ? Map[point] : null; 
    }
}