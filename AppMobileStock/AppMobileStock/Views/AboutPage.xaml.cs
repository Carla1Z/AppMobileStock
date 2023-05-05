using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMobileStock.Views
{
	public partial class AboutPage : ContentPage
	{
		public AboutPage()
		{
			InitializeComponent();
		}

		private void Button_Clicked(object sender, EventArgs e)
		{
			Navigation.PushAsync(new ArticuloPage());
        }

		private void Button_Clicked_1(object sender, EventArgs e)
		{
			Navigation.PushAsync(new DepositoPage());
        }
    }
}