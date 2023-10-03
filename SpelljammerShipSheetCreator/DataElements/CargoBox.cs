using PdfSharpCore.Drawing;
using SpelljammerShipSheetCreator.Drawables;

namespace SpelljammerShipSheetCreator.DataElements
{
    internal class CargoBox : OctBox
    {
        List<Drawable> _drawables = new List<Drawable>();

        public CargoBox(int maxCargo) : base(new XRect(0, 0, 170, 122.5), 5)
        {
            SetText(XStringFormats.TopLeft, "Cargo");

            List<(XPoint start, XPoint end)> lines = new List<(XPoint start, XPoint end)>();
            double lineHeight = 12.5;
            for (int i = 0; i< 15; i++)
            {
                    lines.Add((new XPoint(5, lineHeight), new XPoint(5+(_boundingBox.Width-15)/2, lineHeight)));
                    lines.Add((new XPoint(5+(_boundingBox.Width - 5) / 2, lineHeight), new XPoint(5+_boundingBox.Width - 10, lineHeight)));
                    lineHeight += 7.5;
            }
            var lineBox = new LineBox(new XRect(5, 5, _boundingBox.Width - 10, _boundingBox.Height - 10), lines);
            _drawables.Add(lineBox);

            var maxBox = new HexBox(new XRect(157.5, 0, 15, 10), 2.5);
            maxBox.SetText(XStringFormats.TopLeft, "Max");
            maxBox.SetText(XStringFormats.BottomCenter, $"{maxCargo.ToString()}t");
            _drawables.Add(maxBox);
        }

        public override void Draw(XGraphics gfx)
        {
            base.Draw(gfx);
            foreach (var drawable in _drawables)
            {
                drawable.Draw(gfx);
            }
        }
    }
}
