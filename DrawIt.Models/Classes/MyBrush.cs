using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;

namespace DrawIt.Models
{

	[Serializable]
	public class MyBrush : INotifyPropertyChanged, ICloneable
	{
		public event PropertyChangedEventHandler? PropertyChanged;

		private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		private BrushType sty = BrushType.Solid;
		public BrushType BType
		{
			get
			{
				return sty;
			}
			set
			{
				if (!value.Equals(sty))
				{
					sty = value;
					NotifyPropertyChanged();
				}
			}
		}

		private Color _sld = Color.White;
		public Color SolidColor
		{
			get
			{
				return _sld;
			}
			set
			{
				if (!value.Equals(_sld))
				{
					_sld = value;
					NotifyPropertyChanged();
				}
			}
		}

		private Color _lg1 = Color.White;
		public Color LColor1
		{
			get
			{
				return _lg1;
			}
			set
			{
				if (!value.Equals(_lg1))
				{
					_lg1 = value;
					NotifyPropertyChanged();
				}
			}
		}

		private Color _lg2 = Color.Black;
		public Color LColor2
		{
			get
			{
				return _lg2;
			}
			set
			{
				if (!value.Equals(_lg2))
				{
					_lg2 = value;
					NotifyPropertyChanged();
				}
			}
		}

		private int l_angle = 0;
		public int LinearAngle
		{
			get
			{
				return l_angle;
			}
			set
			{
				if (!value.Equals(l_angle))
				{
					l_angle = value;
					NotifyPropertyChanged();
				}
			}
		}

		private bool _gamma = false;
		public bool LGamma
		{
			get
			{
				return _gamma;
			}
			set
			{
				if (!value.Equals(_gamma))
				{
					_gamma = value;
					NotifyPropertyChanged();
				}
			}
		}

		private bool _tri = false;
		public bool LTriangular
		{
			get
			{
				return _tri;
			}
			set
			{
				if (!value.Equals(_tri))
				{
					if (value)
						LBell = false;
					_tri = value;
					NotifyPropertyChanged();
				}
			}
		}

		private float tri_f = 0.5f;
		public float LTriFocus
		{
			get
			{
				return tri_f;
			}
			set
			{
				if (!value.Equals(tri_f))
				{
					tri_f = value;
					NotifyPropertyChanged();
				}
			}
		}

		private float tri_s = 1;
		public float LTriScale
		{
			get
			{
				return tri_s;
			}
			set
			{
				if (!value.Equals(tri_s))
				{
					tri_s = value;
					NotifyPropertyChanged();
				}
			}
		}

		private bool _bell = false;
		public bool LBell
		{
			get
			{
				return _bell;
			}
			set
			{
				if (!value.Equals(_bell))
				{
					if (value)
						LTriangular = false;
					_bell = value;
					NotifyPropertyChanged();
				}
			}
		}

		private float bell_f = 0.5f;
		public float LBellFocus
		{
			get
			{
				return bell_f;
			}
			set
			{
				if (!value.Equals(bell_f))
				{
					bell_f = value;
					NotifyPropertyChanged();
				}
			}
		}

		private float bell_s = 1;
		public float LBellScale
		{
			get
			{
				return bell_s;
			}
			set
			{
				if (!value.Equals(bell_s))
				{
					bell_s = value;
					NotifyPropertyChanged();
				}
			}
		}

		private bool l_inter = false;
		public bool LInterpolate
		{
			get
			{
				return l_inter;
			}
			set
			{
				if (!value.Equals(l_inter))
				{
					if (value)
						LBlend = false;
					l_inter = value;
					NotifyPropertyChanged();
				}
			}
		}

		private Color[] l_intcol = new Color[] { Color.White, Color.Black };
		public Color[] LInterColors
		{
			get
			{
				return l_intcol;
			}
			set
			{
				if (!value.SequenceEqual(l_intcol))
				{
					l_intcol = value;
					NotifyPropertyChanged();
				}
			}
		}

		private float[] l_intpol = new float[] { 0, 1 };
		public float[] LInterPositions
		{
			get
			{
				return l_intpol;
			}
			set
			{
				if (!value.SequenceEqual(l_intpol))
				{
					l_intpol = value;
					NotifyPropertyChanged();
				}
			}
		}

		private bool l_blend = false;
		public bool LBlend
		{
			get
			{
				return l_blend;
			}
			set
			{
				if (!value.Equals(l_blend))
				{
					if (value)
						LInterpolate = false;
					l_blend = value;
					NotifyPropertyChanged();
				}
			}
		}

		private float[] l_bldfac = new float[] { 0, 1 };
		public float[] LBlendFactors
		{
			get
			{
				return l_bldfac;
			}
			set
			{
				if (!value.SequenceEqual(l_bldfac))
				{
					l_bldfac = value;
					NotifyPropertyChanged();
				}
			}
		}

		private float[] l_bldpos = new float[] { 0, 1 };
		public float[] LBlendPositions
		{
			get
			{
				return l_bldpos;
			}
			set
			{
				if (!value.SequenceEqual(l_bldpos))
				{
					l_bldpos = value;
					NotifyPropertyChanged();
				}
			}
		}

		private Color _pg1 = Color.White;
		public Color PCenter
		{
			get
			{
				return _pg1;
			}
			set
			{
				if (!value.Equals(_pg1))
				{
					_pg1 = value;
					NotifyPropertyChanged();
				}
			}
		}

		private Color[] _pg2 = new Color[] { Color.Black };
		public Color[] PSurround
		{
			get
			{
				return _pg2;
			}
			set
			{
				if (!value.SequenceEqual(_pg2))
				{
					_pg2 = value;
					NotifyPropertyChanged();
				}
			}
		}

		private PointF p_cent = new(50, 50);
		public PointF PCenterPoint
		{
			get
			{
				return p_cent;
			}
			set
			{
				if (!value.Equals(p_cent))
				{
					p_cent = value;
					NotifyPropertyChanged();
				}
			}
		}

		private float pfoc_x = 0;
		public float PFocusX
		{
			get
			{
				return pfoc_x;
			}
			set
			{
				if (!value.Equals(pfoc_x))
				{
					pfoc_x = value;
					NotifyPropertyChanged();
				}
			}
		}

		private float pfoc_y = 0;
		public float PFocusY
		{
			get
			{
				return pfoc_y;
			}
			set
			{
				if (!value.Equals(pfoc_y))
				{
					pfoc_y = value;
					NotifyPropertyChanged();
				}
			}
		}

		private bool p_tri = false;
		public bool PTriangular
		{
			get
			{
				return p_tri;
			}
			set
			{
				if (!value.Equals(p_tri))
				{
					if (value)
						PBell = false;
					p_tri = value;
					NotifyPropertyChanged();
				}
			}
		}

		private float ptri_f = 0.5f;
		public float PTriFocus
		{
			get
			{
				return ptri_f;
			}
			set
			{
				if (!value.Equals(ptri_f))
				{
					ptri_f = value;
					NotifyPropertyChanged();
				}
			}
		}

		private float ptri_s = 1;
		public float PTriScale
		{
			get
			{
				return ptri_s;
			}
			set
			{
				if (!value.Equals(ptri_s))
				{
					ptri_s = value;
					NotifyPropertyChanged();
				}
			}
		}

		private bool p_bell = false;
		public bool PBell
		{
			get
			{
				return p_bell;
			}
			set
			{
				if (!value.Equals(p_bell))
				{
					if (value)
						PTriangular = false;
					p_bell = value;
					NotifyPropertyChanged();
				}
			}
		}

		private float pbell_f = 0.5f;
		public float PBellFocus
		{
			get
			{
				return pbell_f;
			}
			set
			{
				if (!value.Equals(pfoc_x))
				{
					pbell_f = value;
					NotifyPropertyChanged();
				}
			}
		}

		private float pbell_s = 1;
		public float PBellScale
		{
			get
			{
				return pbell_s;
			}
			set
			{
				if (!value.Equals(pfoc_x))
				{
					pbell_s = value;
					NotifyPropertyChanged();
				}
			}
		}

		private bool p_inter = false;
		public bool PInterpolate
		{
			get
			{
				return p_inter;
			}
			set
			{
				if (!value.Equals(p_inter))
				{
					if (value)
						PBlend = false;
					p_inter = value;
					NotifyPropertyChanged();
				}
			}
		}

		private Color[] p_intcol = new Color[] { Color.Black, Color.White };
		public Color[] PInterColors
		{
			get
			{
				return p_intcol;
			}
			set
			{
				if (!value.SequenceEqual(p_intcol))
				{
					p_intcol = value;
					NotifyPropertyChanged();
				}
			}
		}

		private float[] p_intpol = new float[] { 0, 1 };
		public float[] PInterPositions
		{
			get
			{
				return p_intpol;
			}
			set
			{
				if (!value.SequenceEqual(p_intpol))
				{
					p_intpol = value;
					NotifyPropertyChanged();
				}
			}
		}

		private bool p_blend = false;
		public bool PBlend
		{
			get
			{
				return p_blend;
			}
			set
			{
				if (!value.Equals(p_blend))
				{
					if (value)
						PInterpolate = false;
					p_blend = value;
					NotifyPropertyChanged();
				}
			}
		}

		private float[] p_bldfac = new float[] { 0, 1 };
		public float[] PBlendFactors
		{
			get
			{
				return p_bldfac;
			}
			set
			{
				if (!value.SequenceEqual(p_bldfac))
				{
					p_bldfac = value;
					NotifyPropertyChanged();
				}
			}
		}

		private float[] p_bldpos = new float[] { 0, 1 };
		public float[] PBlendPositions
		{
			get
			{
				return p_bldpos;
			}
			set
			{
				if (!value.SequenceEqual(p_bldpos))
				{
					p_bldpos = value;
					NotifyPropertyChanged();
				}
			}
		}

		private Color _hb1 = Color.White;
		public Color HBack
		{
			get
			{
				return _hb1;
			}
			set
			{
				if (!value.Equals(_hb1))
				{
					_hb1 = value;
					NotifyPropertyChanged();
				}
			}
		}

		private Color _hb2 = Color.Black;
		public Color HFore
		{
			get
			{
				return _hb2;
			}
			set
			{
				if (!value.Equals(_hb2))
				{
					_hb2 = value;
					NotifyPropertyChanged();
				}
			}
		}

		private HatchStyle _hst = HatchStyle.Horizontal;
		public HatchStyle HStyle
		{
			get
			{
				return _hst;
			}
			set
			{
				if (!value.Equals(_hst))
				{
					_hst = value;
					NotifyPropertyChanged();
				}
			}
		}

		private Image? t_img = null;
		public Image? TImage
		{
			get
			{
				return t_img;
			}
			set
			{
				t_img = value;
				NotifyPropertyChanged();
			}
		}

		private bool t_trn = false;
		public bool TTransparency
		{
			get
			{
				return t_trn;
			}
			set
			{
				if (!value.Equals(t_trn))
				{
					t_trn = value;
					NotifyPropertyChanged();
				}
			}
		}

		private Color t_col = Color.White;
		public Color TColor
		{
			get
			{
				return t_col;
			}
			set
			{
				if (!value.Equals(t_col))
				{
					t_col = value;
					NotifyPropertyChanged();
				}
			}
		}

		private RotateFlipType t_rot = RotateFlipType.RotateNoneFlipNone;
		public RotateFlipType TRotateFlip
		{
			get
			{
				return t_rot;
			}
			set
			{
				if (!value.Equals(t_rot))
				{
					t_rot = value;
					NotifyPropertyChanged();
				}
			}
		}

		/// <summary>
		/// 	''' Creates an exact copy of this <see cref="MyBrush"/> object.
		/// 	''' </summary>
		public object Clone()
		{
			MyBrush _new = new();
			foreach (PropertyDescriptor pd in TypeDescriptor.GetProperties(typeof(MyBrush)))
				pd.SetValue(_new, pd.GetValue(this));
			return _new;
		}
	}


}
