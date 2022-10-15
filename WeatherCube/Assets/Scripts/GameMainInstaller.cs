
using UnityEngine;
using Zenject;

public class GameMainInstaller : MonoInstaller
{
    public override void InstallBindings() {

        Container.BindInterfacesAndSelfTo<TemperatureService>().AsSingle();
    }
}



public interface ITemperatureSource {
    float Temperature(float kValue);
}
public class CTemperature:ITemperatureSource {
    float ITemperatureSource.Temperature(float kValue)=>Mathf.Round((kValue - 273.15f)*10)/10;
}

public class FTemperature:ITemperatureSource {

    float ITemperatureSource.Temperature(float kValue)=>Mathf.Round(((kValue-273.15f) * 9/5 + 32)*10)/10;
}
