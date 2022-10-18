using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using Testing;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using Zenject;

public partial class Test_PlayMode {
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

}
