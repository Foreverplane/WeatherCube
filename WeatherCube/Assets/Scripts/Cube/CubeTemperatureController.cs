using System;
using System.Collections.Generic;
using System.Linq;
using DynamicExpresso;
using ModestTree;
using UniRx;
using UnityEngine;
using Zenject;
public abstract class CubeTemperatureController<TData, TConfigs> : IInitializable
	where TConfigs : ICondition
	where TData : ISubscriptionData {
	[Inject]
	protected TData Data;
	[Inject]
	protected List<TConfigs> Configs;
	public virtual void Initialize() {
		Assert.That(Configs.Count > 0, $"No configs for: {GetType().Name} found");
		Data.Subscribe((val) => {
			var config = Configs.FirstOrDefault(x => x.Check(val));
			// Debug.Log("Found config: " + config);
			ApplyConfig(config);
		});
	}
	protected abstract void ApplyConfig(TConfigs config);
}
