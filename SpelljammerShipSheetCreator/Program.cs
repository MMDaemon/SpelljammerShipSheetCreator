using SpelljammerShipSheetCreator.DTO;
using SpelljammerShipSheetCreator.PdfCreation;
using System.Diagnostics;
using System.Xml.Serialization;

namespace SpelljammerShipSheetCreator
{
    public static class Program
    {
        static void Main(string[] args)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(SpelljammerData));

            string xmlPath = "C:\\Users\\mette\\Desktop\\SpelljammerData.xml";
            using FileStream xmlStream = File.OpenRead(xmlPath);
            SpelljammerData? xmlData = serializer.Deserialize(xmlStream) as SpelljammerData;

            string pdfPath = "C:\\Users\\mette\\Desktop\\ShipSheets.pdf";
            if (xmlData != null)
            {
                ShipSheetWriter writer = new ShipSheetWriter(xmlData);
                writer.WriteToPdf(pdfPath);
                Process.Start(new ProcessStartInfo(pdfPath) { UseShellExecute = true });
            }
        }
    }
}