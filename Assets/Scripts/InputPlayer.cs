using TMPro;
using UnityEngine;

public class InputPlayer : MonoBehaviour
{
    public Pool pool;
    public Transform spawnTransform; // Posicion donde aparecen las balas
    [SerializeField] private float bulletSpeed = 10f;
    [SerializeField] private float bulletCooldown = 0.5f;
    private float bulletTime;
    [SerializeField] private float bulletReload = 15f;
    bool bulletAutoReload = false;
    bool bulletPlayerReload = false;
    private float bulletReloadAux;
    [SerializeField] private float bulletRechargeAuto = 2f;
    [SerializeField] private float bulletRechargePlayer = 1f;
    private float bulletReloadAutoTime = 0f;
    private float bulletReloadPlayerTime = 0f;
    public TextMeshProUGUI BulletText;


    private void Start()
    {
        bulletTime = bulletCooldown; // Pa que pueda disparar desde el principio
        bulletReloadAux = bulletReload;
    }

    void Update()
    {
        if (Input.GetButtonUp("Fire1") && bulletTime >= bulletCooldown && (bulletPlayerReload == false))
        {
            if (bulletReload >= 1)
            {
                FireBullet();
                bulletTime = 0;
                bulletReload -= 1;
            }
            else
            {
                bulletAutoReload = true;
            }
        }

        if (Input.GetKeyUp(KeyCode.R))
        {
            bulletPlayerReload = true;
        }

        bulletTime += Time.deltaTime;
        
        if (bulletAutoReload)
        {
            bulletReloadAutoTime += Time.deltaTime;
            BulletText.text = "Recargando";
            
        }

        if (bulletPlayerReload)
        {
            bulletReloadPlayerTime += Time.deltaTime;
            
            BulletText.text = "Recargando";

        }

        if (bulletReloadPlayerTime >= bulletRechargePlayer)
        {
            bulletPlayerReload = false;
            bulletReloadPlayerTime = 0f;
            bulletReload = bulletReloadAux;
            
        }

        if (bulletReloadAutoTime >= bulletRechargeAuto)
        {
            bulletAutoReload = false;
            bulletReloadAutoTime = 0f;
            bulletReload = bulletReloadAux;
            
        }


        if (bulletAutoReload == false && bulletPlayerReload == false)
        {
            BulletText.text = bulletReload + "/" + bulletReloadAux;
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
