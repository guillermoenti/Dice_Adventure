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

    private DoorsManager door;

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

        door = FindObjectOfType<DoorsManager>();
    }

    public void KeyActivated()
    {
        keysActivated++;

        if(keysActivated == numberOfKeys)
        {
            door.OpenDoors();
        }
    }
}
