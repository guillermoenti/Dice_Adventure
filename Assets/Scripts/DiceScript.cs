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

        //Debug.Log(Mathf.Abs(rb.velocity.y));

        if (rb.velocity.y == 0)
        {
            isInAir = false;
        }
    }

    public void RollTheDice()
    {
        float dirX = Random.Range(-10000, 10000);
        float dirY = Random.Range(-10000, 10000);
        float dirZ = Random.Range(-10000, 10000);

        transform.position = new Vector3(transform.position.x, transform.position.y + 0.2f, transform.position.z);
        transform.rotation = Quaternion.identity;

        rb.AddForce(transform.up * 250);
        rb.AddTorque(dirX, dirY, dirZ);
    }

}
