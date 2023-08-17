using System;
using System.ComponentModel;

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
        input = input.ToLowerInvariant();

        var command = input.Split(' ')[0];
        var parameters = input.Split(' ').Skip(1).ToArray();

        if (Exit(command)) return;
        if (Move(command, parameters)) return;

        Warn($"Unknown command: {command}");
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
                _state.Cursor.Y -= distance;
                break;
            case "down":
                _state.Cursor.Y += distance;
                break;
            case "left":
                _state.Cursor.X -= distance;
                break;
            case "right":
                _state.Cursor.X += distance;
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