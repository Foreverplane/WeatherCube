using UniRx;
using UnityEngine;
using Zenject;

public class ColorController : CubeTemperatureController<CurrentTemperatureData,ColorConfig> {

	[Inject]
	private Renderer _Renderer;

	[Inject]
	private CurrentColorData _CurrentColorData;

	public override void Initialize() {
		base.Initialize();
		_CurrentColorData.Property.SkipLatestValueOnSubscribe().Subscribe((x) => {
			_Renderer.material.color = x.Value;
		});
	}

	protected override void ApplyConfig(ColorConfig config) {
		_CurrentColorData.Property.SetValueAndForceNotify(config.Object);
	}
}