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
    }
    public void VerificacaoDeVitoria()
    {
        mobsVivos = GameObject.FindGameObjectsWithTag("Inimigos");
        if (mobsVivos.Length == 0)
        {
            SceneManager.LoadScene(PlayerPrefs.GetInt("UltimaCena"));
            move.emCombate = false;
        }
    }
}
