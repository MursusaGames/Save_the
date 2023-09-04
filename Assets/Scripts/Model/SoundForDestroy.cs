using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundForDestroy : MonoBehaviour
{
    private AudioSource soundForDestroy;
    // Start is called before the first frame update
    void Awake()
    {
        soundForDestroy = GetComponent<AudioSource>();
    }

    private void OnDisable()
    {
        soundForDestroy.Play();
    }
}
