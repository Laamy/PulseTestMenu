using System;

class Program
{
    static void Main()
    {
        CConsole.Setup();

        MenuManager.Init();
        MenuManager.RefreshTaskbar();

        while (true)
        {
            char key = Console.ReadKey(true).KeyChar;
            ConsoleEvents.TriggerKeypress(key);
        }
    }
}