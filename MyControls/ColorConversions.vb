Imports System.Drawing

Public Class ColorConversions

#Region "Structs"
    Public Structure RGB
        Private _r As Byte
        Private _g As Byte
        Private _b As Byte

        Public Sub New(r As Byte, g As Byte, b As Byte)
            _r = r
            _g = g
            _b = b
        End Sub

        Public Property R() As Byte
            Get
                Return _r
            End Get
            Set(value As Byte)
                _r = value
            End Set
        End Property

        Public Property G() As Byte
            Get
                Return _g
            End Get
            Set(value As Byte)
                _g = value
            End Set
        End Property

        Public Property B() As Byte
            Get
                Return _b
            End Get
            Set(value As Byte)
                _b = value
            End Set
        End Property

        Public Overloads Function Equals(rgb As RGB) As Boolean
            Return (R = rgb.R) AndAlso (G = rgb.G) AndAlso (B = rgb.B)
        End Function
    End Structure

    Public Structure HSL
        Private _h As Single
        Private _s As Single
        Private _l As Single

        Public Sub New(h As Single, s As Single, l As Single)
            _h = h
            _s = s
            _l = l
        End Sub

        Public Property H() As Single
            Get
                Return _h
            End Get
            Set(value As Single)
                _h = value
            End Set
        End Property

        Public Property S() As Single
            Get
                Return _s
            End Get
            Set(value As Single)
                _s = value
            End Set
        End Property

        Public Property L() As Single
            Get
                Return _l
            End Get
            Set(value As Single)
                _l = value
            End Set
        End Property

        Public Overloads Function Equals(hsl As HSL) As Boolean
            Return (H = hsl.H) AndAlso (S = hsl.S) AndAlso (L = hsl.L)
        End Function
    End Structure

    Public Structure HSV
        Private _h As Single
        Private _s As Single
        Private _v As Single

        Public Sub New(h As Single, s As Single, v As Single)
            Me._h = h
            Me._s = s
            Me._v = v
        End Sub

        Public Property H() As Single
            Get
                Return Me._h
            End Get
            Set(value As Single)
                Me._h = value
            End Set
        End Property

        Public Property S() As Single
            Get
                Return Me._s
            End Get
            Set(value As Single)
                Me._s = value
            End Set
        End Property

        Public Property V() As Single
            Get
                Return Me._v
            End Get
            Set(value As Single)
                Me._v = value
            End Set
        End Property

        Public Overloads Function Equals(hsv As HSV) As Boolean
            Return (Me.H = hsv.H) AndAlso (Me.S = hsv.S) AndAlso (Me.V = hsv.V)
        End Function
    End Structure
#End Region

#Region "From RGB"
    Public Shared Function RGBToHSL(rgb As RGB) As HSL
        Dim R = rgb.R / 255
        Dim G = rgb.G / 255
        Dim B = rgb.B / 255

        Dim h, s, l As Double

        Dim max = Math.Max(R, Math.Max(G, B))
        Dim min = Math.Min(R, Math.Min(G, B))

        Dim diff = max - min
        l = (max + min) / 2

        If (Math.Abs(diff) < 0.00001) Then
            s = 0
            h = 0
        Else
            If (l <= 0.5) Then
                s = diff / (max + min)
            Else
                s = diff / (2 - max - min)
            End If

            Dim r_dist = (max - R) / diff
            Dim g_dist = (max - G) / diff
            Dim b_dist = (max - B) / diff

            If (R = max) Then
                h = b_dist - g_dist
            ElseIf (G = max) Then
                h = 2 + r_dist - b_dist
            Else
                h = 4 + g_dist - r_dist
            End If

            h = h * 60
            If (h < 0) Then h += 360
        End If

        Return New HSL(h, s, l)
    End Function

    Public Shared Function RGBToHSV(rgb As RGB) As HSV
        Dim R = rgb.R
        Dim G = rgb.G
        Dim B = rgb.B

        Dim red As Decimal = R / 255D
        Dim green As Decimal = G / 255D
        Dim blue As Decimal = B / 255D

        Dim minValue As Decimal = Math.Min(red, Math.Min(green, blue))
        Dim maxValue As Decimal = Math.Max(red, Math.Max(green, blue))
        Dim delta As Decimal = maxValue - minValue

        Dim h As Decimal
        Dim s As Decimal
        Dim v As Decimal = maxValue

        Select Case maxValue
            Case red
                If green >= blue Then
                    If delta = 0 Then
                        h = 0
                    Else
                        h = 60 * (green - blue) / delta
                    End If
                ElseIf green < blue Then
                    h = 60 * (green - blue) / delta + 360
                End If
            Case green
                h = 60 * (blue - red) / delta + 120
            Case blue
                h = 60 * (red - green) / delta + 240
        End Select

        If maxValue = 0 Then
            s = 0
        Else
            s = 1D - (minValue / maxValue)
        End If

        Return New HSV(h, s, v)
    End Function
#End Region

#Region "ToRGB"
    Public Shared Function HSLToRGB(hsl As HSL) As RGB
        Dim r As Byte = 0
        Dim g As Byte = 0
        Dim b As Byte = 0

        If hsl.S = 0 Then
            r = CByte(hsl.L * 255)
            g = CByte(hsl.L * 255)
            b = CByte(hsl.L * 255)
        Else
            Dim v1 As Single, v2 As Single
            Dim hue As Single = hsl.H / 360

            v2 = If((hsl.L < 0.5), (hsl.L * (1 + hsl.S)), ((hsl.L + hsl.S) - (hsl.L * hsl.S)))
            v1 = 2 * hsl.L - v2

            r = CByte(255 * HueToRGB(v1, v2, hue + (1.0F / 3)))
            g = CByte(255 * HueToRGB(v1, v2, hue))
            b = CByte(255 * HueToRGB(v1, v2, hue - (1.0F / 3)))
        End If

        Return New RGB(r, g, b)
    End Function

    Private Shared Function HueToRGB(v1 As Single, v2 As Single, vH As Single) As Single
        If vH < 0 Then vH += 1

        If vH > 1 Then vH -= 1

        If (6 * vH) < 1 Then Return (v1 + (v2 - v1) * 6 * vH)

        If (2 * vH) < 1 Then Return v2

        If (3 * vH) < 2 Then Return (v1 + (v2 - v1) * ((2.0F / 3) - vH) * 6)

        Return v1
    End Function

    Public Shared Function HSVtoRGB(hsv As HSV) As RGB
        Dim hue As Decimal = hsv.H
        Dim sat As Decimal = hsv.S
        Dim val As Decimal = hsv.V

        Dim r As Decimal
        Dim g As Decimal
        Dim b As Decimal

        If sat = 0 Then
            r = val
            g = val
            b = val
        Else
            Dim sectorPos As Decimal = hue / 60D
            Dim sectorNumber As Integer = Math.Floor(sectorPos)

            Dim fractionalSector As Decimal = sectorPos - sectorNumber

            Dim p As Decimal = val * (1 - sat)
            Dim q As Decimal = val * (1 - (sat * fractionalSector))
            Dim t As Decimal = val * (1 - (sat * (1 - fractionalSector)))

            Select Case sectorNumber
                Case 0, 6
                    r = val
                    g = t
                    b = p
                Case 1
                    r = q
                    g = val
                    b = p
                Case 2
                    r = p
                    g = val
                    b = t
                Case 3
                    r = p
                    g = q
                    b = val
                Case 4
                    r = t
                    g = p
                    b = val
                Case 5
                    r = val
                    g = p
                    b = q
            End Select
        End If

        r *= 255
        g *= 255
        b *= 255

        Return New RGB(Math.Round(r, MidpointRounding.AwayFromZero),
                       Math.Round(g, MidpointRounding.AwayFromZero),
                       Math.Round(b, MidpointRounding.AwayFromZero))
    End Function
#End Region

#Region "Color"
    Public Shared Function FromHSL(hue As Single, sat As Single, lum As Single) As Color
        Dim hsl As New HSL(hue, sat, lum)
        Dim rgb As RGB = HSLToRGB(hsl)
        Return Color.FromArgb(rgb.R, rgb.G, rgb.B)
    End Function

    Public Shared Function FromHSV(hue As Single, sat As Single, val As Single) As Color
        Dim hsv As New HSV(hue, sat, val)
        Dim rgb As RGB = HSVtoRGB(hsv)
        Return Color.FromArgb(rgb.R, rgb.G, rgb.B)
    End Function
#End Region

End Class
