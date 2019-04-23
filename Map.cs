using System;

namespace SnakeCSharpConsole
{
    class Map

    {
        public static int MapWidth { get; set; }
        public static int MapHeight { get; set; }
        public Map(int w, int h)
        {
            MapWidth = w;
            MapHeight = h;
        }

        public static void RenderFrame()
        {
            Console.Clear();

            for (int i = 0; i < MapWidth; i++)
            {
                Console.Write("#");
            }
            Console.WriteLine();
            for (int i = 0; i < MapHeight; i++)
            {
                Console.Write("#");
                for (int k = 0; k < MapWidth - 2; k++)
                {

                    Console.Write(" ");

                }
                Console.Write("#\n");
            }
            for (int i = 0; i < MapWidth; i++)
            {
                Console.Write("#");
            }
            Program.ScoreUpdate(Program.scoreCounter);
        }
        public static void ClearFrame()
        {
            for(int i = 1; i< MapHeight; i++)
            {
                for(int k = 1; k< MapWidth-2; k++)
                {
                    Console.SetCursorPosition(k, i);
                    Console.Write("\0");
                }
            }
        }
        public static void Draw(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write("*");
        }
    }
}
