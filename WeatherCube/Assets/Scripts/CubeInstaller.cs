using System;
using UnityEngine;
using Zenject;

public class CubeInstaller : MonoInstaller<CubeInstaller> {
    [SerializeField]
    private Renderer _Renderer;

    private void OnValidate() {
        _Renderer = GetComponent<Renderer>();
    }

    public override void InstallBindings() {
        Container.BindInterfacesAndSelfTo<Renderer>().FromInstance(_Renderer).AsSingle();
        Container.BindInterfacesAndSelfTo<ColorService>().AsSingle();
    }
}