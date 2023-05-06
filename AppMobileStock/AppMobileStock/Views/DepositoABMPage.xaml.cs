using AppMobileStock.Models;
using AppMobileStock.Services;
using AppMobileStock.ViewModels;
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
		public DepositoABMViewModel viewModel;
		public DepositoABMPage ()
		{
			InitializeComponent ();
			viewModel = new DepositoABMViewModel();
			viewModel.Navigation = Navigation;
			BindingContext = viewModel;
		}

		protected override async void OnAppearing()
		{
			//await viewModel.LoadArticulo(1);
		}

		//private async void Button_Clicked(object sender, EventArgs e)
		//{
		//	try
		//	{
		//		DepositoDTO depositoDTOAgregar = new DepositoDTO();
		//		depositoDTOAgregar.Capacidad = Convert.ToDecimal(txtCapacidad.Text);
		//		depositoDTOAgregar.Nombre = txtNombre.Text;
		//		depositoDTOAgregar.Direccion = txtDireccion.Text;
		//		depositoDTOAgregar.Mensaje = "Deposito agregado";

		//		ApiDepositoServices apiDepositoServices = new ApiDepositoServices();

		//		depositoDTOAgregar = await apiDepositoServices.SendDeposito(depositoDTOAgregar);

		//		if (depositoDTOAgregar.HuboError)
		//		{
		//			await DisplayAlert("Error", "Ocurrio un error: " + depositoDTOAgregar.Mensaje, "Ok");
		//		}
		//		else
		//		{
		//			await DisplayAlert("Operación exitosa", depositoDTOAgregar.Mensaje, "Ok");
		//		}

		//	}
		//	catch (Exception ex)
		//	{
		//		await DisplayAlert("Error", "Ocurrio un error" + ex.Message, "Ok");
		//	}
		//}
	}
}