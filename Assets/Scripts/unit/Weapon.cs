using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int damage = 2;
    void OnTriggerEnter(Collider other)
    {
        MeleeUnit hit = other.gameObject.GetComponent<MeleeUnit>();
        if (other.tag != this.gameObject.tag && hit)
        {
            Debug.DrawLine(transform.position, other.transform.position, Color.red, 1f);
            Debug.DrawRay(transform.position, Vector3.up, Color.green);
            hit.TakeDamage(damage);
            gameObject.SetActive(false);

            AudioManager.instance.PlaySwordClash();
        }
    }
}
