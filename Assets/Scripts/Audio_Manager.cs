using System;
using UnityEngine;

public class Audio_Manager : MonoBehaviour
{
    public Sound[] Sounds;

    private void Awake()
    {
        foreach(Sound s in Sounds)
        {
            s.audioSource = gameObject.AddComponent<AudioSource>();

            s.audioSource.clip = s.clip;
            s.audioSource.volume = s.Volume;
            s.audioSource.pitch = s.Pitch;
            s.audioSource.loop = s.Loop;
        }
    }

    public void Play(string name)
    {
        Sound s = Array.Find(Sounds, Sound => Sound.name == name);
        s.audioSource.Play();
    }
}
