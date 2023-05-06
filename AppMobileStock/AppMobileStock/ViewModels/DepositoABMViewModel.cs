using AppMobileStock.Models;
using AppMobileStock.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppMobileStock.ViewModels
{
	public class DepositoABMViewModel : BaseViewModel
	{
		#region Properties/ atributos

		public INavigation Navigation { get; set; }

		ApiDepositoServices _service = new ApiDepositoServices();


		//private ProductRead _productRead;

		public DepositoDTO DepositoDTO
		{
			get => GetPropertyValue<DepositoDTO>();
			set => SetPropertyValue(value);
		}

		public string CodeRead
		{
			get => GetPropertyValue<string>();
			set => SetPropertyValue(value);
		}

		public int Numero
		{
			get => GetPropertyValue<int>();
			set => SetPropertyValue(value);
		}

		#endregion

		#region Constructor

		public DepositoABMViewModel()
		{
			DepositoDTO = new DepositoDTO();
			Title = $"Depositos";
		}
		#endregion

		#region Commands

		public Command Guardar
		{
			get
			{
				return new Command(async () => await GuardarDeposito());
			}
		}

		//public Command Borrar
		//{
		//    get
		//    {
		//        return new Command(async () => await BorrarProfesor());
		//    }
		//}

		#endregion

		#region Methods

		public async Task LoadDeposito(int Id)
		{
			if (IsBusy)
				return;

			await Task.Delay(100);
			IsBusy = true;

			try
			{
				DepositoDTO = await _service.GetDepositoById(Id);
				//muestro items de esta ubicación
				//Verificar error
			}
			catch (Exception ex)
			{
				await Application.Current.MainPage.DisplayAlert("Error!", "Ocurrió un error " + ex.Message, "OK");
			}
			finally
			{
				IsBusy = false;
			}
		}

		private async Task GuardarDeposito()
		{
			try
			{
				DepositoDTO.Mensaje = "Deposito agregado";
				DepositoDTO = await _service.SendDeposito(DepositoDTO);

				if (DepositoDTO.HuboError)
				{
					await Application.Current.MainPage.DisplayAlert("Error", "Ocurrio un error " + DepositoDTO.Mensaje, "Ok");

				}
				else
				{
					await Application.Current.MainPage.DisplayAlert("Exito", DepositoDTO.Mensaje, "Ok");
				}

			}
			catch (Exception ex)
			{

				await Application.Current.MainPage.DisplayAlert("Error", "Ocurrio un error " + ex.Message, "Ok");
			}
		}

		#endregion
	}
}
