using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instancia = null;
    
    public GameObject[] mobsVivos;

    Movimentação move;
    EncontroV2 spawnScript;

    void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
        }
        else if (instancia != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        move = FindObjectOfType<Movimentação>();
        spawnScript = FindObjectOfType<EncontroV2>();
    }
    IEnumerator ChecagemDeInimigos()
    {
        yield return new WaitForSeconds(0.05f);
        VerificacaoDeVitoria();
    }
    private void Update()
    {
        if (SceneManager.GetSceneByName("Batalha").isLoaded)
        {
            StartCoroutine(ChecagemDeInimigos());
        }
    }
    public void VerificacaoDeVitoria()
    {
        mobsVivos = GameObject.FindGameObjectsWithTag("Inimigos");
        if (mobsVivos.Length == 0)
        {
            SceneManager.LoadScene(PlayerPrefs.GetInt("UltimaCena"));
            spawnScript.Aleatoriedade = 0;
            move.emCombate = false;
        }
    }
}
