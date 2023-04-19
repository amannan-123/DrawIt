using System.ComponentModel;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;

namespace DrawIt.Models
{

	[Serializable]
	public class MyShape : INotifyPropertyChanged, ICloneable
	{
		public MyShape()
		{
			Corners.PropertyChanged += Corners_PropertyChanged;
		}

		private void Corners_PropertyChanged(object? sender, PropertyChangedEventArgs? e)
		{
			PropertyChanged?.Invoke(this, e!);
		}

		public event PropertyChangedEventHandler? PropertyChanged;

		private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		private ShapeStyle s_type = ShapeStyle.Rectangle;
		public ShapeStyle SType
		{
			get
			{
				return s_type;
			}
			set
			{
				if (!value.Equals(s_type))
				{
					s_type = value;
					NotifyPropertyChanged();
				}
			}
		}

		private MyCorners _crn = new();
		public MyCorners Corners
		{
			get
			{
				return _crn;
			}
			set
			{
				if (value is not null && !value.Equals(_crn))
				{
					_crn = value;
					NotifyPropertyChanged();
				}
			}
		}

		private PointF[] pol_pt = new PointF[] { new PointF(10, 10), new PointF(10, 90), new PointF(90, 90) };
		public PointF[] PolygonPoints
		{
			get
			{
				return pol_pt;
			}
			set
			{
				if (!value.SequenceEqual(pol_pt))
				{
					pol_pt = value;
					NotifyPropertyChanged();
				}
			}
		}

		private PointF[] cur_pt = new PointF[] { new PointF(10, 10), new PointF(10, 90), new PointF(90, 90) };
		public PointF[] CurvePoints
		{
			get
			{
				return cur_pt;
			}
			set
			{
				if (!value.SequenceEqual(cur_pt))
				{
					cur_pt = value;
					NotifyPropertyChanged();
				}
			}
		}

		private float cur_t = 0.5f;
		public float Tension
		{
			get
			{
				return cur_t;
			}
			set
			{
				if (!value.Equals(cur_t))
				{
					cur_t = value;
					NotifyPropertyChanged();
				}
			}
		}

		private float st_ang = 0;
		public float StartAngle
		{
			get
			{
				return st_ang;
			}
			set
			{
				if (!value.Equals(st_ang))
				{
					st_ang = value;
					NotifyPropertyChanged();
				}
			}
		}

		private float end_ang = 270;
		public float SweepAngle
		{
			get
			{
				return end_ang;
			}
			set
			{
				if (!value.Equals(end_ang))
				{
					end_ang = value;
					NotifyPropertyChanged();
				}
			}
		}

		private string f_name = "Segoe UI";
		public string FontName
		{
			get
			{
				return f_name;
			}
			set
			{
				if (!value.Equals(f_name))
				{
					f_name = value;
					NotifyPropertyChanged();
				}
			}
		}

		private float f_size = 30;
		public float FontSize
		{
			get
			{
				return f_size;
			}
			set
			{
				if (!value.Equals(f_size))
				{
					f_size = value;
					NotifyPropertyChanged();
				}
			}
		}

		private FontStyle f_style = FontStyle.Regular;
		public FontStyle FontStyle
		{
			get
			{
				return f_style;
			}
			set
			{
				if (!value.Equals(f_style))
				{
					f_style = value;
					NotifyPropertyChanged();
				}
			}
		}

		private string _txt = "Text";
		public string Text
		{
			get
			{
				return _txt;
			}
			set
			{
				if (!value.Equals(_txt))
				{
					_txt = value;
					NotifyPropertyChanged();
				}
			}
		}

		private ContentAlignment txt_al = ContentAlignment.MiddleCenter;
		public ContentAlignment TextAlignment
		{
			get
			{
				return txt_al;
			}
			set
			{
				if (!value.Equals(txt_al))
				{
					txt_al = value;
					NotifyPropertyChanged();
				}
			}
		}

		/// <summary>
		/// 	Creates an exact copy of this <see cref="MyShape"/> object.
		/// </summary>
		public object Clone()
		{
			MyShape _new = new();
			foreach (PropertyDescriptor pd in TypeDescriptor.GetProperties(typeof(MyShape)))
				pd.SetValue(_new, pd.GetValue(this));
			_new.Corners = (MyCorners)Corners.Clone();
			return _new;
		}
	}

}
