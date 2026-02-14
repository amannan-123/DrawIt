using System.Drawing;
using System.Drawing.Drawing2D;

namespace DrawIt.Helpers
{
    public static class ZoomPanMath
    {
        public static float ClampZoom(float zoom, float min = 0.2f, float max = 10.0f)
        {
            return Math.Max(min, Math.Min(max, zoom));
        }

        public static PointF GetViewportCenterOffset(Size viewportSize, SizeF artboardSize, float zoom)
        {
            var tx = (viewportSize.Width - (artboardSize.Width * zoom)) / 2.0f;
            var ty = (viewportSize.Height - (artboardSize.Height * zoom)) / 2.0f;
            return new PointF(tx, ty);
        }

        public static PointF ToWorldPoint(PointF screenPoint, PointF panOffset, PointF centerOffset, float zoom)
        {
            return new PointF(
                (screenPoint.X + panOffset.X - centerOffset.X) / zoom,
                (screenPoint.Y + panOffset.Y - centerOffset.Y) / zoom);
        }

        public static RectangleF ToScreenRect(RectangleF worldRect, PointF panOffset, PointF centerOffset, float zoom)
        {
            return new RectangleF(
                worldRect.X * zoom + centerOffset.X - panOffset.X,
                worldRect.Y * zoom + centerOffset.Y - panOffset.Y,
                worldRect.Width * zoom,
                worldRect.Height * zoom);
        }

        public static Matrix CreateWorldToScreenMatrix(PointF panOffset, PointF centerOffset, float zoom)
        {
            return new Matrix(zoom, 0, 0, zoom, centerOffset.X - panOffset.X, centerOffset.Y - panOffset.Y);
        }

        public static float AnnotationScaleCompensation(float zoom)
        {
            return 1.0f / Math.Max(zoom, 0.0001f);
        }

        public static PointF ComputePanForZoomAnchor(
            Point anchorClient,
            PointF panOffset,
            PointF centerBefore,
            double oldZoom,
            PointF centerAfter,
            double newZoom)
        {
            var worldAnchorX = (anchorClient.X + panOffset.X - centerBefore.X) / oldZoom;
            var worldAnchorY = (anchorClient.Y + panOffset.Y - centerBefore.Y) / oldZoom;

            var newPanX = worldAnchorX * newZoom + centerAfter.X - anchorClient.X;
            var newPanY = worldAnchorY * newZoom + centerAfter.Y - anchorClient.Y;

            return new PointF((float)newPanX, (float)newPanY);
        }

        public static void GetSymmetricPanLimits(
            RectangleF worldBounds,
            float zoom,
            PointF centerOffset,
            Size viewportSize,
            float margin,
            out float minX,
            out float maxX,
            out float minY,
            out float maxY)
        {
            var rawMinX = worldBounds.Left * zoom + centerOffset.X - margin;
            var rawMinY = worldBounds.Top * zoom + centerOffset.Y - margin;
            var rawMaxX = worldBounds.Right * zoom + centerOffset.X + margin - viewportSize.Width;
            var rawMaxY = worldBounds.Bottom * zoom + centerOffset.Y + margin - viewportSize.Height;

            var absX = Math.Max(Math.Abs(rawMinX), Math.Abs(rawMaxX));
            var absY = Math.Max(Math.Abs(rawMinY), Math.Abs(rawMaxY));

            minX = -absX;
            maxX = absX;
            minY = -absY;
            maxY = absY;
        }
    }
}
