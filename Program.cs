using Raylib_cs;

public class Program
{
    public static void Main(string[] args)
    {
        Raylib.SetConfigFlags(ConfigFlags.FLAG_VSYNC_HINT);
        Raylib.InitWindow(1366, 768, "Flood Fill Test");

        while (!Raylib.WindowShouldClose())
        {
            Raylib.ClearBackground(Color.BLACK);

            Raylib.BeginDrawing();

            Raylib.DrawFPS(2, 2);

            Raylib.EndDrawing();
        }

        Raylib.CloseWindow();
    }
}