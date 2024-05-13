using System;

class TestMenuOne : MenuBase
{
    public TestMenuOne()
    {
        Name = "TestMenuOne";
    }

    public override void RefreshMenu()
    {
        MenuManager.RefreshTaskbar();
        Console.WriteLine("");
    }

    public override void OnConsoleKeypress(char k)
    {

    }
}