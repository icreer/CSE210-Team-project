
namespace Unit04.Game.Casting
{
    class Gems  
    {
        private Point position = new Point(0, 0);
        private Actor actor = new Actor();

        public void GemFall(int maxY) 
        {
            int x = position.GetX();
            int y = (position.GetY() + 3) % maxY;
            position = new Point(x,y);
        }
    }

}