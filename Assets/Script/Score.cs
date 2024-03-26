using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering.LookDev;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int currentLevel = 0;                // ricordarsi di controllare il caso in cui il current level va sotto a 0
    public int currentMatchPlayer1LResult = 3;
    public int currentMatchPlayer2RResult = 3;   // 3 è la base, 2 è quando non si spara, 0 è quando si è morti, 1 quando si ha parryato 
    public bool player1HasShoot = false;
    public bool player2HasShoot = false;
    private int roundBothDied = 0;
    public bool risulatoCalcolato = false;
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

    public void Update()    //non può controllare costantemente, dovrebbe attivarsi solo dopo x tempo (magari sopo la fine delle animazioni di morti o di parry) //Se uno spara e l'artro muore subito non c'è nessuna condizione che controlli sta cosa 
    {
        if (currentMatchPlayer1LResult == 0 && currentMatchPlayer2RResult == 0 && risulatoCalcolato == false)     //entrambi hanno perso e quindi non perdono cuori
        {
            roundBothDied = roundBothDied++;
            if (roundBothDied == 2)
            {
                currentLevel--;
                roundBothDied = 0;
            }

            risulatoCalcolato = true;
        }

        if (currentMatchPlayer1LResult == 1 && currentMatchPlayer2RResult == 1 && risulatoCalcolato == false)
        {
            currentLevel++;

            risulatoCalcolato = true;
        }

        if (currentMatchPlayer1LResult == 1 && currentMatchPlayer2RResult == 0 && risulatoCalcolato == false)
        {
            DeathPlayer2();
        }

        if (currentMatchPlayer1LResult == 0 && currentMatchPlayer2RResult == 1 && risulatoCalcolato == false)
        {
            DeathPlayer1();
        }

        if (player1HasShoot == false && currentMatchPlayer1LResult == 0 && risulatoCalcolato == false)
        {
            DeathPlayer1();
        }

        if (player2HasShoot == false && currentMatchPlayer2RResult == 0 && risulatoCalcolato == false)
        {
            DeathPlayer2();
        }

        if (currentMatchPlayer1LResult == 2) // questo evento forse è meglio toglierlo, conviene fare che se nessuno ha sparato il conto alla roveglia non parte
        {
            //nulla, vi siete dimenticati di sparate?
        }

        if (currentMatchPlayer2RResult == 2)
        {

        }
    }

    public void DeathPlayer1()
    {
        StartCoroutine(cameraShake.Shake(.15f, .4f));

        if (HeartPlayer13.activeSelf && risulatoCalcolato == false)
        {
            HeartPlayer13.SetActive(false);
            risulatoCalcolato = true;
        }
        else if (HeartPlayer12.activeSelf && risulatoCalcolato == false)
        {
            HeartPlayer12.SetActive(false);
            risulatoCalcolato = true;
        }
        else if (HeartPlayer11.activeSelf && risulatoCalcolato == false)
        {
            HeartPlayer11.SetActive(false);
            risulatoCalcolato = true;
        }

        player1HasShoot = false;
        player2HasShoot = false;

        countdownController.timeToshootL = false;

        animator.SetBool("I'm Dead", true);

        Invoke("SetDeathAnimFalse", 1.5f);
    }

    public void DeathPlayer2()
    {
        StartCoroutine(cameraShake.Shake(.15f, .4f));

        if (HeartPlayer21.activeSelf && risulatoCalcolato == false)
        {
            HeartPlayer21.SetActive(false);
            risulatoCalcolato = true;
        }
        else if (HeartPlayer22.activeSelf && risulatoCalcolato == false)
        {
            HeartPlayer22.SetActive(false);
            risulatoCalcolato = true;
        }
        else if (HeartPlayer23.activeSelf && risulatoCalcolato == false)
        {
            HeartPlayer23.SetActive(false);
            risulatoCalcolato = true;
        }

        player1HasShoot = false;
        player2HasShoot = false;

        countdownController.timeToshootR = false;

        animatorR.SetBool("I'm Dead R", true);

        Invoke("SetDeathAnimFalse", 1.5f);
    }

    public void SetDeathAnimFalse()
    {
        animator.SetBool("I'm Dead", false);
        animatorR.SetBool("I'm Dead R", false);
    }
}
