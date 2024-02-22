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
    public CountdownController CountdownControllerIstance1; 
    public CountdownController CountdownControllerIstanceTimeOver;
    private BulletL bulletL;

    string[] myArray = { "P", "O", "I", "U", "L", "K" };
    string[] parryArray = { "M", "N", "B", "V", "J", "H" };
    string randomValue;
    string randomValueParry;

    void Start()
    {
        // Call the function to randomly pick a value from the array at the beginning
        randomValue = GetRandomValue(myArray);
        Debug.Log("Randomly picked value: " + randomValue);

        randomValueParry = GetRandomValueParry(parryArray);
        Debug.Log("Randomly picked value parry : " + randomValueParry);

    }

    void Update()
    {
        bulletL = FindObjectOfType<BulletL>();
        bool isTimeToShootR = CountdownControllerIstance.timeToshootR;
        bool isTimeToShootL = CountdownControllerIstance1.timeToshootL;
        bool isTimeOver = CountdownControllerIstanceTimeOver.timeOver;

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
        if (bulletL != null)
        {
            if (bulletL.parryMomentL)
            {
                DisplayButtonParry(randomValueParry, CountdownControllerIstance.timeToshootR);                 // Display the corresponding button based on the random value

                if (Input.GetKeyDown(KeyCode.M) && randomValueParry == "M")                               // Check if the corresponding key is pressed
                {
                    Parry();
                    bulletL.parryMomentL = false;
                }
                if (Input.GetKeyDown(KeyCode.N) && randomValueParry == "N")
                {
                    Parry();
                    bulletL.parryMomentL = false;
                }
                if (Input.GetKeyDown(KeyCode.B) && randomValueParry == "B")
                {
                    Parry();
                    bulletL.parryMomentL = false;
                }
                if (Input.GetKeyDown(KeyCode.V) && randomValueParry == "V")
                {
                    Parry();
                    bulletL.parryMomentL = false;
                }
                if (Input.GetKeyDown(KeyCode.J) && randomValueParry == "J")
                {
                    Parry();
                    bulletL.parryMomentL = false;
                }
                if (Input.GetKeyDown(KeyCode.H) && randomValueParry == "H")
                {
                    Parry();
                    bulletL.parryMomentL = false;
                }
            }
        }

        if (isTimeOver == true)
        {
            ButtonP.SetActive(false);
            ButtonO.SetActive(false);
            ButtonI.SetActive(false);
            ButtonU.SetActive(false);
            ButtonL.SetActive(false);
            ButtonK.SetActive(false);

            ButtonM.SetActive(false);
            ButtonN.SetActive(false);
            ButtonB.SetActive(false);
            ButtonV.SetActive(false);
            ButtonJ.SetActive(false);
            ButtonH.SetActive(false);
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
    void DisplayButtonParry(string value2, bool isVisible)
    {
        // Display the corresponding button based on the input value
        switch (value2)
        {
            case "M":
                ButtonM.SetActive(true);
                break;
            case "N":
                ButtonN.SetActive(true);
                break;
            case "B":
                ButtonB.SetActive(true);
                break;
            case "V":
                ButtonV.SetActive(true);
                break;
            case "J":
                ButtonJ.SetActive(true);
                break;
            case "H":
                ButtonH.SetActive(true);
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
    }

    void Parry()
    {
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


        SpriteRenderer bulletRenderer = FindObjectOfType<BulletL>().GetComponent<SpriteRenderer>();
        bulletRenderer.enabled = false;
    }

        string GetRandomValue(string[] myArray)
    {
        int randomIndex = Random.Range(0, myArray.Length);
        return myArray[randomIndex];

    }

    string GetRandomValueParry(string[] parryArray)
    {
        int randomIndexParry = Random.Range(0, parryArray.Length);
        return parryArray[randomIndexParry];
    }
}
