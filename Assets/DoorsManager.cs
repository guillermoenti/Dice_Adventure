using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorsManager : MonoBehaviour
{

    [SerializeField] Transform rightDoor;
    [SerializeField] Transform leftDoor;

    [SerializeField] WayPoint wayPoint;

    [SerializeField] EnemyAI boss;

    private bool playerHasEntered = false;

    private void Start()
    {
        boss.canWalk = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !playerHasEntered)
        {
            boss.canWalk = true;

            //Esto puede ahorrar poblemas con el canWalk del jefe, para que funcione cómo de normal
            playerHasEntered = true;
        }
    }

    public void OpenDoors()
    {
        rightDoor.rotation = Quaternion.Euler(new Vector3(0, -120, 0));
        leftDoor.rotation = Quaternion.Euler(new Vector3(0, 120, 0));

        wayPoint.enabled = true;
    }
}
