using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;

namespace DrawIt.Models
{

	[Serializable]
	public class MyPen : INotifyPropertyChanged, ICloneable, IDisposable
	{
		public MyPen()
		{
			PBrush.SolidColor = Color.Black;
			PBrush.LInterpolate = true;
			PBrush.PropertyChanged += (sender, e) =>
			{
				PropertyChanged?.Invoke(this, e!);
			};
		}

		#region INotifyPropertyChanged
		public event PropertyChangedEventHandler? PropertyChanged;

		private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
		#endregion

		#region ICloneable
		/// <summary>
		///		Creates an exact copy of this <see cref="MyPen"/> object.
		/// </summary>
		public object Clone()
		{
			MyPen _new = new();
			foreach (PropertyDescriptor pd in TypeDescriptor.GetProperties(typeof(MyPen)))
				pd.SetValue(_new, pd.GetValue(this));
			_new.PBrush = (MyBrush)PBrush.Clone();
			return _new;
		}
		#endregion

		#region IDisposable
		public void Dispose()
		{
			_br?.Dispose();
		}
		#endregion

		#region Properties
		private MyBrush _br = new();
		public MyBrush PBrush
		{
			get
			{
				return _br;
			}
			set
			{
				if (!value.Equals(_br))
				{
					_br = value;
					NotifyPropertyChanged();
				}
			}
		}

		private float _wid = 1;
		public float PWidth
		{
			get
			{
				return _wid;
			}
			set
			{
				if (!value.Equals(_wid))
				{
					_wid = value;
					NotifyPropertyChanged();
				}
			}
		}

		private DashCap d_cap = DashCap.Flat;
		public DashCap PDashCap
		{
			get
			{
				return d_cap;
			}
			set
			{
				if (!value.Equals(d_cap))
				{
					d_cap = value;
					NotifyPropertyChanged();
				}
			}
		}

		private DashStyle d_style = DashStyle.Solid;
		public DashStyle PDashstyle
		{
			get
			{
				return d_style;
			}
			set
			{
				if (!value.Equals(d_style))
				{
					d_style = value;
					NotifyPropertyChanged();
				}
			}
		}

		private LineCap st_cap = LineCap.Flat;
		public LineCap PStartCap
		{
			get
			{
				return st_cap;
			}
			set
			{
				if (!value.Equals(st_cap))
				{
					st_cap = value;
					NotifyPropertyChanged();
				}
			}
		}

		private LineCap end_cap = LineCap.Flat;
		public LineCap PEndCap
		{
			get
			{
				return end_cap;
			}
			set
			{
				if (!value.Equals(end_cap))
				{
					end_cap = value;
					NotifyPropertyChanged();
				}
			}
		}

		private LineJoin l_join = LineJoin.Miter;
		public LineJoin PLineJoin
		{
			get
			{
				return l_join;
			}
			set
			{
				if (!value.Equals(l_join))
				{
					l_join = value;
					NotifyPropertyChanged();
				}
			}
		}

		private float scale_x = 1;
		public float ScaleX
		{
			get
			{
				return scale_x;
			}
			set
			{
				if (!value.Equals(scale_x))
				{
					scale_x = value;
					NotifyPropertyChanged();
				}
			}
		}

		private float scale_y = 1;
		public float ScaleY
		{
			get
			{
				return scale_y;
			}
			set
			{
				if (!value.Equals(scale_y))
				{
					scale_y = value;
					NotifyPropertyChanged();
				}
			}
		}
		#endregion
	}

}
