using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float velocitaIniziale = 10f; // Velocit� iniziale del proiettile
    public float velocitaMinima = 1f; // Velocit� minima consentita
    public float velocitaDecelerazione = 2f; // Fattore di decelerazione graduale
    public GameObject oggettoTrigger; // Oggetto con Collider2D per il trigger

    private Rigidbody2D rb;
    private bool inTrigger = false;

    private void Start()
    {
        // Inizializza il riferimento al Rigidbody2D
        rb = GetComponent<Rigidbody2D>();

        // Assegna la velocit� iniziale al proiettile
        rb.velocity = transform.right * velocitaIniziale;
    }

    private void Update()
    {
        // Se il proiettile � nel trigger, inizia il rallentamento graduale
        if (inTrigger)
        {
            // Calcola una velocit� decelerata graduale
            float velocitaDecelerata = Mathf.Max(rb.velocity.magnitude - (velocitaDecelerazione * Time.deltaTime), velocitaMinima);

            // Applica la velocit� decelerata al proiettile
            rb.velocity = rb.velocity.normalized * velocitaDecelerata;
        }
        if (inTrigger == false)
        {
            rb.velocity = transform.right * velocitaIniziale;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica se l'oggetto trigger � uguale all'oggetto desiderato
        if (other.gameObject.CompareTag("Rallentatore") )
        {
            inTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Verifica se l'oggetto trigger � uguale all'oggetto desiderato
        if (other.gameObject.CompareTag("Rallentatore"))
        {
            inTrigger = false;
        }
    }
}

