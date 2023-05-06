using AppMobileStock.Models;
using AppMobileStock.Services;
using AppMobileStock.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppMobileStock.ViewModels
{
	public class ArticuloViewModel : BaseViewModel
	{

		#region Properties/ atributos

		public INavigation Navigation { get; set; }

		ApiArticuloServices _service = new ApiArticuloServices();


		public ObservableCollection<ArticuloDTO> Articulos
		{
			get => GetPropertyValue<ObservableCollection<ArticuloDTO>>();
			set => SetPropertyValue(value);
		}


		#endregion

		#region Constructor

		public ArticuloViewModel()
		{
			Articulos = new ObservableCollection<ArticuloDTO>();
			Title = $"Listado Articulos";
		}
		#endregion

		#region Commands

		public Command NuevoArticulo
		{
			get
			{
				return new Command(async () => await GoToABMPage());
			}
		}

		#endregion

		#region Methods

		public async Task LoadArticulos()
		{
			if (IsBusy)
				return;

			await Task.Delay(100);
			IsBusy = true;

			try
			{
				List<ArticuloDTO> articulosList = await _service.GetArticulos();
				//Instancio la observable collection
				Articulos = new ObservableCollection<ArticuloDTO>(articulosList);
			}
			catch (Exception ex)
			{
				await Application.Current.MainPage.DisplayAlert("Error!", "Ocurrió un error i" + ex.Message, "OK");
			}
			finally
			{
				IsBusy = false;
			}
		}

		private async Task GoToABMPage()
		{
			await Navigation.PushAsync(new ArticuloABMPage());
		}

		#endregion



	}
}
