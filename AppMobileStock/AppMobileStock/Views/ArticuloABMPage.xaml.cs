﻿using AppMobileStock.Models;
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
	public partial class ArticuloABMPage : ContentPage
	{
		public ArticuloABMPage()
		{
			InitializeComponent();
		}

		private async void Button_Clicked(object sender, EventArgs e)
		{
			try
			{
				ArticuloDTO articuloDTOAgregar = new ArticuloDTO();
				articuloDTOAgregar.Nombre = txtNombre.Text;
				articuloDTOAgregar.Marca = txtMarca.Text;
				articuloDTOAgregar.MinimoStock = Convert.ToDecimal(txtMinStock.Text);
				articuloDTOAgregar.Proveedor = txtProveedor.Text;
				articuloDTOAgregar.Precio = (float)Convert.ToDecimal(txtPrecio.Text);
				articuloDTOAgregar.Codigo = txtCodigo.Text;

				ApiArticuloServices apiArticuloServices = new ApiArticuloServices();

				articuloDTOAgregar = await apiArticuloServices.SendArticulo(articuloDTOAgregar);
			}
			catch (Exception ex)
			{
				await DisplayAlert("Error", "Ocurrio un error" + ex.Message, "Ok");
			}
		}
	}
}