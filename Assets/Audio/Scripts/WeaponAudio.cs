using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAudio : MonoBehaviour
{
    [Header("Axe")]
    [SerializeField] AudioClip[] axeSwings = new AudioClip[0];

    AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySwing()
    {
        int random1 = Random.Range(0, axeSwings.Length);
        float random2 = Random.Range(0.75f, 1.50f);

        audioSource.pitch = random2;
        audioSource.spatialBlend = 1;
        audioSource.PlayOneShot(axeSwings[random1]);
        audioSource.pitch = 1;
        audioSource.spatialBlend = 0;
    }

}
