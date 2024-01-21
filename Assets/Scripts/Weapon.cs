using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public Gameobject bulletPrefab;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown("Fire1")) //questo fire1 si riferice ad una variabile che può essere cambiata in una finestra di unity, ma devo poi cambiarla in un valore randomico in base al samurai
        {
            Shoot();
        }
    }

    void Shoot ()
    {
        //shooting logic
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
