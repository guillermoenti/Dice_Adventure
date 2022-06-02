using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    [SerializeField] private Transform hand;

    private Transform lastPos;

    private void Start()
    {
        lastPos = hand.transform;
    }

    void Update()
    {
        
        Debug.Log(hand.localRotation + ", " + lastPos.localRotation);

        gameObject.transform.position += hand.transform.position - lastPos.position;
        gameObject.transform.localRotation *= hand.transform.localRotation * Quaternion.Inverse(lastPos.localRotation);

        lastPos = hand.transform;
        
    }
}
