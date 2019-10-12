using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    public enum ViewMode
    {
        SideScroll,
        TopDown,
    }

    public Transform    aim;
    public float        translationSpeed = 0.5f;
    public float        rotationDuration = 0.3f;
    ViewMode            mode = ViewMode.SideScroll;

    void Start()
    {
        // TODO: register to change view event in game manager
    }

    void SwitchToSideScrollerView()
    {
        transform.DORotate(new Vector3(0, 0, 0), rotationDuration, RotateMode.Fast);
        mode = ViewMode.SideScroll;
    }

    void SwitchToTopDownView()
    {
        transform.DORotate(new Vector3(90, 0, 0), rotationDuration, RotateMode.Fast);
        mode = ViewMode.TopDown;
    }

    void ToggleViewMode()
    {
        if (mode == ViewMode.TopDown)
            SwitchToSideScrollerView();
        else
            SwitchToTopDownView();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            ToggleViewMode();
        }

        aim?.Translate(Vector3.right * Input.GetAxisRaw("Horizontal"));
    }
}
