namespace ShapeLibrary
{
    public class Triangle : IShape
    {
        public double SideA { get; }
        public double SideB { get; }
        public double SideC { get; }

        public Triangle(double sideA, double sideB, double sideC)
        {
            // Проверка на валидность треугольника
            if (sideA <= 0 || sideB <= 0 || sideC <= 0 ||
                (sideA + sideB <= sideC) || (sideA + sideC <= sideB) || (sideB + sideC <= sideA))
            {
                throw new ArgumentException("Invalid triangle sides.");
            }

            SideA = sideA;
            SideB = sideB;
            SideC = sideC;
        }

        // Метод для вычисления площади по формуле Герона (по 3 сторонам)
        public double GetArea()
        {
            double semiPerimeter = (SideA + SideB + SideC) / 2;
            return Math.Sqrt(semiPerimeter * (semiPerimeter - SideA) * (semiPerimeter - SideB) * (semiPerimeter - SideC));
        }

        // Проверка, является ли треугольник прямоугольным
        public bool IsRightTriangle()
        {
            double aSquared = SideA * SideA;
            double bSquared = SideB * SideB;
            double cSquared = SideC * SideC;

            // Проверяем теорему Пифагора для всех комбинаций сторон
            return Math.Abs(aSquared + bSquared - cSquared) < 1e-10 ||
                   Math.Abs(aSquared + cSquared - bSquared) < 1e-10 ||
                   Math.Abs(bSquared + cSquared - aSquared) < 1e-10;
        }
    }
}
