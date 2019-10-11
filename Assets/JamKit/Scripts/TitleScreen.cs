using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreen : MonoBehaviour
{
	public string		nextLevelName = "Game";
	public KeyCode[]	nextSceneKeys;

	void Update()
	{
		foreach (var key in nextSceneKeys)
			if (Input.GetKeyDown(key))
				SceneTransition.instance.LoadScene(nextLevelName);
	}

}
