using PdfSharpCore.Drawing;
using SpelljammerShipSheetCreator.Drawables;
using SpelljammerShipSheetCreator.DTO;

namespace SpelljammerShipSheetCreator.DataElements
{
    internal class WeaponHeaderBox : Drawable
    {
        List<Drawable> _drawables = new List<Drawable>();
        public WeaponHeaderBox(WeaponProperties weapon, int weaponCount = 1) : base(new XRect(0, 0, 75, 20))
        {
            var textBox = new Drawable(new XRect(5, 0, 30, 15));
            string title = weapon.Type;
            if (weaponCount > 1)
            {
                title += $" (x{weaponCount})";
            }
            textBox.SetText(XStringFormats.TopLeft, title);
            if (weapon.Ranged)
            {
                textBox.SetText(XStringFormats.BottomLeft, $"{weapon.Range}/{weapon.DisadvantageRange} ft");
            }
            else if (weapon.Range != null)
            {
                string range = $"{weapon.Range}";
                if(weapon.DisadvantageRange != null){
                    range += $"/{weapon.DisadvantageRange}";
                }
                textBox.SetText(XStringFormats.CenterLeft, $"{range} ft");
            }
            _drawables.Add(textBox);

            var damageBox = new OctBox(new XRect(40, 5, 30, 15), 5);
            damageBox.SetText(XStringFormats.TopLeft, "Dmg");
            damageBox.SetText(XStringFormats.CenterLeft, " " + weapon.Damage);
            damageBox.SetText(XStringFormats.BottomLeft, weapon.DamageType);
            _drawables.Add(damageBox);

            var hitBox = new HexBox(new XRect(57.5, 7.5, 15, 10), 2.5);
            hitBox.SetText(XStringFormats.TopLeft, "ToHit");
            hitBox.SetText(XStringFormats.BottomCenter, $"+{weapon.ToHit}");
            _drawables.Add(hitBox);
        }
        public override void Draw(XGraphics gfx)
        {
            XPoint[] points = { _boundingBox.BottomLeft,
                                new XPoint(_boundingBox.Left, _boundingBox.Top + 5),
                                new XPoint(_boundingBox.Left+5, _boundingBox.Top),
                                new XPoint(BoundingBox.Right-5, _boundingBox.Top),
                                new XPoint(BoundingBox.Right, _boundingBox.Top+5),
                                _boundingBox.BottomRight };
            gfx.DrawLines(_defaultPen, points);
            foreach (var drawable in _drawables)
            {
                drawable.Draw(gfx);
            }
            base.Draw(gfx);
        }
    }
}
