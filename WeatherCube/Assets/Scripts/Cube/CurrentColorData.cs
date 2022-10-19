using System;
using UniRx;
[Serializable]
public class CurrentColorData : ISubscriptionData {
	public ColorReferenceReactiveProperty Property = new ColorReferenceReactiveProperty();
	public void Subscribe(Action<object> obj) {
		Property.SkipLatestValueOnSubscribe().Subscribe(obj.Invoke);
	}
}
