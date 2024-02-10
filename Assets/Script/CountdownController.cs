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
    

    private void Start()
    {
        StartCoroutine(CountdownToStart());
    }

    IEnumerator CountdownToStart()
    {
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

        yield return new WaitForSeconds(5f);  // Se entrambi i gioctori hanno sparato allora il countdown si ferma
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
    }
}
