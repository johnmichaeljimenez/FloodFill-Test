using Raylib_cs;

public class Program
{
    static Color[,] Grid = new Color[8, 8];
    static int size = 32;

    public static void Main(string[] args)
    {
        Raylib.SetConfigFlags(ConfigFlags.FLAG_VSYNC_HINT);
        Raylib.InitWindow(1366, 768, "Flood Fill Test");

        while (!Raylib.WindowShouldClose())
        {
            var mx = Raylib.GetMouseX() / 32;
            var my = Raylib.GetMouseY() / 32;

            if ((mx >= 0 && mx < Grid.GetLength(0)) && my >= 0 && my < Grid.GetLength(1))
            {
                if (Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT))
                {
                    FloodFill(mx, my, new Color(Raylib.GetRandomValue(0, 255), Raylib.GetRandomValue(0, 255), Raylib.GetRandomValue(0, 255), 255), Grid[mx, my]);
                }

                if (Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_RIGHT))
                {
                    Grid[mx, my] = new Color(Raylib.GetRandomValue(0, 255), Raylib.GetRandomValue(0, 255), Raylib.GetRandomValue(0, 255), 255);
                }
            }


            Raylib.ClearBackground(Color.BLACK);

            Raylib.BeginDrawing();

            for (int y = 0; y < Grid.GetLength(1); y++)
            {
                for (int x = 0; x < Grid.GetLength(0); x++)
                {
                    Raylib.DrawRectangle(x * size, y * size, size, size, Grid[x, y]);
                    Raylib.DrawRectangleLines(x * size, y * size, size, size, Color.WHITE);
                }
            }


            Raylib.DrawFPS(2, 2);

            Raylib.EndDrawing();
        }

        Raylib.CloseWindow();
    }

    static void FloodFill(int x, int y, Color color, Color old)
    {
        if (x < 0 || x >= Grid.GetLength(0)) return;
        if (y < 0 || y >= Grid.GetLength(1)) return;

        var c = Grid[x, y];
        if (c.R != old.R || c.G != old.G || c.B != old.B)
            return;

        if (c.R == color.R && c.G == color.G && c.B == color.B)
            return;

        Grid[x, y] = color;

        FloodFill(x - 1, y, color, old);
        FloodFill(x + 1, y, color, old);
        FloodFill(x, y - 1, color, old);
        FloodFill(x, y + 1, color, old);
    }
}