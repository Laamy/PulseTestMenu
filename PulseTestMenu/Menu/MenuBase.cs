abstract class MenuBase
{
    public string Name;

    public abstract void RefreshMenu();
    public abstract void OnConsoleKeypress(char k);
}