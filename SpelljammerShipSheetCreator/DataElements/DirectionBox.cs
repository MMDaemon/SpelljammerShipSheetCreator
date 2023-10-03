using PdfSharpCore.Drawing;
using SpelljammerShipSheetCreator.Drawables;
using SpelljammerShipSheetCreator.DTO;

namespace SpelljammerShipSheetCreator.DataElements
{
    internal class DirectionBox : Drawable
    {
        HashSet<AttackAngle> _attackAngles;
        public DirectionBox(XRect boundingBox, Weapon weapon) : base(boundingBox)
        {
            _attackAngles = weapon.AttackAngles;
        }

        public override void Draw(XGraphics gfx)
        {
            XPoint[] points = { new XPoint(_boundingBox.Center.X, _boundingBox.Top-1.5),
                                new XPoint(_boundingBox.Center.X+2.5, _boundingBox.Top+2.5),
                                new XPoint(_boundingBox.Center.X-2.5, _boundingBox.Top+2.5) };
            gfx.DrawPolygon(_defaultPen, XBrushes.Black, points, XFillMode.Winding);

            foreach (AttackAngle direction in Enum.GetValues(typeof(AttackAngle)))
            {
                XBrush brush;
                switch (direction)
                {
                    case AttackAngle.RightBack:
                        brush = XBrushes.DarkSlateGray;
                        if (_attackAngles.Contains(AttackAngle.RightBack))
                        {
                            brush = XBrushes.LightGray;
                        }
                        gfx.DrawPie(_defaultPen, brush, _boundingBox, 0, 60);
                        break;
                    case AttackAngle.Back:
                        brush = XBrushes.DarkSlateGray;
                        if (_attackAngles.Contains(AttackAngle.Back))
                        {
                            brush = XBrushes.LightGray;
                        }
                        gfx.DrawPie(_defaultPen, brush, _boundingBox, 60, 60);
                        break;
                    case AttackAngle.LeftBack:
                        brush = XBrushes.DarkSlateGray;
                        if (_attackAngles.Contains(AttackAngle.LeftBack))
                        {
                            brush = XBrushes.LightGray;
                        }
                        gfx.DrawPie(_defaultPen, brush, _boundingBox, 120, 60);
                        break;
                    case AttackAngle.LeftFront:
                        brush = XBrushes.DarkSlateGray;
                        if (_attackAngles.Contains(AttackAngle.LeftFront))
                        {
                            brush = XBrushes.LightGray;
                        }
                        gfx.DrawPie(_defaultPen, brush, _boundingBox, 180, 60);
                        break;
                    case AttackAngle.Front:
                        brush = XBrushes.DarkSlateGray;
                        if (_attackAngles.Contains(AttackAngle.Front))
                        {
                            brush = XBrushes.LightGray;
                        }
                        gfx.DrawPie(_defaultPen, brush, _boundingBox, 240, 60);
                        break;
                    case AttackAngle.RightFront:
                        brush = XBrushes.DarkSlateGray;
                        if (_attackAngles.Contains(AttackAngle.RightFront))
                        {
                            brush = XBrushes.LightGray;
                        }
                        gfx.DrawPie(_defaultPen, brush, _boundingBox, 300, 60);
                        break;
                }
            }

            base.Draw(gfx);
        }
    }
}
