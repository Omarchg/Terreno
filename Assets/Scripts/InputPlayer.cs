using UnityEngine;

public class InputPlayer : MonoBehaviour
{
    public Pool pool;
    public Transform spawnTransform; // Transform de spawn para las balas
    [SerializeField] private float bulletSpeed = 10f;

    
    void Update()
    {
        if (Input.GetButtonUp("Fire1"))
        {
            FireBullet();
        }
    }

    void FireBullet()
    {
        GameObject bullet = pool.ObtenerObjeto();
        if (bullet != null)
        {
            Rigidbody bulletRB = bullet.GetComponent<Rigidbody>();
            if (bulletRB != null)
            {
                bullet.transform.position = spawnTransform.position;
                bullet.transform.rotation = spawnTransform.rotation * Quaternion.Euler(90f, 0f, 0f);
                bulletRB.velocity = spawnTransform.forward * bulletSpeed;
            }
        }
    }
}
