using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace DrawIt.Models
{
	[Serializable]
	[JsonPolymorphic(TypeDiscriminatorPropertyName = "$type")]
	[JsonDerivedType(typeof(MyRectangle), "rectangle")]
	[JsonDerivedType(typeof(MyRoundedRectangle), "roundedRectangle")]
	[JsonDerivedType(typeof(MyEllipse), "ellipse")]
	[JsonDerivedType(typeof(MyTriangle), "triangle")]
	[JsonDerivedType(typeof(MyLines), "lines")]
	[JsonDerivedType(typeof(MyPolygon), "polygon")]
	[JsonDerivedType(typeof(MyCurves), "curves")]
	[JsonDerivedType(typeof(MyClosedCurve), "closedCurve")]
	[JsonDerivedType(typeof(MyArc), "arc")]
	[JsonDerivedType(typeof(MyPie), "pie")]
	[JsonDerivedType(typeof(MyText), "text")]
	public abstract class MyShape : INotifyPropertyChanged, ICloneable
	{
		[JsonIgnore]
		private Dictionary<ShapeStyle, MyShape>? _stateCache;

		protected MyShape(ShapeStyle style)
		{
			SType = style;
		}

		public event PropertyChangedEventHandler? PropertyChanged;

		public ShapeStyle SType { get; protected set; }

		protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		internal Dictionary<ShapeStyle, MyShape> GetOrCreateStateCache()
		{
			return _stateCache ??= new Dictionary<ShapeStyle, MyShape>();
		}

		internal void SetStateCache(Dictionary<ShapeStyle, MyShape> cache)
		{
			_stateCache = cache;
		}

		public abstract object Clone();
	}

	public static class MyShapeFactory
	{
		public static MyShape Create(ShapeStyle style)
		{
			return style switch
			{
				ShapeStyle.Rectangle => new MyRectangle(),
				ShapeStyle.RoundedRectangle => new MyRoundedRectangle(),
				ShapeStyle.Ellipse => new MyEllipse(),
				ShapeStyle.Triangle => new MyTriangle(),
				ShapeStyle.Lines => new MyLines(),
				ShapeStyle.Polygon => new MyPolygon(),
				ShapeStyle.Curves => new MyCurves(),
				ShapeStyle.ClosedCurve => new MyClosedCurve(),
				ShapeStyle.Arc => new MyArc(),
				ShapeStyle.Pie => new MyPie(),
				ShapeStyle.Text => new MyText(),
				_ => new MyRectangle()
			};
		}

		public static MyShape ChangeType(MyShape? current, ShapeStyle targetStyle)
		{
			if (current is not null && current.SType == targetStyle)
			{
				return current;
			}

			Dictionary<ShapeStyle, MyShape>? cache = null;

			if (current is not null)
			{
				cache = current.GetOrCreateStateCache();
				cache[current.SType] = (MyShape)current.Clone();

				if (cache.TryGetValue(targetStyle, out MyShape? cachedShape))
				{
					MyShape restoredShape = (MyShape)cachedShape.Clone();
					restoredShape.SetStateCache(cache);
					return restoredShape;
				}
			}

			MyShape createdShape = Create(targetStyle);
			if (cache is not null)
			{
				createdShape.SetStateCache(cache);
			}

			return createdShape;
		}
	}

	[Serializable]
	public sealed class MyRectangle : MyShape
	{
		public MyRectangle() : base(ShapeStyle.Rectangle) { }
		public override object Clone() => new MyRectangle();
	}

	[Serializable]
	public sealed class MyRoundedRectangle : MyShape
	{
		private MyCorners _corners = new();

		public MyRoundedRectangle() : base(ShapeStyle.RoundedRectangle)
		{
			AttachCornersEvents(_corners);
		}

		public MyCorners Corners
		{
			get => _corners;
			set
			{
				if (value is null || ReferenceEquals(_corners, value))
				{
					return;
				}

				DetachCornersEvents(_corners);
				_corners = value;
				AttachCornersEvents(_corners);
				NotifyPropertyChanged();
			}
		}

		public override object Clone() => new MyRoundedRectangle { Corners = (MyCorners)Corners.Clone() };

		private void AttachCornersEvents(MyCorners corners)
		{
			corners.PropertyChanged += Corners_PropertyChanged;
		}

		private void DetachCornersEvents(MyCorners corners)
		{
			corners.PropertyChanged -= Corners_PropertyChanged;
		}

		private void Corners_PropertyChanged(object? sender, PropertyChangedEventArgs e)
		{
			NotifyPropertyChanged(nameof(Corners));
		}
	}

	[Serializable]
	public sealed class MyEllipse : MyShape
	{
		public MyEllipse() : base(ShapeStyle.Ellipse) { }
		public override object Clone() => new MyEllipse();
	}

	[Serializable]
	public sealed class MyTriangle : MyShape
	{
		public MyTriangle() : base(ShapeStyle.Triangle) { }
		public override object Clone() => new MyTriangle();
	}

	[Serializable]
	public sealed class MyLines : MyShape
	{
		private PointF[] _polygonPoints = new[] { new PointF(10, 10), new PointF(10, 90), new PointF(90, 90) };

		public MyLines() : base(ShapeStyle.Lines) { }

		public PointF[] PolygonPoints
		{
			get => _polygonPoints;
			set
			{
				if (value.SequenceEqual(_polygonPoints))
				{
					return;
				}

				_polygonPoints = value;
				NotifyPropertyChanged();
			}
		}

		public override object Clone() => new MyLines { PolygonPoints = (PointF[])PolygonPoints.Clone() };
	}

	[Serializable]
	public sealed class MyPolygon : MyShape
	{
		private PointF[] _polygonPoints = new[] { new PointF(10, 10), new PointF(10, 90), new PointF(90, 90) };

		public MyPolygon() : base(ShapeStyle.Polygon) { }

		public PointF[] PolygonPoints
		{
			get => _polygonPoints;
			set
			{
				if (value.SequenceEqual(_polygonPoints))
				{
					return;
				}

				_polygonPoints = value;
				NotifyPropertyChanged();
			}
		}

		public override object Clone() => new MyPolygon { PolygonPoints = (PointF[])PolygonPoints.Clone() };
	}

	[Serializable]
	public sealed class MyCurves : MyShape
	{
		private PointF[] _curvePoints = new[] { new PointF(10, 10), new PointF(10, 90), new PointF(90, 90) };
		private float _tension = 0.5f;

		public MyCurves() : base(ShapeStyle.Curves) { }

		public PointF[] CurvePoints
		{
			get => _curvePoints;
			set
			{
				if (value.SequenceEqual(_curvePoints))
				{
					return;
				}

				_curvePoints = value;
				NotifyPropertyChanged();
			}
		}

		public float Tension
		{
			get => _tension;
			set
			{
				if (value.Equals(_tension))
				{
					return;
				}

				_tension = value;
				NotifyPropertyChanged();
			}
		}

		public override object Clone() => new MyCurves { CurvePoints = (PointF[])CurvePoints.Clone(), Tension = Tension };
	}

	[Serializable]
	public sealed class MyClosedCurve : MyShape
	{
		private PointF[] _curvePoints = new[] { new PointF(10, 10), new PointF(10, 90), new PointF(90, 90) };
		private float _tension = 0.5f;

		public MyClosedCurve() : base(ShapeStyle.ClosedCurve) { }

		public PointF[] CurvePoints
		{
			get => _curvePoints;
			set
			{
				if (value.SequenceEqual(_curvePoints))
				{
					return;
				}

				_curvePoints = value;
				NotifyPropertyChanged();
			}
		}

		public float Tension
		{
			get => _tension;
			set
			{
				if (value.Equals(_tension))
				{
					return;
				}

				_tension = value;
				NotifyPropertyChanged();
			}
		}

		public override object Clone() => new MyClosedCurve { CurvePoints = (PointF[])CurvePoints.Clone(), Tension = Tension };
	}

	[Serializable]
	public sealed class MyArc : MyShape
	{
		private float _startAngle = 0;
		private float _sweepAngle = 270;

		public MyArc() : base(ShapeStyle.Arc) { }

		public float StartAngle
		{
			get => _startAngle;
			set
			{
				if (value.Equals(_startAngle))
				{
					return;
				}

				_startAngle = value;
				NotifyPropertyChanged();
			}
		}

		public float SweepAngle
		{
			get => _sweepAngle;
			set
			{
				if (value.Equals(_sweepAngle))
				{
					return;
				}

				_sweepAngle = value;
				NotifyPropertyChanged();
			}
		}

		public override object Clone() => new MyArc { StartAngle = StartAngle, SweepAngle = SweepAngle };
	}

	[Serializable]
	public sealed class MyPie : MyShape
	{
		private float _startAngle = 0;
		private float _sweepAngle = 270;

		public MyPie() : base(ShapeStyle.Pie) { }

		public float StartAngle
		{
			get => _startAngle;
			set
			{
				if (value.Equals(_startAngle))
				{
					return;
				}

				_startAngle = value;
				NotifyPropertyChanged();
			}
		}

		public float SweepAngle
		{
			get => _sweepAngle;
			set
			{
				if (value.Equals(_sweepAngle))
				{
					return;
				}

				_sweepAngle = value;
				NotifyPropertyChanged();
			}
		}

		public override object Clone() => new MyPie { StartAngle = StartAngle, SweepAngle = SweepAngle };
	}

	[Serializable]
	public sealed class MyText : MyShape
	{
		private string _fontName = "Segoe UI";
		private float _fontSize = 30;
		private MyFontStyle _fontStyle = MyFontStyle.Regular;
		private string _text = "Text";
		private MyTextAlignment _textAlignment = MyTextAlignment.MiddleCenter;

		public MyText() : base(ShapeStyle.Text) { }

		public string FontName
		{
			get => _fontName;
			set
			{
				if (value.Equals(_fontName))
				{
					return;
				}

				_fontName = value;
				NotifyPropertyChanged();
			}
		}

		public float FontSize
		{
			get => _fontSize;
			set
			{
				if (value.Equals(_fontSize))
				{
					return;
				}

				_fontSize = value;
				NotifyPropertyChanged();
			}
		}

		public MyFontStyle FontStyle
		{
			get => _fontStyle;
			set
			{
				if (value.Equals(_fontStyle))
				{
					return;
				}

				_fontStyle = value;
				NotifyPropertyChanged();
			}
		}

		public string Text
		{
			get => _text;
			set
			{
				if (value.Equals(_text))
				{
					return;
				}

				_text = value;
				NotifyPropertyChanged();
			}
		}

		public MyTextAlignment TextAlignment
		{
			get => _textAlignment;
			set
			{
				if (value.Equals(_textAlignment))
				{
					return;
				}

				_textAlignment = value;
				NotifyPropertyChanged();
			}
		}

		public override object Clone()
		{
			return new MyText
			{
				FontName = FontName,
				FontSize = FontSize,
				FontStyle = FontStyle,
				Text = Text,
				TextAlignment = TextAlignment
			};
		}
	}
}
