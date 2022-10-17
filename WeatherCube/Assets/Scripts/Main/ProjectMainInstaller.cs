using Zenject;
public class ProjectMainInstaller : MonoInstaller {
	public override void InstallBindings() {
		Container.BindInterfacesAndSelfTo<JsonDeserializers>().AsSingle();
	}
}
