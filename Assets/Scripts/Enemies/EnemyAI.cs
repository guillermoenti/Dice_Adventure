using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    private NavMeshAgent agent;
    private GameObject player;

    public bool isBeingBlocked = false;

    [SerializeField] private int damage;

    [SerializeField] EnemyWeapon weapon;

    //ESTÁ EN ANIMACION :)
    [SerializeField] bool canWalk = true;

    private bool canAttack = true;

    Animator anim;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        ChasePlayer();

        anim.SetBool("isMoving", agent.velocity.sqrMagnitude > 0);

        if (isBeingBlocked)
        {
            weapon.damage = weapon.maxDamage / 2;
        }
        else
        {
            weapon.damage = weapon.maxDamage;
        }

        if (Vector3.Distance(player.transform.position, transform.position) <= agent.stoppingDistance + 0.2)
        {
            if (canAttack)
            {
                weapon.Attack();
                canAttack = false;
                StartCoroutine(ResetAttack());
            }

        }

        if (!canWalk)
        {
            agent.SetDestination(transform.position);
        }

    }

    IEnumerator ResetAttack()
    {
        yield return new WaitForSeconds(1.5f);
        canAttack = true;
    }

    private void ChasePlayer()
    {
        agent.destination = player.transform.position;
    }

    private void SetDealsDamageTrue()
    {
        weapon.dealsDamage = true;
    }
    private void SetDealsDamageFalse()
    {
        weapon.dealsDamage = false;
    }

}
