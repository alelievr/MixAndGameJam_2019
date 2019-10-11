using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyOnLoadUnique : MonoBehaviour
{
	[HideInInspector]
	public bool	destroyOnLoad = false;

	public static DontDestroyOnLoadUnique	firstInstance;

	void Awake()
	{
		if (firstInstance != null)
		{
			Destroy(gameObject);
			return ;
		}
		
		firstInstance = this;
		DontDestroyOnLoad(gameObject);
	}
}
