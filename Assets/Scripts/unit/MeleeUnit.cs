using System.Collections;
using System.Collections.Generic;

using DG.Tweening;

using UnityEngine;

public class MeleeUnit : MonoBehaviour
{

    public BoxCollider boxCol;
    Rigidbody rb;
    public bool takeTwoLane = false;
    public bool isFlying = false;
    public int health = 10;
    public int fullHealth = 10;
    public UnitType type;

    public float speed = 1f;
    int direction = 1;
    public int price = 10;

    public int lane = 1;
    Vector3 lanepos;
    bool moving = true;

    Animator animator;
    SpriteRenderer spriteRenderer;

    public GameObject weapon;

    // Start is called before the first frame update
    void Start ()
    {
        health = fullHealth;
        rb = gameObject.GetComponent<Rigidbody> ();
        if (this.gameObject.tag == "friendly")
            direction = 1;
        if (this.gameObject.tag == "ennemy")
        {
            direction = -1;
            transform.localScale = new Vector3 (-1, transform.localScale.y, transform.localScale.z);
        }
        // boxCol.center = new Vector3(direction * boxCol.center.x, boxCol.center.y, boxCol.center.z);
        if (GameManager.instance.mode == ViewMode.TopDown)
        {
            transform.position = new Vector3 (GetSpawnX (), GameManager.instance.ypos, 0);
        }
        if (GameManager.instance.mode == ViewMode.SideScroll)
        {
            transform.position = new Vector3 (GetSpawnX (), GameManager.instance.ypos + (isFlying? GameManager.instance.flypos : 0), 0);
        }
        GameManager.instance.changeMode.AddListener (ChangeMode);

        animator = GetComponent<Animator> ();
        spriteRenderer = GetComponentInChildren<SpriteRenderer> ();
    }

    float GetSpawnX ()
    {
        if (gameObject.tag == "friendly")
            return GameManager.instance.playerSpawnPosition.position.x;
        else
            return GameManager.instance.enemiesSpawnPosition.position.x;
    }

    public void Tapping ()
    {
        switch (type)
        {
            case UnitType.Bow:
                AudioManager.instance.PlayArrowShooting (); break;
            case UnitType.chariot:
                AudioManager.instance.PlayTankShooting(); break;
            case UnitType.griffon:
                AudioManager.instance.PlayGriffinAttack (); break;
            default:
            case UnitType.Melee:
                AudioManager.instance.PlaySwordClash (); break;
        }
        weapon.SetActive (true);
    }

    public void TakeDamage (int dmg)
    {
        health -= dmg;
        if (health <= 0)
            DeathIsNow ();

        // Color the sprite in red as feedback for hit
        spriteRenderer.color = Color.red;
        spriteRenderer.DOColor (Color.white, 0.2f);
    }

    void DeathIsNow ()
    {
        AudioManager.instance.PlayUnitDying ();

        if (tag == "ennemy")
            GameManager.instance.gold += (int) (price * 1.1f);

        Destroy (gameObject);
    }

    float getYLane (float offset)
    {
        if (takeTwoLane)
            return (-offset + ((GameManager.instance.laneInterval + GameManager.instance.laneWidth) * 0.5f));
        return (-offset + ((GameManager.instance.laneInterval + GameManager.instance.laneWidth) * lane));
    }

    void ChangeMode ()
    {
        float offset = (GameManager.instance.laneInterval / 2 + GameManager.instance.laneWidth);
        if (GameManager.instance.mode == ViewMode.TopDown)
        {
            lanepos = new Vector3 (transform.position.x, GameManager.instance.ypos, getYLane (offset));
            transform.position = lanepos;

        }
        if (GameManager.instance.mode == ViewMode.SideScroll)
        {
            lanepos = new Vector3 (transform.position.x - 0.3f * direction, GameManager.instance.ypos + (isFlying? GameManager.instance.flypos : 0), 0);
            transform.position = lanepos;

        }
    }
    // Update is called once per frame
    void Update ()
    {
        animator.SetBool ("isTopDown", GameManager.instance.mode == ViewMode.TopDown);
        float offset = (GameManager.instance.laneInterval / 2 + GameManager.instance.laneWidth / 2);
        if (GameManager.instance.mode == ViewMode.TopDown)
        {
            lanepos = new Vector3 (transform.position.x, GameManager.instance.ypos, getYLane (offset));
            transform.position = lanepos;

        }
        if (GameManager.instance.mode == ViewMode.SideScroll)
        {
            lanepos = new Vector3 (transform.position.x, GameManager.instance.ypos + (isFlying? GameManager.instance.flypos : 0), 0);
            transform.position = lanepos;

        }
    }

    float atkspeed = 2f;
    float cur = 2f;

    private void OnTriggerStay (Collider other)
    {
        if (other.gameObject.tag != this.gameObject.tag && other.isTrigger == false)
        {
            //   Debug.Log ("Stay !");
            animator.SetTrigger ("isTapping");
        }
    }

    void FixedUpdate ()
    {
        RaycastHit hit;

        Debug.DrawLine (new Vector3 (transform.position.x, transform.position.y, transform.position.z + 0.2f), new Vector3 (transform.position.x + 0.3f * direction, transform.position.y, transform.position.z), Color.green);
        Debug.DrawRay (transform.position, Vector3.up, Color.blue);

        if (Physics.Raycast (transform.position, new Vector3 (1 * direction, 0, 0), out hit, 0.3f) == true)
        {
            moving = false;
        }
        else
            moving = true;
        rb.velocity = Vector3.zero;
        if (moving == true)
        {

            rb.velocity = new Vector3 (speed * direction, 0, 0);
            Debug.DrawLine (transform.position, transform.position + new Vector3 (5 * direction, 5, 5), Color.red);
        }
    }
}