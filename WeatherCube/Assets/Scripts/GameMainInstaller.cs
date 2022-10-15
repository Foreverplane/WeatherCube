using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using Zenject;

public class GameMainInstaller : MonoInstaller
{
    public override void InstallBindings() {

        Container.BindInterfacesAndSelfTo<TemperatureService>().AsSingle();
    }
}