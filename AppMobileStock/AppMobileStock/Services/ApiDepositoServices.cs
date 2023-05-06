using AppMobileStock.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AppMobileStock.Services
{
    public class ApiDepositoServices
    {
		public HttpClient Client { get; set; }

		public string URL { get; set; }

		public string ErrorLog { get; set; }

		public ApiDepositoServices()
		{
			var httpClientHandler = new HttpClientHandler();

			httpClientHandler.ServerCertificateCustomValidationCallback =
			(message, cert, chain, errors) => { return true; };

			this.Client = new HttpClient(httpClientHandler);

			this.URL = "https://otheraquacat27.conveyor.cloud/api/Depositos";
		}

		public async Task<DepositoDTO> SendDeposito(DepositoDTO depositoDTO)
		{
			var httpClientHandler = new HttpClientHandler();
			httpClientHandler.ServerCertificateCustomValidationCallback =
			   (message, cert, chain, errors) => { return true; };

			using (HttpClient client = new HttpClient(httpClientHandler))
			{

				string url = this.URL;
				//string url = this.URLDeposit.Replace("?", "") + $"/CheckStock";

				client.DefaultRequestHeaders.Accept.TryParseAdd("application/json");

				string content = JsonConvert.SerializeObject(depositoDTO);

				StringContent body = new StringContent(content, Encoding.UTF8, "application/json");

				//var result = await client.PostAsync(url.Replace("?", ""), body);
				var result = await client.PostAsync(url, body);
				//leo respuesta
				string data = await result.Content.ReadAsStringAsync();

				if (result.IsSuccessStatusCode)
				{
					var datos = JsonConvert.DeserializeObject<DepositoDTO>(data);
					return datos;
				}
				else
				{
					return null;
				}
			}
		}
	}
}
