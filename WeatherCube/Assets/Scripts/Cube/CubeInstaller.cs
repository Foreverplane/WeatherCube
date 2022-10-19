using System;
using UnityEngine;
using Zenject;

public class CubeInstaller : MonoInstaller<CubeInstaller> {
	[SerializeField]
	private Renderer _Renderer;

	[SerializeField]
	private Transform _Transform;
	
	[SerializeField]
	private CurrentColorData currentColorData;

	private void OnValidate() {
		_Transform = transform;
		_Renderer = GetComponentInChildren<Renderer>(true);
	}

	public override void InstallBindings() {
		Container.BindInterfacesAndSelfTo<CurrentColorData>().FromInstance(currentColorData).AsSingle();
		Container.BindInterfacesAndSelfTo<Renderer>().FromInstance(_Renderer).AsSingle();
		Container.BindInterfacesAndSelfTo<Transform>().FromInstance(_Transform).AsSingle();
		Container.BindInterfacesAndSelfTo<ColorController>().AsSingle();
		Container.BindInterfacesAndSelfTo<RotationController>().AsSingle();
	}
}
