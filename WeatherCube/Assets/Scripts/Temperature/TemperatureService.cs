using System;
using Cysharp.Threading.Tasks;
using Testing;
using UnityEngine;
using UnityEngine.Networking;
using Zenject;
namespace Testing {
	public enum ResultType {
		None,
		Success,
		Failure,
	}
	public struct Result {
		public ResultType ResultType;
		public string Message;
	}
}

public class TemperatureService : IInitializable {

	[Inject]
	private JsonDeserializers _JsonDeserializers;
	[Inject]
	private WeatherRequestData _WeatherRequestData;
	[Inject]
	private ITemperatureConverter _TemperatureConverter;
	[Inject]
	private CurrentTemperature _CurrentTemperature;
	public Result InitializationResult { get; private set; }

	public async void Initialize() {
		Debug.Log($"Start init: {GetType().Name}");
		var geo = await GetTextAsync<Response.Geo.Root>(UnityWebRequest.Get($"http://api.openweathermap.org/geo/1.0/direct?q={_WeatherRequestData.City},{_WeatherRequestData.StateCode},{_WeatherRequestData.CountryCode}&limit={1}&appid={_WeatherRequestData.ApiKey}"));
		var forecast = await GetTextAsync<Response.Forecast.Root>(UnityWebRequest.Get($"http://api.openweathermap.org/data/2.5/weather?lat={geo.lat}&lon={geo.lon}&appid={_WeatherRequestData.ApiKey}"));
		if (forecast == null) {
			Debug.LogError("Cant get forecast!");
			InitializationResult = new Result {
				ResultType = ResultType.Failure,
				Message = "Cant get forecast!"
			};
			return;
		}
		var temp = _TemperatureConverter.Temperature(forecast.main.temp);
		// Debug.Log($"Temperature in {_WeatherRequestData.City} is {temp} {_TemperatureConverter.Unit}");
		_CurrentTemperature.Value.SetValueAndForceNotify(temp);
		InitializationResult = new Result() {
			ResultType = ResultType.Success
		};
	}

	async UniTask<T> GetTextAsync<T>(UnityWebRequest req) {
		var op = await req.SendWebRequest();
		T response = default;
		response = _JsonDeserializers.Deserialize<T>(op.downloadHandler.text);
		if (response == null) {
			throw new Exception("Cant deserialize " + op.downloadHandler.text);
		}
		return response;
	}

}
