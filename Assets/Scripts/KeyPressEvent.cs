using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class KeyPressEvent : MonoBehaviour
{
    public UnityEvent   callback;
    public InputAction  input;

    void Start()
    {
        input.performed += c => {
            callback.Invoke();
            Debug.Log("fiuehwgi");
        };
    }
}
