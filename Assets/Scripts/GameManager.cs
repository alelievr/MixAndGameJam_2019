using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    float timeBeforeCall = 2.0f;
    float timer;
    public UnityEvent changeEvent = null;
    public GameManager instance = null;

    // Start is called before the first frame update
    void Start()
    {
        if (instance != null){
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }

        if (changeEvent == null)
        {
            changeEvent = new UnityEvent();
            
        }
        changeEvent.AddListener(CallForChange);
        timer = timeBeforeCall;
        DontDestroyOnLoad(this);
    }

    void CallForChange()
    {
        Debug.Log("ITS TIME FOR CHANGE!!!");
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            changeEvent.Invoke();
            timer = timeBeforeCall;
        }
    }
}
