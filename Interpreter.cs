using System;

namespace Moon;

public class Interpreter
{
    private State _state;

    public Interpreter(State state)
    {
        _state = state;
    }

    public bool Read(string? input)
    {
        if (input == null) return false;
        if (Exit(input)) return true;

        input = input.ToLowerInvariant();

        switch (input)
        {
            case "up":
                _state.Cursor.Y--;
                break;
            case "down":
                _state.Cursor.Y++;
                break;
            case "left":
                _state.Cursor.X--;
                break;
            case "right":
                _state.Cursor.X++;
                break;           
        }

        return false;
    }

    private bool Exit(string input)
    {
        var quitStrings = new string[] { 
            "quit", 
            "exit",
            "q",
            "close"
            };

        return quitStrings.Contains(input.ToLowerInvariant());
    }
}