using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DrawIt.Models
{

	[Serializable]
	public class MyGlow : INotifyPropertyChanged, ICloneable
	{
		public event PropertyChangedEventHandler? PropertyChanged;

		private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

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

		private GlowStyle _style = GlowStyle.OnShape;
		public GlowStyle GStyle
		{
			get
			{
				return _style;
			}
			set
			{
				if (!value.Equals(_style))
				{
					_style = value;
					NotifyPropertyChanged();
				}
			}
		}

		private GlowClip _clip = GlowClip.None;
		public GlowClip GClip
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

		private bool _before = true;
		public bool BeforeFill
		{
			get
			{
				return _before;
			}
			set
			{
				if (!value.Equals(_before))
				{
					_before = value;
					NotifyPropertyChanged();
				}
			}
		}

		private int _rad = 35;
		public int Radius
		{
			get
			{
				return _rad;
			}
			set
			{
				if (!value.Equals(_rad))
				{
					_rad = value;
					NotifyPropertyChanged();
				}
			}
		}

		private int _strength = 35;
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

		private Color _clr = Color.Red;
		public Color GlowColor
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

		/// <summary>
		///		Creates an exact copy of this <see cref="MyGlow"/> object.
		/// </summary>
		public object Clone()
		{
			MyGlow _new = new();
			foreach (PropertyDescriptor pd in TypeDescriptor.GetProperties(typeof(MyGlow)))
				pd.SetValue(_new, pd.GetValue(this));
			return _new;
		}
	}

}
