using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidoSalto : MonoBehaviour
{
    public AudioClip JumpSound;
    AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
    }


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            audioSource.clip = JumpSound;
            audioSource.Play();
        }
    }
}
