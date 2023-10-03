using PdfSharpCore.Drawing;
using SpelljammerShipSheetCreator.Drawables;
using SpelljammerShipSheetCreator.DTO;

namespace SpelljammerShipSheetCreator.DataElements
{
    internal class ActionsBox : LineBox
    {
        List<WeaponAction> _actions = new List<WeaponAction>();
        public ActionsBox(XRect boundingBox, Weapon weapon, WeaponProperties weaponProperties) : base(boundingBox)
        {

            if (weaponProperties.Actions != null)
            {
                _actions.AddRange(weaponProperties.Actions);
            }
            if (weapon.Modifications?.Contains(WeaponModifications.TurretRotator) == true)
            {
                _actions.Remove(_actions.First(a => a == WeaponAction.Aim));
            }
            SetText(XStringFormats.TopLeft, $"Actions (x{_actions.Count})");
        }

        public override void Draw(XGraphics gfx)
        {
            double x = 0;
            foreach (WeaponAction action in _actions)
            {
                XRect rect = new XRect(_boundingBox.Left + x, _boundingBox.Top + 5, 5, 5);
                gfx.DrawRectangle(_defaultPen, rect);
                gfx.DrawString(action.ToString().First().ToString(), new XFont("Verdana", 4, XFontStyle.Regular), XBrushes.Black, rect, XStringFormats.Center);
                x += 6;
            }

            base.Draw(gfx);
        }
    }
}
