using PdfSharpCore.Drawing;

namespace SpelljammerShipSheetCreator.Drawables
{
    internal class Drawable
    {
        public XRect BoundingBox { get => _boundingBox; }
        protected XRect _boundingBox;
        protected Dictionary<XStringFormat, (string text, double fontSize)> _texts = new Dictionary<XStringFormat, (string text, double fontSize)>();
        protected XPen _defaultPen = new XPen(XColors.Black, .5);

        public Drawable(XRect boundingBox)
        {
            _boundingBox = boundingBox;
        }

        public virtual void Draw(XGraphics gfx) 
        {
            DrawTexts(gfx);
        }

        public void SetText(XStringFormat format, string text, double fontSize = 4)
        {
            if (_texts.ContainsKey(format))
            {
                _texts[format] = (text, fontSize);
            }
            else
            {
                _texts.Add(format, (text, fontSize));
            }
        }

        protected virtual XPoint GetTextPosition(XStringFormat format)
        {
            double x = -1;
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

        private void DrawTexts(XGraphics gfx)
        {
            foreach (var text in _texts)
            {
                XPoint position = GetTextPosition(text.Key);
                var parts = text.Value.text.Split('\n');
                if (text.Key.LineAlignment == XLineAlignment.Center)
                {
                    position.Y -= (parts.Length - 1) * text.Value.fontSize / 2;
                }
                if (text.Key.LineAlignment == XLineAlignment.Far)
                {
                    position.Y -= (parts.Length - 1) * text.Value.fontSize;
                }
                foreach (var part in parts)
                {
                    gfx.DrawString(part, new XFont("Verdana", text.Value.fontSize, XFontStyle.Regular), XBrushes.Black, position, text.Key);
                    position.Y += text.Value.fontSize;
                }
            }
        }
    }
}
