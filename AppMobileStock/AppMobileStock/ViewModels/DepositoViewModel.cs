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
	public class DepositoViewModel : BaseViewModel
	{

		#region Properties/ atributos

		public INavigation Navigation { get; set; }

		ApiDepositoServices _service = new ApiDepositoServices();


		public ObservableCollection<DepositoDTO> Depositos
		{
			get => GetPropertyValue<ObservableCollection<DepositoDTO>>();
			set => SetPropertyValue(value);
		}


		#endregion

		#region Constructor

		public DepositoViewModel()
		{
			Depositos = new ObservableCollection<DepositoDTO>();
			Title = $"Listado Depositos";
		}
		#endregion

		#region Commands

		public Command NuevoDeposito
		{
			get
			{
				return new Command(async () => await GoToABMPage());
			}
		}

		#endregion

		#region Methods

		public async Task LoadDepositos()
		{
			if (IsBusy)
				return;

			await Task.Delay(100);
			IsBusy = true;

			try
			{
				List<DepositoDTO> depositoList = await _service.GetDepositos();
				//Instancio la observable collection
				Depositos = new ObservableCollection<DepositoDTO>(depositoList);
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
			await Navigation.PushAsync(new DepositoABMPage());
		}

		#endregion

	}
}
