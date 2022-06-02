using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] Image healthSlider;

    private float maxHealth;
    private float health;

    public bool isBeingBlocked = false;

    private int blockStat;

    private void Start()
    {
        maxHealth = GameManager.instance.playerMaxHealth;
        health = maxHealth;
        healthSlider.fillAmount = 1;
        blockStat = GameManager.instance.blocking;
    }



    public void GetHit(int damage)
    {
        if (!isBeingBlocked)
        {
            health -= damage;
        }
        else 
        {
            float actualDamage = damage - blockStat;

            if(actualDamage < 0)
            {
                actualDamage = 0;
            }

            health -= actualDamage;
        }

        health = Mathf.Clamp(health, 0f, maxHealth);
        Debug.Log(health/maxHealth);
        healthSlider.fillAmount = health/maxHealth;

        if(health <= 0)
        {
            SceneManager.LoadScene(1);
        }
    }
}
