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
    private BulletL bulletL;
    private BulletR bulletR;
    public Score Score;


    private void Start()
    {
        StartCoroutine(CountdownToStart());
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
    }

    IEnumerator CountdownToStart()
    {
            Score.cuorePerso = false;

        if (countdownTime == 3)
        {
            countdownLoad.SetActive(true);
            countdownAim.SetActive(false);
            countdownShoot.SetActive(false);

            yield return new WaitForSeconds(1f);
            countdownTime--;
        }

        if (countdownTime == 2)
        {
            countdownLoad.SetActive(false);
            countdownAim.SetActive(true);
            countdownShoot.SetActive(false);

            float wait_time = Random.Range(minRandomCountDownShoot, maxRandomCountDownShoot);
            yield return new WaitForSeconds(wait_time);
        }

        countdownAim.SetActive(false);
        countdownShoot.SetActive(true);

        timeToshootL = true;
        timeToshootR = true;
        
            yield return new WaitForSeconds(0.4f);
            countdownShoot.SetActive(false);

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
        
            StopAllCoroutines();

            countdownShoot.SetActive(false);
            countdown5.SetActive(false);
            countdown4.SetActive(false);
            countdown3.SetActive(false);
            countdown2.SetActive(false);
            countdown1.SetActive(false);
            countdownTimesUp.SetActive(false);

            Invoke("EndRoundStuff", 2f);
    }

    private void EndRoundStuff()
    {
        timeToshootL = false;
        timeToshootR = false;
        timeOver = true;
    }
}
