using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{

    public Transform    aim;
    public float        translationSpeed = 0.5f;
    public float        rotationDuration = 0.3f;

    void Start()
    {
        GameManager.instance.changeMode.AddListener(ToggleViewMode);
        // TODO: register to change view event in game manager
    }

    void SwitchToSideScrollerView()
    {
        transform.DORotate(new Vector3(0, 0, 0), rotationDuration, RotateMode.Fast);
    }

    void SwitchToTopDownView()
    {
        transform.DORotate(new Vector3(90, 0, 0), rotationDuration, RotateMode.Fast);
    }

    void ToggleViewMode()
    {
        if (GameManager.instance.mode == ViewMode.TopDown)
            SwitchToSideScrollerView();
        else
            SwitchToTopDownView();
    }

    void Update()
    {
        aim?.Translate(Vector3.right * Input.GetAxisRaw("Horizontal"));
    }
}
