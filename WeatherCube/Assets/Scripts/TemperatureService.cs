using System;
using Cysharp.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;
using UnityEngine.Networking;
using Zenject;

public abstract class JDeserializer<T> {
	public virtual T Deserialize(string json) {
		return JsonConvert.DeserializeObject<T>(json);
	}
}
public class JArrayDeserializer<T> : JDeserializer<T> {
	public override T Deserialize(string json) {
		var j = JArray.Parse(json);
		var responseJson = j[0].ToString();
		var deserialize = base.Deserialize(responseJson);
		return deserialize;
	}
}

public class JObjectDeserializer<T> : JDeserializer<T> {
	public override T Deserialize(string json) {
		var j = JObject.Parse(json);
		var responseJson = j.ToString();
		var deserialize = base.Deserialize(responseJson);
		return deserialize;
	}
}

public class JsonDeserializers {

	public T Deserialize<T>(string jsonLike) {
		var deserializers = new JDeserializer<T>[] {
			new JArrayDeserializer<T>(),
			new JObjectDeserializer<T>(),
		};
		T result = default;
		foreach (var jDeserializer in deserializers) {
			try {
				result = result ?? jDeserializer.Deserialize(jsonLike);
			}
			catch (Exception e) {
				Debug.LogWarning($"Cant deserialize {typeof(T).Name} with {jDeserializer.GetType().Name}");
			}
		}
		return result;
	}
}

public class TemperatureService : IInitializable {

	[Inject]
	private JsonDeserializers _JsonDeserializers;
	[Inject]
	private TemperatureData _TemperatureData;
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
		var geo = await GetTextAsync<Response.Geo.Root>(UnityWebRequest.Get($"http://api.openweathermap.org/geo/1.0/direct?q={_TemperatureData.City},{_TemperatureData.StateCode},{_TemperatureData.CountryCode}&limit={1}&appid={_TemperatureData.ApiKey}"));
		var forecast = await GetTextAsync<Response.Forecast.Root>(UnityWebRequest.Get($"http://api.openweathermap.org/data/2.5/weather?lat={geo.lat}&lon={geo.lon}&appid={_TemperatureData.ApiKey}"));
		
		Debug.Log($"Temp: {forecast?.main?.temp}");
	}

}
