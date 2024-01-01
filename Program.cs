using Raylib_cs;

public class Program
{
    const int GRID_WIDTH = 32;
    const int GRID_HEIGHT = 32;
    const int Size = 32;
    const int RectSize = 512;
    const int BlockSize = RectSize / Size;

    static Color[,] Grid = new Color[GRID_WIDTH, GRID_HEIGHT];

    public static void Main(string[] args)
    {
        Raylib.SetConfigFlags(ConfigFlags.FLAG_VSYNC_HINT);
        Raylib.InitWindow(1366, 768, "Flood Fill Test");

        while (!Raylib.WindowShouldClose())
        {
            var mx = Raylib.GetMouseX() / BlockSize;
            var my = Raylib.GetMouseY() / BlockSize;

            if ((mx >= 0 && mx < Grid.GetLength(0)) && my >= 0 && my < Grid.GetLength(1))
            {
                if (Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT))
                {
                    FloodFill(mx, my, new Color(Raylib.GetRandomValue(0, 255), Raylib.GetRandomValue(0, 255), Raylib.GetRandomValue(0, 255), 255), Grid[mx, my], mx, my, 10);
                }

                if (Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_RIGHT))
                {
                    Grid[mx, my] = new Color(Raylib.GetRandomValue(0, 255), Raylib.GetRandomValue(0, 255), Raylib.GetRandomValue(0, 255), 255);
                }
            }


            Raylib.ClearBackground(Color.BLACK);

            Raylib.BeginDrawing();

            for (int y = 0; y < GRID_HEIGHT; y++)
            {
                for (int x = 0; x < GRID_WIDTH; x++)
                {
                    Raylib.DrawRectangle(x * BlockSize, y * BlockSize, BlockSize, BlockSize, Grid[x, y]);
                    Raylib.DrawRectangleLines(x * BlockSize, y * BlockSize, BlockSize, BlockSize, Color.BLACK);
                }
            }


            Raylib.DrawFPS(2, 2);
            Raylib.EndDrawing();
        }

        Raylib.CloseWindow();
    }

    static async void FloodFill(int x, int y, Color color, Color old, int originX, int originY, int maxDistance)
    {
        if (x < 0 || x >= GRID_WIDTH) return;
        if (y < 0 || y >= GRID_HEIGHT) return;

        var c = Grid[x, y];
        if (c.R != old.R || c.G != old.G || c.B != old.B)
            return;

        if (c.R == color.R && c.G == color.G && c.B == color.B)
            return;

        Grid[x, y] = color;
        await Task.Delay(1);

        FloodFill(x - 1, y, color, old, originX, originY, maxDistance);
        FloodFill(x + 1, y, color, old, originX, originY, maxDistance);
        FloodFill(x, y - 1, color, old, originX, originY, maxDistance);
        FloodFill(x, y + 1, color, old, originX, originY, maxDistance);
    }
}