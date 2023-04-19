using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DrawIt.Models
{
	[Serializable]
	public class MyCorners : INotifyPropertyChanged, ICloneable
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
		/// 	Creates an exact copy of this <see cref="MyCorners"/> object.
		/// </summary>
		public object Clone()
		{
			MyCorners _new = new();
			foreach (PropertyDescriptor pd in TypeDescriptor.GetProperties(typeof(MyCorners)))
				pd.SetValue(_new, pd.GetValue(this));
			return _new;
		}
		#endregion

		#region CornerType
		private CornerType tl_tp = CornerType.Normal;
		public CornerType TLType
		{
			get
			{
				return tl_tp;
			}
			set
			{
				if (!value.Equals(tl_tp))
				{
					tl_tp = value;
					NotifyPropertyChanged();
				}
			}
		}

		private CornerType tr_tp = CornerType.Normal;
		public CornerType TRType
		{
			get
			{
				return tr_tp;
			}
			set
			{
				if (!value.Equals(tr_tp))
				{
					tr_tp = value;
					NotifyPropertyChanged();
				}
			}
		}

		private CornerType bl_tp = CornerType.Normal;
		public CornerType BLType
		{
			get
			{
				return bl_tp;
			}
			set
			{
				if (!value.Equals(bl_tp))
				{
					bl_tp = value;
					NotifyPropertyChanged();
				}
			}
		}

		private CornerType br_tp = CornerType.Normal;
		public CornerType BRType
		{
			get
			{
				return br_tp;
			}
			set
			{
				if (!value.Equals(br_tp))
				{
					br_tp = value;
					NotifyPropertyChanged();
				}
			}
		}
		#endregion

		#region CornerRadius
		private float _t1 = 25;
		public float T1
		{
			get
			{
				return _t1;
			}
			set
			{
				if (_t1 != value)
				{
					_t1 = value;
					NotifyPropertyChanged();
				}
			}
		}

		private float _t2 = 25;
		public float T2
		{
			get
			{
				return _t2;
			}
			set
			{
				if (_t2 != value)
				{
					_t2 = value;
					NotifyPropertyChanged();
				}
			}
		}

		private float _r1 = 25;
		public float R1
		{
			get
			{
				return _r1;
			}
			set
			{
				if (_r1 != value)
				{
					_r1 = value;
					NotifyPropertyChanged();
				}
			}
		}

		private float _r2 = 25;
		public float R2
		{
			get
			{
				return _r2;
			}
			set
			{
				if (_r2 != value)
				{
					_r2 = value;
					NotifyPropertyChanged();
				}
			}
		}

		private float _b1 = 25;
		public float B1
		{
			get
			{
				return _b1;
			}
			set
			{
				if (_b1 != value)
				{
					_b1 = value;
					NotifyPropertyChanged();
				}
			}
		}

		private float _b2 = 25;
		public float B2
		{
			get
			{
				return _b2;
			}
			set
			{
				if (_b2 != value)
				{
					_b2 = value;
					NotifyPropertyChanged();
				}
			}
		}

		private float _l1 = 25;
		public float L1
		{
			get
			{
				return _l1;
			}
			set
			{
				if (_l1 != value)
				{
					_l1 = value;
					NotifyPropertyChanged();
				}
			}
		}

		private float _l2 = 25;
		public float L2
		{
			get
			{
				return _l2;
			}
			set
			{
				if (_l2 != value)
				{
					_l2 = value;
					NotifyPropertyChanged();
				}
			}
		}
		#endregion

		#region ArrayHelpers
		public static MyCorners? FromArray(float[] arr)
		{
			if (arr.Length < 8)
				return null;
			MyCorners crr = new()
			{
				T1 = arr[0],
				T2 = 100 - arr[1],
				R1 = arr[2],
				R2 = 100 - arr[3],
				B1 = arr[4],
				B2 = 100 - arr[5],
				L1 = arr[6],
				L2 = 100 - arr[7]
			};
			return crr;
		}

		public float[] ToArray()
		{
			return new float[] { T1, 100 - T2, R1, 100 - R2, B1, 100 - B2, L1, 100 - L2 };
		}
		#endregion
	}

}
