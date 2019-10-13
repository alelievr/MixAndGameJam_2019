using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scriptPourFaireChierBciss : MonoBehaviour
{
    public Image image;
    public Image other;

    Button      button;

    public bool selectedByDefault = false;

    public static int selected = 0;

    void Start()
    {
        button = GetComponent< Button >();
        if (selectedByDefault)
            selected = GetHashCode();
    }

    void Update()
    {
        image.color = selected == GetHashCode() ? new Color( image.color.r, image.color.r, image.color.r, 1f) : new Color( image.color.r, image.color.r, image.color.r, 0.50f);
    }

    public void difficulty(float diff)
    {
        GameManager.instance.pourcentqgeDegatEnemy = diff;
        image.color = new Color( image.color.r, image.color.r, image.color.r, 1f);
        other.color = new Color( image.color.r, image.color.r, image.color.r, 0.50f);;
        selected = GetHashCode();
    }
}
