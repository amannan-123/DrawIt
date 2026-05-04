using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace DrawIt.Models
{
    [Serializable]
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "$type")]
    [JsonDerivedType(typeof(MySolidBrush), "solid")]
    [JsonDerivedType(typeof(MyLinearGradientBrush), "linearGradient")]
    [JsonDerivedType(typeof(MyPathGradientBrush), "pathGradient")]
    [JsonDerivedType(typeof(MyHatchBrush), "hatch")]
    [JsonDerivedType(typeof(MyTextureBrush), "texture")]
    public abstract class MyBrush : INotifyPropertyChanged, ICloneable
    {
        [JsonIgnore]
        private Dictionary<BrushType, MyBrush>? _stateCache;

        protected MyBrush(BrushType type)
        {
            BType = type;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public BrushType BType { get; protected set; }

        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        internal Dictionary<BrushType, MyBrush> GetOrCreateStateCache()
        {
            return _stateCache ??= new Dictionary<BrushType, MyBrush>();
        }

        internal void SetStateCache(Dictionary<BrushType, MyBrush> cache)
        {
            _stateCache = cache;
        }

        public abstract object Clone();
    }

    [Serializable]
    public sealed class MySolidBrush : MyBrush
    {
        private Color _color = Color.White;

        public MySolidBrush() : base(BrushType.Solid) { }

        public Color Color
        {
            get => _color;
            set
            {
                if (value.Equals(_color)) return;
                _color = value;
                NotifyPropertyChanged();
            }
        }

        public override object Clone() => new MySolidBrush { Color = Color };
    }

    [Serializable]
    public sealed class MyLinearGradientBrush : MyBrush
    {
        private Color _color1 = Color.White;
        private Color _color2 = Color.Black;
        private int _angle;
        private bool _gamma;
        private bool _triangular;
        private float _triFocus = 0.5f;
        private float _triScale = 1f;
        private bool _bell;
        private float _bellFocus = 0.5f;
        private float _bellScale = 1f;
        private bool _interpolate;
        private Color[] _interColors = new[] { Color.White, Color.Black };
        private float[] _interPositions = new[] { 0f, 1f };
        private bool _blend;
        private float[] _blendFactors = new[] { 0f, 1f };
        private float[] _blendPositions = new[] { 0f, 1f };

        public MyLinearGradientBrush() : base(BrushType.LinearGradient) { }

        public Color Color1
        {
            get => _color1;
            set { if (!value.Equals(_color1)) { _color1 = value; NotifyPropertyChanged(); } }
        }

        public Color Color2
        {
            get => _color2;
            set { if (!value.Equals(_color2)) { _color2 = value; NotifyPropertyChanged(); } }
        }

        public int Angle
        {
            get => _angle;
            set { if (!value.Equals(_angle)) { _angle = value; NotifyPropertyChanged(); } }
        }

        public bool Gamma
        {
            get => _gamma;
            set { if (!value.Equals(_gamma)) { _gamma = value; NotifyPropertyChanged(); } }
        }

        public bool Triangular
        {
            get => _triangular;
            set
            {
                if (value.Equals(_triangular)) return;
                if (value) Bell = false;
                _triangular = value;
                NotifyPropertyChanged();
            }
        }

        public float TriFocus
        {
            get => _triFocus;
            set { if (!value.Equals(_triFocus)) { _triFocus = value; NotifyPropertyChanged(); } }
        }

        public float TriScale
        {
            get => _triScale;
            set { if (!value.Equals(_triScale)) { _triScale = value; NotifyPropertyChanged(); } }
        }

        public bool Bell
        {
            get => _bell;
            set
            {
                if (value.Equals(_bell)) return;
                if (value) Triangular = false;
                _bell = value;
                NotifyPropertyChanged();
            }
        }

        public float BellFocus
        {
            get => _bellFocus;
            set { if (!value.Equals(_bellFocus)) { _bellFocus = value; NotifyPropertyChanged(); } }
        }

        public float BellScale
        {
            get => _bellScale;
            set { if (!value.Equals(_bellScale)) { _bellScale = value; NotifyPropertyChanged(); } }
        }

        public bool Interpolate
        {
            get => _interpolate;
            set
            {
                if (value.Equals(_interpolate)) return;
                if (value) Blend = false;
                _interpolate = value;
                NotifyPropertyChanged();
            }
        }

        public Color[] InterColors
        {
            get => _interColors;
            set { if (!value.SequenceEqual(_interColors)) { _interColors = value; NotifyPropertyChanged(); } }
        }

        public float[] InterPositions
        {
            get => _interPositions;
            set { if (!value.SequenceEqual(_interPositions)) { _interPositions = value; NotifyPropertyChanged(); } }
        }

        public bool Blend
        {
            get => _blend;
            set
            {
                if (value.Equals(_blend)) return;
                if (value) Interpolate = false;
                _blend = value;
                NotifyPropertyChanged();
            }
        }

        public float[] BlendFactors
        {
            get => _blendFactors;
            set { if (!value.SequenceEqual(_blendFactors)) { _blendFactors = value; NotifyPropertyChanged(); } }
        }

        public float[] BlendPositions
        {
            get => _blendPositions;
            set { if (!value.SequenceEqual(_blendPositions)) { _blendPositions = value; NotifyPropertyChanged(); } }
        }

        public override object Clone()
        {
            return new MyLinearGradientBrush
            {
                Color1 = Color1,
                Color2 = Color2,
                Angle = Angle,
                Gamma = Gamma,
                Triangular = Triangular,
                TriFocus = TriFocus,
                TriScale = TriScale,
                Bell = Bell,
                BellFocus = BellFocus,
                BellScale = BellScale,
                Interpolate = Interpolate,
                InterColors = (Color[])InterColors.Clone(),
                InterPositions = (float[])InterPositions.Clone(),
                Blend = Blend,
                BlendFactors = (float[])BlendFactors.Clone(),
                BlendPositions = (float[])BlendPositions.Clone()
            };
        }
    }

    [Serializable]
    public sealed class MyPathGradientBrush : MyBrush
    {
        private Color _center = Color.White;
        private Color[] _surround = new[] { Color.Black };
        private PointF _centerPoint = new(50, 50);
        private float _focusX;
        private float _focusY;
        private bool _triangular;
        private float _triFocus = 0.5f;
        private float _triScale = 1f;
        private bool _bell;
        private float _bellFocus = 0.5f;
        private float _bellScale = 1f;
        private bool _interpolate;
        private Color[] _interColors = new[] { Color.Black, Color.White };
        private float[] _interPositions = new[] { 0f, 1f };
        private bool _blend;
        private float[] _blendFactors = new[] { 0f, 1f };
        private float[] _blendPositions = new[] { 0f, 1f };

        public MyPathGradientBrush() : base(BrushType.PathGradient) { }

        public Color Center
        {
            get => _center;
            set { if (!value.Equals(_center)) { _center = value; NotifyPropertyChanged(); } }
        }

        public Color[] Surround
        {
            get => _surround;
            set { if (!value.SequenceEqual(_surround)) { _surround = value; NotifyPropertyChanged(); } }
        }

        public PointF CenterPoint
        {
            get => _centerPoint;
            set { if (!value.Equals(_centerPoint)) { _centerPoint = value; NotifyPropertyChanged(); } }
        }

        public float FocusX
        {
            get => _focusX;
            set { if (!value.Equals(_focusX)) { _focusX = value; NotifyPropertyChanged(); } }
        }

        public float FocusY
        {
            get => _focusY;
            set { if (!value.Equals(_focusY)) { _focusY = value; NotifyPropertyChanged(); } }
        }

        public bool Triangular
        {
            get => _triangular;
            set
            {
                if (value.Equals(_triangular)) return;
                if (value) Bell = false;
                _triangular = value;
                NotifyPropertyChanged();
            }
        }

        public float TriFocus
        {
            get => _triFocus;
            set { if (!value.Equals(_triFocus)) { _triFocus = value; NotifyPropertyChanged(); } }
        }

        public float TriScale
        {
            get => _triScale;
            set { if (!value.Equals(_triScale)) { _triScale = value; NotifyPropertyChanged(); } }
        }

        public bool Bell
        {
            get => _bell;
            set
            {
                if (value.Equals(_bell)) return;
                if (value) Triangular = false;
                _bell = value;
                NotifyPropertyChanged();
            }
        }

        public float BellFocus
        {
            get => _bellFocus;
            set { if (!value.Equals(_bellFocus)) { _bellFocus = value; NotifyPropertyChanged(); } }
        }

        public float BellScale
        {
            get => _bellScale;
            set { if (!value.Equals(_bellScale)) { _bellScale = value; NotifyPropertyChanged(); } }
        }

        public bool Interpolate
        {
            get => _interpolate;
            set
            {
                if (value.Equals(_interpolate)) return;
                if (value) Blend = false;
                _interpolate = value;
                NotifyPropertyChanged();
            }
        }

        public Color[] InterColors
        {
            get => _interColors;
            set { if (!value.SequenceEqual(_interColors)) { _interColors = value; NotifyPropertyChanged(); } }
        }

        public float[] InterPositions
        {
            get => _interPositions;
            set { if (!value.SequenceEqual(_interPositions)) { _interPositions = value; NotifyPropertyChanged(); } }
        }

        public bool Blend
        {
            get => _blend;
            set
            {
                if (value.Equals(_blend)) return;
                if (value) Interpolate = false;
                _blend = value;
                NotifyPropertyChanged();
            }
        }

        public float[] BlendFactors
        {
            get => _blendFactors;
            set { if (!value.SequenceEqual(_blendFactors)) { _blendFactors = value; NotifyPropertyChanged(); } }
        }

        public float[] BlendPositions
        {
            get => _blendPositions;
            set { if (!value.SequenceEqual(_blendPositions)) { _blendPositions = value; NotifyPropertyChanged(); } }
        }

        public override object Clone()
        {
            return new MyPathGradientBrush
            {
                Center = Center,
                Surround = (Color[])Surround.Clone(),
                CenterPoint = CenterPoint,
                FocusX = FocusX,
                FocusY = FocusY,
                Triangular = Triangular,
                TriFocus = TriFocus,
                TriScale = TriScale,
                Bell = Bell,
                BellFocus = BellFocus,
                BellScale = BellScale,
                Interpolate = Interpolate,
                InterColors = (Color[])InterColors.Clone(),
                InterPositions = (float[])InterPositions.Clone(),
                Blend = Blend,
                BlendFactors = (float[])BlendFactors.Clone(),
                BlendPositions = (float[])BlendPositions.Clone()
            };
        }
    }

    [Serializable]
    public sealed class MyHatchBrush : MyBrush
    {
        private Color _back = Color.White;
        private Color _fore = Color.Black;
        private string _style = "Horizontal";

        public MyHatchBrush() : base(BrushType.Hatch) { }

        public Color Back
        {
            get => _back;
            set { if (!value.Equals(_back)) { _back = value; NotifyPropertyChanged(); } }
        }

        public Color Fore
        {
            get => _fore;
            set { if (!value.Equals(_fore)) { _fore = value; NotifyPropertyChanged(); } }
        }

        public string Style
        {
            get => _style;
            set
            {
                if (string.Equals(value, _style, StringComparison.Ordinal)) return;
                _style = value;
                NotifyPropertyChanged();
            }
        }

        public override object Clone() => new MyHatchBrush { Back = Back, Fore = Fore, Style = Style };
    }

    [Serializable]
    public sealed class MyTextureBrush : MyBrush
    {
        private byte[]? _imageBytes;
        private bool _transparency;
        private Color _transparentColor = Color.White;
        private string _rotateFlip = "RotateNoneFlipNone";

        public MyTextureBrush() : base(BrushType.Texture) { }

        public byte[]? ImageBytes
        {
            get => _imageBytes;
            set { _imageBytes = value; NotifyPropertyChanged(); }
        }

        public bool Transparency
        {
            get => _transparency;
            set { if (!value.Equals(_transparency)) { _transparency = value; NotifyPropertyChanged(); } }
        }

        public Color TransparentColor
        {
            get => _transparentColor;
            set { if (!value.Equals(_transparentColor)) { _transparentColor = value; NotifyPropertyChanged(); } }
        }

        public string RotateFlip
        {
            get => _rotateFlip;
            set
            {
                if (string.Equals(value, _rotateFlip, StringComparison.Ordinal)) return;
                _rotateFlip = value;
                NotifyPropertyChanged();
            }
        }

        public override object Clone()
        {
            return new MyTextureBrush
            {
                ImageBytes = ImageBytes is null ? null : (byte[])ImageBytes.Clone(),
                Transparency = Transparency,
                TransparentColor = TransparentColor,
                RotateFlip = RotateFlip
            };
        }
    }

    public static class MyBrushFactory
    {
        public static MyBrush Create(BrushType type)
        {
            return type switch
            {
                BrushType.Solid => new MySolidBrush(),
                BrushType.LinearGradient => new MyLinearGradientBrush(),
                BrushType.PathGradient => new MyPathGradientBrush(),
                BrushType.Hatch => new MyHatchBrush(),
                BrushType.Texture => new MyTextureBrush(),
                _ => new MySolidBrush()
            };
        }

        public static MyBrush ChangeType(MyBrush? current, BrushType targetType)
        {
            if (current is not null && current.BType == targetType)
            {
                return current;
            }

            Dictionary<BrushType, MyBrush>? cache = null;

            if (current is not null)
            {
                cache = current.GetOrCreateStateCache();
                cache[current.BType] = (MyBrush)current.Clone();

                if (cache.TryGetValue(targetType, out MyBrush? cachedBrush))
                {
                    MyBrush restoredBrush = (MyBrush)cachedBrush.Clone();
                    restoredBrush.SetStateCache(cache);
                    return restoredBrush;
                }
            }

            MyBrush createdBrush = Create(targetType);
            if (cache is not null)
            {
                createdBrush.SetStateCache(cache);
            }

            return createdBrush;
        }
    }
}
