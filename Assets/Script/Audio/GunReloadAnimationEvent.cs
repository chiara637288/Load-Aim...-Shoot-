using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunReloadAnimationEvent : MonoBehaviour
{
    public void HandleAnimationEvent()
    {
        if (AudioManager.instance != null)
            AudioManager.instance.FadeIn("GunReload");
    }

    public void PlaySoundBodyFall1()
    {
        if (AudioManager.instance != null)
            AudioManager.instance.FadeIn("BodyFall1");
    }

    public void PlaySoundBodyFall2()
    {
        if (AudioManager.instance != null)
            AudioManager.instance.FadeIn("BodyFall2");
    }
}
