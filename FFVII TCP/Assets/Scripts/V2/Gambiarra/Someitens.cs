using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Someitens : MonoBehaviour
{
    // Faz intes ficarem invisiveis
    public Renderer render;
    Scene cena;
    private void Start()
    {
        render = GetComponent<Renderer>();
    }
    private void FixedUpdate()
    {
        if (SceneManager.GetSceneByName("Batalha").isLoaded)
        {
            render.enabled = false;
        }
        else render.enabled = true;
        /*cena.name = SceneManager.GetActiveScene().name;
        if (cena.name == ("Batalha"))
        {
            render.enabled = false;
        }*/
    }
}
