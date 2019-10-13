using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;

class GUIQueueManager : MonoBehaviour
{
    public Image[]  queueImage;
    public Slider   queueSlider;

    public bool     lane1;

    GUI_manager manager;

    bool isSpawningUnit = false;

    Sprite  defaultSprite;

    void Start()
    {
        manager = FindObjectOfType<GUI_manager>();
        defaultSprite = queueImage[0].sprite;
    }

    void Update()
    {
        int i = 0;

        var lane = lane1 ? manager.unitsToSpawnLane1 : manager.unitsToSpawnLane2;

        if (!isSpawningUnit && lane.Count > 0)
        {
            StartCoroutine(SpawnUnit(lane));
            isSpawningUnit = true;
        }

        for (i = 0; i < 3; i++)
            queueImage[i].sprite = defaultSprite;

        i = 0;
        foreach (var q in lane)
        {
            queueImage[i].sprite = q.sprite;
            i++;
        }
    }

    IEnumerator SpawnUnit(Queue<GUI_manager.Unit> lane)
    {
        float t = Time.timeSinceLevelLoad;
        var u  = lane.Peek();

        while (Time.timeSinceLevelLoad - t < u.spawnTime)
        {
            queueSlider.value = (Time.timeSinceLevelLoad - t) / u.spawnTime;
            yield return new WaitForEndOfFrame();
        }

        Debug.Log (u.name);
        manager.spawner.unitInvoke (u.meleeUnit, false, lane1 ? 0 : 1);
        queueSlider.value = 0;
        isSpawningUnit = false;
        lane.Dequeue();
    }
}