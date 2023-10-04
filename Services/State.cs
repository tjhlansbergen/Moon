using System.Text.Json;
using System.Text.Json.Serialization;


namespace Moon;

public class State
{
    // List<KVP> to allow json serialization
    private Dictionary<Point, Tile> _map = new(); 
    public List<KeyValuePair<Point, Tile>> Map  
    { 
        get { return _map.ToList(); }
        set { _map = value.ToDictionary(x => x.Key, x => x.Value); }
    }

    public Point Cursor { get; set; } = new(0,0);
    
    public long Date { get; set; } = 0;

    [JsonIgnore]
    public bool Quit { get; set; } = false;

    [JsonIgnore]
    public Tuple<string, bool> Status { get; private set; } = new("v", true);

    public static State LoadOrNew()
    {
        return File.Exists(Constants.SaveFile) ? JsonSerializer.Deserialize<State>(File.ReadAllText(Constants.SaveFile)) ?? New() : New();
    }

    public void Store()
    {
        var json = JsonSerializer.Serialize(this);
        File.WriteAllText(Constants.SaveFile, json);
    }

    private static State New()
    {
        var state = new State();
        state.AddTile(new Tile { DisplayChar = 'e', DisplayColor = ConsoleColor.Green }, new Point(10, 10));
        return state;
    }

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
        _map.Add(Cursor, tile);
    }

    public void ClearSelectedTile()
    {
        _map.Remove(Cursor);
    }

    public void AddTile(Tile tile, Point point)
    {
        _map.Add(point, tile);
    }

    public Tile? SelectedTileOrDefault()
    {
        return _map.ContainsKey(Cursor) ? _map[Cursor] : null; 
    }

    public Tile? TileOrDefault(Point point)
    {
        return _map.ContainsKey(point) ? _map[point] : null; 
    }
}