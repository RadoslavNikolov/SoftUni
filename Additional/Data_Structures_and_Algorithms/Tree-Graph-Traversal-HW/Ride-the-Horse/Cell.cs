namespace Ride_the_Horse
{
    public class Cell
    {
        public Cell(int x, int y, int value = 1)
        {
            this.X = x;
            this.Y = y;
            this.Value = value;
        }

        public int X { get; set; }

        public int Y { get; set; }

        public int Value { get; set; }

    }
}