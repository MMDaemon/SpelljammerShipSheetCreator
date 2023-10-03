using PdfSharpCore.Drawing;
using SpelljammerShipSheetCreator.Drawables;
using SpelljammerShipSheetCreator.DTO;

namespace SpelljammerShipSheetCreator.DataElements
{
    internal class WeaponStatsBox : Drawable
    {
        List<Drawable> _drawables = new List<Drawable>();
        public WeaponStatsBox(Ship ship, WeaponProperties weaponProperties) : base(new XRect(0, 0, 75, 0))
        {
            _drawables.Add(new WeaponHeaderBox(weaponProperties, ship.Weapons.Count(w => w.Type == weaponProperties.Type)));
            if (weaponProperties.Ranged)
            {
                foreach (var weapon in ship.Weapons.Where(w => w.Type == weaponProperties.Type))
                {
                    _drawables.Add(new WeaponBox(weapon, weaponProperties));
                }
            }
            else
            {
                double xPos = 2.5;
                foreach (var weapon in ship.Weapons.Where(w => w.Type == weaponProperties.Type))
                {
                    _drawables.Add(new MeleeBox(weapon, new XPoint(xPos, -10)));
                    xPos += 12.5;
                }
            }
            _drawables.Add(new WeaponFooterBox());

            _boundingBox.Height += _drawables.Sum(d => d.BoundingBox.Height);
        }

        public override void Draw(XGraphics gfx)
        {
            XGraphicsState before = gfx.Save();
            foreach (var drawable in _drawables)
            {
                drawable.Draw(gfx);
                gfx.TranslateTransform(0, drawable.BoundingBox.Height);
            }
            gfx.Restore(before);
            base.Draw(gfx);
        }
    }
}
