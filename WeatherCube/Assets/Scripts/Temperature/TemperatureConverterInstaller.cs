using Zenject;
public abstract class TemperatureConverterInstaller<TConverter>  :ScriptableObjectInstaller<TemperatureConverterInstaller<TConverter>> where TConverter : ITemperatureConverter {
	public override void InstallBindings() {
		Container.BindInterfacesAndSelfTo<TConverter>().AsSingle();
	}
}
