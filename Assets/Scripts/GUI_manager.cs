using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUI_manager : MonoBehaviour
{

    [System.Serializable]
    public class Unit
    {
        public int    id;
        public Sprite sprite;
        public string name;
    }

    [System.Serializable]
    public class Line
    {
        public int id;
        public Color color;
    }

    public Line curLine;
    public GameObject lineVisual;
    [Space]

    public GameObject blocPrefab;
    public GameObject itemPanel;
    [Space]

    public List<Unit> unitList = new List<Unit>();
    public List<Line> Lines;

    //private List<GameObject> usableUnitList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        ChangeLine(1);
        foreach (Unit unit in unitList)
        {
            var tmp = Instantiate(blocPrefab, itemPanel.transform);
            tmp.GetComponent<Image>().sprite = unit.sprite;
            tmp.GetComponent<Button>().onClick.AddListener(() => UnitOnClick(unit.id));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            ChangeLine(1);
        }
        else if (Input.GetKeyDown("2"))
        {
            ChangeLine(2);
        }
        else if (Input.GetKeyDown("q"))
        {
            UnitOnClick(1);
        }
        else if (Input.GetKeyDown("w"))
        {
            UnitOnClick(2);
        }
        else if (Input.GetKeyDown("e"))
        {
            UnitOnClick(3);
        }
        else if (Input.GetKeyDown("r"))
        {
            UnitOnClick(4);
        }
        else if (Input.GetKeyDown("t"))
        {
            UnitOnClick(5);
        }
    }

    void UnitOnClick(int id) {
        Unit unit = unitList.Find(x => x.id == id);
        if (unit != null) {
            Debug.Log(unit.name);
        }
    }

    public void ChangeLine(int id) {
        Line line = Lines.Find(x => x.id == id);
        if (line != null) {
            curLine = line;
            lineVisual.GetComponent<Image>().color = line.color;
        }
    }
}