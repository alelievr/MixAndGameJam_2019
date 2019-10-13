using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameState : MonoBehaviour
{
    public static GameState instance;

    public List< MeleeUnit >    unitsOnLane1 = new List<MeleeUnit>();
    public List< MeleeUnit >    unitsOnLane2 = new List<MeleeUnit>();

    public List< MeleeUnit >    enemyUnitsOnLane1 => unitsOnLane1.Where(u => u.tag == "ennemy").ToList();
    public List< MeleeUnit >    enemyUnitsOnLane2 => unitsOnLane2.Where(u => u.tag == "ennemy").ToList();

    public List< MeleeUnit >    allyUnitsOnLane1 => unitsOnLane1.Where(u => u.tag != "ennemy").ToList();
    public List< MeleeUnit >    allyUnitsOnLane2 => unitsOnLane2.Where(u => u.tag != "ennemy").ToList();

    void Awake()
    {
        instance = this;
    }
}
