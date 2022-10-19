using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.Linq;
using UnityEngine;
using Zenject;
public class RotationController : CubeTemperatureController<CurrentColorData, RotationConfig>, IDisposable {

	[Inject]
	private Transform _Transform;
	private RotationConfig _CurrentConfig;

	private readonly CancellationTokenSource _CancellationTokenSource = new();

	public override async void Initialize() {
		base.Initialize();
		await foreach (var _ in UniTaskAsyncEnumerable.EveryUpdate().WithCancellation(_CancellationTokenSource.Token)) {
			if (_CurrentConfig == null)
				continue;
			_Transform.Rotate(Vector3.up, _CurrentConfig.Object.Value * Time.deltaTime);
		}
	}

	protected override void ApplyConfig(RotationConfig config) {
		_CurrentConfig = config;
	}

	public void Dispose() {
		_CancellationTokenSource.Cancel();
		_CancellationTokenSource?.Dispose();
	}
}
