using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponR : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public ParticleSystem BulletL_ps;
    public GameObject ButtonP; // Elencare i bottoni che quando accesi mostrano al giocatore quale pulsante premere.
    public GameObject ButtonO;
    public GameObject ButtonI;
    public GameObject ButtonU;
    public GameObject ButtonJ;

    public GameObject ButtonK; // Elencare i bottoni che quando accesi mostrano al giocatore quale pulsante premere.
    public GameObject ButtonN;
    public GameObject ButtonB;
    public GameObject ButtonL;
    public GameObject ButtonH;
    public CountdownController CountdownControllerIstance;
    public CountdownController CountdownControllerIstance1; 
    public CountdownController CountdownControllerIstanceTimeOver;
    public Score Score;
    private BulletL bulletL;
    public Animator animator;

    string[] myArray = { "P", "O", "I", "U", "J" };
    string[] parryArray = { "K", "N", "B", "L", "H" };
    string randomValue;
    string randomValueParry;

    void OnEnable()
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
            if (Input.GetKeyDown(KeyCode.J) && randomValue == "J")
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

                if (Input.GetKeyDown(KeyCode.K) && randomValueParry == "K")                               // Check if the corresponding key is pressed
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
                if (Input.GetKeyDown(KeyCode.L) && randomValueParry == "L")
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

        if (isTimeOver == true || Score.currentMatchPlayer2RResult == 0)
        {
            ButtonP.SetActive(false);
            ButtonO.SetActive(false);
            ButtonI.SetActive(false);
            ButtonU.SetActive(false);
            ButtonJ.SetActive(false);

            ButtonK.SetActive(false);
            ButtonN.SetActive(false);
            ButtonB.SetActive(false);
            ButtonL.SetActive(false);
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
            case "J":
                ButtonJ.SetActive(true);
                break;
        }
    }
    void DisplayButtonParry(string value2, bool isVisible)
    {
        // Display the corresponding button based on the input value
        switch (value2)
        {
            case "K":
                ButtonK.SetActive(true);
                break;
            case "N":
                ButtonN.SetActive(true);
                break;
            case "B":
                ButtonB.SetActive(true);
                break;
            case "L":
                ButtonL.SetActive(true);
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

        animator.SetBool("Time To Gun R", false);
        animator.SetBool("Time To Parry R", true);

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
            case "J":
                ButtonJ.SetActive(false);
                break;
        }
    }

    void Parry()
    {
        AudioManager.instance.FadeIn("Slash2");

        switch (randomValueParry)
        {
            case "K":
                ButtonK.SetActive(false);
                break;
            case "N":
                ButtonN.SetActive(false);
                break;
            case "B":
                ButtonB.SetActive(false);
                break;
            case "L":
                ButtonL.SetActive(false);
                break;
            case "H":
                ButtonH.SetActive(false);
                break;
        }


        SpriteRenderer bulletRenderer = FindObjectOfType<BulletL>().GetComponent<SpriteRenderer>();
        bulletRenderer.enabled = false;

        animator.SetBool("Parry Slash R", true);
        Invoke("SlashStopR", 0.17f);

        BulletL_ps.Play();
        Score.currentMatchPlayer2RResult = 1;
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
    public void SlashStopR()
    {
        animator.SetBool("Parry Slash R", false);
    }
}
