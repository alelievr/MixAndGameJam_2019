using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CastleUnit : MonoBehaviour
{

    public float fullHealth = 100;
    public float health = 100;
    public Image healthBar;
    SpriteRenderer spriteRenderer;

    void Start()
    {
        GameManager.instance.changeMode.AddListener(ToggleViewMode);
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = health / 100f;
    }

    public void TakeDamage (int dmg)
    {
        Debug.Log("taking damage");
        health -= dmg;
        if (health <= 0)
            DeathIsNow ();
        Debug.Log(health);

        // Color the sprite in red as feedback for hit
        spriteRenderer.color = Color.red;
        spriteRenderer.DOColor (Color.white, 0.2f);
    }

    void DeathIsNow ()
    {
        if (gameObject.tag == "ennemy") {
            GameManager.instance.Win();
        }
        else if (gameObject.tag == "friendly")
        {
            GameManager.instance.Lose();
        }
        Destroy (gameObject);
    }

    void ToggleViewMode()
    {
        if (GameManager.instance.mode == ViewMode.TopDown)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else
        {
            transform.eulerAngles = new Vector3(90, 0, 0);
        }
    }
}
