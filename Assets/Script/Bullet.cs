using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    float level = 0;
    public Rigidbody2D rb;
    public Transform knight;                 // Riferimento all'oggetto fermo
    public float slowDistance = 3f; // Distanza sotto la quale inizia il rallentamento
    public float velocitaRallentamento = 2f; // Velocità di rallentamento
    public float minVelocity = 1f; // Velocità minima consentita

    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();// fare che controlla la distanza tra player e proiettile e sotto quel valore il proiettile inizia a rallentare
    }                                           // Il rallentamento è un lerp function tra due velocità (una minima velocità del proiettile che dovrà essere modificabile in base
                                                // base al livello in cui ti trovi). La distanza in cui inizia a rallentare è uguale.
    private void Update()
    {
        // Calcola la distanza tra il proiettile e l'oggetto fermo
        float distance = Vector3.Distance(transform.position, knight.position); // non dovrei definirgli se è sull asse delle x o Y?

        // Se la distanza è inferiore alla soglia di rallentamento
        if (distance < slowDistance)
        {
            // Calcola una velocità decelerata graduale
            float velocitaDecelerata = Mathf.Lerp(minVelocity, velocitaRallentamento, distance / slowDistance);

            // Applica la velocità decelerata al proiettile
            rb.velocity = transform.right * speed;
            rb.velocity = rb.velocity.normalized * velocitaDecelerata;
        }
    }

}