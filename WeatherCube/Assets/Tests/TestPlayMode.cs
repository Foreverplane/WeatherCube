using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using Testing;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using Zenject;

public partial class TestPlayMode {
	private AsyncOperation _LoadingRoutine;

	[UnitySetUp]
	public IEnumerator SetupRoutine() {

		if (_LoadingRoutine != null)
			yield break;
		Debug.Log("SetupRoutine");
		_LoadingRoutine = SceneManager.LoadSceneAsync("SampleScene", LoadSceneMode.Single);
		while (!_LoadingRoutine.isDone) {
			yield return null;
		}
	}

	[Test]
	public void Test_IsCubeSpawned() {
		Debug.Log("Test_IsCubeSpawned");
		// Use the Assert class to test conditions
		CheckIfValuableObjectExist<CubeInstaller>();
	}

	[Test]
	public void Test_IsGameMainInstallerExist() {
		Debug.Log("Test_IsCubeSpawned");
		CheckIfValuableObjectExist<GameMainInstaller>();
	}

	private T CheckIfValuableObjectExist<T>() where T : Object {
		var valuableObject = Object.FindObjectOfType<T>(true);
		Assert.IsTrue(valuableObject != null, $"{valuableObject.GetType().Name}");
		return valuableObject;
	}

}
