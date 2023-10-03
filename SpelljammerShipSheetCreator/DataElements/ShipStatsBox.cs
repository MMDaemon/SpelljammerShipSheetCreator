using PdfSharpCore.Drawing;
using SpelljammerShipSheetCreator.Drawables;
using SpelljammerShipSheetCreator.DTO;

namespace SpelljammerShipSheetCreator.DataElements
{
    internal class ShipStatsBox : OctBox
    {
        List<Drawable> _drawables = new List<Drawable>();

        public ShipStatsBox(Ship ship) : base(new XRect(0, 0, 75, 75), 5)
        {
            double rowPos = 5;

            var hpBox = new OctBox(new XRect(5, rowPos, 30, 30), 5);
            hpBox.SetText(XStringFormats.TopLeft, "HP");
            _drawables.Add(hpBox);

            var maxHpBox = new HexBox(new XRect(22.5, rowPos, 15, 10), 2.5);
            maxHpBox.SetText(XStringFormats.TopLeft, "Max");
            maxHpBox.SetText(XStringFormats.BottomCenter, ship.MaxHp.ToString());
            _drawables.Add(maxHpBox);

            var damageThresholdBox = new HexBox(new XRect(12.5, rowPos + 20, 15, 10), 2.5);
            damageThresholdBox.SetText(XStringFormats.TopLeft, "DTH");
            damageThresholdBox.SetText(XStringFormats.BottomCenter, ship.DamageThreshold.ToString());
            _drawables.Add(damageThresholdBox);

            var armorClassBox = new ShieldBox(new XRect(25, rowPos +17.5, 10, 15), 2.5);
            armorClassBox.SetText(XStringFormats.TopCenter, "AC");
            armorClassBox.SetText(XStringFormats.Center, ship.ArmorClass.ToString());
            _drawables.Add(armorClassBox);

            var speedBox = new HexBox(new XRect(53.75, rowPos, 18.75, 10), 2.5);
            speedBox.SetText(XStringFormats.TopLeft, "Speed");
            speedBox.SetText(XStringFormats.BottomCenter, ship.Speed.ToString());
            _drawables.Add(speedBox);

            var agilityBox = new HexBox(new XRect(37.5, rowPos + 5, 18.75, 10), 2.5);
            agilityBox.SetText(XStringFormats.TopLeft, "Agility");
            agilityBox.SetText(XStringFormats.BottomCenter, ship.Agility.ToString());
            _drawables.Add(agilityBox);


            var sizeBox = new HexBox(new XRect(53.75, rowPos + 15, 18.75, 10), 2.5);
            sizeBox.SetText(XStringFormats.TopLeft, "Size");
            sizeBox.SetText(XStringFormats.BottomCenter, $"{ship.Length.ToString()}x{ship.Width.ToString()} ft", 3);
            _drawables.Add(sizeBox);

            var costBox = new HexBox(new XRect(37.5, rowPos + 20, 18.75, 10), 2.5);
            costBox.SetText(XStringFormats.TopLeft, "Cost");
            costBox.SetText(XStringFormats.BottomCenter, $"{ship.Cost.ToString()}GP", 3);
            _drawables.Add(costBox);

            rowPos += 35;

            var airBox = new OctBox(new XRect(5, rowPos, 27.5, 30), 5);
            airBox.SetText(XStringFormats.TopLeft, "Air");
            airBox.SetText(XStringFormats.BottomCenter, "days");
            _drawables.Add(airBox);

            var freshBox = new OctBox(new XRect(25, rowPos, 45, 10), 2.5);
            freshBox.SetText(XStringFormats.Center, "    Fresh\n    (0-120 days)");
            _drawables.Add(freshBox);
            var freshCircle = new CircleBox(new XRect(27.5, rowPos + 2.5, 5, 5));
            _drawables.Add(freshCircle);

            var foulBox = new OctBox(new XRect(25, rowPos + 10, 45, 10), 2.5);
            foulBox.SetText(XStringFormats.Center, "    Foul\n    (121-240 days)");
            _drawables.Add(foulBox);
            var foulCircle = new CircleBox(new XRect(27.5, rowPos + 12.5, 5, 5));
            _drawables.Add(foulCircle);

            var deadlyBox = new OctBox(new XRect(25, rowPos + 20, 45, 10), 2.5);
            deadlyBox.SetText(XStringFormats.Center, "    Deadly\n    (241+ days)");
            _drawables.Add(deadlyBox);
            var deadlyCircle = new CircleBox(new XRect(27.5, rowPos + 22.5, 5, 5));
            _drawables.Add(deadlyCircle);

            if (ship.Modifications?.Contains(ShipModification.Treant) == true)
            {
                rowPos += 35;

                var modBox = new OctBox(new XRect(5, rowPos, 65, 30), 5);
                modBox.SetText(XStringFormats.TopLeft, "Treant");
                modBox.SetText(XStringFormats.CenterLeft, " On Long Rest:\n  -Repair 4d12 HP\n  -Refresh Air to next stage\n Dies when ship at 0 HP");
                _drawables.Add(modBox);
            }

            if (ship.Modifications?.Contains(ShipModification.PlanarShift) == true)
            {
                rowPos += 35;

                var modBox = new OctBox(new XRect(5, rowPos, 65, 30), 5);
                modBox.SetText(XStringFormats.TopLeft, "Planar Shift");
                modBox.SetText(XStringFormats.CenterLeft, " Action: (Recharge 5-6)\n  -Transport Ship and content\n   to an envisioned or random\n   location in another plane\n  -On recharge: 1min else 24h");
                _drawables.Add(modBox);
            }

            if (ship.Modifications?.Contains(ShipModification.Directionless) == true)
            {
                rowPos += 35;

                var modBox = new OctBox(new XRect(5, rowPos, 65, 30), 5);
                modBox.SetText(XStringFormats.TopLeft, "Directionless");
                modBox.SetText(XStringFormats.CenterLeft, " This ship can move backwards\n at the same speed at which\n it can move forewards");
                _drawables.Add(modBox);
            }

            _boundingBox.Height = rowPos + 35;
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
