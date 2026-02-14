using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace DrawIt.Models
{

	[Serializable]
	public class MyPen : INotifyPropertyChanged, ICloneable
	{
		private readonly PropertyChangedEventHandler _brushChangedHandler;

		public MyPen()
		{
			_brushChangedHandler = (sender, e) => PropertyChanged?.Invoke(this, e);
			var solid = (MySolidBrush)PBrush;
			solid.Color = Color.Black;
			PBrush.PropertyChanged += _brushChangedHandler;
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

		
		#region Properties
		private MyBrush _br = new MySolidBrush();
		public MyBrush PBrush
		{
			get
			{
				return _br;
			}
			set
			{
				if (value is null || ReferenceEquals(value, _br)) return;
				_br.PropertyChanged -= _brushChangedHandler;
				_br = value;
				_br.PropertyChanged += _brushChangedHandler;
				NotifyPropertyChanged();
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

		private string d_cap = "Flat";
		public string PDashCap
		{
			get
			{
				return d_cap;
			}
			set
			{
				if (!string.Equals(value, d_cap, StringComparison.Ordinal))
				{
					d_cap = value;
					NotifyPropertyChanged();
				}
			}
		}

		private string d_style = "Solid";
		public string PDashstyle
		{
			get
			{
				return d_style;
			}
			set
			{
				if (!string.Equals(value, d_style, StringComparison.Ordinal))
				{
					d_style = value;
					NotifyPropertyChanged();
				}
			}
		}

		private string st_cap = "Flat";
		public string PStartCap
		{
			get
			{
				return st_cap;
			}
			set
			{
				if (!string.Equals(value, st_cap, StringComparison.Ordinal))
				{
					st_cap = value;
					NotifyPropertyChanged();
				}
			}
		}

		private string end_cap = "Flat";
		public string PEndCap
		{
			get
			{
				return end_cap;
			}
			set
			{
				if (!string.Equals(value, end_cap, StringComparison.Ordinal))
				{
					end_cap = value;
					NotifyPropertyChanged();
				}
			}
		}

		private string l_join = "Miter";
		public string PLineJoin
		{
			get
			{
				return l_join;
			}
			set
			{
				if (!string.Equals(value, l_join, StringComparison.Ordinal))
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
