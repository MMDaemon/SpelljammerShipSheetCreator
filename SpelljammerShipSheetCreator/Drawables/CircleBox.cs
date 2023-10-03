using PdfSharpCore.Drawing;
using SpelljammerShipSheetCreator.PdfCreation;

namespace SpelljammerShipSheetCreator.Drawables
{
    internal class CircleBox : Drawable
    {
        private double _offset;
        public CircleBox(XRect boundingBox, double offset = 0) : base(boundingBox)
        {
            _offset = offset;
        }

        public override void Draw(XGraphics gfx)
        {
            gfx.DrawEllipse(_defaultPen, XBrushes.White, BoundingBox);

            base.Draw(gfx);
        }

        protected override XPoint GetTextPosition(XStringFormat format)
        {
            double x = -1;
            double y = -1;
            switch (format.LineAlignment)
            {
                case XLineAlignment.Near:
                    y = BoundingBox.Top;
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
                    break;
                case XLineAlignment.Center:
                    y = BoundingBox.Center.Y;
                    switch (format.Alignment)
                    {
                        case XStringAlignment.Near:
                            x = BoundingBox.Left;
                            break;
                        case XStringAlignment.Center:
                            x = BoundingBox.Center.X;
                            break;
                        case XStringAlignment.Far:
                            x = BoundingBox.Right;
                            break;
                    }
                    break;
                case XLineAlignment.Far:
                    y = BoundingBox.Bottom;
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
                    break;
            }

            return new XPoint(x, y);
        }
    }
}
