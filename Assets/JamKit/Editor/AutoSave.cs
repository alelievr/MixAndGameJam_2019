using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;
using System;

[InitializeOnLoad]
public class AutoSave
{
	static public float		saveTimeout = 60 * 2; //2 mins

	static double			lastSave;

	static AutoSave()
	{
		EditorApplication.update += Update;
	}

	static void Update()
	{
		if (EditorApplication.timeSinceStartup - lastSave > saveTimeout)
			Save();
	}

	static void Save()
	{
		if (EditorApplication.isPlaying || EditorApplication.isPaused)
			return ;
		Scene sc = EditorSceneManager.GetActiveScene();
		if (sc.isDirty && !String.IsNullOrEmpty(sc.path))
			EditorSceneManager.SaveScene(sc);
		AssetDatabase.SaveAssets();
		lastSave = EditorApplication.timeSinceStartup;
	}
}
