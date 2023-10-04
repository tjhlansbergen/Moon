using System;

namespace Moon;

public class Main
{
    private Time _time;
    private State _state;
    private Drawer _drawer;
    private Interpreter _interpreter;

    public Main(Time time, State state, Drawer drawer, Interpreter interpreter)
    {
        _time = time;
        _state = state;
        _drawer = drawer;
        _interpreter = interpreter;
    }

    public void Run()
    {
        _time.Start();

        do
        {
            _drawer.Draw();
            _state.Store();     // note we only store after the user 'does something', not on each tick
            _interpreter.Read(Console.ReadLine());

        } while (!_state.Quit);

        _time.Stop();
        _state.Store();
    }
}