using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Spawner : MonoBehaviour
{
    public int nblane = 2;
    public void unitInvoke (GameObject unit, bool enemy, int lane)
    {
        var o = GameObject.Instantiate (unit);
        o.GetComponent<MeleeUnit> ().lane = lane;

        if (enemy)
        {
            o.GetComponent<MeleeUnit> ().lane = Random.Range (0, nblane);
            o.tag = "ennemy";
            foreach (Transform c in o.transform)
                c.gameObject.tag = "ennemy";
        }
        if (lane == 0)
            GameState.instance.unitsOnLane1.Add(o.GetComponent<MeleeUnit>());
        else
            GameState.instance.unitsOnLane2.Add(o.GetComponent<MeleeUnit>());
    }
}