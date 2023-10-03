using PdfSharpCore.Drawing;

namespace SpelljammerShipSheetCreator.Drawables
{
    internal class LineBox : Drawable
    {
        List<(XPoint start, XPoint end)> _lines = new List<(XPoint start, XPoint end)>();

        public LineBox(XRect boundingBox) : base(boundingBox)
        {
            _lines.Add((boundingBox.BottomLeft, boundingBox.BottomRight));
        }

        public LineBox(XRect boundingBox, XPoint start, XPoint end) : base(boundingBox)
        {
            _lines.Add((start, end));
        }

        public LineBox(XRect boundingBox, List<(XPoint start, XPoint end)> lines) : base(boundingBox)
        {
            _lines = lines;
        }

        public void AddLine(XPoint start, XPoint end)
        {
            _lines.Add((start, end));
        }

        public override void Draw(XGraphics gfx)
        {
            foreach (var line in _lines)
            {
                gfx.DrawLine(_defaultPen, line.start, line.end);
            }
            base.Draw(gfx);
        }
    }
}
