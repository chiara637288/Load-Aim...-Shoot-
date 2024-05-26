using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int currentLevel = 0;                // ricordarsi di controllare il caso in cui il current level va sotto a 0
    public int currentMatchPlayer1LResult = 3;
    public int currentMatchPlayer2RResult = 3;   // 3 è la base, 2 è quando non si spara, 0 è quando si è morti, 1 quando si ha parryato 
    public bool player1HasShoot = false;
    public bool player2HasShoot = false;
    private int roundBothDied = 0;
    public bool risultatoCalcolato = false;
    public bool gameFinished = false;
    public GameObject HeartPlayer11;
    public GameObject HeartPlayer12;
    public GameObject HeartPlayer13;
    public GameObject HeartPlayer21;
    public GameObject HeartPlayer22;
    public GameObject HeartPlayer23;
    public Animator animator;
    public Animator animatorR;
    public CameraShake cameraShake;
    public CountdownController countdownController;

    public void Update()    
    {
        if (currentMatchPlayer1LResult == 0 && currentMatchPlayer2RResult == 0 && risultatoCalcolato == false)     //entrambi hanno perso e quindi non perdono cuori
        {
            roundBothDied = roundBothDied++;

            if (roundBothDied == 2)
            {
                currentLevel--;
                roundBothDied = 0;
            }
             //Aggiungiamo una scritta per far capire cos'è successo?

            risultatoCalcolato = true;
        }

        else if (currentMatchPlayer1LResult == 1 && currentMatchPlayer2RResult == 1 && risultatoCalcolato == false)
        {
            currentLevel++;

            risultatoCalcolato = true;
        }

        else if (currentMatchPlayer1LResult == 1 && currentMatchPlayer2RResult == 0 && risultatoCalcolato == false)
        {
            DeathPlayer2();
        }

        else if (currentMatchPlayer1LResult == 0 && currentMatchPlayer2RResult == 1 && risultatoCalcolato == false)
        {
            DeathPlayer1();
        }

        else if (player1HasShoot == false && currentMatchPlayer1LResult == 0 && risultatoCalcolato == false)
        {
            DeathPlayer1();
        }

        else if (player2HasShoot == false && currentMatchPlayer2RResult == 0 && risultatoCalcolato == false)
        {
            DeathPlayer2();
        }

        else if (currentMatchPlayer1LResult == 2) // questo evento forse è meglio toglierlo, conviene fare che se nessuno ha sparato il conto alla roveglia non parte
        {
            //nulla, vi siete dimenticati di sparate?
        }

        else if (currentMatchPlayer2RResult == 2)
        {

        }
    }

    public void DeathPlayer1()
    {
        StartCoroutine(cameraShake.Shake(.15f, .4f));

        if (HeartPlayer13.activeSelf && risultatoCalcolato == false)
        {
            HeartPlayer13.SetActive(false);
            risultatoCalcolato = true;
        }
        else if (HeartPlayer12.activeSelf && risultatoCalcolato == false)
        {
            HeartPlayer12.SetActive(false);
            risultatoCalcolato = true;
        }
        else if (HeartPlayer11.activeSelf && risultatoCalcolato == false)
        {
            HeartPlayer11.SetActive(false);
            risultatoCalcolato = true;
            GameOver();
        }

        player1HasShoot = false;
        player2HasShoot = false;

        countdownController.timeToshootL = false;

        animator.SetBool("I'm Dead", true);
    }

    public void DeathPlayer2()
    {
        StartCoroutine(cameraShake.Shake(.15f, .4f));

        if (HeartPlayer21.activeSelf && risultatoCalcolato == false)
        {
            HeartPlayer21.SetActive(false);
            risultatoCalcolato = true;
        }
        else if (HeartPlayer22.activeSelf && risultatoCalcolato == false)
        {
            HeartPlayer22.SetActive(false);
            risultatoCalcolato = true;
        }
        else if (HeartPlayer23.activeSelf && risultatoCalcolato == false)
        {
            HeartPlayer23.SetActive(false);
            risultatoCalcolato = true;
            GameOver();
        }

        player1HasShoot = false;
        player2HasShoot = false;

        countdownController.timeToshootR = false;

        animatorR.SetBool("I'm Dead R", true);
    }

    public void GameOver()
    {
        countdownController.StopAllCoroutines();

        if (HeartPlayer21.activeSelf == false)
        {
            animator.SetBool("I Win", true);
        }
        if (HeartPlayer11.activeSelf == false)
        {
            animatorR.SetBool("I Win R", true);
        }

        gameFinished = true;

        // fai apparire il tasto restart 
        // fai apprare il tasto per il main menu

    }

}
