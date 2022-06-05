using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    [Header("Character")]
    [SerializeField] AudioClip[] characterHurt = new AudioClip[0];

    [Header("Footsteps")]
    [SerializeField] AudioClip[] footsteps = new AudioClip[0];

    AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }


    public void PlayFootstep()
    {
        int random = Random.Range(0, footsteps.Length);
        audioSource.PlayOneShot(footsteps[random]);
    }

    public void PlayHurt()
    {
        int random = Random.Range(0, characterHurt.Length);
        audioSource.PlayOneShot(characterHurt[random]);
    }

}
