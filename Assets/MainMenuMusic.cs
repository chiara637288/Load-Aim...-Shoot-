using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuMusic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (AudioManager.instance != null)
            AudioManager.instance.FadeIn("Stronzo");

    }
}
