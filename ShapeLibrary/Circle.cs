namespace ShapeLibrary
{
    public class Circle : IShape
    {
        public double Radius { get; }

        public Circle(double radius)
        {
            if (radius <= 0)
                throw new ArgumentException("Radius must be > 0");
            Radius = radius;
        }

        public double GetArea()
        {
            return Math.PI * Radius * Radius;
        }
    }
}
