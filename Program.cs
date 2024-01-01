using Raylib_cs;

public class Program
{
    static Color[,] Grid = new Color[8, 8];

    public static void Main(string[] args)
    {
        Raylib.SetConfigFlags(ConfigFlags.FLAG_VSYNC_HINT);
        Raylib.InitWindow(1366, 768, "Flood Fill Test");

        while (!Raylib.WindowShouldClose())
        {
            Raylib.ClearBackground(Color.BLACK);

            Raylib.BeginDrawing();

            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    int size = 32;

                    Raylib.DrawRectangle(x*size, y* size, size, size, Color.RED);
                    Raylib.DrawRectangleLines(x * size, y * size, size, size, Color.WHITE);
                }
            }


            Raylib.DrawFPS(2, 2);

            Raylib.EndDrawing();
        }

        Raylib.CloseWindow();
    }

    static void FloodFill(int x, int y)
    {

    }
}