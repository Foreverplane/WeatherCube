using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    public override void InstallBindings() {
        Container.BindInterfacesAndSelfTo<TemperatureData>().AsSingle();
        
        Container.BindInterfacesAndSelfTo<TemperatureService>().AsSingle();
    }
}