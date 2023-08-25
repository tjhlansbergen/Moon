using System;

namespace Moon;

public class State
{
    public Dictionary<Point, Tile> Map { get; private set; } = new Dictionary<Point, Tile>();
    public Point Cursor { get; set; } = new(0,0);
    public bool Quit { get; set; } = false;
    public Tuple<string, bool> Status { get; private set; } = new("v", true);

    public void SetStatus(string message, bool ok)
    {
        Status = new(message, ok);
    }

    public void ResetStatus()
    {
        Status = new("v", true);
    }

    public void AddSelectedTile(Tile tile)
    {
        Map.Add(Cursor, tile);
    }

    public void AddTile(Tile tile, Point point)
    {
        Map.Add(point, tile);
    }

    public Tile? SelectedTileOrDefault()
    {
        return Map.ContainsKey(Cursor) ? Map[Cursor] : null; 
    }

    public Tile? TileOrDefault(Point point)
    {
        return Map.ContainsKey(point) ? Map[point] : null; 
    }
}