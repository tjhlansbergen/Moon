namespace Moon;

public class Interpreter
{
    private State _state;

    public Interpreter(State state)
    {
        _state = state;
    }

    public void Read(string? input)
    {
        _state.ResetStatus();

        if (string.IsNullOrWhiteSpace(input)) return;
        input = input.ToLowerInvariant().Trim();

        var commands = input.Split(';', StringSplitOptions.RemoveEmptyEntries);
        var iterations = 1;

        if (commands.Length > 1 &&
            commands.Last().Trim().StartsWith("x") &&
            int.TryParse(commands.Last().Split('x')[1], out var i))
        {
            commands = commands.Take(commands.Length - 1).ToArray();
            iterations = i;
        }

        Process(commands, iterations);
    }

    private void Process(string[] commands, int iterations)
    {
        for (int i = 0; i < iterations; i++)
        {
            foreach (var command in commands)
            {
                var input = command.Trim().Split(' ')[0];
                var parameters = command.Trim().Split(' ').Skip(1).Select(p => p.Trim().ToLowerInvariant()).ToArray();

                if (Exit(input)) continue;
                if (Clear(input)) continue;
                if (Move(input, parameters)) continue;
                if (Build(input, parameters)) continue;
                
                Warn($"Unknown command: {input}");
                break;
            }
        }
    }

    private bool Build(string command, string[] p)
    {
        if (command != "new") return false;

        if (_state.SelectedTileOrDefault() != null) return Warn($"New failed, tile {_state.Cursor} is in use");
        if (p.Length != 1 || !Enum.TryParse<New>(p[0], out var t)) return Warn($"New failed, not sure what to build");

        _state.AddSelectedTile(Tile.New(t));
        return true;
    }

    private bool Clear(string command)
    {
        if (command != "clear") return false;
        if (_state.SelectedTileOrDefault() == null) return Warn($"Clear failed, nothing to clear at {_state.Cursor}");

        _state.ClearSelectedTile();
        return true;
    }

    private bool Move(string command, string[] p)
    {
        var directions = new string[] {
            "up",
            "down",
            "left",
            "right",
        };

        if (!directions.Contains(command)) return false;
        if (p.Count() > 1) return Warn($"too many parameters for command {command}");
        if (p.Count() == 1 && !IsNumeric(p[0])) return Warn($"parameter is not numeric: {p[0]}");

        var distance = 1;
        if (p.Count() == 1) distance = int.Parse(p[0]);

        switch (command)
        {
            case "up":
                _state.Cursor = _state.Cursor.MoveVertical(-distance);
                break;
            case "down":
                _state.Cursor = _state.Cursor.MoveVertical(distance);
                break;
            case "left":
                _state.Cursor = _state.Cursor.MoveHorizontal(-distance);
                break;
            case "right":
                _state.Cursor = _state.Cursor.MoveHorizontal(distance);
                break;
        }

        return true;
    }

    private bool Exit(string command)
    {
        var quitStrings = new string[] {
            "quit",
            "exit",
            "q",
            "close"
            };

        if (quitStrings.Contains(command))
        {
            _state.Quit = true;
            return true;
        }

        return false;
    }

    private bool Warn(string message)
    {
        _state.SetStatus(message, false);
        return true;
    }

    private bool IsNumeric(string str)
    {
        return int.TryParse(str, out _);
    }
}