using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPR2 : MonoBehaviour
{
    public Score currentMatchPlayer2R;

    // Update is called once per frame
    void Update()
    {
        int CurrentMatchPlayer2R = currentMatchPlayer2R.currentMatchPlayer2RResult;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

    }
}
