using NUnit.Framework;
using System;
using ShapeLibrary;

namespace ShapeLibrary.Tests
{
    public class ShapeTests
    {
        [Test]
        public void CircleArea_ShouldBeCorrect()
        {
            var circle = new Circle(5);

            double area = circle.GetArea();

            Assert.That(area, Is.EqualTo(Math.PI * 25).Within(1e-5));
        }

        [Test]
        public void TriangleArea_ShouldBeCorrect()
        {
            var triangle = new Triangle(3, 4, 5);

            double area = triangle.GetArea();

            Assert.That(area, Is.EqualTo(6).Within(1e-5));
        }

        [Test]
        public void RightTriangle_ShouldBeIdentifiedCorrectly()
        {
            var triangle = new Triangle(3, 4, 5);
            var triangle2 = new Triangle(5, 12, 13);


            bool isRight = triangle.IsRightTriangle();
            bool isRight2 = triangle2.IsRightTriangle();

            Assert.That(isRight == true);
            Assert.That(isRight2 == true);
        }

        [Test]
        public void NonRightTriangle_ShouldBeIdentifiedCorrectly()
        {
            var triangle = new Triangle(2, 2, 3);

            bool isRight = triangle.IsRightTriangle();

            Assert.That(isRight == false);
        }

        [Test]
        public void RightCalculateAreaFromShape()
        {
            var triangle = new Triangle(3, 4, 5);
            var circle = new Circle(5);

            Assert.That(Shape.CalculateArea(triangle), Is.EqualTo(6).Within(1e-5));
            Assert.That(Shape.CalculateArea(circle), Is.EqualTo(Math.PI * 25).Within(1e-5));

        }

        [Test]
        public void Circle_NegativeOrZeroRadius_ShouldThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Circle(-1));
            Assert.Throws<ArgumentException>(() => new Circle(0));
        }

        [Test]
        public void Triangle_InvalidSides_ShouldThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Triangle(-1, 4, 5));
            Assert.Throws<ArgumentException>(() => new Triangle(3, -4, 5));
            Assert.Throws<ArgumentException>(() => new Triangle(3, 4, -5));

            Assert.Throws<ArgumentException>(() => new Triangle(1, 2, 3)); // Сумма двух сторон равна третьей
            Assert.Throws<ArgumentException>(() => new Triangle(10, 2, 3)); // Сумма двух сторон меньше третьей
        }

        [Test]
        public void Triangle_Equilateral_ShouldNotBeRightTriangle()
        {
            var triangle = new Triangle(3, 3, 3);

            bool isRight = triangle.IsRightTriangle();

            Assert.That(isRight == false);
        }

        [Test]
        public void Triangle_AlmostRight_ShouldNotBeRightTriangle()
        {
            var triangle = new Triangle(3, 4, 5.1);

            bool isRight = triangle.IsRightTriangle();

            Assert.That(isRight == false);
        }

        [Test]
        public void Circle_MinimumPositiveRadius_ShouldWork()
        {
            var circle = new Circle(1e-10);

            double area = circle.GetArea();

            Assert.That(area, Is.GreaterThan(0));
        }

        [Test]
        public void Triangle_LargeSides_ShouldWorkCorrectly()
        {
            var triangle = new Triangle(1e9, 1e9, 1e9);

            double area = triangle.GetArea();

            Assert.That(area, Is.GreaterThan(0));
        }
    }
}
