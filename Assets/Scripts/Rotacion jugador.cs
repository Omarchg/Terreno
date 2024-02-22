using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotacionjugador : MonoBehaviour
{
    
    float x;
    float y;
    public float sensibilidad = 2f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        x +=  Input.GetAxis("Mouse X") * sensibilidad;
        y -=  Input.GetAxis("Mouse Y") * sensibilidad;
        transform.eulerAngles = new Vector3(y, x, 0);
    }
}
