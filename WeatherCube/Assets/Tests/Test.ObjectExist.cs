using NUnit.Framework;
using UnityEngine;
public partial class Test_PlayMode {
	[Test]
	public void Is_CubeInstaller_Spawned_On_Scene_Loaded() {
		CheckIfValuableObjectExist<CubeInstaller>();
	}
	[Test]
	public void Is_GameMainInstaller_Exists_On_Scene_Loaded() {
		CheckIfValuableObjectExist<GameMainInstaller>();
	}
	private T CheckIfValuableObjectExist<T>() where T : Object {
		var valuableObject = Object.FindObjectOfType<T>(true);
		Assert.IsTrue(valuableObject != null, $"{valuableObject.GetType().Name}");
		return valuableObject;
	}
}
