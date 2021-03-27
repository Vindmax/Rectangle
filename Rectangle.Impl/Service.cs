using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;

namespace Rectangle.Impl
{
	public static class Service
	{
		/// <summary>
		/// See TODO.txt file for task details.
		/// Do not change contracts: input and output arguments, method name and access modifiers
		/// </summary>
		/// <param name="points"></param>
		/// <returns></returns>
		public static Rectangle FindRectangle(List<Point> points)
		{
			if (points is null)
				throw new ArgumentNullException("\"Points\" argument is null");

			if (points.Count < 2)
				throw new ArgumentException("\"Points\" should have at least 2 points");

			if (ArePointsDistinct(points))
				throw new ArgumentException("\"Points\" should have different coordinates");


			var xCoords = points.OrderBy(p => p.X).ToList();
			var yCoords = points.OrderBy(p => p.Y).ToList();

			var minX = xCoords.First().X;
			var minY = yCoords.First().Y;
			var maxX = xCoords.Last().X;
			var maxY = yCoords.Last().Y;

			var rectWithoutTopPoint = new Rectangle()
			{
				X = minX,
				Y = maxY - 1,
				Height = (maxY - 1) - minY,
				Width = maxX - minX
			};

			var rectWithoutRightPoint = new Rectangle()
			{
				X = minX,
				Y = maxY,
				Height = maxY - minY,
				Width = (maxX - 1) - minX
			};

			var rectWithoutBottomPoint = new Rectangle()
			{
				X = minX,
				Y = maxY,
				Height = maxY - minY - 1,
				Width = maxX - minX
			};

			var rectWithoutLeftPoint = new Rectangle()
			{
				X = minX + 1,
				Y = maxY,
				Height = maxY - minY,
				Width = maxX - minX - 1
			};

			var rectList = new List<Rectangle>() { rectWithoutTopPoint, rectWithoutRightPoint, rectWithoutBottomPoint, rectWithoutLeftPoint };

            foreach (var rect in rectList)
            {
				if (rect.Height == 0)
					rect.Height = rect.Width + 1;
				if (rect.Width == 0)
					rect.Width = rect.Height + 1;

				if (IsRectangle(rect))
				{
					if (GetNumberOfPointsOutsideRect(rect, points) == 1)
						return rect;
                }
            }

			return null;
		}

		private static int GetNumberOfPointsOutsideRect(Rectangle rect, List<Point> points)
        {
			int numberOfPoints = 0;
            foreach (var point in points)
            { 
				if (!(point.X >= rect.X && point.X <= (rect.Width + rect.X)
					&& point.Y <= rect.Y && point.Y >= (rect.Y - rect.Height)))
					numberOfPoints++;
            }
			return numberOfPoints;
        }

		private static bool IsRectangle(Rectangle rect) => rect.Width != rect.Height ? true : false;

		private static bool ArePointsDistinct(List<Point> points)
        {
            for (int i = 0; i < points.Count; i++)
            {
                for (int j = i + 1; j < points.Count; j++)
                {
					if(points[i].X == points[j].X && points[i].Y == points[j].Y)
						return true;
                }
            }
			return false;
        }
	}
}
