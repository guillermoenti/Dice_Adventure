using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossHealth : NPCHealth
{
    AudioSource audio;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public override void OnDamage(int damage)
    {
        base.OnDamage(damage);

        audio.Play();

    }

    public override void Death()
    {
        base.Death();
        SceneManager.LoadScene(0);
    }


}
