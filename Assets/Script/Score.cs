using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int currentLevel = 0;                // ricordarsi di controllare il caso in cui il current level va sotto a 0
    public int currentMatchPlayer1LResult = 2;
    public int currentMatchPlayer2RResult = 2;   // 2 è quando non si spara, 0 è quando si è morti, 1 quando si è vivi 
    public int currentHeartsPlayer1 = 3;
    public int currentHeartsPlayer2 = 3;

    // Update is called once per frame
    void Update()
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

        if (currentMatchPlayer1LResult == 1 && currentMatchPlayer2RResult == 0)
        {

        }

        if (currentMatchPlayer1LResult == 0 && currentMatchPlayer2RResult == 1)
        {

        }

        if (currentMatchPlayer1LResult == 2 && currentMatchPlayer2RResult == 2)
        {
            //nulla, vi siete dimenticati di sparate?
        }

        if (currentHeartsPlayer1 == 0)
        {
            //Loser
        }

        if (currentHeartsPlayer2 == 0)
        {
            //Loser
        }
    }

    void DeathPlayer1()
    {

    }

    void DeathPlayer2()
    {

    }
}
