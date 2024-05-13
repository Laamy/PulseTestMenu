using System;
using System.Timers;

class ConsoleEvents
{
    static int bufferWidth;
    static int bufferHeight;

    public static event Action Resize;
    public static event Action<char> Keypress;

    public static void TriggerKeypress(char key)
        => Keypress.Invoke(key);

    public static void SetupEvents()
    {
        Timer timer = new Timer();

        timer.Interval = 75; // 64fps
        timer.Elapsed += CheckEvents;
        timer.AutoReset = true;
        timer.Enabled = true;
    }

    static void CheckEvents(object sender, ElapsedEventArgs e)
    {
        if (Console.BufferWidth != bufferWidth || Console.BufferHeight != bufferHeight)
        {
            if (Resize != null)
                Resize.Invoke();

            bufferWidth = Console.BufferWidth;
            bufferHeight = Console.BufferHeight;
        }
    }
}