using System.Diagnostics;

namespace DrawIt
{

	internal sealed class Helpers
	{
		public static float ToPercentage(float p1, float p2, float pt)
		{
			return (pt - p1) * 100f / (p2 - p1);
		}

		public static float FromPercentage(float p1, float p2, float pt)
		{
			return pt * (p2 - p1) / 100f + p1;
		}

		public static PointF ToPercentage(RectangleF rect, PointF pt)
		{
			return new((pt.X - rect.X) * 100f / (rect.Right - rect.X), (pt.Y - rect.Y) * 100f / (rect.Bottom - rect.Y));
		}

		public static PointF FromPercentage(RectangleF rect, PointF pt)
		{
			return new(pt.X * (rect.Right - rect.X) / 100f + rect.X, pt.Y * (rect.Bottom - rect.Y) / 100f + rect.Y);
		}

		public static RectangleF ToPercentage(RectangleF baseRect, RectangleF childRect)
		{
			return new(Helpers.ToPercentage(baseRect, childRect.Location), new SizeF(childRect.Width * 100f / baseRect.Width, childRect.Height * 100f / baseRect.Height));
		}

		public static RectangleF FromPercentage(RectangleF baseRect, RectangleF childRect)
		{
			return new(FromPercentage(baseRect, childRect.Location),
				   new SizeF(childRect.Width * baseRect.Width / 100f,
							 childRect.Height * baseRect.Height / 100f));
		}

	}
}
