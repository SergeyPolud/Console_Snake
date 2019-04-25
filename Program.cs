using System;
using System.Collections.Generic;
using System.Threading;

namespace SnakeCSharpConsole
{
    class Program
    {
        internal static TimerCallback callback = new TimerCallback(Async);
        internal static List<MainObject> Stars = new List<MainObject>();
        internal static Directions dir;
        internal static Map map = new Map(100,25);
        internal static int scoreCounter =0;
        internal static FoodGenerator item = new FoodGenerator();
        internal static int interval = 10000;
        internal static bool IsOver = false;
        internal static int tmp = 0;
        internal static Timer timer1 = new Timer(Async, null, Timeout.Infinite, interval);
        internal enum Directions
        {
            DOWN,
            UP,
            LEFT,
            RIGHT
        }
        public static void ScoreUpdate(int score)
        {
            Console.SetCursorPosition(1, Map.MapHeight + 10);
            Console.Write("Current Score:  {0}", score);
        }
        public static void Init(List<MainObject> Stars)
        {
            Stars.Add(new MainObject(25, 25));
            Stars.Add(new MainObject(25, 23));
            Stars.Add(new MainObject(25, 21));
            Map.RenderFrame();
            Map.Draw(item.x, item.y);
            Map.Draw(Stars[0].x, Stars[0].y);
            Map.Draw(Stars[1].x, Stars[1].y);
            Map.Draw(Stars[2].x, Stars[2].y);
        }
        public static void Async(object obj)
        {
            Move(Stars, dir, map);
        }
      
        public static Directions GetCurrentDirection()
        {
            
            Directions direction;
            var key = Console.ReadKey().Key;
            switch (key)
            {
                case ConsoleKey.DownArrow:
                    direction = Directions.DOWN;
                    return direction;

                case ConsoleKey.UpArrow:
                    direction = Directions.UP;
                    return direction;

                case ConsoleKey.LeftArrow:
                    direction = Directions.LEFT;
                    return direction;

                case ConsoleKey.RightArrow:
                    direction = Directions.RIGHT;
                    return direction;
            }
            return GetCurrentDirection();
        }
        public static void Move(List<MainObject> Stars, Directions dir, Map map)
        {
            int x = Stars[0].x;
            int y = Stars[0].y;
            switch (dir)
            {
                case Directions.DOWN:
                    y++;
                    break;
                case Directions.UP:
                    y--;
                    break;
                case Directions.LEFT:
                    x--;
                    break;
                case Directions.RIGHT:
                    x++;
                    break;
            }
            MainObject head = new MainObject(x*2, y*2);
            if (head.x == item.x && head.y == item.y)
            {
                timer1.Change(Timeout.Infinite, Timeout.Infinite);
                Stars.Add(new MainObject(Stars[Stars.Count - 1].x - 2, Stars[Stars.Count - 1].y - 2));
                scoreCounter += 100;
                item.RandomGenerate();
                Stars.Insert(0, head);
                Stars.RemoveAt(Stars.Count - 1);
                Map.ClearFrame();
                Map.Draw(item.x, item.y);
                for (int i = 0; i < Stars.Count; i++)
                {
                    Map.Draw(Stars[i].x, Stars[i].y);
                }
                timer1.Change(0, interval);
            }
            else
            {
                timer1.Change(Timeout.Infinite, Timeout.Infinite);
                Stars.Insert(0, head);
                Stars.RemoveAt(Stars.Count - 1);
                Map.ClearFrame();
               
                Map.Draw(item.x, item.y);
                for (int i = 0; i < Stars.Count; i++)
                {
                    Map.Draw(Stars[i].x, Stars[i].y);
                }
                timer1.Change(0, interval);
            }
            
                   
        }
       
        static void Main(string[] args)
        {
            Console.Clear();
            
            Init(Stars);
            dir = GetCurrentDirection();
            timer1.Change(0, 1000);
          
            do
            {
                if(!IsOver)
                {
                    
                    dir = GetCurrentDirection();
                }
            } while (true);
        }
    }
}

