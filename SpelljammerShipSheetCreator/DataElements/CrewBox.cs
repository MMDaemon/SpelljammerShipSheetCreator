using PdfSharpCore.Drawing;
using SpelljammerShipSheetCreator.Drawables;

namespace SpelljammerShipSheetCreator.DataElements
{
    internal class CrewBox : OctBox
    {
        List<Drawable> _drawables = new List<Drawable>();

        public CrewBox(int crewCount) : base(new XRect(0, 0, 170, 15 + (crewCount+1) / 2 * 7.5), 5)
        {
            SetText(XStringFormats.TopLeft, "Crew");

            List<(XPoint start, XPoint end)> lines = new List<(XPoint start, XPoint end)>();
            double lineHeight = 17.5;
            for (int i = 0; i< crewCount; i++)
            {
                if ((i % 2)==0)
                {
                    lines.Add((new XPoint(5, lineHeight), new XPoint(5+(_boundingBox.Width-15)/2, lineHeight)));
                }
                else
                {
                    lines.Add((new XPoint(5+(_boundingBox.Width - 5) / 2, lineHeight), new XPoint(5+_boundingBox.Width - 10, lineHeight)));
                    lineHeight += 7.5;
                }
            }
            var lineBox = new LineBox(new XRect(5, 5, _boundingBox.Width - 10, _boundingBox.Height - 10), lines);
            lineBox.SetText(XStringFormats.TopLeft, "Name               Role               HP");
            _drawables.Add(lineBox);

            var textBox = new Drawable(new XRect(5 + (_boundingBox.Width - 5) / 2, 5, 0, 0));
            textBox.SetText(XStringFormats.TopLeft, "Name               Role               HP");
            _drawables.Add(textBox);

            var maxBox = new HexBox(new XRect(157.5, 0, 15, 10), 2.5);
            maxBox.SetText(XStringFormats.TopLeft, "Max");
            maxBox.SetText(XStringFormats.BottomCenter, crewCount.ToString());
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
