using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CastleUnit : MonoBehaviour
{

    public int fullHealth = 100;
    public int health = 100;
    public Image healthBar;
    SpriteRenderer spriteRenderer;

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = health / 100;
    }

    public void TakeDamage (int dmg)
    {
        Debug.Log("taking damage");
        health -= dmg;
        if (health <= 0)
            DeathIsNow ();

        // Color the sprite in red as feedback for hit
        spriteRenderer.color = Color.red;
        spriteRenderer.DOColor (Color.white, 0.2f);
    }

    void DeathIsNow ()
    {
        Destroy (gameObject);
    }
}
