using System;
using System.Collections.Generic;
using System.Linq;
using Rectangle.Impl;

namespace Rectangle.Console
{
	class Program
	{
		/// <summary>
		/// Use this method for local debugging only. The implementation should remain in Rectangle.Impl project.
		/// See TODO.txt file for task details.
		/// </summary>
		/// <param name="args"></param>
		static void Main(string[] args)
		{
			var point1 = new Point() { X = -2, Y = 5 };
            var point2 = new Point() { X = -5, Y = 1 };
            var point3 = new Point() { X = 2, Y = 15 };
            var point4 = new Point() { X = 7, Y = 3 };
            var point5 = new Point() { X = -5, Y = 1 };

            var points = new List<Point>(new Point[] { point1, point2, point3, point4, point5 });
            try
            {
				var rect = Service.FindRectangle(points);
				if (rect != null)
                {
                    System.Console.WriteLine($"X: {rect.X}");
                    System.Console.WriteLine($"Y: {rect.Y}");
                    System.Console.WriteLine($"Width: {rect.Width}");
                    System.Console.WriteLine($"Height: {rect.Height}");
                }
			}
            catch (ArgumentNullException ex)
            {
                System.Console.WriteLine($"Argument null exception: {ex.Message}");
            }
            catch (ArgumentException ex)
            {
                System.Console.WriteLine($"Argument exception: {ex.Message}");
            }

            System.Console.ReadKey();
		}
	}
}
