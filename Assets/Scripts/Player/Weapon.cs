using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [HideInInspector] public int damage;

    Animator anim;

    [SerializeField] private bool isAttacking = false;
    [SerializeField] private bool dealsDamage = false;

    InputManager inputManager;

    private bool isBlocking = false;

    private PlayerHealth player;

    private WeaponAudio wa;


    private void Awake()
    {
        anim = GetComponent<Animator>();
        inputManager = InputManager.Instance;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        damage = GameManager.instance.damage;
        wa = GetComponent<WeaponAudio>();
    }

    private void Update()
    {
        if (inputManager.HasPlayerAttackedThisFrame())
        {
            Attack();
        }
        if(inputManager.GetBlockData() == 0)
        {
            isBlocking = false;
            player.isBeingBlocked = false;
        }
        else
        {
            isBlocking = true;
            player.isBeingBlocked = true;
        }

        anim.SetBool("isBlocking", isBlocking);

    }

    public void Attack()
    {
        if(!isAttacking)
        anim.SetTrigger("attack");
    }

    private void Block()
    {
        anim.SetBool("isBlocking", true);
    }

    private void ReleaseBlock()
    {
        anim.SetBool("isBlocking", false);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if (dealsDamage) {
            other.TryGetComponent(out NPCHealth enemy);
            if (enemy)
            {
                enemy.OnDamage(damage);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
    }

    private void HandleAnimation()
    {

    }

}
