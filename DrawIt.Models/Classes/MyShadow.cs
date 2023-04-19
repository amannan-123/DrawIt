using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DrawIt.Models
{

	[Serializable]
	public class MyShadow : INotifyPropertyChanged, ICloneable
	{
		#region INotifyPropertyChanged
		public event PropertyChangedEventHandler? PropertyChanged;

		private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
		#endregion

		#region ICloneable
		/// <summary>
		/// 	Creates an exact copy of this <see cref="MyShadow"/> object.
		/// </summary>
		public object Clone()
		{
			MyShadow _new = new();
			foreach (PropertyDescriptor pd in TypeDescriptor.GetProperties(typeof(MyShadow)))
				pd.SetValue(_new, pd.GetValue(this));
			return _new;
		}
		#endregion

		#region Properties
		private bool _enabled = false;
		public bool Enabled
		{
			get
			{
				return _enabled;
			}
			set
			{
				if (!value.Equals(_enabled))
				{
					_enabled = value;
					NotifyPropertyChanged();
				}
			}
		}

		private Point _off = new(10, 10);
		public Point Offset
		{
			get
			{
				return _off;
			}
			set
			{
				if (!value.Equals(_off))
				{
					_off = value;
					NotifyPropertyChanged();
				}
			}
		}

		private bool _fill = true;
		public bool Fill
		{
			get
			{
				return _fill;
			}
			set
			{
				if (!value.Equals(_fill))
				{
					_fill = value;
					NotifyPropertyChanged();
				}
			}
		}

		private bool _clip = true;
		public bool RegionClipping
		{
			get
			{
				return _clip;
			}
			set
			{
				if (!value.Equals(_clip))
				{
					_clip = value;
					NotifyPropertyChanged();
				}
			}
		}

		private int _radius = 2;
		public int Radius
		{
			get
			{
				return _radius;
			}
			set
			{
				if (!value.Equals(_radius))
				{
					_radius = value;
					NotifyPropertyChanged();
				}
			}
		}

		private int _strength = 100;
		public int Strength
		{
			get
			{
				return _strength;
			}
			set
			{
				if (!value.Equals(_strength))
				{
					_strength = value;
					NotifyPropertyChanged();
				}
			}
		}

		private Color _clr = Color.Gray;
		public Color ShadowColor
		{
			get
			{
				return _clr;
			}
			set
			{
				if (!value.Equals(_clr))
				{
					_clr = value;
					NotifyPropertyChanged();
				}
			}
		}
		#endregion
	}

}
