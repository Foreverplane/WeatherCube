using System;
using UniRx;
[Serializable]
public class CurrentTemperatureData : ISubscriptionData {
	public FloatReactiveProperty Property = new FloatReactiveProperty();

	public void Subscribe(Action<object> obj) {
		Property.SkipLatestValueOnSubscribe().Subscribe((v) => {
			obj.Invoke(v);
		});
	}
}