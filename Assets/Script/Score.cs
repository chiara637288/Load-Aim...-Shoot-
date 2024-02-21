using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int currentLevel = 0;                // ricordarsi di controllare il caso in cui il current level va sotto a 0
    public int currentMatchPlayer1LResult = 2;
    public int currentMatchPlayer2RResult = 2;   // 2 è quando non si spara, 0 è quando si è morti, 1 quando si è vivi 
    public GameObject HeartPlayer11;
    public GameObject HeartPlayer12;
    public GameObject HeartPlayer13;
    public GameObject HeartPlayer21;
    public GameObject HeartPlayer22;
    public GameObject HeartPlayer23;

    public void ScoreControl() //lo score control viene chiamato se entrambi muoiono, se entrambi parryano, se scade il tempo (il tempo dovrebbe controllare da solo che non ci sono proiettili in movimento), e se uno dei due muore senza aver sparato 
    {
        if (currentMatchPlayer1LResult == 0 && currentMatchPlayer2RResult == 0)
        {
            //entrambi hanno perso e quindi non perdono cuori
            //se entrambi perdono per 2 volte di fila currentLevel = currentLevel--;
        }

        if (currentMatchPlayer1LResult == 1 && currentMatchPlayer2RResult == 1) //e se uno fa 1 e l'altro fa 2?
        {
            //entrambi non perdono un cuore
            currentLevel = currentLevel++;
        }

        if (currentMatchPlayer1LResult == 1 && currentMatchPlayer2RResult == 0) //player 1 ha vinto e player 2 ha perso
        {
            if (HeartPlayer21.activeSelf)
            {
                HeartPlayer21.SetActive(false);
            }
            else
            {
                if (HeartPlayer22.activeSelf)
                {
                    HeartPlayer22.SetActive(false);
                }
                else
                {
                    HeartPlayer23.SetActive(false);
                    DeathPlayer2();
                }
            }
        }

        if (currentMatchPlayer1LResult == 0 && currentMatchPlayer2RResult == 1) // Player1 ha perso e player 2 ha vinto
        {
            if (HeartPlayer13.activeSelf)
            {
                HeartPlayer13.SetActive(false);
            }
            else
            {
                if (HeartPlayer12.activeSelf)
                {
                    HeartPlayer12.SetActive(false);
                }
                else
                {
                    HeartPlayer11.SetActive(false);
                    DeathPlayer1();
                }
            }
        }

        if (currentMatchPlayer1LResult == 2 && currentMatchPlayer2RResult == 2) // questo evento forse è meglio toglierlo, conviene fare che se nessuno ha sparato il conto alla roveglia non parte
        {
            //nulla, vi siete dimenticati di sparate?
        }
    }

    void DeathPlayer1()
    {

    }

    void DeathPlayer2()
    {

    }
}
