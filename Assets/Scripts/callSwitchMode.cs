using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class callSwitchMode : MonoBehaviour
{
    public void switchMode()
    {
        GameManager.instance.SwitchMode();
    }
}
