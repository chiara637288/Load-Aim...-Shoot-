using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CountdownController : MonoBehaviour
{
    public float countdownTime;
    public GameObject countdownLoad; //TextMeshProUGUI Serve per il testo di TextMeshPro
    public GameObject countdownAim;
    public GameObject countdownShoot;
    public GameObject LoadText;
    public GameObject AimText;
    public GameObject ShootText;
    public GameObject countdown5;
    public GameObject countdown4;
    public GameObject countdown3;
    public GameObject countdown2;
    public GameObject countdown1;
    public GameObject countdownTimesUp;
    public float minRandomCountDownShoot;
    public float maxRandomCountDownShoot;
    public bool timeToshootL = false;
    public bool timeToshootR = false;
    public bool timeOver = false;
    private bool previousParryL = false;
    private bool previousParryR = false;
    private bool CountdownStop = false;
    private BulletL bulletL;
    private BulletR bulletR;
    public GameObject weaponL;
    public GameObject weaponR;
    public Score Score;
    public Animator animator;


    private void Start()
    {
        timeToshootL = false;
        timeToshootR = false;
        timeOver = false;
        Invoke("StartIdle", 4f);

        Invoke("StartGame", 4f);
    }

    public void Update()
    {
        bulletL = FindObjectOfType<BulletL>();
        bulletR = FindObjectOfType<BulletR>();

        if (bulletL != null && bulletR != null)
        {
            if (bulletL.parryMomentL == true && bulletR.parryMomentR == true)
            {
                StopCountdown();
            }
        }

        if (Score.risulatoCalcolato == true)
        {
            StopCountdown();
        }
    }

    IEnumerator CountdownToStart()
    {
        Score.risulatoCalcolato = false;
        Score.currentMatchPlayer1LResult = 3;
        Score.currentMatchPlayer2RResult = 3;
        timeOver = false;

        CountdownStop = false;

        if (countdownTime == 3)
        {
            animator.SetBool("Time To Gun", true);
            animator.SetBool("Time To Gun 2", true);
            countdownLoad.SetActive(true);
            LoadText.SetActive(true);

            yield return new WaitForSeconds(1f);
            countdownTime--;
        }

        if (countdownTime == 2)
        {
            countdownLoad.SetActive(false);
            LoadText.SetActive(false);
            countdownAim.SetActive(true);
            AimText.SetActive(true);

            float wait_time = Random.Range(minRandomCountDownShoot, maxRandomCountDownShoot);
            yield return new WaitForSeconds(wait_time);
        }

        countdownAim.SetActive(false);
        AimText.SetActive(false);
        countdownShoot.SetActive(true);
        ShootText.SetActive(true);

        timeToshootL = true;
        timeToshootR = true;

        yield return new WaitForSeconds(0.6f);
        countdownShoot.SetActive(false);
        ShootText.SetActive(false);

        yield return new WaitForSeconds(5f);
        countdown5.SetActive(true);

        yield return new WaitForSeconds(1f);
        countdown5.SetActive(false);
        countdown4.SetActive(true);

        yield return new WaitForSeconds(1f);
        countdown4.SetActive(false);
        countdown3.SetActive(true);

        yield return new WaitForSeconds(1f);
        countdown3.SetActive(false);
        countdown2.SetActive(true);

        yield return new WaitForSeconds(1f);
        countdown2.SetActive(false);
        countdown1.SetActive(true);

        yield return new WaitForSeconds(1f);
        countdown1.SetActive(false);
        countdownTimesUp.SetActive(true);

        timeToshootL = false;
        timeToshootR = false;
        timeOver = true;
    }

    private void StopCountdown()
    {
        if (CountdownStop == false)
        {
            StopAllCoroutines();

            countdownShoot.SetActive(false);
            countdown5.SetActive(false);
            countdown4.SetActive(false);
            countdown3.SetActive(false);
            countdown2.SetActive(false);
            countdown1.SetActive(false);
            countdownTimesUp.SetActive(false);

            Invoke("EndRoundStuff", 2f);

            CountdownStop = true;
        }
    }

    private void EndRoundStuff()
    {
        timeToshootL = false;
        timeToshootR = false;
        timeOver = true;

        Invoke("RestartGame", 2f);
    }

    private void RestartGame()
    {
        weaponL.GetComponent<WeaponL>().enabled = false;
        weaponL.GetComponent<WeaponL>().enabled = true;

        weaponR.GetComponent<WeaponR>().enabled = false;
        weaponR.GetComponent<WeaponR>().enabled = true;

        StopAllCoroutines();

        countdownTime = 3;

        StartCoroutine(CountdownToStart());
    }

    private void StartGame()
    {
        StartCoroutine(CountdownToStart());
    }
    private void StartIdle()
    {
        animator.SetBool("Start Idle", true);
        animator.SetBool("Start Idle 2", true);
    }
}
