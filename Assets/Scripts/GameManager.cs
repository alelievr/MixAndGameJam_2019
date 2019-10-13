using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;

public enum ViewMode
{
    SideScroll,
    TopDown,
}

public class GameManager : MonoBehaviour
{
    public UnityEvent changeMode = new UnityEvent ();
    public static GameManager instance = null;

    public Transform playerSpawnPosition;
    public Transform enemiesSpawnPosition;

    public ViewMode mode { get; private set; } = ViewMode.SideScroll;

    public int gold = 0;

    // two lanes are between 0
    public float laneInterval;
    public float laneWidth;
    public float flypos;
    public float ypos;

    void Awake ()
    {
        if (instance != null)
            Destroy (gameObject);
        else
            instance = this;

        DontDestroyOnLoad (this);
    }

    public void SwitchMode ()
    {
        changeMode.Invoke ();
        mode = mode == ViewMode.SideScroll ? ViewMode.TopDown : ViewMode.SideScroll;
    }

    void Update ()
    {
        if (Input.GetKeyDown (KeyCode.S))
        {
            SwitchMode ();
        }
    }

    public void Win()
    {
        Debug.Log("WIN !!!!");
    }

    public void Lose()
    {
        Debug.Log("Lose !!!!");
    }
}