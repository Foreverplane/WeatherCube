using UniRx;
using UnityEngine;
using Zenject;
public class ColorService : IInitializable {

	[Inject]
	private CurrentTemperature _CurrentTemperature;
	public void Initialize() {
		_CurrentTemperature.Value.SkipLatestValueOnSubscribe().Subscribe((val) => {
			// Debug.Log($"Color: {val}");
		});
	}
}
