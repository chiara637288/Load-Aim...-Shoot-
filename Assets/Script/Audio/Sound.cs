using UnityEngine;

public enum Type
{
    Music,
    SFX
}

[System.Serializable]
public class Sound
{
    /// <summary>
    /// Name of the clip
    /// </summary>
    public string name;

    /// <summary>
    /// Clip to play
    /// </summary>
    public AudioClip clip;

    /// <summary>
    /// Check for the loop of the Clip
    /// </summary>
    public bool loop;

    /// <summary>
    /// Type of the clip
    /// </summary>
    public Type type;

    [Range(0, 256)]
    public int priority = 128;

    [Range(0, 1)]
    public float volume = 1;

    public float fadeInTime = 1;

    public float fadeOutTime = 1;

    /// <summary>
    /// AudioSource of the clip
    /// </summary>
    [HideInInspector]
    public AudioSource source;
}