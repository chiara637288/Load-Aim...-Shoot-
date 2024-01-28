using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject ButtonQ; // Elencare i bottoni che quando accesi mostrano al giocatore quale pulsante premere.
    public GameObject ButtonW;
    public GameObject ButtonE;
    public GameObject ButtonR;
    public CountdownController timeToshoot;

    public KeyCode[] validSequenceKeys = new[] 
    {
        KeyCode.Q,
        KeyCode.W,
        KeyCode.E,
        KeyCode.R
    };
    //roba trovata su di un forum, capire cosa esattamente fa ma era in risposta a "random sequence of keys to press"

    /*KeyCode[] GenerateSequence(int length = 4)
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
        if (timeToshoot = true && )                                          //la seconda condizione è che nell arrey viene sorteggiato la lettere Q
        {
            ButtonQ.SetActive(true);

        }


        if (timeToshoot = true && Input.GetKeyDown(KeyCode.Q) &&  )          //dovrebbe 1 controllase se viene premuto uno dei tasti possibili, 2 se viene premuto quando è tempo di sparare,
        {                                                                    //3 che il tasto premuto è quello giusto, 4 che il tempo per sparare non sia scaduto e 5 che il player non è morto. 
            Shoot();                                                         //Ripetere poi l'"if" per tutti i tasti disponibili.
        }

    }

    void Shoot()
    {
        //shooting Spawn
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
