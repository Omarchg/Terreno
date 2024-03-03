using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour
{
    
    public GameObject particulas;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        explotar();
        Destroy(gameObject);
        
    }

    void explotar()
    {
        GameObject Explosion = Instantiate(particulas, transform.position, transform.rotation);
        Explosion.SetActive(true);
        Destroy(Explosion,2f);
    }

}
