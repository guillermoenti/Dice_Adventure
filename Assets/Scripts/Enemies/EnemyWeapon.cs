using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    public int maxDamage;
    [HideInInspector] public int damage;

    [SerializeField] private Animator anim;

    public bool dealsDamage = false;

    InputManager inputManager;

    bool isBeingBlocked = false;

    private void Awake()
    {
        inputManager = InputManager.Instance;
    }

    private void Update()
    {

    }

    public void Attack()
    {
            anim.SetTrigger("attack");
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if (dealsDamage)
        {
            if (other.TryGetComponent(out PlayerHealth player)){
                if (isBeingBlocked)
                {
                    player.GetHit(damage / 2);
                }
                else
                {
                    player.GetHit(damage);
                }
            }
        }
    }

}
