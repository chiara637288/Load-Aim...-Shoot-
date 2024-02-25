using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletL : MonoBehaviour
{
    public float velocitaIniziale = 10f; // Velocità iniziale del proiettile
    public float velocitaMinima = 1f; // Velocità minima consentita
    public float velocitaDecelerazione = 2f; // Fattore di decelerazione graduale
    public GameObject oggettoTrigger; // Oggetto con Collider2D per il trigger

    private Rigidbody2D rb;
    private bool inTrigger = false;
    public bool parryMomentL = false;

    private void Start()
    {
        // Inizializza il riferimento al Rigidbody2D
        rb = GetComponent<Rigidbody2D>();

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

