using System;
using System.Collections.Generic;
using System.Linq;

class MenuManager
{
    public static List<MenuBase> menus = new List<MenuBase>();
    public static int page = 0;

    public static void Init()
    {
        ConsoleEvents.SetupEvents();
        ConsoleEvents.Resize += OnResize;
        ConsoleEvents.Keypress += OnKeypress;

        menus.Add(new TestMenuOne());
        menus.Add(new TestMenuOne() { Name = "TEST" });
    }

    static void OnKeypress(char key)
    {

    }

    static void OnResize()
    {
        RefreshTaskbar();
    }

    public static void DrawLine(string text)
    {
        int Width = Console.BufferWidth,
            Height = Console.BufferHeight;

        int count = text.Count(c => c == '&');

        CConsole.WriteLine(
            ASCII.LINES.HLINE + " " +
            text +
            new string(' ', Width - 3 - (text.Length - (count * 2))) +
            ASCII.LINES.HLINE
        );
    }

    public static void RefreshTaskbar()
    {
        Console.BackgroundColor = CConsole.BackColour;
        Console.Clear();

        int Width = Console.BufferWidth,
            Height = Console.BufferHeight;

        // TopLine
        {
            CConsole.WriteLine(
                ASCII.LINES.LCORNER +
                new string(ASCII.LINES.WLINE, Width - 2) +
                ASCII.LINES.RCORNER
            );
        }

        // Tabs
        {
            string tabs = string.Empty;

            for (int i = 0; i < menus.Count; ++i)
            {
                MenuBase menu = menus[i];

                tabs += i == page ? $"&c&u[{menu.Name}]&r " : $"[{menu.Name}]&r ";
            }

            DrawLine(tabs);
        }

        // CenterLine
        {
            CConsole.WriteLine(
                ASCII.LINES.MLLINE +
                new string(ASCII.LINES.WLINE, Width - 2) +
                ASCII.LINES.MRLINE
            );
        }

        // actual menu info
        {
            DrawLine("Version: fbc13708-c316");
            DrawLine("");
            DrawLine("&cDisclaimer: Using this application does not guarantee immunity from bans. Use at your own discretion.&r");
        }

        // BottomLine
        {
            CConsole.WriteLine(
                ASCII.LINES.BLCORNER +
                new string(ASCII.LINES.WLINE, Width - 2) +
                ASCII.LINES.BRCORNER
            );
        }
    }
}