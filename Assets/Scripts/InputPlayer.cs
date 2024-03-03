using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputPlayer : MonoBehaviour
{
    public Pool pool;
    [SerializeField]
    private float bulletspeed = 10f;
    

    void Awake()
    {
        pool = Pool.instance;
    }

    void Update()
    {
        if (Input.GetButtonUp("Fire1"))
        {
            
            GameObject casco = pool.ObtenerObjeto();
            if (casco != null)
            {
                Rigidbody cascoRB = casco.GetComponent<Rigidbody>();
                if (cascoRB != null)
                {
                    
                    cascoRB.velocity = pool.parentTransform.forward * bulletspeed;
                }
            }
        }
    }
}
