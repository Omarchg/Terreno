using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    private bool Scene = false;
    private float timer;
    public GameObject nave;
    

    private void Update()
    {
        if (Scene)
        {
            timer += Time.deltaTime;
        }

        if (timer >= 3f)
        {
            SceneManager.LoadScene("Juego");
        }

        if (nave == null)
        {
            Scene = true;
        }
    }
}
