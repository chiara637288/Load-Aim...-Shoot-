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
}
