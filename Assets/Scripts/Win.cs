using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    string nextScene;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.win.AddListener(Wination);
    }
	
	protected IEnumerator WaitForNext()
	{
		yield return null; //wait one frame in case the scene just loaded
		yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(nextScene);
	}

    // Update is called once per frame
    void Wination()
    {
        StartCoroutine(WaitForNext());
        // transform.GetChild(0).gameObject.SetActive(true);
    }
}
