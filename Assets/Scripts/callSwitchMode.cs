using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class callSwitchMode : MonoBehaviour
{
    public GameObject otherButton;
    public bool isTopDown = true;
    void Start()
    {
        GameManager.instance.changeMode.AddListener(switchButton);
    }

    void switchButton()
    {
        otherButton.SetActive(isTopDown != (GameManager.instance.mode == ViewMode.TopDown));
        gameObject.SetActive(isTopDown == (GameManager.instance.mode == ViewMode.TopDown));
    }

    public void switchMode()
    {
        GameManager.instance.SwitchMode();
    }
}
