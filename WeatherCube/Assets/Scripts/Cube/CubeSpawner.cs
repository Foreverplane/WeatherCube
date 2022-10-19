using Zenject;
public class CubeSpawner : IInitializable {

	private readonly Cube.Factory _Factory;

	public CubeSpawner(Cube.Factory factory) {
		_Factory = factory;
	}

	public void Initialize() {
		_Factory.Create();
	}
}
