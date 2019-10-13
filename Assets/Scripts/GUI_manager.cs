﻿using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public enum UnitType
{
    Melee,
    Bow,
    chariot,
    griffon,
    // Tank,
}

public class GUI_manager : MonoBehaviour
{
    [System.Serializable]
    public class Unit
    {
        public UnitType id;
        public Sprite sprite;
        public string name;
        public GameObject meleeUnit;
        public int price;
        public float spawnTime = 1;
    }

    [System.Serializable]
    public class Line
    {
        public int id;
        public Color color;
    }

    [Header ("Line")]
    public Line curLine;
    public GameObject lineVisual;
    [Space]

    [Header ("Trucs")]
    public GameObject blocPrefab;
    public GameObject itemPanel;
    [Space]

    [Header ("Units")]
    public List<Unit> unitList = new List<Unit> ();
    public List<Line> Lines;

    [Space, Header ("Gold")]
    public Text goldText;

    public Queue< Unit >   unitsToSpawnLane1 = new Queue<Unit>();
    public Queue< Unit >   unitsToSpawnLane2 = new Queue<Unit>();

    public Spawner spawner;

    //private List<GameObject> usableUnitList = new List<GameObject>();

    // Start is called before the first frame update
    void Start ()
    {
        ChangeLine (0);
        foreach (Unit unit in unitList)
        {
            var tmp = Instantiate (blocPrefab, itemPanel.transform);
            tmp.GetComponent<Image> ().sprite = unit.sprite;
            tmp.GetComponent<Button> ().onClick.AddListener (() => UnitOnClick (unit.id));
        }

        spawner = GetComponent<Spawner> ();
    }

    // Update is called once per frame
    void Update ()
    {
        if (Input.GetKeyDown ("1"))
        {
            ChangeLine (0);
        }
        else if (Input.GetKeyDown ("2"))
        {
            ChangeLine (1);
        }
        else if (Input.GetKeyDown ("q"))
        {
            UnitOnClick (UnitType.Melee);
        }
        else if (Input.GetKeyDown ("w"))
        {
            UnitOnClick (UnitType.Bow);
        }
        else if (Input.GetKeyDown ("e"))
        {
            UnitOnClick (UnitType.chariot);
        }
        else if (Input.GetKeyDown ("r"))
        {
            UnitOnClick (UnitType.griffon);
        }
        else if (Input.GetKeyDown ("t"))
        {
            // UnitOnClick(5);
        }

        goldText.text = GameManager.instance.gold.ToString ();
    }

    void UnitOnClick (UnitType id)
    {
        Unit unit = unitList.Find (x => x.id == id);

        if (unit != null && unit.price <= GameManager.instance.gold)
        {
            if (curLine.id == 1)
            {
                if (unitsToSpawnLane1.Count > 2)
                    AudioManager.instance.PlayInvalidActionSound();
                else
                    unitsToSpawnLane1.Enqueue(unit);
            }
            else
                if (unitsToSpawnLane2.Count > 2)
                    AudioManager.instance.PlayInvalidActionSound();
                else
                    unitsToSpawnLane2.Enqueue(unit);

            GameManager.instance.gold -= unit.price;
        }
    }

    public void ChangeLine (int id)
    {
        Line line = Lines.Find (x => x.id == id);
        if (line != null)
        {
            curLine = line;
            lineVisual.GetComponent<Image> ().color = line.color;
        }
    }
}