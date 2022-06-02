using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] Image healthSlider;

    private float maxHealth;
    private float health;

    private void Start()
    {
        maxHealth = GameManager.instance.playerMaxHealth;
        health = maxHealth;
        healthSlider.fillAmount = 1;
    }

    public void GetHit(int damage)
    {
        health -= damage;
        health = Mathf.Clamp(health, 0f, maxHealth);
        Debug.Log(health/maxHealth);
        healthSlider.fillAmount = health/maxHealth;
    }
}
