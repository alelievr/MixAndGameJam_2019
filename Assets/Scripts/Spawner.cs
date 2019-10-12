using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public int nblane = 2;
    public void unitInvoke(GameObject unit, bool enemy)
    {
        var o = GameObject.Instantiate(unit);
        o.GetComponent<MeleeUnit>().lane = Random.Range(0, nblane) + 1; 

        if (enemy)
        {
            o.tag = "ennemy";
            foreach (Transform c in o.transform)
                c.gameObject.tag = "ennemy";
        }
    }

}
