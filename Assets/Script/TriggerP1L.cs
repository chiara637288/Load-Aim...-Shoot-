using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerP1L : MonoBehaviour
{
    public Score currentMatchPlayer1L;

    // Update is called once per frame
    void Update()
    {
        int CurrentMatchPlayer1L = currentMatchPlayer1L.currentMatchPlayer1LResult;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

    }
}
