using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicGame : MonoBehaviour
{
    [SerializeField] private MatchData data;
    [SerializeField] private AudioSource source;
    void OnEnable()
    {
        if (data.music)
        {
            source.volume = PlayerPrefs.GetFloat(Constant.MUSIC);
            source.Play();
        }
    }

    
}
