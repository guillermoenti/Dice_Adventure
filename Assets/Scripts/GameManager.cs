using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int numberOfPortals = 3;
    public int numberOfKeys = 3;

    public int keysActivated = 0;

    public int playerMaxHealth;
    public int damage;
    public int attackSpeed;
    public int blocking;

    public DoorsManager door;

    private void Awake()
    {

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else if (instance != null && instance != this)
        {
            Destroy(this);
        }

    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    public void KeyActivated()
    {
        keysActivated++;

        if(keysActivated == numberOfKeys)
        {
            door.OpenDoors();
        }
    }

    public void SetStats(int _damage, int health, int _attackSpeed, int block, int spawners)
    {
        damage = _damage;
        playerMaxHealth = health * 10;
        attackSpeed = _attackSpeed;
        blocking = block;
        numberOfPortals = (spawners / 3);
        numberOfPortals = Mathf.Clamp(numberOfPortals, 1, 7);
        numberOfKeys = 8 - numberOfPortals;

        Debug.Log(damage + " " + playerMaxHealth + " " + attackSpeed + " " + blocking + " " + numberOfPortals + " " + numberOfKeys);
    }
}
