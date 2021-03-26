using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Rectangle.Impl;

namespace Rectangle.Tests
{
	public class RectangleTests
	{
		[Test]
		public void Points_Argument_Which_Passes_Null_Should_Throw_ArgumentNullException()
		{
			Assert.Throws<ArgumentNullException>(() => Service.FindRectangle(null));
		}
		
		[Test]
		public void Argument_With_Less_Than_2_Points_Should_Throw_ArgumentException()
		{
			var point = new Point() { X = 1, Y = 5 };

			var points = new List<Point>(new Point[] { point });

			Assert.Throws<ArgumentException>(() => Service.FindRectangle(points));
		}

        [Test]
        public void Points_With_The_Same_Coordinates_Should_Throw_ArgumentException()
        {
            var point1 = new Point() { X = -2, Y = 5 };
            var point2 = new Point() { X = -5, Y = 1 };
            var point3 = new Point() { X = 2, Y = 15 };
            var point4 = new Point() { X = 7, Y = 3 };
            var point5 = new Point() { X = -5, Y = 1 };

            var points = new List<Point>(new Point[] { point1, point2, point3, point4, point5 });

            Assert.Throws<ArgumentException>(() => Service.FindRectangle(points));
        }


        [Test]
        public void _4_Points_Should_Return_Rectangle()
        {
            var point1 = new Point() { X = -3, Y = 2 };
            var point2 = new Point() { X = 3, Y = 5 };
            var point3 = new Point() { X = -2, Y = -2 };
            var point4 = new Point() { X = 5, Y = -1 };

            var points = new List<Point>(new Point[] { point1, point2, point3, point4 });

            var rectangle = Service.FindRectangle(points);

            Assert.IsNotNull(rectangle);
        }

        [Test]
        public void _2_Points_Should_Return_Rectangle()
        {
            var point1 = new Point() { X = -3, Y = 2 };
            var point2 = new Point() { X = 3, Y = 5 };

            var points = new List<Point>(new Point[] { point1, point2});

            var rectangle = Service.FindRectangle(points);

            Assert.IsNotNull(rectangle);
        }

        [Test]
        public void _5_Points_Should_Return_Rectangle()
        {
            var point1 = new Point() { X = -2, Y = 5 };
            var point2 = new Point() { X = -5, Y = 1 };
            var point3 = new Point() { X = 2, Y = 15 };
            var point4 = new Point() { X = 7, Y = 3 };
            var point5 = new Point() { X = -5, Y = 3 };

            var points = new List<Point>(new Point[] { point1, point2, point3, point4, point5 });

            var rectangle = Service.FindRectangle(points);

            Assert.IsNotNull(rectangle);
        }

        [Test]
        public void _2_Close_Points_X_Axis_Should_Return_Rectangle()
        {
            var point1 = new Point() { X = -3, Y = 5 };
            var point2 = new Point() { X = -2, Y = 5 };

            var points = new List<Point>(new Point[] { point1, point2 });

            var rectangle = Service.FindRectangle(points);

            Assert.IsNotNull(rectangle);
        }

        [Test]
        public void _3_Close_Points_X_Axis_Should_Return_Rectangle()
        {
            var point1 = new Point() { X = -2, Y = 5 };
            var point2 = new Point() { X = -3, Y = 5 };
            var point3 = new Point() { X = -4, Y = 5 };

            var points = new List<Point>(new Point[] { point1, point2, point3 });

            var rectangle = Service.FindRectangle(points);

            Assert.IsNotNull(rectangle);
        }

        [Test]
        public void _2_Close_Points_Y_Axis_Should_Return_Rectangle()
        {
            var point1 = new Point() { X = -2, Y = 5 };
            var point2 = new Point() { X = -2, Y = 6 };

            var points = new List<Point>(new Point[] { point1, point2 });

            var rectangle = Service.FindRectangle(points);

            Assert.IsNotNull(rectangle);
        }

        [Test]
        public void _3_Close_Points_Y_Axis_Should_Return_Rectangle()
        {
            var point1 = new Point() { X = -2, Y = 5 };
            var point2 = new Point() { X = -2, Y = 6 };
            var point3 = new Point() { X = -2, Y = 7 };

            var points = new List<Point>(new Point[] { point1, point2, point3 });

            var rectangle = Service.FindRectangle(points);

            Assert.IsNotNull(rectangle);
        }

        [Test]
        public void _4_Points_In_Square_Shape_Should_Not_Return_Rectangle()
        {
            var point1 = new Point() { X = -2, Y = 2 };
            var point2 = new Point() { X = 2, Y = 2 };
            var point3 = new Point() { X = 2, Y = -2 };
            var point4 = new Point() { X = -2, Y = -2 };

            var points = new List<Point>(new Point[] { point1, point2, point3, point4 });

            var rectangle = Service.FindRectangle(points);

            Assert.Null(rectangle);
        }

        [Test]
        public void _3_Diagonal_Points_Should_Return_Rectangle()
        {
            var point1 = new Point() { X = 4, Y = 8 };
            var point2 = new Point() { X = 6, Y = 6 };
            var point3 = new Point() { X = 8, Y = 4 };

            var points = new List<Point>(new Point[] { point1, point2, point3 });

            var rectangle = Service.FindRectangle(points);

            Assert.IsNotNull(rectangle);
        }
    }
}