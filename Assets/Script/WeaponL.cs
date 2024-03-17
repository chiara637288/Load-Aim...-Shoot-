using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponL : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public ParticleSystem BulletR_ps;
    public GameObject ButtonQ; // Elencare i bottoni che quando accesi mostrano al giocatore quale pulsante premere.
    public GameObject ButtonW;
    public GameObject ButtonE;
    public GameObject ButtonR;
    public GameObject ButtonT;
    public GameObject ButtonY;

    public GameObject ButtonA;
    public GameObject ButtonS;
    public GameObject ButtonD;
    public GameObject ButtonF;
    public GameObject ButtonZ;
    public GameObject ButtonX;

    public CountdownController CountdownControllerIstance;
    public CountdownController CountdownControllerIstance1;
    public CountdownController CountdownControllerIstanceTimeOver;
    public Score Score;
    private BulletR bulletR;
    public Animator animator;

    string[] myArray = { "Q", "W", "E", "R", "T", "Y" };
    string[] parryArrayL = { "A", "S", "D", "F", "Z", "X" };
    string randomValue;
    string randomValueParryL;

    void OnEnable()
    {
        // Call the function to randomly pick a value from the array at the beginning
        randomValue = GetRandomValue(myArray);
        Debug.Log("Randomly picked value: " + randomValue);

        randomValueParryL = GetRandomValueParry(parryArrayL);
        Debug.Log("Randomly picked value parryL : " + randomValueParryL);

    }

    void Update()
    {
        bulletR = FindObjectOfType<BulletR>();
        bool isTimeToShootL = CountdownControllerIstance.timeToshootL;
        bool isTimeToShootR = CountdownControllerIstance1.timeToshootR;
        bool isTimeOver = CountdownControllerIstanceTimeOver.timeOver;
        //int currentMatchPlayer1LResult = Score.currentMatchPlayer1LResult;

        if (isTimeToShootL)
        {
            DisplayButton(randomValue, CountdownControllerIstance.timeToshootL);                 // Display the corresponding button based on the random value

            // Check if the corresponding key is pressed
            if (Input.GetKeyDown(KeyCode.Q) && randomValue == "Q")
            {
                Shoot();                                                                         //  isTimeToShoot = false; dovrebbe far smettere di funzionare lo sparo ma dunno non va
                CountdownControllerIstance.timeToshootL = false;
            }
            if (Input.GetKeyDown(KeyCode.W) && randomValue == "W")
            {
                Shoot();
                CountdownControllerIstance.timeToshootL = false;
            }
            if (Input.GetKeyDown(KeyCode.E) && randomValue == "E")
            {
                Shoot();
                CountdownControllerIstance.timeToshootL = false;
            }
            if (Input.GetKeyDown(KeyCode.R) && randomValue == "R")
            {
                Shoot();
                CountdownControllerIstance.timeToshootL = false;
            }
            if (Input.GetKeyDown(KeyCode.T) && randomValue == "T")
            {
                Shoot();
                CountdownControllerIstance.timeToshootL = false;
            }
            if (Input.GetKeyDown(KeyCode.Y) && randomValue == "Y")
            {
                Shoot();
                CountdownControllerIstance.timeToshootL = false;
            }
        }

        if (bulletR != null) 
        {
            if (bulletR.parryMomentR == true)
            {
                DisplayButtonParry(randomValueParryL, CountdownControllerIstance.timeToshootL);                 // Display the corresponding button based on the random value

                if (Input.GetKeyDown(KeyCode.A) && randomValueParryL == "A")                               // Check if the corresponding key is pressed
                {
                    Parry();
                    bulletR.parryMomentR = false;
                }
                if (Input.GetKeyDown(KeyCode.S) && randomValueParryL == "S")
                {
                    Parry();
                    bulletR.parryMomentR = false;
                }
                if (Input.GetKeyDown(KeyCode.D) && randomValueParryL == "D")
                {
                    Parry();
                    bulletR.parryMomentR = false;
                }
                if (Input.GetKeyDown(KeyCode.F) && randomValueParryL == "F")
                {
                    Parry();
                    bulletR.parryMomentR = false;
                }
                if (Input.GetKeyDown(KeyCode.Z) && randomValueParryL == "Z")
                {
                    Parry();
                    bulletR.parryMomentR = false;
                }
                if (Input.GetKeyDown(KeyCode.X) && randomValueParryL == "X")
                {
                    Parry();
                    bulletR.parryMomentR = false;
                }
            }
        }

        if (isTimeOver == true || Score.currentMatchPlayer1LResult == 0)
        {
            ButtonQ.SetActive(false);
            ButtonW.SetActive(false);
            ButtonE.SetActive(false);
            ButtonR.SetActive(false);
            ButtonT.SetActive(false);
            ButtonY.SetActive(false);

            ButtonA.SetActive(false);
            ButtonS.SetActive(false);
            ButtonD.SetActive(false);
            ButtonF.SetActive(false);
            ButtonZ.SetActive(false);
            ButtonX.SetActive(false);
        }
    }

    void DisplayButton(string value, bool isVisible)
    {
        // Display the corresponding button based on the input value
        switch (value) //la seconda volta non partono ma qua dentro ci entra
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

    void DisplayButtonParry(string value2, bool isVisible) 
    {
        // Display the corresponding button based on the input value
        switch (value2)
        {
            case "A":
                ButtonA.SetActive(true);
                break;
            case "S":
                ButtonS.SetActive(true);
                break;
            case "D":
                ButtonD.SetActive(true);
                break;
            case "F":
                ButtonF.SetActive(true);
                break;
            case "Z":
                ButtonZ.SetActive(true);
                break;
            case "X":
                ButtonX.SetActive(true);
                break;
        }
    }
    void Shoot()
    {
        // Shooting spawn
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        animator.SetBool("Time To Gun", false);
        animator.SetBool("Time To Parry", true);

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
    void Parry()
    {

        switch (randomValueParryL)
        {

            case "A":
                ButtonA.SetActive(false);
                break;
            case "S":
                ButtonS.SetActive(false);
                break;
            case "D":
                ButtonD.SetActive(false);
                break;
            case "F":
                ButtonF.SetActive(false);
                break;
            case "Z":
                ButtonZ.SetActive(false);
                break;
            case "X":
                ButtonX.SetActive(false);
                break;
        }
        
          SpriteRenderer bulletRenderer = FindObjectOfType<BulletR>().GetComponent<SpriteRenderer>();
          bulletRenderer.enabled = false;

          animator.SetBool("Parry Slash", true);
          Invoke("SlashStop", 0.5f);

          BulletR_ps.Play();
          Score.currentMatchPlayer1LResult = 1;
    }

    string GetRandomValue(string[] myArray)
    {
        int randomIndex = Random.Range(0, myArray.Length);
        return myArray[randomIndex];
    }
    string GetRandomValueParry(string[] parryArrayL)
    {
        int randomIndexParry = Random.Range(0, parryArrayL.Length);
        return parryArrayL[randomIndexParry];
    }

    public void SlashStop()
    {
        animator.SetBool("Parry Slash", false);
    }
}