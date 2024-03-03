using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimientojugador : MonoBehaviour
{
    public float velocidad = 10f;
    public float velocidadMaxima = 80f;
    public float velocidadMinima = 30f;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * velocidad * Time.deltaTime;
        if (Input.GetKey(KeyCode.W) && (velocidad < velocidadMaxima))
        {
            velocidad += 0.1f;
        }

        if (Input.GetKey(KeyCode.S) && (velocidad > velocidadMinima))
        {
            velocidad -= 0.1f;
        }
    }


}
