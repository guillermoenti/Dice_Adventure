using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAudio : MonoBehaviour
{
    [Header("Hit")]
    [SerializeField] AudioClip[] hits = new AudioClip[0];

    AudioSource audioMoan;
    AudioSource audioHit;
    AudioSource audioAttack;

    private float counter;
    private float random;


    private void Start()
    {
        counter = 0;

        random = Random.Range(1f, 5f);

        AudioSource[] tmpAudio = GetComponents<AudioSource>();
        audioMoan = tmpAudio[0];
        audioHit = tmpAudio[1];
        audioAttack = tmpAudio[2];
    }

    private void Update()
    {
        if(counter >= random)
        {
            audioMoan.Play();

            counter = 0;
            random = Random.Range(5f, 15f);
        }
        counter += Time.deltaTime;
    }

    public void PlayHit()
    {
        Debug.Log("HA SONADO EL CRUJIDO");

        int random1 = Random.Range(1, hits.Length);
        float random2 = Random.Range(0.75f, 0.25f);

        audioHit.pitch = random2;
        audioHit.PlayOneShot(hits[random1]);
    }

    public void PlayAttack()
    {
        float random = Random.Range(0.75f, 0.25f);

        audioHit.pitch = random;
        audioAttack.Play();
    }
}
