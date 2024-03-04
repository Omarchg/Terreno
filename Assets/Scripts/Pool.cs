using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    [SerializeField] private int maximoElementos = 100;
    [SerializeField] private GameObject objetoACrear;
    [SerializeField] public Transform parentTransform; // Referencia al objeto Empty

    private Stack<GameObject> pool;

    public static Pool instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        SetUpPool();
    }

    void SetUpPool()
    {
        pool = new Stack<GameObject>();

        for (int i = 0; i < maximoElementos; i++)
        {
            GameObject cascoCreado = Instantiate(objetoACrear);
            cascoCreado.SetActive(false);
            pool.Push(cascoCreado);
        }
    }

    public GameObject ObtenerObjeto()
    {
        GameObject casco = null;
        if (pool.Count == 0)
        {
            casco = Instantiate(objetoACrear, transform.position, transform.rotation * Quaternion.Euler(90f, 0f, 0f));
        }
        else
        {
            casco = pool.Pop();
            casco.SetActive(true);
            
        }
        return casco;
    }

    public void DevolverObjeto(GameObject cascoDevuelto)
    {
        
        pool.Push(cascoDevuelto);
        cascoDevuelto.SetActive(false);
    }
}
