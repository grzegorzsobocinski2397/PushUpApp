using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace PushUpApp
{
    public class HomeViewModel
    {
        public Command PaintCommand { get; set; }
        public HomeViewModel()
        {
            PaintCommand = new Command<SKPaintSurfaceEventArgs>(OnPainting);
        }
        private void OnPainting(SKPaintSurfaceEventArgs e)
        {
            var info = e.Info;
            var surface = e.Surface;
            var canvas = surface.Canvas;
            var paint = new SKPaint
            {
                Style = SKPaintStyle.Fill,
                Color = Color.Orange.ToSKColor(),

            };

            canvas.DrawCircle(info.Width / 2, info.Height / 2, 100, paint);
        }
    }
}
