using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletL : MonoBehaviour
{
    public float velocitaIniziale = 10f; // Velocità iniziale del proiettile
    public float velocitaMinima = 0.1f; // Velocità minima consentita
    public float velocitaMinimaLiv1 = 0.2f; //velocità minima al livello 1
    public float velocitaMinimaLiv2 = 0.4f;
    public float velocitaMinimaLiv3 = 0.6f;
    public float velocitaMinimaLiv4 = 0.8f;
    public float velocitaMinimaLiv5 = 0.9f;
    public float velocitaMinimaLiv6 = 1f;
    public float velocitaDecelerazione = 2f; // Fattore di decelerazione graduale
    public GameObject oggettoTrigger; // Oggetto con Collider2D per il trigger

    private Rigidbody2D rb;
    private bool inTrigger = false;
    public bool parryMomentL = false;
    public Score Score;

    private void Start()
    {
        Score = FindObjectOfType<Score>();

        Score.player1HasShoot = true;

        // Inizializza il riferimento al Rigidbody2D
        rb = GetComponent<Rigidbody2D>();

        if (Score.currentLevel <= 0)
        {

        }
        else if (Score.currentLevel == 1)
        {
            velocitaMinima = velocitaMinimaLiv1;
        }
        else if (Score.currentLevel == 2)
        {
            velocitaMinima = velocitaMinimaLiv2;
        }
        else if (Score.currentLevel == 3)
        {
            velocitaMinima = velocitaMinimaLiv3;
        }
        else if (Score.currentLevel == 4)
        {
            velocitaMinima = velocitaMinimaLiv4;
        }
        else if (Score.currentLevel == 5)
        {
            velocitaMinima = velocitaMinimaLiv5;
        }
        else
        {
            velocitaMinima = velocitaMinimaLiv6;
        }

        // Assegna la velocità iniziale al proiettile
        rb.velocity = transform.right * velocitaIniziale;

        parryMomentL = true;
    }

    private void Update()
    {

        // Se il proiettile è nel trigger, inizia il rallentamento graduale
        if (inTrigger)
        {
            // Calcola una velocità decelerata graduale
            float velocitaDecelerata = Mathf.Max(rb.velocity.magnitude - (velocitaDecelerazione * Time.deltaTime), velocitaMinima);

            // Applica la velocità decelerata al proiettile
            rb.velocity = rb.velocity.normalized * velocitaDecelerata;
        }
        if (inTrigger == false)
        {
            rb.velocity = transform.right * velocitaIniziale;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica se l'oggetto trigger è uguale all'oggetto desiderato
        if (other.gameObject.CompareTag("RallentatoreL") )
        {
            inTrigger = true;
        }

        if (other.gameObject.CompareTag("TriggerSconfitta") && GetComponent<SpriteRenderer>().enabled)
        {
            Score.currentMatchPlayer2RResult = 0;
        }

        if (other.gameObject.CompareTag("BulletKiller"))
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Verifica se l'oggetto trigger è uguale all'oggetto desiderato
        if (other.gameObject.CompareTag("RallentatoreL"))
        {
            inTrigger = false;
            parryMomentL = false;
        }
    }
}

