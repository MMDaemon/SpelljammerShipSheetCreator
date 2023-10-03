using PdfSharpCore.Drawing;
using SpelljammerShipSheetCreator.PdfCreation;

namespace SpelljammerShipSheetCreator.Drawables
{
    internal class ShieldBox : Drawable
    {
        private double _offset;
        public ShieldBox(XRect boundingBox, double offset): base(boundingBox)
        {
            _offset = offset;
        }

        public override void Draw(XGraphics gfx)
        {
            gfx.DrawShieldBox(_defaultPen, XBrushes.White, BoundingBox, _offset);

            base.Draw(gfx);
        }

        protected override XPoint GetTextPosition(XStringFormat format)
        {
            double x = -1;
            switch (format.Alignment)
            {
                case XStringAlignment.Near:
                    x = BoundingBox.Left + _offset;
                    break;
                case XStringAlignment.Center:
                    x = BoundingBox.Center.X;
                    break;
                case XStringAlignment.Far:
                    x = BoundingBox.Right - _offset;
                    break;
            }

            double y = -1;
            switch (format.LineAlignment)
            {
                case XLineAlignment.Near:
                    y = BoundingBox.Top;
                    break;
                case XLineAlignment.Center:
                    y = BoundingBox.Center.Y;
                    break;
                case XLineAlignment.Far:
                    y = BoundingBox.Bottom;
                    break;
            }

            return new XPoint(x, y);
        }
    }
}
