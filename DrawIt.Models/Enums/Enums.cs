namespace DrawIt.Models
{

	public enum BrushType
	{
		Solid,
		LinearGradient,
		PathGradient,
		Hatch,
		Texture
	}

	public enum GlowStyle
	{
		OnShape,
		OnBorder
	}

	public enum GlowClip
	{
		None,
		Inside,
		Outside
	}

	public enum CornerType
	{
		Normal,
		Inverted
	}

	public enum ShapeStyle
	{
		Rectangle,
		RoundedRectangle,
		Ellipse,
		Triangle,
		Lines,
		Polygon,
		Curves,
		ClosedCurve,
		Arc,
		Pie,
		Text
	}

	[Flags]
	public enum MyFontStyle
	{
		Regular = 0,
		Bold = 1,
		Italic = 2,
		Underline = 4,
		Strikeout = 8
	}

	public enum MyTextAlignment
	{
		TopLeft,
		TopCenter,
		TopRight,
		MiddleLeft,
		MiddleCenter,
		MiddleRight,
		BottomLeft,
		BottomCenter,
		BottomRight
	}

}
