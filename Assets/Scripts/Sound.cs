using UnityEngine;

[System.Serializable]
public class Sound
{
    // Clip
    public string name;
    public AudioClip clip;

    // Clip Properties
    [Range(0f, 1f)] public float Volume;
    [Range(0.1f, 3f)] public float Pitch;
    public bool Loop;

    // Audiosource
    [HideInInspector] public AudioSource audioSource;
}
