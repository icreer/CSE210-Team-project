namespace Unit04.Game.Casting
{
    public class Score 
    {
        private int score = 0;
        public int getScore()
        {
            return score;
        }

        public void setscore(bool hitgem)
        {
            if (hitgem)
            {
                score += 10;
            }
            else
            {
                score -= 10;
            }
            
        }
    
        
    }
}