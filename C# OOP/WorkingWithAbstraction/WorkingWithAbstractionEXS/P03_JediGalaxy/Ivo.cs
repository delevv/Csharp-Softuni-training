namespace P03_JediGalaxy
{
   public class Ivo
    {
        public int Row { get; set; }
        public int Col { get; set; }
        public long CollectedStars { get; set; }

        public void Move(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }

        public void AddStars(int stars)
        {
            this.CollectedStars += stars;
        }
    }
}
