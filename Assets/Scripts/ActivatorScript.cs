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

    private void Awake()
    {
        anim = GetComponent<Animator>();
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
       //yasta uwu eso lo veremos en un rato
    }

    public void FlameOn()
    {
        light.SetActive(true);
        particles.SetActive(true);
        //Play sounds
        GameManager.instance.torchesActivated++;
    }
}
