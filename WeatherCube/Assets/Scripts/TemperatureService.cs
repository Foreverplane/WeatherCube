using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using Zenject;
public class TemperatureService : IInitializable {

	[Inject]
	private TemperatureData _TemperatureData;
	public async void Initialize() {
		async UniTask<string> GetTextAsync(UnityWebRequest req)
		{
			var op = await req.SendWebRequest();
			Debug.Log($"{op.downloadHandler.text}");
			return op.downloadHandler.text;
		}
		
		var task1 = GetTextAsync(UnityWebRequest.Get("https://api.openweathermap.org/data/3.0/weather?q=" + _TemperatureData.City + "&appid=" + _TemperatureData.ApiKey));
		await task1;
	}
}
