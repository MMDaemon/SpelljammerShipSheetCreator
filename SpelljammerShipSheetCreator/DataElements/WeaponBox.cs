using PdfSharpCore.Drawing;
using SpelljammerShipSheetCreator.Drawables;
using SpelljammerShipSheetCreator.DTO;

namespace SpelljammerShipSheetCreator.DataElements
{
    internal class WeaponBox : Drawable
    {
        List<Drawable> _drawables = new List<Drawable>();

        public WeaponBox(Weapon weapon, WeaponProperties weaponProperties) : base(new XRect(0, 0, 75, 35))
        {
            var hpBox = new OctBox(new XRect(5, 5, 30, 30), 5);
            hpBox.SetText(XStringFormats.TopLeft, "HP");
            _drawables.Add(hpBox);

            var maxHpBox = new HexBox(new XRect(22.5, 5, 15, 10), 2.5);
            maxHpBox.SetText(XStringFormats.TopLeft, "Max");
            maxHpBox.SetText(XStringFormats.BottomCenter, weaponProperties.MaxHp?.ToString() ?? "");
            _drawables.Add(maxHpBox);

            var directionsBox = new DirectionBox(new XRect(25, 25, 10, 10), weapon);
            _drawables.Add(directionsBox);

            var actionsBox = new ActionsBox(new XRect(40, 5, 30, 12.5), weapon, weaponProperties);
            _drawables.Add(actionsBox);

            var ammoBox = new LineBox(new XRect(40, 20, 30, 15));
            ammoBox.SetText(XStringFormats.TopLeft, "Ammunition");
            ammoBox.SetText(XStringFormats.CenterLeft, $"{weaponProperties.Ammunition}");
            _drawables.Add(ammoBox);
        }

        public override void Draw(XGraphics gfx)
        {
            XPoint[] leftPoints = { _boundingBox.TopLeft,
                                new XPoint(_boundingBox.Left+2.5, _boundingBox.Top + 2.5),
                                new XPoint(_boundingBox.Left, _boundingBox.Top + 5),
                                _boundingBox.BottomLeft };
            gfx.DrawLines(_defaultPen, leftPoints);
            XPoint[] rightPoints = { _boundingBox.TopRight,
                                new XPoint(_boundingBox.Right-2.5, _boundingBox.Top + 2.5),
                                new XPoint(_boundingBox.Right, _boundingBox.Top + 5),
                                _boundingBox.BottomRight };
            gfx.DrawLines(_defaultPen, rightPoints);
            foreach (var drawable in _drawables)
            {
                drawable.Draw(gfx);
            }
            base.Draw(gfx);
        }
    }
}
