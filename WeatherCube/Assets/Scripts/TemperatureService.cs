using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using Zenject;

public class TemperatureService : IInitializable {

	[Inject]
	private JsonDeserializers _JsonDeserializers;
	[Inject]
	private WeatherRequestData _WeatherRequestData;
	public async void Initialize() {
		async UniTask<T> GetTextAsync<T>(UnityWebRequest req) {
			var op = await req.SendWebRequest();
			T response = default;
			response = _JsonDeserializers.Deserialize<T>(op.downloadHandler.text);
			if (response == null) {
				throw new Exception("Cant deserialize " + op.downloadHandler.text);
			}
			return response;
		}
		var geo = await GetTextAsync<Response.Geo.Root>(UnityWebRequest.Get($"http://api.openweathermap.org/geo/1.0/direct?q={_WeatherRequestData.City},{_WeatherRequestData.StateCode},{_WeatherRequestData.CountryCode}&limit={1}&appid={_WeatherRequestData.ApiKey}"));
		var forecast = await GetTextAsync<Response.Forecast.Root>(UnityWebRequest.Get($"http://api.openweathermap.org/data/2.5/weather?lat={geo.lat}&lon={geo.lon}&appid={_WeatherRequestData.ApiKey}"));
		if (forecast == null) {
			Debug.LogError("Cant get forecast!");
			return;
		}
		float finalTemp = Mathf.Round((float)((forecast.main.temp - 273.0f)*10))/10; //holds the actual converted temperature

	}

}
