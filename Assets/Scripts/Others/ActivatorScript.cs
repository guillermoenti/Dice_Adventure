using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatorScript : Interactable
{
    
    private PlayerControls playerControls;

    private bool isActivated = false;

    Animator anim;

    [SerializeField] GameObject light;
    [SerializeField] GameObject particles;



    private DoorsManager doors;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        doors = FindObjectOfType<DoorsManager>();
    }

    private void Start()
    {
        light.SetActive(false);
        particles.SetActive(false);
    }

    public override void OnInteract()
    {
        if (!isActivated)
        {
            isActivated = true;
            anim.SetTrigger("Activate");
        }
    }

    public void FlameOn()
    {
        light.SetActive(true);
        particles.SetActive(true);
        //Play sounds
        GameManager.instance.KeyActivated();
        GetComponent<WayPoint>().enabled = false;
    }
}
