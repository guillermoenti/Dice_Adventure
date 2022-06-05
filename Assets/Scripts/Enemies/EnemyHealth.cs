using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : NPCHealth
{
    private EnemyAudio audio;

    [SerializeField] GameObject audioDeathGO;

    private void Start()
    {
        audio = GetComponent<EnemyAudio>();
    }

    public override void OnDamage(int damage)
    {
        base.OnDamage(damage);
        audio.PlayHit();
    }

    public override void Death()
    {

        Instantiate(audioDeathGO, transform.position, Quaternion.identity);
        base.Death();

    }

    
}
