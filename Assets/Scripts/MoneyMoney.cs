using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyMoney : MonoBehaviour
{

    public GameObject moneyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        Gain("25", new Vector3(0,0,0));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Gain(string number, Vector3 pos)
    {
        var tmp = Instantiate(moneyPrefab, pos, Quaternion.identity);

        tmp.GetComponent<TextMesh>().text = "+" + number;
        tmp.transform.LookAt(Camera.main.transform);
        StartCoroutine(MoveFromTo(tmp));
    }

    IEnumerator MoveFromTo(GameObject tmp)
    {
        var color = tmp.GetComponent<MeshRenderer>();
        float t = 0;
        while (t < 1)
        {
            t += Time.deltaTime;
            tmp.transform.position = tmp.transform.position + Camera.main.transform.up * 20 * Time.deltaTime;
            color.material.color = new Color(1, 1, 1, 1 - t);
            yield return new WaitForEndOfFrame();         // Leave the routine and return here in the next frame
        }
    }
}
