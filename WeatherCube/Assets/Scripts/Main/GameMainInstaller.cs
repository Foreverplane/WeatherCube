using UnityEngine;
using Zenject;

public class GameMainInstaller : MonoInstaller {
    [SerializeField]
    private CurrentTemperature _CurrentTemperature;
    public override void InstallBindings() {
        
        Container.BindInterfacesAndSelfTo<TemperatureService>().AsSingle();
        Container.BindInterfacesAndSelfTo<CurrentTemperature>().FromInstance(_CurrentTemperature).AsSingle();
    }
}