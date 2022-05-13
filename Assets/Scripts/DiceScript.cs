using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceScript : MonoBehaviour
{

    private Rigidbody rb;
    [SerializeField] private Vector3 diceVelocity;

    private bool isInAir;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        isInAir = false;
    }

    // Update is called once per frame
    void Update()
    {
        diceVelocity = rb.velocity;

        if (!isInAir && Input.GetKeyDown(KeyCode.Space))
        {
            isInAir = true;
            RollTheDice();
        }

        Debug.Log(Mathf.Abs(rb.velocity.y));

        if (rb.velocity.y == 0)
        {
            isInAir = false;
        }
    }

    void RollTheDice()
    {
        float dirX = Random.Range(0, 500);
        float dirY = Random.Range(0, 500);
        float dirZ = Random.Range(0, 500);

        transform.position = new Vector3(transform.position.x, transform.position.y + 0.2f, transform.position.z);
        transform.rotation = Quaternion.identity;

        rb.AddForce(transform.up * 500);
        rb.AddTorque(dirX, dirY, dirZ);
    }

}
