using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeUnit : MonoBehaviour
{

    public int health = 10;

    public float speed = 1f;

    public int lane = 1;

    bool moving = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }



    void OnTriggerEnter(Collider other)
    {
        Debug.Log("collide " + other.tag);
        if (other.tag == "ennemy")
        {
            moving = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("exit " + other.tag);
        if (other.tag == "ennemy")
        {
            moving = true;
        }
    }

    void FixedUpdate()
    {
        if (moving == true)
        {
            transform.position = new Vector3(transform.position.x + Time.fixedDeltaTime * speed, transform.position.y, transform.position.z);
        }
    }
}
