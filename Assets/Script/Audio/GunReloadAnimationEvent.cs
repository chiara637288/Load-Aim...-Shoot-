using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunReloadAnimationEvent : MonoBehaviour
{
    private void Start()
    {
        AudioManager.instance.FadeIn("GunReload");
    }
}
