using PdfSharpCore.Drawing;
using SpelljammerShipSheetCreator.Drawables;

namespace SpelljammerShipSheetCreator.DataElements
{
    internal class WeaponFooterBox : Drawable
    {
        public WeaponFooterBox() : base(new XRect(0, 0, 75, 5))
        {
        }

        public override void Draw(XGraphics gfx)
        {
            XPoint[] points = { _boundingBox.TopLeft,
                                new XPoint(_boundingBox.Left + 5, _boundingBox.Top + 5),
                                new XPoint(_boundingBox.Right - 5, _boundingBox.Top + 5),
                                _boundingBox.TopRight };
            gfx.DrawLines(_defaultPen, points);
            base.Draw(gfx);
        }
    }
}
