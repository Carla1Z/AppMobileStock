using AppMobileStock.Models;
using AppMobileStock.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMobileStock.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DepositoABMPage : ContentPage
	{
		public DepositoABMPage ()
		{
			InitializeComponent ();
		}

		private async void Button_Clicked(object sender, EventArgs e)
		{
			try
			{
				DepositoDTO depositoDTOAgregar = new DepositoDTO();
				depositoDTOAgregar.Capacidad = Convert.ToDecimal(txtCapacidad.Text);
				depositoDTOAgregar.Nombre = txtNombre.Text;
				depositoDTOAgregar.Direccion = txtDireccion.Text;

				ApiDepositoServices apiDepositoServices = new ApiDepositoServices();

				depositoDTOAgregar = await apiDepositoServices.SendDeposito(depositoDTOAgregar);
			}
			catch (Exception ex)
			{
				await DisplayAlert("Error", "Ocurrio un error" + ex.Message, "Ok");
			}
		}
    }
}