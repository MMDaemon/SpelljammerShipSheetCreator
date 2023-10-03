using PdfSharpCore.Drawing;

namespace SpelljammerShipSheetCreator.PdfCreation
{
    public static class GraphicsExtensions
    {
        public static void DrawOctBox(this XGraphics gfx, XPen pen, XBrush brush, XRect rect, double offset)
        {
            XPoint[] points = { rect.TopLeft + new XVector(0,offset), rect.TopLeft + new XVector(offset,0),
                        rect.TopRight - new XVector(offset,0), rect.TopRight + new XVector(0,offset),
                        rect.BottomRight - new XVector(0,offset), rect.BottomRight - new XVector(offset,0),
                        rect.BottomLeft + new XVector(offset,0), rect.BottomLeft - new XVector(0,offset) };
            gfx.DrawPolygon(pen, brush, points, XFillMode.Winding);
            return;
        }
        public static void DrawOctBox(this XGraphics gfx, XBrush brush, XRect rect, double offset)
        {
            gfx.DrawOctBox(XPens.Transparent, brush, rect, offset);
        }
        public static void DrawOctBox(this XGraphics gfx, XPen pen, XRect rect, double offset)
        {
            gfx.DrawOctBox(pen, XBrushes.Transparent, rect, offset);
        }

        public static void DrawHexBox(this XGraphics gfx, XPen pen, XBrush brush, XRect rect, double offset)
        {
            XPoint[] points = { new XPoint(rect.Left+offset, rect.Bottom), new XPoint(rect.Left, rect.Center.Y), new XPoint(rect.Left+offset, rect.Top),
                                new XPoint(rect.Right-offset, rect.Top), new XPoint(rect.Right, rect.Center.Y), new XPoint(rect.Right-offset, rect.Bottom) };
            gfx.DrawPolygon(pen, brush, points, XFillMode.Winding);
            return;
        }
        public static void DrawHexBox(this XGraphics gfx, XBrush brush, XRect rect, double offset)
        {
            gfx.DrawHexBox(XPens.Transparent, brush, rect, offset);
        }
        public static void DrawHexBox(this XGraphics gfx, XPen pen, XRect rect, double offset)
        {
            gfx.DrawHexBox(pen, XBrushes.Transparent, rect, offset);
        }

        public static void DrawShieldBox(this XGraphics gfx, XPen pen, XBrush brush, XRect rect, double offset)
        {
            XPoint[] points = { new XPoint(rect.Left ,rect.Top + offset),
                                new XPoint(rect.Center.X ,rect.Top),
                                new XPoint(rect.Right ,rect.Top + offset),
                                new XPoint(rect.Right , rect.Center.Y),
                                new XPoint((2*rect.Right+rect.Center.X)/3 , (rect.Bottom+rect.Center.Y)/2),
                                new XPoint(rect.Center.X , rect.Bottom),
                                new XPoint((2*rect.Left+rect.Center.X)/3 , (rect.Bottom+rect.Center.Y)/2),
                                new XPoint(rect.Left , rect.Center.Y)};
            gfx.DrawPolygon(pen, brush, points, XFillMode.Winding);
        }
        public static void DrawShieldBox(this XGraphics gfx, XBrush brush, XRect rect, double offset)
        {
            gfx.DrawShieldBox(XPens.Transparent, brush, rect, offset);
        }
        public static void DrawShieldBox(this XGraphics gfx, XPen pen, XRect rect, double offset)
        {
            gfx.DrawShieldBox(pen, XBrushes.Transparent, rect, offset);
        }
    }
}
