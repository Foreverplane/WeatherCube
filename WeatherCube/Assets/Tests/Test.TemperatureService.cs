using System.Collections;
using NUnit.Framework;
using Testing;
using UnityEngine;
using UnityEngine.TestTools;
using Zenject;
public partial class Test_PlayMode {
	private const int TEMPERATURE_REQUEST_TIME = 10;
	[UnityTest]
	public IEnumerator Is_TemperatureService_Can_Get_Temperature_In_10sec() {
		var container = new DiContainer();
		container.Bind<WeatherRequestData>().AsSingle();
		container.Bind<ITemperatureConverter>().FromInstance(new FTemperature()).AsSingle();
		container.Bind<CurrentTemperatureData>().AsSingle();
		container.Bind<JsonDeserializers>().AsSingle();
		container.BindInterfacesAndSelfTo<TemperatureService>().AsSingle();
		float waitTime = 0;
		var tempService = container.Resolve<TemperatureService>();
		tempService.Initialize();
		while (tempService.InitializationResult.ResultType == ResultType.None && waitTime < TEMPERATURE_REQUEST_TIME) {
			yield return null;
			waitTime += Time.deltaTime;
		}
		Assert.That(tempService.InitializationResult.ResultType, Is.EqualTo(ResultType.Success), $"Temperature service initialization failed: {tempService.InitializationResult.Message}");
	}
}
