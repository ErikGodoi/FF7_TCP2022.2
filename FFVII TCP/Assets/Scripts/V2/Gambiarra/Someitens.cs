using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Someitens : MonoBehaviour
{
    // Faz intes ficarem invisiveis
    public GameObject claudio;
    Scene cena;
    private void Start()
    {
        claudio = GetComponentInChildren<GameObject>();
    }
    private void FixedUpdate()
    {
        if (SceneManager.GetSceneByName("Batalha").isLoaded)
        {
            claudio.SetActive(false);
        }
        else if (SceneManager.GetSceneByName("FimDeJogo").isLoaded)
        {
            claudio.SetActive(false);
        }
        else claudio.SetActive(true);
        /*cena.name = SceneManager.GetActiveScene().name;
        if (cena.name == ("Batalha"))
        {
            render.enabled = false;
        }*/
    }
}
