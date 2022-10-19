using UnityEngine;
using Zenject;

public class GameMainInstaller : MonoInstaller {
    [SerializeField]
    private CurrentTemperatureData currentTemperatureData;


    [SerializeField]
    private Object _Cube;
    public override void InstallBindings() {
        
        Container.BindInterfacesAndSelfTo<TemperatureService>().AsSingle();
        Container.BindInterfacesAndSelfTo<CurrentTemperatureData>().FromInstance(currentTemperatureData).AsSingle();
        Container.BindFactory<Cube, Cube.Factory>().FromComponentInNewPrefab(_Cube).UnderTransformGroup("Cubes");
        Container.BindInterfacesTo<CubeSpawner>().AsSingle();
    }
}

