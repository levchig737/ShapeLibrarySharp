namespace ShapeLibrary
{
    public static class Shape
    {
        public static double CalculateArea(IShape shape)
        {
            return shape.GetArea();
        }
    }
}
