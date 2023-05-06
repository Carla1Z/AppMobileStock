using AppMobileStock.Models;
using AppMobileStock.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppMobileStock.ViewModels
{
	public class ArticuloABMViewModel : BaseViewModel
	{
		#region Properties/ atributos

		public INavigation Navigation { get; set; }

		ApiArticuloServices _service = new ApiArticuloServices();


		//private ProductRead _productRead;

		public ArticuloDTO ArticuloDTO
		{
			get => GetPropertyValue<ArticuloDTO>();
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

		public ArticuloABMViewModel()
		{
			ArticuloDTO = new ArticuloDTO();
			Title = $"Articulos";
		}
		#endregion

		#region Commands

		public Command Guardar
		{
			get
			{
				return new Command(async () => await GuardarArticulo());
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

		public async Task LoadArticulo(int Id)
		{
			if (IsBusy)
				return;

			await Task.Delay(100);
			IsBusy = true;

			try
			{
				ArticuloDTO = await _service.GetArticuloById(Id);
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

		private async Task GuardarArticulo()
		{
			try
			{

				//ArticuloDTO.Nombre = "Prueba";
				//ArticuloDTO.Marca = "Prueba Mobile";
				//ArticuloDTO.MinimoStock = 10;
				//ArticuloDTO.Mensaje = "-";
				//ArticuloDTO.Proveedor = "AppMobile";
				//ArticuloDTO.Precio = 10;
				//ArticuloDTO.Codigo = "10";
				//ArticuloDTO = await _service.SendArticulo(ArticuloDTO);

				ArticuloDTO.Mensaje = "Articulo agregado";
				ArticuloDTO = await _service.SendArticulo(ArticuloDTO);

				if (ArticuloDTO.HuboError)
				{
					await Application.Current.MainPage.DisplayAlert("Error", "Ocurrio un error " + ArticuloDTO.Mensaje, "Ok");

				}
				else
				{
					await Application.Current.MainPage.DisplayAlert("Exito", ArticuloDTO.Mensaje, "Ok");
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
