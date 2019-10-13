using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public enum Strategy
{
    Easy,
}

[RequireComponent(typeof(Spawner))]
public class EnemyAI : MonoBehaviour
{
    public int  startGold = 50;
    public int         gold;

    public Strategy strategy;
    Spawner         spawner;

    public static EnemyAI   instance;

    public MeleeUnit[]   spawnableEnemies;

    List<MeleeUnit>     enemiesByPrice;
    bool                isSpawning = false;

    void Awake()
    {
        if (instance != null)
            Debug.LogError("There are two enemy AI in the scene !");
        instance = this;
    }

    void Start()
    {
        gold = startGold;
        spawner = GetComponent<Spawner>();
        enemiesByPrice = spawnableEnemies.ToList().OrderBy(m => m.price).ToList();
    }

    void Update()
    {
        switch (strategy)
        {
            default:
            case Strategy.Easy:
                UpdateEasy();
                break;
        }
    }

    GameObject FindEnemy(UnitType type) => spawnableEnemies.FirstOrDefault(m => m.type == type).gameObject;

    IEnumerator Spawn(MeleeUnit enemy)
    {
        gold -= enemy.price;
        isSpawning = true;
        spawner.unitInvoke(enemy.gameObject, true, Random.value > 0.5f ? 0 : 1);
        yield return new WaitForSeconds(1.5f);
        isSpawning = false;
    }

    void UpdateEasy()
    {
        if (isSpawning)
            return;

        // TODO: wait if there is no danger and spawn bigger units

        foreach (var e in enemiesByPrice)
        {
            if (gold > e.price * 2)
                StartCoroutine(Spawn(e));
        }
    }
}
