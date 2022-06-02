using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockArea : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        other.TryGetComponent(out EnemyAI enemy);
        if (enemy)
        {
            enemy.isBeingBlocked = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        other.TryGetComponent(out EnemyAI enemy);
        if (enemy)
        {
            enemy.isBeingBlocked = false;
        }
    }
}
