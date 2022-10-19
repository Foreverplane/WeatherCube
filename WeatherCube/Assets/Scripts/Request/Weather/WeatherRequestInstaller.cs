using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "WeatherRequestInstaller", menuName = "Installers/WeatherRequestInstaller")]
public class WeatherRequestInstaller : ScriptableObjectInstaller<WeatherRequestInstaller> {
    [SerializeField]
    private WeatherRequestData _WeatherRequestData;
    public override void InstallBindings() {
        Container.BindInterfacesAndSelfTo<WeatherRequestData>().FromInstance(_WeatherRequestData).AsSingle();
    }
}