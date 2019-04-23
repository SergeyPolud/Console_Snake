using System;

namespace SnakeCSharpConsole
{
    class FoodGenerator
    {
        
        public  int x { get; set; }
        public  int y { get; set; }
       
        public FoodGenerator()
        {
            Random InitRnd = new Random();
            x = InitRnd.Next(2, Map.MapWidth - 1);
            y = InitRnd.Next(2, Map.MapHeight - 1);
        }
        public void RandomGenerate()
        {
            Random rnd = new Random();
            x = rnd.Next(2, Map.MapWidth - 1);
            y = rnd.Next(2, Map.MapHeight - 1);
        }
    }
}
