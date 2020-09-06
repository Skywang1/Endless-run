using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Sprite[] images;
    public Image healthBar;

    public void SetHealth (int newHealth)
    {
        newHealth -= 1;
        if (newHealth < images.Length && newHealth >= 0)
        {
            healthBar.sprite = images[newHealth];
        }
        else
        {
            Debug.LogWarning("Index " + newHealth + " is out of bounds");
        }
    }
}