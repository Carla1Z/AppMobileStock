using AppMobileStock.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AppMobileStock.Services
{
	public class ApiArticuloServices
	{
		public HttpClient Client { get; set; }

		public string URL { get; set; }

		public string ErrorLog { get; set; }

		public ApiArticuloServices()
		{
			var httpClientHandler = new HttpClientHandler();

			httpClientHandler.ServerCertificateCustomValidationCallback =
			(message, cert, chain, errors) => { return true; };

			this.Client = new HttpClient(httpClientHandler);

			this.URL = "https://differentaquashop17.conveyor.cloud/api/Articulos";
		}

		public async Task<ArticuloDTO> SendArticulo(ArticuloDTO articuloDTO)
		{
			var httpClientHandler = new HttpClientHandler();
			httpClientHandler.ServerCertificateCustomValidationCallback =
			   (message, cert, chain, errors) => { return true; };

			using (HttpClient client = new HttpClient(httpClientHandler))
			{

				string url = this.URL;
				//string url = this.URLDeposit.Replace("?", "") + $"/CheckStock";

				client.DefaultRequestHeaders.Accept.TryParseAdd("application/json");

				string content = JsonConvert.SerializeObject(articuloDTO);

				StringContent body = new StringContent(content, Encoding.UTF8, "application/json");

				//var result = await client.PostAsync(url.Replace("?", ""), body);
				var result = await client.PostAsync(url, body);
				//leo respuesta
				string data = await result.Content.ReadAsStringAsync();

				if (result.IsSuccessStatusCode)
				{
					var datos = JsonConvert.DeserializeObject<ArticuloDTO>(data);
					return datos;
				}
				else
				{
					return null;
				}
			}
		}

		//nuevo

		public async Task<List<ArticuloDTO>> GetArticulos()
		{
			try
			{
				var httpClientHandler = new HttpClientHandler();

				httpClientHandler.ServerCertificateCustomValidationCallback =
				(message, cert, chain, errors) => { return true; };

				using (HttpClient client = new HttpClient(httpClientHandler))
				{
					//client.Timeout = TimeSpan.FromMinutes(App.HttpClientTimeOut);
					string url = $"{this.URL}";

					ErrorLog += $"Inicio Get order con url {url}";
					//client.DefaultRequestHeaders.Add("ZUMO-API-VERSION", "2.0.0");
					client.DefaultRequestHeaders.Accept.TryParseAdd("application/json");

					HttpResponseMessage response = await client.GetAsync(url);
					ErrorLog += $"Hice Get Async";
					string data = await response.Content.ReadAsStringAsync();

					if (response.IsSuccessStatusCode)
					{
						ErrorLog += $"Recibi data";
						var datos = JsonConvert.DeserializeObject<List<ArticuloDTO>>(data);
						return datos;
					}
					else
					{
						ErrorLog += $"Recibi error";
						return null;
					}
				}
			}
			catch (Exception ex)
			{
				ErrorLog += $"Error Ejecutando get  {ex.Message}";
				return null;
			}
		}

		public async Task<ArticuloDTO> GetArticuloById(int id)
		{
			try
			{
				var httpClientHandler = new HttpClientHandler();

				httpClientHandler.ServerCertificateCustomValidationCallback =
				(message, cert, chain, errors) => { return true; };

				using (HttpClient client = new HttpClient(httpClientHandler))
				{
					//client.Timeout = TimeSpan.FromMinutes(App.HttpClientTimeOut);
					string url = $"{this.URL}{id}";

					ErrorLog += $"Inicio Get order con url {url}";
					//client.DefaultRequestHeaders.Add("ZUMO-API-VERSION", "2.0.0");
					client.DefaultRequestHeaders.Accept.TryParseAdd("application/json");

					HttpResponseMessage response = await client.GetAsync(url);
					ErrorLog += $"Hice Get Async";
					string data = await response.Content.ReadAsStringAsync();

					if (response.IsSuccessStatusCode)
					{
						ErrorLog += $"Recibi data";
						var datos = JsonConvert.DeserializeObject<ArticuloDTO>(data);
						return datos;
					}
					else
					{
						ErrorLog += $"Recibi error";
						return null;
					}
				}
			}
			catch (Exception ex)
			{
				ErrorLog += $"Error Ejecutando get  {ex.Message}";
				return null;
			}
		}


	}
}
