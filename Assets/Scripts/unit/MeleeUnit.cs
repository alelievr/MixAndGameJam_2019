using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeUnit : MonoBehaviour
{

    public BoxCollider boxCol;
    Rigidbody rb;
    public int health = 10;

    public float speed = 1f;
    int direction = 1;

    public int lane = 1;
    Vector3 lanepos;
    bool moving = true;

    public GameObject weapon;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        if (this.gameObject.tag == "friendly")
            direction = 1;
        if (this.gameObject.tag == "ennemy")
        {
            direction = -1;
            transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
        }
        // boxCol.center = new Vector3(direction * boxCol.center.x, boxCol.center.y, boxCol.center.z);
        if (GameManager.instance.mode == ViewMode.TopDown)
        {
            lanepos = new Vector3(0, 5 * lane, 0);
            transform.position = new Vector3(transform.position.x, lanepos.y, lanepos.z);
        }
        if (GameManager.instance.mode == ViewMode.SideScroll)
        {
            lanepos = new Vector3(0, 5, 0);
            transform.position = new Vector3(transform.position.x, lanepos.y, lanepos.z);
        }
        GameManager.instance.changeMode.AddListener(ChangeMode);
    }

    public void TakeDamage(int dmg)
    {
        health -= dmg;
        if (health <= 0)
            DeathIsNow();
    }

    void DeathIsNow()
    {
        Destroy(gameObject);
    }
    void ChangeMode()
    {
        if (GameManager.instance.mode == ViewMode.TopDown)
        {
            lanepos = new Vector3(0, 5 * lane, 0);
            transform.position = new Vector3(transform.position.x - 0.3f * direction, lanepos.y, lanepos.z);

        }
        if (GameManager.instance.mode == ViewMode.SideScroll)
        {
            lanepos = new Vector3(0, 5, 0);
            transform.position = new Vector3(transform.position.x - 0.3f * direction, lanepos.y, lanepos.z);

        }
    }
    // Update is called once per frame
    void Update()
    {
        if (tapper)
        {
            cur -= Time.deltaTime;
            if (cur < 0)
            {
                weapon.SetActive(true);
                cur = atkspeed;
            }
        }



    }

    bool tapper = false;
    float atkspeed = 2f;
    float cur = 2f;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag != this.gameObject.tag)
        {
            // animator.settrigger("attack");
            tapper = true;
        }
    }


    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag != this.gameObject.tag)
        {
            // animator.settrigger("attack");
            tapper = false;
        }
    }



    void FixedUpdate()
    {
        RaycastHit hit;

        Debug.DrawLine(transform.position, new Vector3(transform.position.x + 0.8f * direction, transform.position.y, transform.position.z), Color.green);

        if (Physics.Raycast(transform.position, new Vector3(1 * direction, 0, 0), out hit, 0.8f) == true)
        {
            moving = false;
        }
        else
            moving = true;
        rb.velocity = Vector3.zero;
        if (moving == true)
        {

            rb.velocity = new Vector3(speed * direction, 0, 0);
            Debug.DrawLine(transform.position, transform.position + new Vector3(5 * direction, 5, 5), Color.red);
        }
    }
}
