using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponR : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject ButtonP; // Elencare i bottoni che quando accesi mostrano al giocatore quale pulsante premere.
    public GameObject ButtonO;
    public GameObject ButtonI;
    public GameObject ButtonU;
    public GameObject ButtonL;
    public GameObject ButtonK;

    public GameObject ButtonM; // Elencare i bottoni che quando accesi mostrano al giocatore quale pulsante premere.
    public GameObject ButtonN;
    public GameObject ButtonB;
    public GameObject ButtonV;
    public GameObject ButtonJ;
    public GameObject ButtonH;
    public CountdownController CountdownControllerIstance;
    public BulletL ParryMoment;

    string[] myArray = { "P", "O", "I", "U", "L", "K" };
    string[] parryArray = { "M", "N", "B", "V", "J", "H" };
    string randomValue;
    string randomValueParry;

    void Start()
    {
        // Call the function to randomly pick a value from the array at the beginning
        randomValue = GetRandomValue(myArray);
        Debug.Log("Randomly picked value: " + randomValue);

        randomValueParry = GetRandomValue(parryArray);
        Debug.Log("Randomly picked value: " + randomValueParry);
    }

    void Update()
    {
        bool isTimeToShootR = CountdownControllerIstance.timeToshootR;
        bool myParryMoment = ParryMoment.parryMomentL;

        if (isTimeToShootR)
        {
            DisplayButton(randomValue, CountdownControllerIstance.timeToshootR);                 // Display the corresponding button based on the random value

            // Check if the corresponding key is pressed
            if (Input.GetKeyDown(KeyCode.P) && randomValue == "P")
            {
                Shoot();                                                                         //  isTimeToShoot = false; dovrebbe far smettere di funzionare lo sparo ma dunno non va
                CountdownControllerIstance.timeToshootR = false;
            }
            if (Input.GetKeyDown(KeyCode.O) && randomValue == "O")
            {
                Shoot();
                CountdownControllerIstance.timeToshootR = false;
            }
            if (Input.GetKeyDown(KeyCode.I) && randomValue == "I")
            {
                Shoot();
                CountdownControllerIstance.timeToshootR = false;
            }
            if (Input.GetKeyDown(KeyCode.U) && randomValue == "U")
            {
                Shoot();
                CountdownControllerIstance.timeToshootR = false;
            }
            if (Input.GetKeyDown(KeyCode.L) && randomValue == "L")
            {
                Shoot();
                CountdownControllerIstance.timeToshootR = false;
            }
            if (Input.GetKeyDown(KeyCode.K) && randomValue == "K")
            {
                Shoot();
                CountdownControllerIstance.timeToshootR = false;
            }
        }

        if (myParryMoment == true)
        {
            DisplayButton(randomValue, CountdownControllerIstance.timeToshootR);                 // Display the corresponding button based on the random value

            if (Input.GetKeyDown(KeyCode.M) && randomValue == "M")                               // Check if the corresponding key is pressed
            {
                ParryMoment.parryMomentL = false;
            }
            if (Input.GetKeyDown(KeyCode.N) && randomValue == "N")
            {
                ParryMoment.parryMomentL = false;
            }
            if (Input.GetKeyDown(KeyCode.B) && randomValue == "B")
            {
                ParryMoment.parryMomentL = false;
            }
            if (Input.GetKeyDown(KeyCode.V) && randomValue == "V")
            {
                ParryMoment.parryMomentL = false;
            }
            if (Input.GetKeyDown(KeyCode.J) && randomValue == "J")
            {
                ParryMoment.parryMomentL = false;
            }
            if (Input.GetKeyDown(KeyCode.H) && randomValue == "H")
            {
                ParryMoment.parryMomentL = false;
            }
        }

    }

   void DisplayButton(string value, bool isVisible) 
    {
        // Display the corresponding button based on the input value
         switch (value)
        {
            case "P":
                ButtonP.SetActive(true);
                break;
            case "O":
                ButtonO.SetActive(true);
                break;
            case "I":
                ButtonI.SetActive(true);
                break;
            case "U":
                ButtonU.SetActive(true);
                break;
            case "L":
                ButtonL.SetActive(true);
                break;
            case "K":
                ButtonK.SetActive(true);
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
            case "P":
                ButtonP.SetActive(false);
                break;
            case "O":
                ButtonO.SetActive(false);
                break;
            case "I":
                ButtonI.SetActive(false);
                break;
            case "U":
                ButtonU.SetActive(false);
                break;
            case "L":
                ButtonL.SetActive(false);
                break;
            case "K":
                ButtonK.SetActive(false);
                break;
        }

        switch (randomValueParry)
        {
            case "M":
                ButtonM.SetActive(false);
                break;
            case "N":
                ButtonN.SetActive(false);
                break;
            case "B":
                ButtonB.SetActive(false);
                break;
            case "V":
                ButtonV.SetActive(false);
                break;
            case "J":
                ButtonJ.SetActive(false);
                break;
            case "H":
                ButtonH.SetActive(false);
                break;
        }
    }

    string GetRandomValue(string[] myArray)
    {
        int randomIndex = Random.Range(0, myArray.Length);
        return myArray[randomIndex];

    }

    string GetRandomValueParry()
    {

        int randomIndexParry = Random.Range(0, parryArray.Length);
        return myArray[randomIndexParry];
    }
}
