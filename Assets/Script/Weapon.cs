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
    public GameObject ButtonT;
    public GameObject ButtonY;
    public CountdownController CountdownControllerIstance;

    string[] myArray = 
    {   "Q", 
        "W", 
        "E", 
        "R", 
        "T", 
        "Y" 
    };

    string GetRandomValue()                                         // Function to randomly pick a value from the array
    {
        int randomIndex = Random.Range(0, myArray.Length);          // Use Random.Range to generate a random index within the array length

        return myArray[randomIndex];                                // Return the value at the randomly generated index
    }

    void Start()
    {
        string randomValue = GetRandomValue();                      // Call the function to randomly pick a value from the array
        Debug.Log("Randomly picked value: " + randomValue);
    }


    void Update()
    {
        bool isTimeToShoot = CountdownControllerIstance.timeToshoot;

        if (isTimeToShoot == true)               //&& randomValue == "Q" la seconda condizione è che nell arrey viene sorteggiato la lettere Q. Possibile togliere la condizione del timeToShoot?
        {
            ButtonQ.SetActive(true);

        }


        if (isTimeToShoot == true && Input.GetKeyDown(KeyCode.Q))          //dovrebbe 1 controllase se viene premuto uno dei tasti possibili, 2 se viene premuto quando è tempo di sparare,
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
