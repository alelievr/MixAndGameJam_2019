using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Weapon : MonoBehaviour
{
    Animator animator;

    void Start ()
    {
        animator = GetComponentInParent<Animator> ();
    }

    public float damage = 2;
    void OnTriggerEnter (Collider other)
    {
        MeleeUnit hit = other.gameObject.GetComponent<MeleeUnit> ();
        if (other.tag != this.gameObject.tag && hit && other.isTrigger == false)
        {
            Debug.DrawLine (transform.position, other.transform.position, Color.red, 1f);
            Debug.DrawRay (transform.position, Vector3.up, Color.green);
            hit.TakeDamage ((int)(damage * ((tag == "ennemy") ? GameManager.instance.pourcentqgeDegatEnemy : 1f)));
            gameObject.SetActive (false);
            return;
        }


        CastleUnit hitu = other.gameObject.GetComponent<CastleUnit> ();
        if (other.tag != this.gameObject.tag && hitu && other.isTrigger == false)
        {
            Debug.Log("found a target");
            Debug.DrawLine (transform.position, other.transform.position, Color.red, 1f);
            Debug.DrawRay (transform.position, Vector3.up, Color.green);
            hitu.TakeDamage ((int)damage);
            animator.gameObject.GetComponent<MeleeUnit>().TakeDamage((int)damage/2);
            gameObject.SetActive (false);
            return;
        }
    }
}