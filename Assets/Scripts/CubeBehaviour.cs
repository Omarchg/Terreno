using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeBehaviour : MonoBehaviour
{
    private float time = 0.0f;

    void Update()
    {
        time += Time.deltaTime;
        if (time > 2f)
        {
            // Desactivar el objeto y devolverlo al pool
            gameObject.SetActive(false);
            Pool.instance.DevolverObjeto(gameObject);
            time = 0.0f;
        }
    }

    void OnEnable()
    {
        time = 0.0f;
    }
}
