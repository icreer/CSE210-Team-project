 using System;
 namespace Unit04.Game.Casting
 {
    class Gems
    {
         private static int FONT_SIZE = 30;
         private static int MAX_Y = 600;
        public void create_gems()
        {
            Random random = new Random();
            Actor gem = new Actor();
                gem.SetText("*");
                gem.SetFontSize(FONT_SIZE);
                int r = random.Next(0, 256);
                int g = random.Next(0, 256);
                int b = random.Next(0, 256);
                Color color = new Color(r, g, b);
                gem.SetColor(color);
                int x = random.Next(1, 5);
                int y = 0;
                int dx = 0;
                int dy = random.Next(1, 5);
                Point position = new Point(x, y);
                gem.SetPosition(new Point (random.Next(0,900),MAX_Y));
                Point velocity = new Point(dx,dy);
                gem.SetVelocity(velocity);
                
        }
        public void create_rocks()
        {
            Actor rock = new Actor();
            Random random = new Random();
                rock.SetText("o");
                rock.SetFontSize(FONT_SIZE);
                int rr = random.Next(0, 256);
                int gr = random.Next(0, 256);
                int br = random.Next(0, 256);
                Color color_rock = new Color(rr, gr, br);
                rock.SetColor(color_rock);
                int rx = random.Next(1, 5);
                int ry = 0;
                int rdx = 0;
                int rdy = random.Next(1, 5);
                Point rposition = new Point(rx, ry);
                rock.SetPosition(new Point(random.Next(0,900),MAX_Y));
                Point rvelocity = new Point(rdx,rdy);
                rock.SetVelocity(rvelocity);
        }
    }

}