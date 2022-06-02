using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    [SerializeField] private int spawnSecconds = 60;
    private bool bCanSpawnAgain = true;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(Resources.Load("Enemy1") as GameObject, transform.position, Quaternion.identity, transform);
    }

    // Update is called once per frame
    void Update()
    {
        if (bCanSpawnAgain)
        {
            StartCoroutine(spawnEnemy());
            bCanSpawnAgain = false;
        }
    }

    IEnumerator spawnEnemy()
    {
        yield return new WaitForSeconds(spawnSecconds);

        Instantiate(Resources.Load("Enemy1") as GameObject, transform.position, Quaternion.identity, transform);

        bCanSpawnAgain = true;
        Debug.Log("Spawn");

    }
}
