using System;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

public class CConsole
{
    private static int STD_OUTPUT_HANDLE = -11;
    private static uint ENABLE_VIRTUAL_TERMINAL_PROCESSING = 4;

    [DllImport("kernel32.dll", SetLastError = true)]
    static extern IntPtr GetStdHandle(int nStdHandle);

    [DllImport("kernel32.dll")]
    static extern bool GetConsoleMode(IntPtr hConsoleHandle, out uint lpMode);

    [DllImport("kernel32.dll")]
    static extern bool SetConsoleMode(IntPtr hConsoleHandle, uint dwMode);

    const string RESET = "\x1B[0m";
    const string BOLD = "\x1B[1m";
    const string CURSIVE = "\x1B[3m";
    const string UNDERLINE = "\x1B[4m";

    public static void Setup()
    {
        var handle = GetStdHandle(STD_OUTPUT_HANDLE);
        uint mode;
        GetConsoleMode(handle, out mode);
        mode |= ENABLE_VIRTUAL_TERMINAL_PROCESSING;
        SetConsoleMode(handle, mode);
    }

    public static ConsoleColor BackColour = ConsoleColor.Blue;

    public static void Write(string text = "")
    {
        string[] texts = Regex.Split(text, "(&r)");

        foreach (string str in texts)
        {
            if (str == "&r") // &r resets colour too (its a full reset of every style)
            {
                Console.Write(RESET);
                continue;
            }

            Console.BackgroundColor = BackColour;

            Console.Write(str
                .Replace("&u", UNDERLINE)
                .Replace("&b", BOLD)
                .Replace("&c", CURSIVE)
            );
        }
    }

    public static void WriteLine(string text = "")
        => Write($"{text}\r\n");
}