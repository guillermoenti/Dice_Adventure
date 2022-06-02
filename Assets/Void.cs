using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Void : MonoBehaviour
{
    [SerializeField] CharacterController character;

    private Vector3 playerInitPos;


    private void Start()
    {
        playerInitPos = character.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            character.GetComponent<CharacterController>().enabled = false;
            other.transform.position = playerInitPos;
            character.GetComponent<CharacterController>().enabled = true;
        }
    }
}
