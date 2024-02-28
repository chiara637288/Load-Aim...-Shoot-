using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int currentLevel = 0;                // ricordarsi di controllare il caso in cui il current level va sotto a 0
    public int currentMatchPlayer1LResult = 3;
    public int currentMatchPlayer2RResult = 3;   // 3 � la base, 2 � quando non si spara, 0 � quando si � morti, 1 quando si ha parryato 
    public bool player1HasShoot = false;
    public bool player2HasShoot = false;
    private int roundBothDied = 0;
    public bool cuorePerso = false;
    public GameObject HeartPlayer11;
    public GameObject HeartPlayer12;
    public GameObject HeartPlayer13;
    public GameObject HeartPlayer21;
    public GameObject HeartPlayer22;
    public GameObject HeartPlayer23;

    public void Update()    //non pu� controllare costantemente, dovrebbe attivarsi solo dopo x tempo (magari sopo la fine delle animazioni di morti o di parry) //Se uno spara e l'artro muore subito non c'� nessuna condizione che controlli sta cosa 
    {
        if (currentMatchPlayer1LResult == 0 && currentMatchPlayer2RResult == 0 && cuorePerso == false)     //entrambi hanno perso e quindi non perdono cuori
        {
            roundBothDied = roundBothDied++;
            if (roundBothDied == 2)
            {
                currentLevel = currentLevel--;
                roundBothDied = 0;
            }
        }

        if (currentMatchPlayer1LResult == 1 && currentMatchPlayer2RResult == 1 && cuorePerso == false) //e se uno fa 1 e l'altro fa 2?
        {
            currentLevel = currentLevel++;
        }

        if (currentMatchPlayer1LResult == 1 && currentMatchPlayer2RResult == 0 && cuorePerso == false) //player 1 ha vinto e player 2 ha perso
        {
           DeathPlayer2();
        }

        if (currentMatchPlayer1LResult == 0 && currentMatchPlayer2RResult == 1 && cuorePerso == false) // Player1 ha perso e player 2 ha vinto
        {
           DeathPlayer1();
        }

        if (player1HasShoot == false && currentMatchPlayer1LResult == 0) 
        {
            DeathPlayer1();
        }

        if (player2HasShoot == false && currentMatchPlayer2RResult == 0)
        {
           DeathPlayer2();
        }

        if (currentMatchPlayer1LResult == 2 ) // questo evento forse � meglio toglierlo, conviene fare che se nessuno ha sparato il conto alla roveglia non parte
        {
            //nulla, vi siete dimenticati di sparate?
        }

        if (currentMatchPlayer2RResult == 2) 
        {

        }
    }

   public void DeathPlayer1()
    {
        if (HeartPlayer13.activeSelf && cuorePerso == false)
        {
            HeartPlayer13.SetActive(false);
            cuorePerso = true;
        }
        else if (HeartPlayer12.activeSelf && cuorePerso == false)
        {
            HeartPlayer12.SetActive(false);
            cuorePerso = true;
        }
        else if (HeartPlayer13.activeSelf && cuorePerso == false)
        {
            HeartPlayer11.SetActive(false);
            cuorePerso = true;
        }
        player1HasShoot = false;
        player2HasShoot = false;

}

   public void DeathPlayer2()
    {
        if (HeartPlayer21.activeSelf && cuorePerso == false)
        {
            HeartPlayer21.SetActive(false);
            cuorePerso = true;
        }
        else if (HeartPlayer22.activeSelf && cuorePerso == false)
        {
            HeartPlayer22.SetActive(false);
            cuorePerso = true;
        }
        else if (HeartPlayer23.activeSelf && cuorePerso == false)
        {
            HeartPlayer23.SetActive(false);
            cuorePerso = true;
        }

        player1HasShoot = false;
        player2HasShoot = false;
    }
}
