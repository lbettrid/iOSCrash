using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace iOSCrash
{
	public class BackgroundColours
	{
		public Xamarin.Forms.Color StartColour = Xamarin.Forms.Color.Blue;
		public Xamarin.Forms.Color MidColour = Xamarin.Forms.Color.Green;
		public Xamarin.Forms.Color EndColour = Xamarin.Forms.Color.Red;

		public BackgroundColours()
		{
		}

		public BackgroundColours(Xamarin.Forms.Color sColour, Xamarin.Forms.Color mColour, Xamarin.Forms.Color eColour)
		{
			StartColour = sColour;
			MidColour = mColour;
			EndColour = eColour;
		}
	}

	public class BackgroundView : View
	{
		public static readonly BindableProperty TheColoursProperty = BindableProperty.Create<BackgroundView, BackgroundColours>(p => p.TheColours, new BackgroundColours());
		public BackgroundColours TheColours
		{
			get { return (BackgroundColours)base.GetValue(TheColoursProperty); }
			set { base.SetValue(TheColoursProperty, value); }
		}
	}
}
