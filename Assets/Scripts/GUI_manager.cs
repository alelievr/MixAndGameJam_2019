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

    public List<Unit> unitList;
    public List<Line> Lines;

    //private List<GameObject> usableUnitList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        foreach (Unit unit in unitList)
        {
            var tmp = Instantiate(blocPrefab, itemPanel.transform);
            tmp.GetComponent<Image>().sprite = unit.sprite;
            tmp.GetComponent<Button>().onClick.AddListener(() => UnitOnClick(unit.name));
            //usableUnitList.Add(tmp);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("1")) {
            ChangeLine(Lines.Find(x => x.id == 1));
        } else if (Input.GetKeyDown("2")) {
            ChangeLine(Lines.Find(x => x.id == 2));

        }
    }

    void UnitOnClick(string name) {
        Debug.Log(name);
    }

    void ChangeLine(Line line) {
        curLine = line;
        lineVisual.GetComponent<Image>().color = line.color;
    }
}
