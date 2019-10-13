using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public MeleeUnit target;
    public Transform bar;
    public Transform bgbar;

    float fillAmount = 1;
    // Start is called before the first frame update
    void Start () { }

    // Update is called once per frame
    void Update ()
    {
        fillAmount = (float) target.health / (float) target.fullHealth;
        Debug.Log (fillAmount);
        bgbar.position = new Vector3 (target.transform.position.x, target.transform.position.y + 1, bgbar.position.z);
        bar.position = new Vector3 (bar.position.x, target.transform.position.y + 1, bar.position.z);
        bar.localScale = new Vector3 (fillAmount, 1, 1);
        gameObject.transform.rotation = new Quaternion (Camera.main.transform.rotation.x, 0, 0, 1);
    }
}