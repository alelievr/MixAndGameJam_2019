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
        if (GameManager.instance.mode == ViewMode.TopDown)
        {
            bgbar.rotation = Quaternion.Euler (90, 0, 0);
            bar.rotation = Quaternion.Euler (90, 0, 0);
            bgbar.position = new Vector3 (bgbar.transform.position.x, 0, target.transform.position.z + 1);
            bar.position = new Vector3 (bar.position.x, 0, target.transform.position.z + 1);

        }
        if (GameManager.instance.mode == ViewMode.SideScroll)
        {
            bgbar.rotation = Quaternion.Euler (0, 0, 0);
            bar.rotation = Quaternion.Euler (0, 0, 0);
            bgbar.position = new Vector3 (bgbar.transform.position.x, target.transform.position.y + 1, 0);
            bar.position = new Vector3 (bar.position.x, target.transform.position.y + 1, 0);
        }
        bar.localScale = new Vector3 (fillAmount, 1, 1);
    }
}