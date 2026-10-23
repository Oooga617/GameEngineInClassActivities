using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential)]
public struct Vector2D
{
    public float x, y;
}

public static class MyPlugin
{
    [DllImport("TestDLL2026")]
    private static extern int GetID();

    [DllImport("TestDLL2026")]
    private static extern void SetID(int id);

    [DllImport("TestDLL2026")]
    private static extern Vector2D GetPosition();

    [DllImport("TestDLL2026")]
    private static extern Vector2D GetPosition(float x, float y);

    public static int ID
    {
        get { return GetID(); }
        set { SetID(value); }
    }
}
