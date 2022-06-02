using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    private int currentHealth;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public virtual void OnDamage(int damage)
    {
        Debug.Log("Daño " + damage);

        currentHealth -= damage;

        if (currentHealth <= 0) Death();
    }

    public virtual void Death()
    {
        Debug.Log("Me muero");
        Destroy(gameObject);
    }


}
