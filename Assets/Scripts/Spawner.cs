using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public int nblane = 2;
    public void unityInvoke(MeleeUnit unit)
    {
        GameObject.Instantiate(unit);
        unit.lane = Random.Range(0, nblane) + 1; 
    }

}
