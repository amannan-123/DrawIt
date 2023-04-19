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

}
