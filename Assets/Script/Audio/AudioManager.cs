using UnityEngine;
using System.Collections;
using System;

public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;
    public static AudioManager instance;
    [HideInInspector]
    public Sound currentMusic;
    /// <summary>
    /// Start the selected song
    /// </summary>
    /// <param name="name"> Name of the song</param>
    /// <param name="volume"> Volume of the song </param>
    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s.type == Type.Music)
        {
            s.source.volume = PlayerPrefs.GetFloat("MusicVolume") * PlayerPrefs.GetFloat("MasterVolume") * s.volume;
            //currentMusic = s;
        }
        else
        {
            s.source.volume = PlayerPrefs.GetFloat("SfxVolume") * PlayerPrefs.GetFloat("MasterVolume") * s.volume;
            //currentMusic = s;
        }
        s.source.Play();
    }

    /// <summary>
    /// Stop the selected song
    /// </summary>
    /// <param name="name"> Name of the song </param>
    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Stop();
    }

    /// <summary>
    /// Stops all musics in game
    /// </summary>
    public void StopAllMusics()
    {
        foreach (Sound s in sounds)
        {
            if (s.type == Type.Music)
                s.source.Stop();
        }
    }

    /// <summary>
    /// Stops all SFX in game
    /// </summary>
    public void StopAllSFX()
    {
        foreach (Sound s in sounds)
        {
            if (s.type == Type.SFX)
                s.source.Stop();
        }
    }

    /// <summary>
    /// Stops all sounds in game
    /// </summary>
    public void StopAllSounds()
    {
        foreach (Sound s in sounds)
        {
            s.source.Stop();
        }
    }

    /// <summary>
    /// Stops all sounds in game
    /// </summary>
    ///     /// <param name="name"></param>
    public void FadeOutAllSounds()
    {
        foreach (Sound s in sounds)
        {
            if (s.type == Type.Music)
            {
                if (s != currentMusic)
                    StartCoroutine(StartFadeOut(s, 0));

            }
        }
    }

    /// <summary>
    /// Fade out a sound
    /// </summary>
    /// <param name="name">Name of the Clip</param>
    public void FadeOut(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        StartCoroutine(StartFadeOut(s, 0));
    }

    /// <summary>
    /// Coroutine for fade out a Sound
    /// </summary>
    /// <param name="clip">Clip to fade</param>
    /// <param name="duration">Duration of the fade</param>
    /// <param name="targetVolume">Volume to reach</param>
    /// <returns></returns>
    public static IEnumerator StartFadeOut(Sound clip, float targetVolume)
    {
        float currentTime = 0;
        float start = clip.volume;
        float originalVolume = clip.volume;
        float duration = clip.fadeOutTime;

        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            clip.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
            yield return null;
        }

        clip.source.Stop();
        clip.volume = originalVolume;

        yield break;
    }



    /// <summary>
    /// Fade in a sound
    /// </summary>
    /// <param name="name"></param>
    public void FadeIn(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        float originalVolume = s.volume;
        s.volume = 0;
        s.source.Play();
        currentMusic = s;

        /*if (s.name != "MenuMusic")
        {
            currentMusic = s;
        }*/

        StartCoroutine(StartFadeIn(s, s.fadeInTime, originalVolume));
    }

    /// <summary>
    /// Coroutine for fade in a Sound
    /// </summary>
    /// <param name="clip">Clip to fade</param>
    /// <param name="duration">Duration of the fade</param>
    /// <param name="targetVolume">Volume to reach</param>
    /// <returns></returns>
    public static IEnumerator StartFadeIn(Sound clip, float duration, float targetVolume)
    {
        float currentTime = 0;
        float start = clip.volume;

        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            clip.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
            yield return null;
        }
        yield break;
    }



    /// <summary>
    /// Change Music Volume by slider
    /// </summary>
    /// <param name="name"> Name of the song </param>
    /// <param name="slider"> Slider that change the volume </param>
    public void ChangeMusicVolume()
    {
        foreach (Sound s in sounds)
        {
            if (s.type == Type.Music)
                s.source.volume = s.volume * PlayerPrefs.GetFloat("MusicVolume") * PlayerPrefs.GetFloat("MasterVolume");
        }
    }

    /// <summary>
    /// Change SFX Volume by slider
    /// </summary>
    /// <param name="name"> Name of the song </param>
    /// <param name="slider"> Slider that change the volume </param>
    public void ChangeSfxVolume()
    {
        foreach (Sound s in sounds)
        {
            if (s.type == Type.SFX)
                s.source.volume = s.volume * PlayerPrefs.GetFloat("SfxVolume") * PlayerPrefs.GetFloat("MasterVolume");
        }
    }


    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.loop = s.loop;
            s.source.priority = s.priority;
            s.source.volume = s.volume;
        }
    }
    void Start()
    {
        if (AudioManager.instance != null)
            AudioManager.instance.FadeIn("Stronzo");

    }
}
