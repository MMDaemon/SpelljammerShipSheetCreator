using PdfSharpCore.Drawing;

namespace SpelljammerShipSheetCreator.Drawables
{
    internal class ImageBox : Drawable
    {
        XImage _image;
        public ImageBox(XRect boundingBox, string imagePath) : base(boundingBox)
        {
            _image = XImage.FromFile(imagePath);
        }

        public override void Draw(XGraphics gfx)
        {
            XSize imageSize = _image.Size;
            double widthFactor = _boundingBox.Width / imageSize.Width;
            double heightFactor = _boundingBox.Height / imageSize.Height;
            double scalingFactor = widthFactor<heightFactor ? widthFactor : heightFactor;
            XSize newImageSize = new XSize(imageSize.Width * scalingFactor, imageSize.Height * scalingFactor);
            XPoint newImagePos = new XPoint(_boundingBox.X + _boundingBox.Width / 2 - newImageSize.Width / 2, _boundingBox.Y + _boundingBox.Height / 2 - newImageSize.Height / 2);
            XRect imageRect = new XRect(newImagePos, newImageSize);
            gfx.DrawImage(_image, imageRect);

            base.Draw(gfx);
        }
    }
}
