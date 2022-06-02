using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : NPCHealth
{
    private AudioSource audio;

    [SerializeField] AudioClip audioHit;
    [SerializeField] AudioClip audioDie;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public override void OnDamage(int damage)
    {
        base.OnDamage(damage);
        audio.PlayOneShot(audioHit);
    }

    public override void Death()
    {

        audio.PlayOneShot(audioDie);
        base.Death();

    }

    
}
