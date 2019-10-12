using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[RequireComponent(typeof(Spawner))]
public class EnemyDebile : MonoBehaviour
{
    [System.Serializable]
    public class MeleeUnitRatio
    {
        public MeleeUnit meleeUnit;
        public float ratio;

    }
    public List<MeleeUnitRatio> listToSpawnWithRatio = null;
    public float chanceToSpawnEnemybySecond = 1;
    float totalRatio = 0;
    Spawner spawner;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        spawner = GetComponent<Spawner>();
        listToSpawnWithRatio.ForEach(e => totalRatio += e.ratio);
    }

    MeleeUnit chooseUnit()
    {
        float rand = Random.Range (0f, totalRatio);
        foreach (var unit in listToSpawnWithRatio)
        {
            if ((rand -= unit.ratio) < 0)
                return (unit.meleeUnit);
        }
        return (listToSpawnWithRatio.LastOrDefault().meleeUnit);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.deltaTime > Random.Range(0f, 1f / chanceToSpawnEnemybySecond))
            spawner.unityInvoke(chooseUnit());
    }
}
