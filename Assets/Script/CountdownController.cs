using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CountdownController : MonoBehaviour
{
    public float countdownTime;
    public GameObject countdownLoad; //TextMeshProUGUI Serve per il testo di TextMeshPro
    public GameObject countdownAim;
    public GameObject countdownShoot;

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

            float wait_time = Random.Range(0.5f, 5);
            yield return new WaitForSeconds(wait_time);
        }

        countdownShoot.SetActive(true);
                                                //GameController.instance.BeginGame(); il video parlava di come ha una classe gamecontroller che fa partire il gioco accendendo input e ste cose
        yield return new WaitForSeconds(1f);

        countdownShoot.SetActive(false);

    }
}
