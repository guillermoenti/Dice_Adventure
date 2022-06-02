using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossHealth : NPCHealth
{
    public override void OnDamage(int damage)
    {
        base.OnDamage(damage);

        SceneManager.LoadScene(0);
    }


}
