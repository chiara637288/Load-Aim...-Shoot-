using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponL : MonoBehaviour
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

    string[] myArray = { "Q", "W", "E", "R", "T", "Y" };
    string randomValue;

    void Start()
    {
        // Call the function to randomly pick a value from the array at the beginning
        randomValue = GetRandomValue();
        Debug.Log("Randomly picked value: " + randomValue);
    }

    void Update()
    {
        bool isTimeToShoot = CountdownControllerIstance.timeToshoot;

        if (isTimeToShoot)
        {
            DisplayButton(randomValue, CountdownControllerIstance.timeToshoot);                 // Display the corresponding button based on the random value

            // Check if the corresponding key is pressed
            if (Input.GetKeyDown(KeyCode.Q) && randomValue == "Q")
            {
                Shoot();                                                                         //  isTimeToShoot = false; dovrebbe far smettere di funzionare lo sparo ma dunno non va
                CountdownControllerIstance.timeToshoot = false;
            }
            if (Input.GetKeyDown(KeyCode.W) && randomValue == "W")
            {
                Shoot();
                CountdownControllerIstance.timeToshoot = false;
            }
            if (Input.GetKeyDown(KeyCode.E) && randomValue == "E")
            {
                Shoot();
                CountdownControllerIstance.timeToshoot = false;
            }
            if (Input.GetKeyDown(KeyCode.R) && randomValue == "R")
            {
                Shoot();
                CountdownControllerIstance.timeToshoot = false;
            }
            if (Input.GetKeyDown(KeyCode.T) && randomValue == "T")
            {
                Shoot();
                CountdownControllerIstance.timeToshoot = false;
            }
            if (Input.GetKeyDown(KeyCode.Y) && randomValue == "Y")
            {
                Shoot();
                CountdownControllerIstance.timeToshoot = false;
            }
        }
    }

    void DisplayButton(string value, bool isVisible)
    {
        // Display the corresponding button based on the input value
        switch (value)
        {
            case "Q":
                ButtonQ.SetActive(true);
                break;
            case "W":
                ButtonW.SetActive(true);
                break;
            case "E":
                ButtonE.SetActive(true);
                break;
            case "R":
                ButtonR.SetActive(true);
                break;
            case "T":
                ButtonT.SetActive(true);
                break;
            case "Y":
                ButtonY.SetActive(true);
                break;
        }
    }

    void Shoot()
    {
        // Shooting spawn
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // Hide the button after shooting
        switch (randomValue)
        {
            case "Q":
                ButtonQ.SetActive(false);
                break;
            case "W":
                ButtonW.SetActive(false);
                break;
            case "E":
                ButtonE.SetActive(false);
                break;
            case "R":
                ButtonR.SetActive(false);
                break;
            case "T":
                ButtonT.SetActive(false);
                break;
            case "Y":
                ButtonY.SetActive(false);
                break;
        }

    }

    string GetRandomValue()
    {
        int randomIndex = Random.Range(0, myArray.Length);
        return myArray[randomIndex];
    }
}
