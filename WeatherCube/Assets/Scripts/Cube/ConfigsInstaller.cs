using System.Collections.Generic;
using UnityEngine;
using Zenject;



public abstract class ConfigsInstaller<TConfig> : ScriptableObjectInstaller<ConfigsInstaller<TConfig>> {

	[SerializeField]
	private List<TConfig> _Configs;

	public override void InstallBindings() {
		Container.BindInterfacesAndSelfTo<List<TConfig>>().FromInstance(_Configs).AsSingle();
	}
}