using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunReloadAnimationEvent : MonoBehaviour
{
    public void HandleAnimationEvent()
    {
        AudioManager.instance.FadeIn("GunReload");
    }
}
