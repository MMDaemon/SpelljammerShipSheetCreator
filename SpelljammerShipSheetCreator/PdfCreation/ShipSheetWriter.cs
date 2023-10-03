using PdfSharpCore.Drawing;
using PdfSharpCore.Pdf;
using SpelljammerShipSheetCreator.DataElements;
using SpelljammerShipSheetCreator.Drawables;
using SpelljammerShipSheetCreator.DTO;

namespace SpelljammerShipSheetCreator.PdfCreation
{
    internal class ShipSheetWriter
    {
        public SpelljammerData SpelljammerData { private get; set; }

        public ShipSheetWriter(SpelljammerData spelljammerData)
        {
            SpelljammerData = spelljammerData;
        }

        public void WriteToPdf(string filePath)
        {
            PdfDocument document = new PdfDocument();
            document.Info.Title = "Test";
            document.Info.Author = "Matthias Mettenleiter";
            document.Info.Subject = "Test";
            document.Info.Keywords = "Test";

            foreach (Ship ship in SpelljammerData.Ships)
            {
                PdfPage page = document.AddPage();
                page.Size = PdfSharpCore.PageSize.A5;
                XGraphics gfx = XGraphics.FromPdfPage(page, XGraphicsUnit.Millimeter);
                gfx.TranslateTransform(10, 10);
                gfx.ScaleTransform(0.5);
                XGraphicsState baseState = gfx.Save();
                var nameBox = new OctBox(new XRect(0, 0, 250, 15), 5);
                nameBox.SetText(XStringFormats.TopLeft, "Name");
                nameBox.Draw(gfx);
                gfx.TranslateTransform(0, 20);

                string imagePath = $"C:\\Users\\mette\\Desktop\\Ships\\{ship.Type}.png";
                if (File.Exists(imagePath))
                {
                    var imageBox = new ImageBox(new XRect(80, 0, 170, 75), imagePath);
                    imageBox.Draw(gfx);
                }

                var typeBox = new Drawable(new XRect(80, 0, 0, 0));
                typeBox.SetText(XStringFormats.TopLeft, ship.Type, 10);
                typeBox.Draw(gfx);
                ShipStatsBox shipStatsBox = new ShipStatsBox(ship);
                shipStatsBox.Draw(gfx);

                gfx.TranslateTransform(0, shipStatsBox.BoundingBox.Height + 5);

                foreach (string type in ship.Weapons.Select(w => w.Type).Distinct())
                {
                    WeaponProperties weapon = SpelljammerData.Weapons.Where(w => w.Type == type).First();
                    var weaponBox = new WeaponStatsBox(ship, weapon);

                    if (gfx.Transform.OffsetY + gfx.Transform.M22 * weaponBox.BoundingBox.Height > 200)
                    {
                        gfx.Restore(baseState);
                        baseState = gfx.Save();
                        gfx.TranslateTransform(80, 100);
                    }

                    weaponBox.Draw(gfx);
                    gfx.TranslateTransform(0, weaponBox.BoundingBox.Height + 5);
                }

                if (gfx.Transform.OffsetX == 10)
                {
                    gfx.Restore(baseState);
                    baseState = gfx.Save();
                    gfx.TranslateTransform(80, 100);
                }

                var crewBox = new CrewBox(ship.MaxCrew);
                crewBox.Draw(gfx);

                gfx.TranslateTransform(0, crewBox.BoundingBox.Height + 5);

                var cargoBox = new CargoBox(ship.MaxCargo);
                cargoBox.Draw(gfx);

                gfx.Restore(baseState);
                baseState = gfx.Save();
            }

            document.Save(filePath);

            Console.WriteLine($"Saved to {filePath}");
        }
    }
}
