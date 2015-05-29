using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Graphics;
using Android.Graphics.Drawables;

using iOSCrash;
using iOSCrash.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRendererAttribute(typeof(BackgroundView), typeof(BackgroundViewRenderer))]
namespace iOSCrash.Droid
{
	public class BackgroundViewRenderer : ViewRenderer
	{
		BackgroundView backgroundView;
		Paint paint = new Paint();
		Paint circPaint = new Paint();
		LinearGradient gradient;

		public BackgroundViewRenderer()
		{
			this.SetWillNotDraw(false);
		}

		protected override void OnDraw(Canvas canvas)
		{
			backgroundView = (BackgroundView)this.Element;

			base.OnDraw(canvas);

			gradient = new LinearGradient(canvas.Width, 0, 0, canvas.Height, new int[] { backgroundView.TheColours.StartColour.ToAndroid(), backgroundView.TheColours.MidColour.ToAndroid(), backgroundView.TheColours.EndColour.ToAndroid() }, new float[] { 0, 0.5f, 1 }, Shader.TileMode.Clamp);
			paint.SetShader(gradient);
			paint.SetStyle(Paint.Style.Fill);
			canvas.DrawPaint(paint);

			circPaint.AntiAlias = true;
			circPaint.StrokeWidth = canvas.Height / 38;
			circPaint.Color = Android.Graphics.Color.Argb(15, 255, 255, 255);
			circPaint.SetStyle(Paint.Style.Stroke);

			Random random = new Random();
			float x = canvas.Width / random.Next(2, 10);
			float y = canvas.Height - (canvas.Height / random.Next(2, 10));
			float r = (canvas.Height / 3) / 2;
			canvas.DrawCircle(x, y, r, circPaint);
			circPaint.StrokeWidth = canvas.Height / 70;
			x -= r / 1.25f;
			y -= r / 1.25f;
			r = (canvas.Height / 3.5f) / 2;
			canvas.DrawCircle(x, y, r, circPaint);

			circPaint.StrokeWidth = canvas.Height / 50;
			x = canvas.Width - (canvas.Width / random.Next(2, 10));
			y = canvas.Height / random.Next(2, 6);
			r = (canvas.Height / 6) / 2;
			canvas.DrawCircle(x, y, r, circPaint);
			circPaint.StrokeWidth = canvas.Height / 70;
			x += r / 1.4f;
			y -= r / 1.2f;
			r = (canvas.Height / 10) / 2;
			canvas.DrawCircle(x, y, r, circPaint);

			circPaint.StrokeWidth = canvas.Height / 44;
			x = canvas.Width / random.Next(2, 10);
			y = canvas.Height / random.Next(2, 10);
			r = (canvas.Height / 3.5f) / 2;
			canvas.DrawCircle(x, y, r, circPaint);
			circPaint.StrokeWidth = circPaint.StrokeWidth / 2;
			x -= r / 1.3f;
			y += r / 1.5f;
			r = r / 1.5f;
			canvas.DrawCircle(x, y, r, circPaint);
		}

		protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);

			if (e.PropertyName == BackgroundView.TheColoursProperty.PropertyName)
			{
				this.Invalidate();
			}
		}
	}
}