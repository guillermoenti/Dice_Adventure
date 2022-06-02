using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorsManager : MonoBehaviour
{

    [SerializeField] Transform rightDoor;
    [SerializeField] Transform leftDoor;

    [SerializeField] WayPoint wayPoint;


    public void OpenDoors()
    {
        rightDoor.rotation = Quaternion.Euler(new Vector3(0, -120, 0));
        leftDoor.rotation = Quaternion.Euler(new Vector3(0, 120, 0));

        wayPoint.enabled = true;
    }
}
