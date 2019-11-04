namespace P03_JediGalaxy
{
    public class Evil
    {
        public int Row { get; set; }
        public int Col { get; set; }

        public void Move(int row,int col)
        {
            this.Row = row;
            this.Col = col;
        }
    }
}
