using System;
using UniRx;
[Serializable]
public class CurrentTemperature {
	public FloatReactiveProperty Value = new FloatReactiveProperty();
}
