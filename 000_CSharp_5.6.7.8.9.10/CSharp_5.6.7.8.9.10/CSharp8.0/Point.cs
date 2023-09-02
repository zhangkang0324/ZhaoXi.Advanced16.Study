namespace CSharp_5._6._7._8._9._10.CSharp8._0
{
    public struct Point
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Point(int x, int y) => (X, Y) = (x, y);

        public void Deconstruct(out double x, out double y) => (x, y) = (X, Y);

        public double Distance => Math.Sqrt(X * X + Y * Y);

        public readonly override string ToString() =>
            $"({X}, {Y}) is {Distance} from the origin.";
    }
}
