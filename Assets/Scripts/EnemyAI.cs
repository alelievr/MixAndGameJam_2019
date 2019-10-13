using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public enum Strategy
{
    Easy,
    Medium,
}

[RequireComponent(typeof(Spawner))]
public class EnemyAI : MonoBehaviour
{
    public int          startGold = 50;
    public int          gold;

    public Strategy strategy;
    Spawner         spawner;

    public int      incomePerSecond = 1;

    public static EnemyAI   instance;

    public MeleeUnit[]   spawnableEnemies;

    List<MeleeUnit>     enemiesByPrice;
    bool                isSpawning = false;

    public float        spawnTimer = 1.5f;

    bool started = false;

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
        enemiesByPrice = spawnableEnemies.ToList().OrderByDescending(m => m.price).ToList();

        StartCoroutine(Income());
        StartCoroutine(Startup());
    }

    IEnumerator Income()
    {
        while (true)
        {
            gold += incomePerSecond;
            yield return new WaitForSeconds(1);
        }
    }

    IEnumerator Startup()
    {
        yield return new WaitForSeconds(4f);
        started = true;
    }

    void Update()
    {
        if (!started)
            return;

        switch (strategy)
        {
            default:
            case Strategy.Easy:
                UpdateEasy();
                break;
            case Strategy.Medium:
                UpdateMedium();
                break;
        }
    }

    MeleeUnit FindEnemy(UnitType type) => spawnableEnemies.FirstOrDefault(m => m.type == type);

    IEnumerator Spawn(MeleeUnit enemy, bool lane, float spawnTimer)
    {
        gold -= enemy.price;
        isSpawning = true;
        spawner.unitInvoke(enemy.gameObject, true, lane ? 0 : 1);
        yield return new WaitForSeconds(spawnTimer);
        isSpawning = false;
    }

    IEnumerator SpawnMultiple(List<UnitType> types, bool lane)
    {
        isSpawning = true;
        foreach (var type in types)
        {
            var enemy = FindEnemy(type);
            gold -= enemy.price;
            spawner.unitInvoke(enemy.gameObject, true, lane ? 0 : 1);
            yield return new WaitForSeconds(spawnTimer);
        }
        isSpawning = false;
    }

    int GetSquadPrice(List< UnitType > types)
    {
        int price = 0;

        foreach (var e in types)
            price += FindEnemy(e).price;

        return price;
    }

    void UpdateEasy()
    {
        if (isSpawning)
            return;

        // TODO: wait if there is no danger and spawn bigger units

        foreach (var e in enemiesByPrice)
        {
            if (gold > e.price * 1.5f)
            {
                StartCoroutine(Spawn(e, Random.value > 0.5f, spawnTimer));
                return;
            }
        }
    }

    List< List< UnitType > > squads = new List<List<UnitType>>
    {
        new List<UnitType>{ UnitType.Melee, UnitType.chariot, UnitType.Bow, UnitType.Bow },
        new List<UnitType>{ UnitType.chariot, UnitType.Bow, UnitType.Bow },
        new List<UnitType>{ UnitType.griffon, UnitType.Bow },
        new List<UnitType>{ UnitType.griffon, UnitType.Melee },
        new List<UnitType>{ UnitType.Melee, UnitType.Melee, UnitType.Bow, UnitType.Bow },
        new List<UnitType>{ UnitType.Melee, UnitType.Melee, UnitType.Bow },
        new List<UnitType>{ UnitType.Melee, UnitType.Bow },
    };

    void UpdateMedium()
    {
        if (isSpawning)
            return;
        
        // TODO: choose if we defend or attack
        MediumDefendUpdate();
    }

    void MediumDefendUpdate()
    {
        bool laneToSpawn = GameState.instance.allyUnitsOnLane1.Count > GameState.instance.allyUnitsOnLane2.Count;

        // Spawn a squad:
        foreach (var squad in squads)
        {
            if (gold > GetSquadPrice(squad))
            {
                StartCoroutine(SpawnMultiple(squad, laneToSpawn));
                return;
            }
        }
    }
}
