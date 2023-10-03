using PdfSharpCore.Drawing;
using SpelljammerShipSheetCreator.Drawables;
using SpelljammerShipSheetCreator.DTO;

namespace SpelljammerShipSheetCreator.DataElements
{
    internal class MeleeBox : Drawable
    {
        List<Drawable> _drawables = new List<Drawable>();
        public MeleeBox(Weapon weapon, XPoint position) : base(new XRect(0, 0, 0, 0))
        {
            var directionBox = new DirectionBox(new XRect(position.X, position.Y, 10, 10), weapon);
            _drawables.Add(directionBox);
        }
        public override void Draw(XGraphics gfx)
        {
            foreach (var drawable in _drawables)
            {
                drawable.Draw(gfx);
            }
            base.Draw(gfx);
        }
    }
}
