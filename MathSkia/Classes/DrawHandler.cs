using System;
using AppKit;
using Foundation;
using SkiaSharp;

namespace MathSkia.Classes
{
    public class DrawHandler
    {
        
        public DrawHandler() {
        }
        
        
        /// <summary>
        /// Convert the Image sketch to a png encoded SkiaSharp data object.
        /// </summary>
        /// <returns>The Sketch as a <c>SKData</c> object.</returns>
        private SKData GenerateImageData(Point pt){
            var ballStyleFillPaint = new SKPaint(){
                Style = SKPaintStyle.Fill,
                Color = SKColors.Red,
                BlendMode = SKBlendMode.SrcOver,
                IsAntialias = true};
            var ballStyleFrameColor = new SKColor(255, 255, 255, 255);
            SKImageInfo info =  new SKImageInfo(1280, 720, SKImageInfo.PlatformColorType, SKAlphaType.Premul);
            using (var surface = SKSurface.Create(info))
            {
                // Create Canvas
                SKCanvas canvas = surface.Canvas;
                canvas.Clear(SKColors.Black);
                canvas.DrawCircle(pt.X, 680 - pt.Y,25,ballStyleFillPaint);
                // Return data from sketch
                return surface.Snapshot().Encode();
            }

        }

        private void DrawItems(SKCanvas canvas)
        {
            
        }
        /// <summary>
        /// Convert the Image sketch to a bitmap image.
        /// </summary>
        /// <returns>The sketch as a platform specific bitmap image.</returns>
        public NSImage GenerateImage(Point pt){
            // Get image data from sketch
            var skPngdata = GenerateImageData(pt);
		
            // Convert to image and return
            var data = NSData.FromBytes(skPngdata.Data, (nuint)skPngdata.Size);
            return new NSImage(data);
        }

    }
}