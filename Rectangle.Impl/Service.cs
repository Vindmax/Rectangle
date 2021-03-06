using Rectangle.Impl.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

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

			if (ArePointsSimilar(points))
				throw new ArgumentException("\"Points\" should have different coordinates");

			var minX = points.Min(p => p.X);
			var minY = points.Min(p => p.Y);
			var maxX = points.Max(p => p.X);
			var maxY = points.Max(p => p.Y);

			var rectWithoutTopPoint = CreateRectangle(minX, maxY - 1, maxX - minX, (maxY - 1) - minY);

			var rectWithoutRightPoint = CreateRectangle(minX, maxY, (maxX - 1) - minX, maxY - minY);

			var rectWithoutBottomPoint = CreateRectangle(minX, maxY, maxX - minX, maxY - minY - 1);

			var rectWithoutLeftPoint = CreateRectangle(minX + 1, maxY, maxX - minX - 1, maxY - minY);

			var rectList = new List<Rectangle>() { rectWithoutTopPoint, rectWithoutRightPoint, rectWithoutBottomPoint, rectWithoutLeftPoint };

            foreach (var rect in rectList)
            {
				if (rect.Height == 0)
					rect.Height = rect.Width + 1;
				if (rect.Width == 0)
					rect.Width = rect.Height + 1;

				if (IsRectangle(rect))
					if (GetNumberOfPointsOutsideRect(rect, points) == 1)
						return rect;
            }

			return null;
		}

		private static Rectangle CreateRectangle(int x, int y, int width, int height)
        {
			return new Rectangle
			{
				X = x,
				Y = y,
				Width = width,
				Height = height
			};
        }

		private static int GetNumberOfPointsOutsideRect(Rectangle rect, List<Point> points) => 
			points.Where(p => !(p.X >= rect.X && p.X <= (rect.Width + rect.X) && 
								p.Y <= rect.Y && p.Y >= (rect.Y - rect.Height))).Count();

		private static bool IsRectangle(Rectangle rect) => rect.Width != rect.Height ? true : false;

		private static bool ArePointsSimilar(List<Point> points) =>
			points.Distinct(new PointsComparer()).Count() != points.Count ? true : false;

    }
}
