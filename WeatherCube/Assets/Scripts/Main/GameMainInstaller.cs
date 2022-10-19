using EasyButtons;
using UnityEngine;
using UnityEngine.Events;
using Zenject;
using Object = UnityEngine.Object;

public class GameMainInstaller : MonoInstaller {
	[SerializeField]
	private CurrentTemperatureData _CurrentTemperatureData;

	// for testing purposes
	private readonly RequestTemperatureProvider _ButtonProvider = new RequestTemperatureProvider();

	[SerializeField]
	private Object _Cube;
	public override void InstallBindings() {

		Container.BindInterfacesAndSelfTo<RequestTemperatureProvider>().FromInstance(_ButtonProvider).AsSingle();
		Container.BindInterfacesAndSelfTo<TemperatureService>().AsSingle();
		Container.BindInterfacesAndSelfTo<CurrentTemperatureData>().FromInstance(_CurrentTemperatureData).AsSingle();
		Container.BindFactory<Cube, Cube.Factory>().FromComponentInNewPrefab(_Cube).UnderTransformGroup("Cubes");
		Container.BindInterfacesTo<CubeSpawner>().AsSingle();
	}

	[Button]
	public void RequestTemperature() {
		_ButtonProvider.Action?.Invoke();
	}
}
