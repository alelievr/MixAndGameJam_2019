using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scriptPourFaireChierBciss : MonoBehaviour
{
    public Image image;
    public Image other;

    public void difficulty(float diff)
    {
        GameManager.instance.pourcentqgeDegatEnemy = diff;
        image.color = new Color( image.color.r, image.color.r, image.color.r, 1f);
        other.color = new Color( image.color.r, image.color.r, image.color.r, 0.50f);;
    }
}
