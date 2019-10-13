using UnityEngine;
using UnityEngine.Events;
using System.Linq;

public class KeyPressEvent : MonoBehaviour
{
    public KeyCode[]    keys;
    public UnityEvent   callback;

    void Update()
    {
        if (keys.Any(k => Input.GetKeyDown(k)))
            callback.Invoke();
    }
}
