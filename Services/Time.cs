using System.Timers;
using Timer = System.Timers.Timer;

namespace Moon;

public class Time
{
    private Drawer _drawer;
    private State _state;
    private Timer _timer;

    public Time(State state, Drawer drawer)
    {
        _drawer = drawer;
        _state = state;
        _timer = new Timer(5000);

        _timer.Elapsed += Tick;
        _timer.AutoReset = true;
    }

    public void Start() => _timer.Start();
    public void Stop() => _timer.Stop();


    public void Tick(object? source, ElapsedEventArgs e)
    {
        _state.Date++;

        // todo: do not draw if the user is typing
        _drawer.Draw();
    }
}