using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    public KeyCode[] validSequenceKeys = new[] 
    {
        KeyCode.Q,
        KeyCode.W,
        KeyCode.E,
        KeyCode.R
    };
    //roba trovata su di un forum, capire cosa esattamente fa ma era in risposta a "random sequence of keys to press"
    /*KeyCode[] GenerateSequence(int length = 6)
    {
        KeyCode[] sequence = new KeyCode[length];

        for (int i = 0; i < length; i++)
        {
            var key = validSequenceKeys[Random.Range(0, validSequenceKeys.Length)];
            sequence[i] = key;
        }

        return sequence;
    }*/

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) //dovrebbe controllaser se il tasto premuto è giusto 
        {
            Shoot();
        }
    }

    void Shoot()
    {
        //shooting logic
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
