using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [SerializeField] private AudioSource FlameDying;
    [SerializeField] private AudioSource Music;

    private void Awake()
    {
        Music.Play();
        instance = this;
    }

    public void PlayFlameDying()
    {
        //AudioSource not on replay
        FlameDying.Play();
    }
}
