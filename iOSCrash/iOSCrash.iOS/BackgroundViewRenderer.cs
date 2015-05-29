using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using CoreGraphics;
using CoreAnimation;

using iOSCrash;
using iOSCrash.iOS;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;

[assembly: ExportRendererAttribute(typeof(BackgroundView), typeof(BackgroundViewRenderer))]
namespace iOSCrash.iOS
{
	class BackgroundViewRenderer : ViewRenderer
	{
		BackgroundView backgroundView;

		public BackgroundViewRenderer()
		{
			BackgroundColor = UIColor.Clear;
			Opaque = true;
			this.MultipleTouchEnabled = false;
		}

		protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);

			if (e.PropertyName == BackgroundView.TheColoursProperty.PropertyName)
			{
				this.SetNeedsDisplay();
			}
		}

		public override void Draw(CGRect rect)
		{
			backgroundView = (BackgroundView)this.Element;

			using (var context = UIGraphics.GetCurrentContext())
			{
				using (CGColorSpace rgb = CGColorSpace.CreateDeviceRGB())
				{
					CGGradient gradient = new CGGradient(rgb, new CGColor[] { backgroundView.TheColours.StartColour.ToCGColor(), backgroundView.TheColours.MidColour.ToCGColor(), backgroundView.TheColours.EndColour.ToCGColor() });

					// draw a linear gradient
					context.DrawLinearGradient((CGGradient)gradient, (CGPoint)new CGPoint(rect.Right, rect.Top), (CGPoint)new CGPoint(rect.Left, rect.Bottom), (CGGradientDrawingOptions)CGGradientDrawingOptions.DrawsBeforeStartLocation);

					// draw the circles
					Random random = new Random();
					nfloat x = rect.Width / random.Next(2, 10);
					nfloat y = rect.Height - (rect.Height / random.Next(2, 6));
					nfloat radius = (rect.Height / 3) / 2;

					context.SetFillColor(UIColor.Clear.CGColor);
					context.SetStrokeColor(UIColor.FromRGBA(255, 255, 255, 10).CGColor);

					context.SetLineWidth(rect.Height / 38);
					CGPoint circlePoint = new CGPoint(x, y);
					context.AddArc(circlePoint.X, circlePoint.Y, radius, 0, (nfloat)(2 * Math.PI), true);
					context.DrawPath(CGPathDrawingMode.FillStroke);

					context.SetLineWidth(rect.Height / 70);
					circlePoint = new CGPoint(x - (radius / 2), y - (radius / 1.25F));
					context.AddArc(circlePoint.X, circlePoint.Y, radius - (radius / 2), 0, (nfloat)(2 * Math.PI), true);
					context.DrawPath(CGPathDrawingMode.FillStroke);

					context.SetLineWidth(rect.Height / 50);
					x = rect.Width - (rect.Width / random.Next(2, 10));
					y = rect.Height / random.Next(2, 6);
					radius = (rect.Height / 6) / 2;
					circlePoint = new CGPoint(x, y);
					context.AddArc(circlePoint.X, circlePoint.Y, radius, 0, (nfloat)(2 * Math.PI), true);
					context.DrawPath(CGPathDrawingMode.FillStroke);

					context.SetLineWidth(rect.Height / 70);
					circlePoint = new CGPoint(x + (radius / 1.4f), y - (radius / 1.2F));
					context.AddArc(circlePoint.X, circlePoint.Y, radius - (radius / 3), 0, (nfloat)(2 * Math.PI), true);
					context.DrawPath(CGPathDrawingMode.FillStroke);

					context.SetLineWidth((nfloat)rect.Height / 44);
					x = rect.Width / random.Next(2, 10);
					y = rect.Height / random.Next(2, 10);
					radius = (rect.Height / 3.5f) / 2;
					circlePoint = new CGPoint(x, y);
					context.AddArc(circlePoint.X, circlePoint.Y, radius, 0, (nfloat)(2 * Math.PI), true);
					context.DrawPath(CGPathDrawingMode.FillStroke);

					context.SetLineWidth(rect.Height / 88);
					circlePoint = new CGPoint(x - (radius / 1.3f), y + (radius / 1.5F));
					context.AddArc(circlePoint.X, circlePoint.Y, radius - (radius / 2f), 0, (nfloat)(2 * Math.PI), true);
					context.DrawPath(CGPathDrawingMode.FillStroke);
				}
			}
		}
	}
}