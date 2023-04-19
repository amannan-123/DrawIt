namespace DrawIt.Helpers
{

	public sealed class MathUtils
	{
		public static float ToPercentage(float p1, float p2, float pt)
		{
			return (pt - p1) * 100f / (p2 - p1);
		}

		public static float FromPercentage(float p1, float p2, float pt)
		{
			return pt * (p2 - p1) / 100f + p1;
		}

		public static PointF ToPercentage(PointF p1, PointF p2, PointF pt)
		{
			return new PointF((float)((pt.X - p1.X) * 100 / (double)(p2.X - p1.X)), (float)((pt.Y - p1.Y) * 100 / (double)(p2.Y - p1.Y)));
		}

		public static PointF FromPercentage(PointF p1, PointF p2, PointF pt)
		{
			return new PointF((float)(pt.X * (p2.X - p1.X) / (double)100 + p1.X), (float)(pt.Y * (p2.Y - p1.Y) / (double)100 + p1.Y));
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
			return new(ToPercentage(baseRect, childRect.Location), new SizeF(childRect.Width * 100f / baseRect.Width, childRect.Height * 100f / baseRect.Height));
		}

		public static RectangleF FromPercentage(RectangleF baseRect, RectangleF childRect)
		{
			return new(FromPercentage(baseRect, childRect.Location),
				   new SizeF(childRect.Width * baseRect.Width / 100f,
							 childRect.Height * baseRect.Height / 100f));
		}

	}
}
